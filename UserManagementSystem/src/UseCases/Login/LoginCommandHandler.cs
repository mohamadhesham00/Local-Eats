namespace UserManagementSystem.Src.UseCases.Login;

public class LoginCommandHandler : ILoginCommandHandler
{
    private readonly IPasswordHashService passwordHashService;
    private readonly IUserRepository userRepo;
    private readonly IJWTProvider jwtProvider;

    public LoginCommandHandler(IPasswordHashService passwordHashService, IUserRepository userRepo, IJWTProvider jwtProvider)
    {
        this.passwordHashService = passwordHashService;
        this.userRepo = userRepo;
        this.jwtProvider = jwtProvider;
    }
    public async Task<string> Execute(LoginCommand loginCommand)
    {
        var user = await this.userRepo.FindByEmailAsync(loginCommand.Email) ?? throw new UserNotFoundException($"Can't find user with email {loginCommand.Email}");

        var isValidPassword = this.passwordHashService.VerifyPassword(loginCommand.Password, user.Password);

        if (!isValidPassword)
        {
            throw new InvalidCredentialsException();
        }

        return this.jwtProvider.Generate(user);

    }
}
