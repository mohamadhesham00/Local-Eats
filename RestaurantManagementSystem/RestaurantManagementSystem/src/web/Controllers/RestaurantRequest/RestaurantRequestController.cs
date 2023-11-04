using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.EmailConfirmation;
using RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.GetRegistrationRequests;
using RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.Register;
using RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.RequestApproval;
using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;

namespace RestaurantManagementSystem.src.web.Controllers.RestaurantRequest.RestaurantRequestController
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantRequestController: ControllerBase
    {
        private readonly IRegisterRequestCommandHandler _requesthandler;
        private readonly IVerifyRequestCommandHandler  _vertifyrequestcommandhandler;
        private readonly IGetRequestsHandler _getRequestsHandler;
        private readonly IRequestApprovalCommandHandler _requestApprovalCommandHandler;
        public RestaurantRequestController (IRegisterRequestCommandHandler requesthandler
            , IVerifyRequestCommandHandler vertifyrequestcommandhandler
            , IGetRequestsHandler getRequestsHandler
            , IRequestApprovalCommandHandler requestApprovalCommandHandler)
        {
            _requesthandler = requesthandler;
            _vertifyrequestcommandhandler = vertifyrequestcommandhandler;
            _getRequestsHandler = getRequestsHandler;
            _requestApprovalCommandHandler = requestApprovalCommandHandler;
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

        [HttpGet("RegistrationRequests/getall")]
        public async Task <IActionResult> GetRequests()
        {
            List<RestaurantRegistrationResponseDTO> list = await _getRequestsHandler.GetRequests();
            return Ok(list);
        }

        [HttpPost("RegistrationRequests/{id}/approve")]
        public async Task<IActionResult> approve(string id)
        {
            try
            {
                _requestApprovalCommandHandler.ApproveRequest(id);
                return Ok(new { Message = "Requset Approved Sucessfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });

            }
            
        }

    }
}
