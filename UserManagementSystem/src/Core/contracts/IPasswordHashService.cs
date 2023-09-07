public interface IPasswordHashService
{
    string HashPassword(string password);
    bool VerifyPassword(string providedPassword, string hashedPassword);
}