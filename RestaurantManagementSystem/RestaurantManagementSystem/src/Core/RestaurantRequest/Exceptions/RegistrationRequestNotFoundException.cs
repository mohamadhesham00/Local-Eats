namespace RestaurantManagementSystem.src.Core.RestaurantRequest.Exceptions
{
    public class RegistrationRequestNotFoundException : Exception
    {
        public RegistrationRequestNotFoundException(string message = "Request cannot be found") : base(message) { }

    }
}
