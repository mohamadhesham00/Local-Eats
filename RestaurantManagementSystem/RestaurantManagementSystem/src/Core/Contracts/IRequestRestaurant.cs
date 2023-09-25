using RestaurantManagementSystem.src.Core.Entities;

namespace RestaurantManagementSystem.src.Core.Contracts
{
    public interface IRequestRestaurant
    {
        void Add(RegistrationRequest waitingListRestaurant);
    }
}

