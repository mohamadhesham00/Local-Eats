using RestaurantManagementSystem.src.Core.Contracts;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Core.Exceptions;

namespace RestaurantManagementSystem.src.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _conf;
        public EmailService (IConfiguration conf)
        {
            _conf = conf;
        }

        public void SendConfirmationEmail(string recipientEmail, Guid Id, string VerificationCode)
        {
            string MessageBody = "You need to vertify your Email to Complete Your Request \n Your Request ID is : " + Id + "\n" + " Your code is " + VerificationCode;
            string MessageSubject = "Email Confirmation";
            SendEmail(recipientEmail, MessageSubject,MessageBody);
        }


        public void SendEmailConfirmedEmail (string recipientEmail) {
            string MessageSubject = "Email Confirmed";
            string MessageBody = "Email Confirmed Successfullly \n Your Restaurant is now on the waiting list";
            SendEmail(recipientEmail, MessageSubject,MessageBody);
        }
        private async void SendEmail (string recipientEmail,string MessageSubject,string MessageBody)
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
                    
                }
                catch (Exception ex)
                {
                    throw new EmailSendingException();
                }
            }

        }


    }
}
