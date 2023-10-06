using RestaurantManagementSystem.src.Core.Entities;

namespace RestaurantManagementSystem.src.UseCases.GetRegistrationRequests
{
    public interface IGetRequestsHandler
    {
        public Task<List<RestaurantRegistrationResponseDTO>> GetRequests();
    }
}
