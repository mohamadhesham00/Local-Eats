using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Core.RestaurantManagement.Entities;
using RestaurantManagementSystem.src.Core.RestaurantManagement.Entities;
using RestaurantManagementSystem.src.Infrastructure.Configuration;
using RestaurantManagementSystem.src.Infrastructure.RestaurantManagement.DbConfiguration;

namespace RestaurantManagementSystem.src.Infrastructure.Common.Db
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
