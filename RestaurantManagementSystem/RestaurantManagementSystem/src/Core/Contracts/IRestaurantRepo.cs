using RestaurantManagementSystem.src.Core.Entities;

namespace RestaurantManagementSystem.src.Core.Contracts
{
    public interface IRestaurantRepo
    {
        public Task<RegistrationRequest> FindByIdAsync (Guid id);
        public void Update(RegistrationRequest registrationRequest);
    }
}
