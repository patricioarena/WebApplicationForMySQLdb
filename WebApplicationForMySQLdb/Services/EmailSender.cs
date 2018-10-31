using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApplicationForMySQLdb.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string normalizeEmail(string Cadena)
        {
            while (Cadena.Contains(" "))
            {
                Cadena = Cadena.Replace(" ", "");
            }

            return Cadena;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var normalizedEmail = normalizeEmail(email);
            var fromEmail = _configuration["Smtp:Email"];
            var fromPWD = _configuration["Smtp:Password"];
            var smtp = _configuration["Smtp:Smtp"];
            var port = _configuration["Smtp:Port"];

            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress(fromEmail));
            msg.To.Add(new MailboxAddress(normalizedEmail));
            msg.Subject = subject;
            msg.Body = new TextPart("html")
            {
                Text = "From " + subject + " <br>" +
                "Contact Information: " + fromEmail + "<br>" +
                "Messege: " + message + " <br>"
            };
            using (var SmtpClient = new SmtpClient())
            {
                SmtpClient.Connect(smtp, Int32.Parse(port));
                SmtpClient.Authenticate(fromEmail, fromPWD);
                SmtpClient.Send(msg);
                SmtpClient.Disconnect(false);
            }
            return Task.CompletedTask;
        }
    }
}
