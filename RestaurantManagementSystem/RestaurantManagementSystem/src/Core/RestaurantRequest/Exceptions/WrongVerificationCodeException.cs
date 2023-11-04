namespace RestaurantManagementSystem.src.Core.Exceptions
{
    public class WrongVerificationCodeException : Exception
    {
        public WrongVerificationCodeException(string message = "Wrong verification code you may check your email and make sure you type it right"): base(message)
        {
        }
    }
}
