using RestaurantManagementSystem.src.Core.RestaurantManagement.Entities;
using RestaurantManagementSystem.src.Core.RestaurantManagement.Contracts;
using RestaurantManagementSystem.src.Infrastructure.Common.Db;

namespace RestaurantManagementSystem.src.Infrastructure.RestaurantManagement.Repositories
{
    public class RestaurantRepo : IRestaurantRepo
    {
        private readonly ApplicationDbContext _db;
        public RestaurantRepo(ApplicationDbContext db)
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
