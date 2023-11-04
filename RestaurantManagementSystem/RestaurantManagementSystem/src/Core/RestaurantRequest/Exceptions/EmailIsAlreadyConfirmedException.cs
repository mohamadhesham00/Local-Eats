namespace RestaurantManagementSystem.src.Core.Exceptions
{
    public class EmailIsAlreadyConfirmedException : Exception 
    {
        public EmailIsAlreadyConfirmedException(string message = "Your Email Is already confirmed") : base( message ) { }

    }
}
