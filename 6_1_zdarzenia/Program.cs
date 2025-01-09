using System;
using System.Collections.Generic;
using System.IO;    //do otwierania plików zewnętrznych
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography; //do hashowania np. hasła
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _6_1_zdarzenia
{
    internal class Program
    {
        public enum Role
        {
            Administrator,
            Manager,
            User
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
            private readonly Dictionary<Role, List<string>> _rolePermissions; //podłogę robiono kiedyś, aby podkreślić że pole jest prywatne
            public RBAC()
            {
                _rolePermissions = new Dictionary<Role, List<string>>
                {
                    { Role.Administrator, new List<string> {"Read", "Write", "Delete"} },
                    { Role.Manager, new List<string> {"Read", "Write"} },
                    { Role.User, new List<string> {"Read"} }
                };
            }

            public bool HasPermission(User user, string permission)
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
                if(File.ReadLines(_passwordFilePath).Any(line => line.Split(',')[0] == username))
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
                foreach(var line in File.ReadLines(_passwordFilePath))
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

        static void Main(string[] args)
        {
            PasswordManager.PasswordVerified += (username, success) => Console.WriteLine($"Logowanie użytkownika {username} : {(success ? "udane" : "nieudane")}");

            PasswordManager.SavePassword("AdminUser", "adminPassword");

            Console.WriteLine("\nWprowadź nazwę użytkownika:");
            string username = Console.ReadLine();

            Console.WriteLine("\nWprowadź hasło:");
            string password = Console.ReadLine();
            Console.WriteLine();

            if(!PasswordManager.VerifyPassword(username, password))
            {
                Console.WriteLine("Niepaprawna nazwa użytkownika lub hasło");
                return;
            }


            var user = new User(username);

            if(username == "AdminUser")
            {
                user.AddRole(Role.Administrator);
                //user.AddRole(Role.Manager);
                //user.AddRole(Role.User);
            }
            
            var rbacSystem = new RBAC();

            Console.WriteLine("Sprawdzenie dostępudo różnych zasobów:");

            Console.WriteLine("Read: " + rbacSystem.HasPermission(user, "Read"));
            Console.WriteLine("Write: " + rbacSystem.HasPermission(user, "Write"));
            Console.WriteLine("Delete: " + rbacSystem.HasPermission(user, "Delete"));

            Console.ReadKey();
        }
    }
}
