using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.Services.Repositories;
using RestaurantManagementSystem.src.UseCases.Email_Confirmation;
using RestaurantManagementSystem.src.UseCases.GetRegistrationRequests;
using RestaurantManagementSystem.src.UseCases.Register;

namespace RestaurantManagementSystem.src.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController: ControllerBase
    {
        private readonly IRegisterRequestCommandHandler _requesthandler;
        private readonly IVerifyRequestCommandHandler  _vertifyrequestcommandhandler;
        private readonly IGetRequestsHandler _getRequestsHandler;
        public RestaurantController (IRegisterRequestCommandHandler requesthandler, IVerifyRequestCommandHandler vertifyrequestcommandhandler
            , IGetRequestsHandler getRequestsHandler)
        {
           _requesthandler = requesthandler;
            _vertifyrequestcommandhandler = vertifyrequestcommandhandler;
            _getRequestsHandler = getRequestsHandler;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestCommand registerCommand)
        {
            _requesthandler.Execute(registerCommand);
            return Ok();
        }
        [HttpPost("VerifyRequest")]
        public async Task<IActionResult> VerifyRequest([FromBody] VerifyRequestCommand confirmationCommand)
        {
            try
            {
                _vertifyrequestcommandhandler.VerifyRegistrationRequest(confirmationCommand);
                return Ok(new { Message = "Email Confirmed Sucessfully" });

            }catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
                
            }
        }

        [HttpGet("RegistrationRequests/GetAll")]
        public async Task <IActionResult> GetRequests()
        {
            List<RestaurantRegistrationResponseDTO> list = await _getRequestsHandler.GetRequests();
            return Ok(list);
        }

        [HttpPost("RegistrationRequests/{id}/approve")]
        public async Task<IActionResult> approve (int id)
        {
            //haven't done anything yet
            return Ok($"the id is {id}");
        }
    }
}
