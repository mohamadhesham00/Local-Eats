using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.Src.UseCases.login;

namespace UserManagementSystem.Src.web.Controllers
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
            catch (InvalidOperationException)
            {
                return BadRequest(new { Message = "Invalid operation" });
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new { Message = "User was not found" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

    }
}
