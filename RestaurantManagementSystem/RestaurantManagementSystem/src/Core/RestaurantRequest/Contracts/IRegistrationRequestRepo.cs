using RestaurantManagementSystem.src.Core.Entities;

namespace RestaurantManagementSystem.src.Core.Contracts
{
    public interface IRegistrationRequestRepo
    {
        public Task AddRequest(RegistrationRequest waitingListRestaurant);
        public Task<RegistrationRequest> FindByIdAsync (string ID);
        public Task Update(RegistrationRequest registrationRequest);
        public Task<List<RegistrationRequest>> GetRegistrationRequestsAsync();

    }
}
