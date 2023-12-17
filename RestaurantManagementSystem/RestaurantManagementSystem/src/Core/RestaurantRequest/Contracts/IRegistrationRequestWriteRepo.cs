using RestaurantManagementSystem.Core.RestaurantRequest.Entities;

namespace RestaurantManagementSystem.Core.RestaurantRequest.Contracts
{
    public interface IRegistrationRequestWriteRepo
    {
        public Task AddRequest(RegistrationRequest waitingListRestaurant);
        public Task Update(RegistrationRequest registrationRequest);

    }
}
