using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Exceptions;
using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.Common.Services;

namespace RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.EmailConfirmation
{
    public class VerifyRequestCommandHandler : IVerifyRequestCommandHandler
    {
        private readonly IRegistrationRequestRepo _registrationRequestRepo;
        private readonly IEmailService _emailservice;
        public VerifyRequestCommandHandler(IRegistrationRequestRepo restaurantRepo, IEmailService emailservice)
        {
            _registrationRequestRepo = restaurantRepo;
            _emailservice = emailservice;
        }
        public async Task VerifyRegistrationRequest(VerifyRequestCommand confirmationCommand)
        {
            try
            {
                RegistrationRequest registrationRequest = await _registrationRequestRepo.FindByIdAsync(confirmationCommand.RequestId);
                registrationRequest.VertifyCode(confirmationCommand.VerificationCode);
                await _registrationRequestRepo.Update(registrationRequest);
                _emailservice.SendEmailConfirmedEmail(registrationRequest.Email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

