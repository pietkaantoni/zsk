using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;                      

namespace _05_2_delegaty_powiadomienia_Menu3
{
    internal class Program
    {
        public delegate void Notificationhandler(string message);

        public interface INotifier
        {
            void Notify(string message);
        }
        public class EmailNotifier : INotifier
        {
            public void Notify(string message)
            {
                try
                {
                    Console.WriteLine($"Email wysłany: {message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas wysyłania Email: {ex.Message}");
                }
            }
        }

        public class SMSNotifier : INotifier
        {
            public void Notify(string message)
            {
                try
                {
                    Console.WriteLine($"SMS wysłany: {message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas wysyłania SMS: {ex.Message}");
                }
            }
        }
        public class PushNotifier : INotifier
        {
            public void Notify(string message)
            {
                try
                {
                    Console.WriteLine($"Powiadomienie push wysłane: {message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas wysyłania powiadomienia push: {ex.Message}");
                }
            }
        }

        public class NotificationManager
        {
            public Notificationhandler Notify;

            public void AddNotificationMethod(Notificationhandler handler)
            {
                if (Notify != null && Notify.GetInvocationList().Contains(handler))
                {
                    Console.WriteLine("Ta metoda powiadomienia jest już dodana");
                    return;
                }
                else
                {
                    Notify += handler;
                    Console.WriteLine("Dodano metodę powiadomienia");
                }
            }

            public void RemoveNotificationMethod(Notificationhandler handler)
            {
                if (Notify != null && Notify.GetInvocationList().Contains(handler))
                {
                    Notify -= handler;
                    Console.WriteLine("Usunięto metodę powiadomienia");
                    return;
                }
                else
                {
                    Console.WriteLine("Nie można usunąć metody powiadomienia");
                }
            }

            public void SendNotification(string message)
            {
                if (Notify == null)
                {
                    Console.WriteLine("Brak dostępnych metod powiadomień. Dodaj co najmniej jedną metodę");
                    return;
                }

                foreach (var handler in Notify.GetInvocationList())
                {
                    try
                    {
                        handler.DynamicInvoke(message);
                        string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Wysłano: " +
                            $"{handler.Method.Name}, wiadomość : {message}{Environment.NewLine}";
                        File.AppendAllText("log.txt", logEntry);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Błąd podczas wysyłania powiadomienia: {ex.Message}");
                    }
                }
            }

            public void ListNotificationMethods()
            {
                if (Notify == null)
                {
                    Console.WriteLine("Brak zarejestrowanej metod powiadomień");
                    return;
                }
                Console.WriteLine("Zarejestrowane metody powiadomień:");

                var displayHandlers = new HashSet<string>();    //HashSet odpowiada za unikania powtórzeń metod

                foreach (var handler in Notify.GetInvocationList())
                {
                    var target = handler.Target;
                    var methodName = handler.Method.Name;
                    var className = target?.GetType().Name ?? "Nieznany";   //zapis a ?? b oznacza, że do zmiennej przypisze lewą stronę, jeśli jest różna od null

                    var uniqueKey = $"{className}.{methodName}";

                    if (!displayHandlers.Contains(uniqueKey))
                    {
                        displayHandlers.Add(uniqueKey);
                        Console.WriteLine($"- Klasa: {className}, metoda: {methodName}");
                    }

                }

            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Dodaj powiadomienie Email");
            Console.WriteLine("2. Dodaj powiadomienie SMS");
            Console.WriteLine("3. Dodaj powiadomienie Push");
            Console.WriteLine("4. Usuń powiadomienie Email");
            Console.WriteLine("5. Usuń powiadomienie SMS");
            Console.WriteLine("6. Usuń powiadomienie Push");
            Console.WriteLine("7. Wyślij powiadomienia");
            Console.WriteLine("8. Pokaż zarejestrowane metody powiadomień");
            Console.WriteLine("9. Wyjdź");
            Console.Write("Wybierz opcję: ");
        }

        static void Main(string[] args)
        {
            var emailNotifier = new EmailNotifier();
            var smsNotifier = new SMSNotifier();
            var pushNotifier = new PushNotifier();

            var notificationManager = new NotificationManager();

            while (true)
            {
                try
                {
                    ShowMenu();
                    var choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            notificationManager.AddNotificationMethod(emailNotifier.Notify);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            notificationManager.AddNotificationMethod(smsNotifier.Notify);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            notificationManager.AddNotificationMethod(pushNotifier.Notify);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 4:
                            notificationManager.RemoveNotificationMethod(emailNotifier.Notify);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 5:
                            notificationManager.RemoveNotificationMethod(smsNotifier.Notify);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 6:
                            notificationManager.RemoveNotificationMethod(pushNotifier.Notify);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 7:
                            Console.Write("Wpisz wiadomość do wysłania: ");
                            var message = Console.ReadLine();

                            //walidacja wiadomości
                            if (string.IsNullOrWhiteSpace(message))
                            {
                                Console.WriteLine("\nWiadomość nie może być pusta\n");
                                break;
                            }

                            if (message.Length > 20)
                            {
                                Console.WriteLine("Wiadomość jest zbyt długa (max 20 znaków)");
                                break;
                            }

                            notificationManager.SendNotification(message);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 8:
                            notificationManager.ListNotificationMethods();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 9:
                            return;
                        default:
                            Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }
    }
}
