using System;
using System.Net.Mail;
using System.Net;

namespace Email
{
    public class EmailHelper
    {
        private string Sender { get; }
        private string Password { get; }
        public EmailHelper(string sender, string password)
        {
            Sender = sender;
            Password = password;
        }

        public void SendMail(string empfaenger, string betreff, string nachricht)
        {
            NetworkCredential credentials = new NetworkCredential(Sender, Password);
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = credentials,
            };

            try
            {
                MailMessage mail = new MailMessage(Sender, empfaenger)
                {
                    Subject = betreff,
                    Body = nachricht
                };
                client.Send(mail);

                Console.WriteLine("Email wurde an {0} gesendet",empfaenger);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
    }
}