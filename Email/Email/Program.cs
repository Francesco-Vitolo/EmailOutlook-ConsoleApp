using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email
{
    class Program
    {
        private const string EmailEmpfaenger = "example@example.de";
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"../../LoginCred.txt");
            Console.WriteLine("Betreff eingeben");
            string betreff = Console.ReadLine();
            Console.WriteLine("Nachricht eingeben");
            string nachricht = Console.ReadLine();

            EmailHelper sender = new EmailHelper(lines[0], lines[1]);
            sender.SendMail(EmailEmpfaenger, betreff, nachricht);
        }
    }
}
