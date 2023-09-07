using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
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
                return Unauthorized(new { Message = "Invalid Password" });
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
