using Microsoft.AspNetCore.Mvc;

namespace UserManagementSystem.Src.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILoginCommandHandler _loginCommandHandler;
        public UserController(ILoginCommandHandler loginCommandHandler) {
            _loginCommandHandler = loginCommandHandler;
        }

        [HttpPost("login")]      
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            try
            {
                string token = await _loginCommandHandler.Execute(loginCommand);
                return Ok(new { Token = token });
            }
            catch (InvalidCredentialsException e)
            {
                return Unauthorized(new { e.Message });
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(new { e.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

    }
}
