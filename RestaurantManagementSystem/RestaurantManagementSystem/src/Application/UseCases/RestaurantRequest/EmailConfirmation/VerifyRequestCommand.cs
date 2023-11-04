namespace RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.EmailConfirmation
{
    public class VerifyRequestCommand
    {
        public string RequestId { get; set; }
        public string VerificationCode { get; set; }
    }
}
