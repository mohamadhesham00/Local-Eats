namespace RestaurantManagementSystem.Application.UseCases.RestaurantRequest.EmailConfirmation
{
    public interface IVerifyRequestCommandHandler
    {
        public Task VerifyRegistrationRequest(VerifyRequestCommand confirmationCommand);
    }
}
