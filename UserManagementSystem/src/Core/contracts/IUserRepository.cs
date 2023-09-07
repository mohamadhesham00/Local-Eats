using UserManagementSystem.Src.Core.Entities;

public interface IUserRepository
{
    Task<User> FindByEmailAsync(string email);
}