using RestaurantManagementSystem.src.Core.Entities;

namespace RestaurantManagementSystem.src.Core.Contracts
{
    public interface IEmailService
    {
        public void SendConfirmationEmail(string recipientEmail, Guid Id ,string VerificationCode);
        public void SendEmailConfirmedEmail(string recipientEmail);

    }
}
