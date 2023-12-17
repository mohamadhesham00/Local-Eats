using RestaurantManagementSystem.Core.RestaurantManagement.Entities;

namespace RestaurantManagementSystem.Core.RestaurantManagement.Contracts
{
    public interface IRestaurantWriteRepo
    {
        public Task AddRestaurantAsync(Restaurant restaurant);
        public Task<int> AddRestaurantMenuItemAsync(List<RestaurantMenuItem> restaurantMenuItems);
    }
}
