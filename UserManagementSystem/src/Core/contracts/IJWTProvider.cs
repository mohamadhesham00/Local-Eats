using UserManagementSystem.Src.Core.Entities;

public interface IJWTProvider
{
    string Generate(User user);
}
