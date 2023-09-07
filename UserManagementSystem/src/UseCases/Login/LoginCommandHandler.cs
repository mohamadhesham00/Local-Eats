using UserManagementSystem.Src.Core.Entities;

namespace UserManagementSystem.Src.UseCases.login;

public class LoginCommandHandler : ILoginCommandHandler
{
    private readonly IPasswordHashService _passwordHashService;
    private readonly IUserRepository _userRepo;
    private readonly IJWTProvider _jwtProvider;
    public LoginCommandHandler(IPasswordHashService passwordHashService, IUserRepository userRepo, IJWTProvider jwtProvider)
    {
        _passwordHashService = passwordHashService;
        _userRepo = userRepo;
        _jwtProvider = jwtProvider;
    }
    public async Task<string> Execute(LoginCommand command)
    {
        try
        {
            User? user = await _userRepo.FindByEmailAsync(command.Email);

            if (user == null)
            {
                // TODO: throw domain defined errors
                throw new ArgumentNullException($"Can't find user with email {command.Email}");
            }

            bool isValidPassword = _passwordHashService.VerifyPassword(command.Password, user.Password);

            if (!isValidPassword)
            {
                throw new InvalidOperationException("Invalid Password");
            }

            return _jwtProvider.Generate(user);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine($"Null exception: {e.Message}");
            throw e;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected Error {e.Message}");
            throw e;
        }

    }
}