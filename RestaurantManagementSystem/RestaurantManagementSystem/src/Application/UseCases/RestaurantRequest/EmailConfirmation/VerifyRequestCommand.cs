namespace RestaurantManagementSystem.Application.UseCases.RestaurantRequest.EmailConfirmation
{
    public class VerifyRequestCommand
    {
        public string RequestId { get; set; }
        public string VerificationCode { get; set; }

        public VerifyRequestCommand(string requestId, string verificationCode)
        {
            RequestId = requestId;
            VerificationCode = verificationCode;
        }

    }
}
