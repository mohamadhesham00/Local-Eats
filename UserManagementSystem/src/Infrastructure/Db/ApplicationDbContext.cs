using Microsoft.EntityFrameworkCore;
using UserManagementSystem.Src.Core.Entities;

namespace UserManagementSystem.Src.Infrastructure.Db
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IPasswordHashService _passwordHashService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPasswordHashService passwordHashService) : base(options)
        {
            _passwordHashService = passwordHashService;
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
            base.OnModelCreating(modelBuilder);
            this.seedUsers(modelBuilder);
        }

        private void seedUsers(ModelBuilder modelBuilder)
        {
            List<User> users = getSeedUsers();
            modelBuilder.Entity<User>().HasData(users);
        }

        private List<User> getSeedUsers()
        {
            string userPassword = _passwordHashService.HashPassword("mohamed@localeats.com");
            User user = new("Mohamed", "Hesham", "mohamed@localeats.com", userPassword)
            {
                Id = Guid.NewGuid()
            };
            string scndUserPassword = _passwordHashService.HashPassword("abdelrahman@localeats.com");
            User scndUser = new("Abdelrahman", "Omran", "abdelrahman@localeats.com", scndUserPassword)
            {
                Id = Guid.NewGuid()
            };
            List<User> users = new() { user, scndUser };
            return users;
        }
    }
}
