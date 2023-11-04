using RestaurantManagementSystem.src.Core.RestaurantManagement.Entities;

namespace RestaurantManagementSystem.src.Core.RestaurantManagement.Contracts
{
    public interface IRestaurantRepo
    {
        public Task<int> AddRestaurantAsync(Restaurant restaurant);
        public Task<int> AddRestaurantMenuItemAsync(List<RestaurantMenuItem> restaurantMenuItems);
    }
}
