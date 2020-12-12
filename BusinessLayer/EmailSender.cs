using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace BusinessLayer
{
    public static class EmailSender
    {
        public static void sendEmail(string name, string subject, string body)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Informační fitness systém", "vis-fitness@seznam.cz"));
            message.To.Add(new MailboxAddress(name, "adam.smieja.st@vsb.cz"));
            message.Subject = subject;
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = body;
            message.Body = bodyBuilder.ToMessageBody();
            using(SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.seznam.cz", 465, true);
               
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
