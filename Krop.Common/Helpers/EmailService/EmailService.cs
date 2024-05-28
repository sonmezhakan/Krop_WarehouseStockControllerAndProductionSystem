using Krop.Common.Models;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Krop.Common.Helpers.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendMailAsync(EmailViewModel emailViewModel)
        {
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress(_configuration["EmailSettings:Username"], emailViewModel.subject);
            sender.Subject = emailViewModel.subject;
            sender.Body = $@"{emailViewModel.textBody} {emailViewModel.htmlBody}";
            sender.IsBodyHtml = true;
            sender.To.Add(emailViewModel.toEmail);

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(_configuration["EmailSettings:Username"], _configuration["EmailSettings:Password"]);
            smtpClient.Port = int.Parse(_configuration["EmailSettings:SmtpPort"]);
            smtpClient.Host = _configuration["EmailSettings:SmtpServer"];
            smtpClient.EnableSsl = true;

            await smtpClient.SendMailAsync(sender);
        }
    }
}
