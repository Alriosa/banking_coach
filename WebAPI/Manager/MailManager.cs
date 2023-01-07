using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class MailManager
    {
        private IConfiguration configuration;
        public MailManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public MailManager()
        {
        }

        private MailMessage ConfigureMail
            (string email, string subject, string message)
        {
            // string from = this.configuration.GetValue<string>("MailSettings:user");

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("mbonilla.guti@gmail.com");
            mail.To.Add(new MailAddress(email));
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            return mail;
        }

        private void ConfigureSmtp(MailMessage mail)
        {

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("mbonilla.guti@gmail.com", "dzhddnepmfpdimxe"),
                EnableSsl = true
                // specify whether your host accepts SSL connections
            };

            client.Send(mail);
        }

        public void SendMail(string email, string subject, string message)
        {
            MailMessage mail = this.ConfigureMail(email, subject, message);
            this.ConfigureSmtp(mail);
        }
    }
}
