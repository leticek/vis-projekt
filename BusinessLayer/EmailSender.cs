﻿using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class EmailSender
    {
        public static void SendEmail(string name, string subject, string body)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Informační fitness systém", "vis-fitness@seznam.cz"));
            message.To.Add(new MailboxAddress(name, "adam.smieja.st@vsb.cz"));
            message.Subject = subject;
            BodyBuilder bodyBuilder = new BodyBuilder
            {
                TextBody = body
            };
            message.Body = bodyBuilder.ToMessageBody();
            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.seznam.cz", 465, true);
                client.Authenticate("vis-fitness@seznam.cz", "");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
