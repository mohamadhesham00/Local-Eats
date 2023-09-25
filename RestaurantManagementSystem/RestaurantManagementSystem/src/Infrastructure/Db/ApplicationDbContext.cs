using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.Configuration;

namespace RestaurantManagementSystem.src.Infrastructure.Db
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<RegistrationRequest> RegistrationRequests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RegistrationRequestEntityTypeConfiguration());

        }

    }
}
