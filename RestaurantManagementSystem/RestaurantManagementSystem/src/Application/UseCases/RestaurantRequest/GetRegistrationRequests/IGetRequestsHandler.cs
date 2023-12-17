namespace RestaurantManagementSystem.Application.UseCases.RestaurantRequest.GetRegistrationRequests
{
    public interface IGetRequestsHandler
    {
        public Task<List<RestaurantRegistrationResponseDTO>> GetRequests();
    }
}
