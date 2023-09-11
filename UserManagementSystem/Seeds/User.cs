using UserManagementSystem.Src.Core.Entities;
using UserManagementSystem.Src.Infrastructure.Db;

namespace UserManagementSystem.Seeds;

public static class UserSeeder
{
    public static void SeedUsers(ApplicationDbContext dbContext, IPasswordHashService passwordHashService)
    {
        if (!dbContext.Users.Any(u => u.Email == "mohamed@localeats.com"))
        {
            string userPassword = passwordHashService.HashPassword("mohamed@localeats.com");
            User user = new User("Mohamed", "Hesham", "mohamed@localeats.com", userPassword);
            dbContext.Users.Add(user);
        }
        if (!dbContext.Users.Any(u => u.Email == "abdelrahman@localeats.com"))
        {
            string scndUserPassword = passwordHashService.HashPassword("abdelrahman@localeats.com");
            User scndUser = new User("Abdelrahman", "Omran", "abdelrahman@localeats.com", scndUserPassword);
            dbContext.Users.Add(scndUser);
        }

        dbContext.SaveChanges();
    }
}