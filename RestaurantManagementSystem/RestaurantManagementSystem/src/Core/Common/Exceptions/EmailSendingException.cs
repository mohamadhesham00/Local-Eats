namespace RestaurantManagementSystem.src.Core.Exceptions
{
    public class EmailSendingException : Exception
    {
        public EmailSendingException(string message = "An error occurred while sending Email"):base(message) { }
    }
}
