using RestaurantManagementSystem.Core.RestaurantRequest.Contracts;
using RestaurantManagementSystem.Core.RestaurantRequest.Entities;
using RestaurantManagementSystem.Core.Common.Contracts.Services.EmailService;

namespace RestaurantManagementSystem.Application.UseCases.RestaurantRequest.EmailConfirmation
{
    public class VerifyRequestCommandHandler : IVerifyRequestCommandHandler
    {
        private readonly IRegistrationRequestReadRepo _registrationRequestReadRepo;
        private readonly IRegistrationRequestWriteRepo _registrationRequestWriteRepo;
        private readonly IEmailService _emailservice;
        public VerifyRequestCommandHandler(IRegistrationRequestReadRepo restaurantReadRepo
            , IRegistrationRequestWriteRepo registrationRequestWriteRepo
            , IEmailService emailService)
        {
            _registrationRequestReadRepo = restaurantReadRepo;
            _registrationRequestWriteRepo = registrationRequestWriteRepo;
            _emailservice = emailService;
        }
        public async Task VerifyRegistrationRequest(VerifyRequestCommand confirmationCommand)
        {
            try
            {
                RegistrationRequest registrationRequest = await _registrationRequestReadRepo.FindByIdAsync(confirmationCommand.RequestId);
                registrationRequest.VertifyCode(confirmationCommand.VerificationCode);
                await _registrationRequestWriteRepo.Update(registrationRequest);
                await _emailservice.SendEmailConfirmedEmail(registrationRequest.Email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

