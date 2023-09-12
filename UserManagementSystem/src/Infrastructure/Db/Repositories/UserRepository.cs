using Microsoft.EntityFrameworkCore;
using UserManagementSystem.Src.Core.Entities;
using UserManagementSystem.Src.Infrastructure.Db;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext dbContext;

    public UserRepository(ApplicationDbContext dbContext) => this.dbContext = dbContext;

    public async Task<User?> FindByEmailAsync(string email) => await this.dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
}
