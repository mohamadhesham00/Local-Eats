namespace RestaurantManagementSystem.src.Core.Common.Exceptions
{
    public class CodeExpiredException : Exception
    {
        public CodeExpiredException(string message = " Code has Expired"):base(message) { }
    }
}
