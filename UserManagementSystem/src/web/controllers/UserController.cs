using Microsoft.AspNetCore.Mvc;

namespace UserManagementSystem.Src.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        
        [HttpPost]
        
        public async Task<IActionResult> Login()
        {
            var user = Request.Body;
            Console.WriteLine(user);

            return Ok(user);
        }

    }
}
