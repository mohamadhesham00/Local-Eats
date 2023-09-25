namespace RestaurantManagementSystem.src.Core.Contracts
{
    public interface IEmailService
    {
        public Task<string> SendEmail(string recipientEmail, string MessageSubject, string body);
    }
}
