using System.Net;
using System.Net.Mail;
using RestaurantManagementSystem.Core.Common.Exceptions;
using RestaurantManagementSystem.Core.Common.Contracts.Services.EmailService;
using RestaurantManagementSystem.Core.Common.Exceptions.EmailExceptions;

namespace RestaurantManagementSystem.Infrastructure.Common.Services.SendEmail
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _conf;
        public EmailService (IConfiguration conf)
        {
            _conf = conf;
        }

        public async Task SendConfirmationEmail(string recipientEmail, Guid id, string verificationCode)
        {
            string messageBody = "You need to verify your Email to Complete Your Request \n Your Request ID is : " + id + "\n" 
                                 + " Your code is " + verificationCode;
            string messageSubject = "Email Confirmation";
            await SendEmail(recipientEmail, messageSubject,messageBody);
        }


        public async Task SendEmailConfirmedEmail (string recipientEmail) {
            string messageSubject = "Email Confirmed";
            string messageBody = "Email Confirmed Successfully \n Your Restaurant is now on the waiting list";
            await SendEmail(recipientEmail, messageSubject,messageBody);
        }
        private async Task SendEmail (string recipientEmail,string messageSubject,string messageBody)
        {
            string? senderEmail = _conf["SmtpSettings:Email"];
            string? senderPassword = _conf["SmtpSettings:Password"];
            string? smtpServer = _conf["SmtpSettings:Server"];
            int smtpPort = int.Parse(_conf["SmtpSettings:Port"] ?? throw new InvalidOperationException());
            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;
                if (senderEmail is null)
                {
                    throw new EmailNotFoundException();
                }
                MailMessage mailMessage = new MailMessage(from: senderEmail, to: recipientEmail
                 , subject:messageSubject, body: messageBody);
                
                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                    
                }
                catch (Exception)
                {
                    throw new EmailSendingException();
                }
            }

        }


    }
}
