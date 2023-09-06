using Microsoft.AspNetCore.Mvc;

namespace UserManagementSystem.Src.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        
        [HttpPost("login")]
        
        public async Task<IActionResult> Login()
        {
            var user = Request.Body;
            Console.WriteLine(user);

            return new JsonResult(user);
        }

    }
}
