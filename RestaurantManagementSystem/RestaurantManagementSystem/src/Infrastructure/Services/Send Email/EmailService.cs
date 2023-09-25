using RestaurantManagementSystem.src.Core.Contracts;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;


namespace RestaurantManagementSystem.src.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _conf;
        public EmailService (IConfiguration conf)
        {
            _conf = conf;
        }
        public async Task<string> SendEmail (string recipientEmail,string MessageSubject,string MessageBody)
        {
            string? senderEmail = _conf["SmtpSettings:Email"];
            string? senderPassword = _conf["SmtpSettings:Password"];
            string? smtpServer = _conf["SmtpSettings:Server"];
            int smtpPort = int.Parse(_conf["SmtpSettings:Port"]);
            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;
                MailMessage mailMessage = new MailMessage(from: senderEmail, to: recipientEmail
                 , subject:MessageSubject, body: MessageBody);
                
                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                    return ("Email sent successfully.");
                    
                }
                catch (Exception ex)
                {
                    throw new ($"Error sending email: {ex.Message}");
                }
            }

        }


    }
}
