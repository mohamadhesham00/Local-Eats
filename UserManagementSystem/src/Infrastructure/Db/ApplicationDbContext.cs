namespace UserManagementSystem.Src.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using UserManagementSystem.Src.Core.Entities;

public class ApplicationDbContext : DbContext
{
    private readonly IPasswordHashService passwordHashService;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPasswordHashService passwordHashService) : base(options) => this.passwordHashService = passwordHashService;
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity => entity.HasIndex(e => e.Email).IsUnique());
        base.OnModelCreating(modelBuilder);
        this.SeedUsers(modelBuilder);
    }

    private void SeedUsers(ModelBuilder modelBuilder)
    {
        var users = this.GetSeedUsers();
        modelBuilder.Entity<User>().HasData(users);
    }

    private List<User> GetSeedUsers()
    {
        var userPassword = this.passwordHashService.HashPassword("mohamed@localeats.com");
        User user = new("Mohamed", "Hesham", "mohamed@localeats.com", userPassword)
        {
            Id = Guid.NewGuid()
        };
        var scndUserPassword = this.passwordHashService.HashPassword("abdelrahman@localeats.com");
        User scndUser = new("Abdelrahman", "Omran", "abdelrahman@localeats.com", scndUserPassword)
        {
            Id = Guid.NewGuid()
        };
        List<User> users = new() { user, scndUser };
        return users;
    }
}
