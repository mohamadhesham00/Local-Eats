using RestaurantManagementSystem.src.Core.Entities;

namespace RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.GetRegistrationRequests
{
    public interface IGetRequestsHandler
    {
        public Task<List<RestaurantRegistrationResponseDTO>> GetRequests();
    }
}
