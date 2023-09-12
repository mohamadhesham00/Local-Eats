namespace UserManagementSystem.Src.Web.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILoginCommandHandler loginCommandHandler;
    public UserController(ILoginCommandHandler loginCommandHandler) => this.loginCommandHandler = loginCommandHandler;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
    {
        try
        {
            var token = await this.loginCommandHandler.Execute(loginCommand);
            return this.Ok(new { Token = token });
        }
        catch (InvalidCredentialsException e)
        {
            return this.Unauthorized(new { e.Message });
        }
        catch (UserNotFoundException e)
        {
            return this.BadRequest(new { e.Message });
        }
        catch (Exception)
        {
            return this.StatusCode(500, new { Message = "Internal Server Error" });
        }
    }

}
