using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace ProjectPlanner.Classes
{
    class Email
    {
        public void EmailTest(string destinationEmail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Bobby Test", "unraid900cool@gmail.com"));
            message.To.Add(new MailboxAddress("Tester", destinationEmail));
            message.Subject = "Hello";

            message.Body = new TextPart("plain")
            {
                Text = @"Hello World!"
            };
            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("unraid900cool", "Scar_heavy17");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
