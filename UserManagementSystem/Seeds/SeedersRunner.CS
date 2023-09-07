using UserManagementSystem.Seeds;
using UserManagementSystem.Src.Infrastructure.Db;

public class SeedersRunner {
    private readonly ApplicationDbContext _dbContext;
    private readonly IPasswordHashService _passwordHashService;

    public SeedersRunner(ApplicationDbContext dbContext, IPasswordHashService passwordHashService)
    {
        _dbContext = dbContext;
        _passwordHashService = passwordHashService;
    }

    public void Run()
    {
        UserSeeder.SeedUsers(_dbContext, _passwordHashService);
    }
}