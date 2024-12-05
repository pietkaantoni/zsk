using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_delegaty_powiadomienia
{
    internal class Program
    {
        public delegate void NotificationHandler(string message);

        public class EmailNotifier
        {
            public void SendEmail(string message)
            {
                Console.WriteLine($"Email wysłany: {message}");
            }
        }

        public class SMSNotifier
        {
            public void SendSMS(string message)
            {
                Console.WriteLine($"SMS wysłany {message}");
            }
        }

        public class PushNotifier
        {
            public void SendPush(string message)
            {
                Console.WriteLine($"Powiadomienie push wysłane: {message}");
            }
        }

        public class NotificationManager
        {
            public NotificationHandler Notify;

            public void AddNotificationMethod(NotificationHandler handler)
            {
                Notify += handler;
            }
            public void RemoveNotificationMethod(NotificationHandler handler)
            {
                Notify -= handler;
            }

            public void SendNotification(string message)
            {
                //Notify.Invoke(message);
                Notify?.Invoke(message);
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Dodaj powiadomienie email");
            Console.WriteLine("2. Dodaj powiadomienie sms");
            Console.WriteLine("3. Dodaj powiadomienie push");
            Console.WriteLine("4. Usuń powiadomienie email");
            Console.WriteLine("5. Usuń powiadomienie sms");
            Console.WriteLine("6. Usuń powiadomienie push");
            Console.WriteLine("7. Wyślij powiadomienia");
            Console.WriteLine("8. Wyjście");
            Console.WriteLine("\nWybierz obcję:");
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
                            notificationManager.AddNotificationMethod(emailNotifier.SendEmail);
                            Console.WriteLine("Dodano powiadomienia email");
                            break;
                        case 2:
                            Console.Clear();
                            notificationManager.AddNotificationMethod(smsNotifier.SendSMS);
                            Console.WriteLine("Dodano powiadomienia SMS");
                            break;
                        case 3:
                            Console.Clear();
                            notificationManager.AddNotificationMethod(pushNotifier.SendPush);
                            Console.WriteLine("Dodano powiadomienia push");
                            break;
                        case 4:
                            Console.Clear();
                            notificationManager.RemoveNotificationMethod(emailNotifier.SendEmail);
                            Console.WriteLine("Usunięto powiadomienia email");
                            break;
                        case 5:
                            Console.Clear();
                            notificationManager.RemoveNotificationMethod(smsNotifier.SendSMS);
                            Console.WriteLine("Usunięto powiadomienia SMS");
                            break;
                        case 6:
                            Console.Clear();
                            notificationManager.RemoveNotificationMethod(pushNotifier.SendPush);
                            Console.WriteLine("Usunięto powiadomienia push");
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Wpisz wiadomość do wysłania");
                            var message = Console.ReadLine();

                            //  walidacja wiadomości
                            if (string.IsNullOrEmpty(message))
                            {
                                Console.WriteLine("Wiadomość nie może być pusta");
                                break;
                            }
                            if(message.Length > 20)
                            {
                                Console.WriteLine("Wiadomość jest zbyt długa, maksymalnie 20 znaków");
                                break;
                            }
                            notificationManager.SendNotification(message);
                            break;
                        case 8:
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Nieprawidłowa opcja, spróbuj ponownie");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Błąd: {e.Message}\n");
                }
            }

        }
    }
}
