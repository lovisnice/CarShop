using BuisinessLogic.Interfaces;
using MimeKit;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit.Text;
using MailKit.Net.Smtp;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Utilities;
using Microsoft.Extensions.Configuration;
using BusinessLogic.Helpers;
using System.ComponentModel.DataAnnotations;
using BuisinessLogic.Helpers;

namespace BuisinessLogic.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendMailAsync(string subject, string body, string toSend, string? fromSend = null)
        {

            // create email message
            MailData data = _configuration.GetSection("MailData").Get<MailData>();
            string EMAIL = data.EmailFrom;
            string PASSWORD = data.Password;

            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(EMAIL));
            email.To.Add(MailboxAddress.Parse(toSend));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = $"<h1>Your order</h1><p>{body}</p>" };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(EMAIL, PASSWORD);
            smtp.Send(email);
            smtp.Disconnect(true);


        }
    }
}
