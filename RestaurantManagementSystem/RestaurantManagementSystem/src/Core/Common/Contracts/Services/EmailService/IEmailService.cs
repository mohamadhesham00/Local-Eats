namespace RestaurantManagementSystem.Core.Common.Contracts.Services.EmailService
{
    public interface IEmailService
    {
        public Task SendConfirmationEmail(string recipientEmail, Guid Id, string VerificationCode);
        public Task SendEmailConfirmedEmail(string recipientEmail);

    }
}
