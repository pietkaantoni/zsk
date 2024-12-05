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

            public void AddNotificationHandler(NotificationHandler handler)
            {
                Notify += handler;
            }
            public void RemoveNotificationHandler(NotificationHandler handler)
            {
                Notify -= handler;
            }

            public void SendNotification(string message)
            {
                //Notify.Invoke(message);
                Notify?.Invoke(message);
            }
        }

        static void Main(string[] args)
        {
            
            var emailNotifier = new EmailNotifier();
            var smsNotifier = new SMSNotifier();
            var pushNotifier = new PushNotifier();

            var notificationManager = new NotificationManager();

            notificationManager.AddNotificationHandler(emailNotifier.SendEmail);
            notificationManager.AddNotificationHandler(smsNotifier.SendSMS);

            notificationManager.SendNotification("text1");

            notificationManager.AddNotificationHandler(pushNotifier.SendPush);
            notificationManager.RemoveNotificationHandler(smsNotifier.SendSMS);
            notificationManager.SendNotification("text2");
            
            Console.ReadKey();
        }
    }
}
