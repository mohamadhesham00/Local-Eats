namespace RestaurantManagementSystem.src.UseCases.Email_Confirmation
{
    public class ConfirmationCommand
    {
        public string RequestId { get; set; }
        public string VerificationCode { get; set; }
    }
}
