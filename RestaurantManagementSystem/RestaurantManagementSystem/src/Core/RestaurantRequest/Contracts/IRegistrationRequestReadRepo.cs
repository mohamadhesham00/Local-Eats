using RestaurantManagementSystem.Core.RestaurantRequest.Entities;

namespace RestaurantManagementSystem.Core.RestaurantRequest.Contracts
{
    public interface IRegistrationRequestReadRepo
    {
        public Task<RegistrationRequest> FindByIdAsync(string ID);
        public Task<List<RegistrationRequest>> GetRegistrationRequestsAsync();

    }
}
