namespace RestaurantManagementSystem.Application.UseCases.RestaurantRequest.Register
{
    public interface IRegisterRequestCommandHandler
    {
        Task Execute(RegisterRequestCommand registerCommand);

    }
}
