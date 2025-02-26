using System;
using System.Collections.Generic;
using System.IO;    //do otwierania plików zewnętrznych
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography; //do hashowania np. hasła
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _6_3_zdarzenia
{
    internal class Program
    {
        public enum Role
        {
            Administrator,
            Manager,
            User
        }
        public enum Permission
        {
            Read,
            Write,
            Delete,
            Manageusers
        }
        public class User
        {
            public string Username;
            public List<Role> Roles;

            public User(string username)
            {
                Username = username;
                Roles = new List<Role>();
            }

            public void AddRole(Role role)
            {
                if (!Roles.Contains(role))
                {
                    Roles.Add(role);
                }
            }
            /*
            public void RemoveRole(Role role)
            {
                if (Roles.Contains(role))
                {
                    Roles.Remove(role);
                }
            }
            public void ShowRoles()
            {
                foreach (Role role in Roles)
                {
                    Console.WriteLine(role);
                }
            }
            */
        }
        //RBAC
        public class RBAC
        {
            private readonly Dictionary<Role, List<Permission>> _rolePermissions; //podłogę robiono kiedyś, aby podkreślić że pole jest prywatne
            public RBAC()
            {
                _rolePermissions = new Dictionary<Role, List<Permission>>
                {
                    { Role.Administrator, new List<Permission> {Permission.Read, Permission.Write, Permission.Delete, Permission.Manageusers} },
                    { Role.Manager, new List<Permission> { Permission.Read, Permission.Write} },
                    { Role.User, new List<Permission> {Permission.Read} }
                };
            }

            public bool HasPermission(User user, Permission permission)
            {
                foreach (var role in user.Roles)
                {
                    if (_rolePermissions.ContainsKey(role) && _rolePermissions[role].Contains(permission))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public class PasswordManager
        {
            private const string _passwordFilePath = "userPasswords.txt";
            public static event Action<string, bool> PasswordVerified;

            static PasswordManager()
            {
                if (!File.Exists(_passwordFilePath))
                {
                    File.Create(_passwordFilePath).Dispose();
                }
            }

            //statyczna żeby nie trzeba było tworzyć obiektu danej klasy
            public static void SavePassword(string username, string password)
            {
                if (File.ReadLines(_passwordFilePath).Any(line => line.Split(',')[0] == username))
                {
                    Console.WriteLine($"Użytkownik {username} już istnieje w systemie");
                    return;
                }

                string hashedPassword = HashPassword(password);
                File.AppendAllText(_passwordFilePath, $"{username},{hashedPassword}\n");
                Console.WriteLine($"Użytkownik {username} został zapisany");
            }

            public static bool VerifyPassword(string username, string password)
            {
                string hashedPassword = HashPassword(password);
                foreach (var line in File.ReadLines(_passwordFilePath))
                {
                    var parts = line.Split(',');
                    if (parts[0] == username && parts[1] == hashedPassword)
                    {
                        PasswordVerified?.Invoke(username, true);
                        return true;
                    }
                }
                PasswordVerified?.Invoke(username, false);
                return false;
            }

            private static string HashPassword(string password)
            {
                using (var sha256 = SHA256.Create())
                {
                    var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    return Convert.ToBase64String(bytes);
                }
            }
        }

        public delegate void FileOperation(string filepath);

        public class FileManager
        {
            public static void ReadFile(string filePath)
            {
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    Console.WriteLine("Zawartość pliku:\n" + content);
                }
                else
                {
                    Console.WriteLine("Plik nie istnieje");
                }
            }

            public static void WriteFile(string filePath)
            {
                Console.WriteLine("Podaj tekst do zapisania w pliku: ");
                string text = Console.ReadLine();
                File.WriteAllText(filePath, text);
                Console.WriteLine("Zapisano do pliku");
            }

            public static void ModifyFile(string filePath)
            {
                if (File.Exists(filePath))
                {
                    Console.WriteLine("Podaj tekst do modyfikacji w pliku: ");
                    string text = Console.ReadLine();
                    File.AppendAllText(filePath, text);
                    Console.WriteLine("Zmodyfikowano plik");
                }
                else
                {
                    Console.WriteLine("Plik nie istnieje");
                }
            }
            public static void AddNewUser()
            {
                Console.WriteLine("Podaj nazwę użytkownika:");
                string newUsername = Console.ReadLine();

                Console.WriteLine("Podaj hasło:");
                string newPassword = Console.ReadLine();

                PasswordManager.SavePassword(newUsername, newPassword);
                Console.WriteLine($"Dodano nowego użytkownika: {newUsername}");
            }
        }
        static void Main(string[] args)
        {
            //PasswordManager.PasswordVerified += (username, success) => Console.WriteLine($"Logowanie użytkownika {username} : {(success ? "udane" : "nieudane")}");

            PasswordManager.SavePassword("AdminUser", "adminPassword");
            PasswordManager.SavePassword("ManagerUser", "managerPassword");
            PasswordManager.SavePassword("NormalUser", "userPassword");
            PasswordManager.SavePassword("xyz", "userPassword");

            bool exitProgram = false;
            bool loggedIn = true;

            while (!exitProgram)
            {
                
                Console.Clear();
                Console.WriteLine("=== SYSTEM LOGOWANIA ===");

                Console.WriteLine("Wprowadź nazwę użytkownika: ");
                string username = Console.ReadLine();

                Console.WriteLine("Wprowadź hasło: ");
                string password = Console.ReadLine();

                if (!PasswordManager.VerifyPassword(username, password))
                {
                    Console.WriteLine("Niepopeawna nazwa użytkownika lub hasło");
                    Console.ReadKey();
                    continue;
                }

                loggedIn = true;
                var user = new User(username);
                if (username == "AdminUser") user.AddRole(Role.Administrator);
                else if (username == "ManagerUser") user.AddRole(Role.Manager);
                else if (username == "NormalUser") user.AddRole(Role.User);

                var rbacSystem = new RBAC();
                string filePath = "testFile.txt";
                while (loggedIn)
                {
                    Console.Clear();
                    Console.WriteLine($"Zalogowano jako: {username}");
                    Console.WriteLine("\nWybierz opsję:");
                    Console.WriteLine("1. Odczytaj plik");
                    if (rbacSystem.HasPermission(user, Permission.Write))
                        Console.WriteLine("2. Zapisz do pliku");
                    if (rbacSystem.HasPermission(user, Permission.Delete))
                        Console.WriteLine("3. Modyfikuj plik");
                    if (rbacSystem.HasPermission(user, Permission.Manageusers))
                        Console.WriteLine("4. Dodaj nowego użytkownika");
                    Console.WriteLine("5. Wyloguj się");
                    Console.WriteLine("6. Wyjdź z programu");

                    int choice;
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Niepoprawny wybór, spróbuj ponownie");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            FileManager.ReadFile(filePath);
                            break;
                        case 2:
                            if (rbacSystem.HasPermission(user, Permission.Write))
                                FileManager.WriteFile(filePath);
                            else
                                Console.WriteLine("Nie masz uprawnień");
                            break;
                        case 3:
                            if (rbacSystem.HasPermission(user, Permission.Delete))
                                FileManager.ModifyFile(filePath);
                            else
                                Console.WriteLine("Nie masz uprawnień");
                            break;
                        case 4:
                            if (rbacSystem.HasPermission(user, Permission.Manageusers))
                                FileManager.AddNewUser();
                            else
                                Console.WriteLine("Nie masz uprawnień");
                            break;
                        case 5:
                            Console.WriteLine("Wylogowano");
                            loggedIn = false;
                            break;
                        case 6:
                            Console.WriteLine("Zamykanie programu");
                            //return;
                            loggedIn = false;
                            exitProgram = true;
                            break;
                        default:
                            Console.WriteLine("Niepoprawny wybór");
                            break;
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}