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
        User? user = await _userRepo.FindByEmailAsync(command.Email);

        if (user == null)
        {
            throw new UserNotFoundException($"Can't find user with email {command.Email}");
        }

        bool isValidPassword = _passwordHashService.VerifyPassword(command.Password, user.Password);

        if (!isValidPassword)
        {
            throw new InvalidCredentialsException();
        }

        return _jwtProvider.Generate(user);

    }
}