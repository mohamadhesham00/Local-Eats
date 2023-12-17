using RestaurantManagementSystem.Core.RestaurantManagement.Contracts;
using RestaurantManagementSystem.Core.RestaurantManagement.Entities;
using RestaurantManagementSystem.Infrastructure.Common.Db;

namespace RestaurantManagementSystem.Infrastructure.RestaurantManagement.Repositories
{
    public class RestaurantWriteRepo : IRestaurantWriteRepo
    {
        private readonly ApplicationDbContext _db;
        public RestaurantWriteRepo(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
           await _db.Restaurants.AddAsync(restaurant);
           await _db.SaveChangesAsync();
           }
        public async Task<int> AddRestaurantMenuItemAsync (List<RestaurantMenuItem> restaurantMenuItems)
        {
            await _db.RestaurantMenuItems.AddRangeAsync(restaurantMenuItems);
            return await _db.SaveChangesAsync();
        }
    }
}
