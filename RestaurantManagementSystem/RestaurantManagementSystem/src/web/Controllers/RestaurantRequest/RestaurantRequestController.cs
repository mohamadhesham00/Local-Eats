using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Application.UseCases.RestaurantRequest.EmailConfirmation;
using RestaurantManagementSystem.Application.UseCases.RestaurantRequest.GetRegistrationRequests;
using RestaurantManagementSystem.Application.UseCases.RestaurantRequest.Register;
using RestaurantManagementSystem.Application.UseCases.RestaurantRequest.RequestApproval;

namespace RestaurantManagementSystem.web.Controllers.RestaurantRequest
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
            try
            {
                await _requesthandler.Execute(registerCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("VerifyRequest")]
        public async Task<IActionResult> VerifyRequest([FromBody] VerifyRequestCommand confirmationCommand)
        {
            try
            {
                await _vertifyrequestcommandhandler.VerifyRegistrationRequest(confirmationCommand);
                return Ok(new { message = "Email Confirmed Successfully" });

            }catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
                
            }
        }

        [HttpGet("RegistrationRequests/getall")]
        public async Task <IActionResult> GetRequests()
        {
            List<RestaurantRegistrationResponseDTO> list = await _getRequestsHandler.GetRequests();
            return Ok(list);
        }

        [HttpPost("RegistrationRequests/{id}/approve")]
        public async Task<IActionResult> Approve(string id)
        {
            try
            {
                await _requestApprovalCommandHandler.ApproveRequest(id);
                return Ok(new { Message = "Request Approved Successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });

            }
            
        }

    }
}
