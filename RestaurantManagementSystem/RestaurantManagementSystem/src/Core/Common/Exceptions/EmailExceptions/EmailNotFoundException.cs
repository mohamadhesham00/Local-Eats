namespace RestaurantManagementSystem.Core.Common.Exceptions.EmailExceptions
{
    public class EmailNotFoundException : Exception
    {
        public EmailNotFoundException(string message = "Cannot find this Email make sure you type it right") : base(message) { }
    }
}
