using Microsoft.EntityFrameworkCore;
using UserManagementSystem.Src.Core.Entities;
using UserManagementSystem.Src.Infrastructure.Db;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext; // Replace with your database context

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            throw new ArgumentNullException();
        }
        return user;
    }
}