namespace RestaurantManagementSystem.Core.RestaurantRequest.Exceptions
{
    public class RequestCannotBeAcceptedException : Exception
    {
        public RequestCannotBeAcceptedException(string message = "Your Request Cannot be accepted because it's not in the right status") : base(message) { }

    }
}
