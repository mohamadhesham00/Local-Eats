﻿using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.UseCases.Email_Confirmation;
using RestaurantManagementSystem.src.UseCases.Register;

namespace RestaurantManagementSystem.src.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController: ControllerBase
    {
        private readonly IRegisterRequestCommandHandler _requesthandler;
        private readonly IEmailConfirmationHandler  _emailconfirmationhandler;
        public RestaurantController (IRegisterRequestCommandHandler requesthandler, IEmailConfirmationHandler emailConfirmation)
        {
           _requesthandler = requesthandler;
           _emailconfirmationhandler = emailConfirmation;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestCommand registerCommand)
        {
            _requesthandler.Execute(registerCommand.Name, registerCommand.Email
            , registerCommand.Address, registerCommand.contactinfoemail,registerCommand.contactinfophonenumber);
            return Ok();
        }
        [HttpPost("EmailConfirmation")]
        public async Task<IActionResult> EmailConfirmation([FromBody] ConfirmationCommand confirmationCommand)
        {
            bool result = _emailconfirmationhandler.VerifyEmail(confirmationCommand).Result;
            if (result)
            {
                return Ok(new { Message = "Email Confirmed Sucessfully" });
            }
            else
            {
                return BadRequest(new { Message = "Email confirmation failed." });
            }
        }


    }
}
