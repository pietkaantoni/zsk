using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _05_2_delegaty_powiadomienia_Menu2
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
                    Console.WriteLine($"Błąd podczas wysyłania Emaila: {ex.Message}");
                }
            }
        }

        public class SMSNotifier
        {
            public void Notify(string message)
            {
                try
                {
                    Console.WriteLine($"Wiadomość wysłana: {message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas wysyłania wiadomości: {ex.Message}");
                }
            }
        }
        public class PushNotifier
        {
            public void Notify(string message)
            {
                try
                {
                    Console.WriteLine($"Powiadomienie push wysłane: {message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas wysyłania Powiadomienie push: {ex.Message}");
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
                }
                else
                {
                    Console.WriteLine("Nie można usunąć metody powiadomienia");
                }
            }

            public void SendNotification(string message)
            {
                if (Notify != null)
                {
                    Console.WriteLine("Brak dostępnych metod powiadomień. Dodaj co najmniej 1 metodę");
                    return;
                }

                foreach (var handler in Notify.GetInvocationList())
                {
                    try
                    {
                        handler.DynamicInvoke(message);
                        string logEntry = $"";
                        File.AppendAllText("log.txt", logEntry);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Błąd podczas wysyłania powiadomienia: {ex.Message}");
                    }
                }
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("\n\nMenu");
            Console.WriteLine("1. Dodaj powiadomienie Email");
            Console.WriteLine("2. Dodaj powiadomienie SMS");
            Console.WriteLine("3. Dodaj powiadomienie Push");
            Console.WriteLine("4. Usuń powiadomienie Email");
            Console.WriteLine("5. Usuń powiadomienie SMS");
            Console.WriteLine("6. Usuń powiadomienie Push");
            Console.WriteLine("7. Wyślij powiadomienia");
            Console.WriteLine("8. Wyjdź");
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
                            Console.Clear();
                            notificationManager.AddNotificationMethod(emailNotifier.Notify);
                            Console.WriteLine("Dodano powiadomienie Email\n");
                            break;
                        case 2:
                            Console.Clear();
                            notificationManager.AddNotificationMethod(smsNotifier.Notify);
                            Console.WriteLine("Dodano powiadomienie SMS\n");
                            break;
                        case 3:
                            Console.Clear();
                            notificationManager.AddNotificationMethod(pushNotifier.Notify);
                            Console.WriteLine("Dodano powiadomienie Push\n");
                            break;
                        case 4:
                            Console.Clear();
                            notificationManager.RemoveNotificationMethod(emailNotifier.Notify);
                            Console.WriteLine("Usunięto powiadomienie Email\n");
                            break;
                        case 5:
                            Console.Clear();
                            notificationManager.RemoveNotificationMethod(smsNotifier.Notify);
                            Console.WriteLine("Usunięto powiadomienie SMS\n");
                            break;
                        case 6:
                            Console.Clear();
                            notificationManager.RemoveNotificationMethod(pushNotifier.Notify);
                            Console.WriteLine("Usunięto powiadomienie Push\n");
                            break;
                        case 7:
                            Console.Clear();
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
                            break;
                        case 8:
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}