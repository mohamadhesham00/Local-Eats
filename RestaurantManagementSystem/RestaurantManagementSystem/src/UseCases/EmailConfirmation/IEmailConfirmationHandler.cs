namespace RestaurantManagementSystem.src.UseCases.Email_Confirmation
{
    public interface IEmailConfirmationHandler
    {
        public void VerifyEmail(ConfirmationCommand confirmationCommand);
    }
}
