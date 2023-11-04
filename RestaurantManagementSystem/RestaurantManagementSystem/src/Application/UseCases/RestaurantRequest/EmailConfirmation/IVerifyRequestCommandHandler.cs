namespace RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.EmailConfirmation
{
    public interface IVerifyRequestCommandHandler
    {
        public void VerifyRegistrationRequest(VerifyRequestCommand confirmationCommand);
    }
}
