using UserManagementSystem.Src.Core.Entities;
using UserManagementSystem.Src.Infrastructure.Db;

namespace UserManagementSystem.Seeds;

public static class UserSeeder {
    public static void SeedUsers(ApplicationDbContext dbContext, IPasswordHashService passwordHashService) {
        string userPassword = passwordHashService.HashPassword("mohamed@localeats.com");
        User user = new User("Mohamed", "Hesham", "mohamed@localeats.com", userPassword);
        
        string scndUserPassword = passwordHashService.HashPassword("abdelrahman@localeats.com");
        User scndUser = new User("Abdelrahman", "Omran", "abdelrahman@localeats.com", scndUserPassword);

        List<User> users = new List<User>
        {
            user,
            scndUser
        };

        dbContext.Users.AddRange(users);
        dbContext.SaveChanges();

    }   
}