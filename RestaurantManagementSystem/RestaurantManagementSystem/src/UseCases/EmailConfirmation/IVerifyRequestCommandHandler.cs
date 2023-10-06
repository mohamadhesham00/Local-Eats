namespace RestaurantManagementSystem.src.UseCases.Email_Confirmation
{
    public interface IVerifyRequestCommandHandler
    {
        public void VerifyRegistrationRequest(VerifyRequestCommand confirmationCommand);
    }
}
