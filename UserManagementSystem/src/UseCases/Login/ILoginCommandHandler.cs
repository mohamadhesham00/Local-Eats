public interface ILoginCommandHandler
{
    Task<string> Execute(LoginCommand loginCommand);
}
