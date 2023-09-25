namespace RestaurantManagementSystem.src.UseCases.Email_Confirmation
{
    public interface IEmailConfirmationHandler
    {
        public Task<bool> Confirm(ConfirmationCommand confirmationCommand);
    }
}
