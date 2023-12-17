using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Core.RestaurantManagement.Entities;
using RestaurantManagementSystem.Core.RestaurantRequest.Entities;
using RestaurantManagementSystem.Infrastructure.RestaurantManagement.DbConfiguration;
using RestaurantManagementSystem.Infrastructure.RestaurantRequest.DbConfiguration;

namespace RestaurantManagementSystem.Infrastructure.Common.Db
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<RegistrationRequest> RegistrationRequests { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantMenuItem> RestaurantMenuItems {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RegistrationRequestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RestaurantEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RestaurantMenuItemEntityTypeConfiguration());
        }

    }
}
