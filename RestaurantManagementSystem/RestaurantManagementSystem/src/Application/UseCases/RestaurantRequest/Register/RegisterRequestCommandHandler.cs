using RestaurantManagementSystem.Core.RestaurantRequest.Contracts;
using RestaurantManagementSystem.Core.RestaurantRequest.Entities;
using RestaurantManagementSystem.Infrastructure.Common.Services.VerificationCodeGenerator;
using RestaurantManagementSystem.Core.Common.Contracts.Services.EmailService;

namespace RestaurantManagementSystem.Application.UseCases.RestaurantRequest.Register
{
    public class RegisterRequestCommandHandler : IRegisterRequestCommandHandler
    {
        private readonly IRegistrationRequestWriteRepo _registrationRequestRepo;
        private readonly IEmailService _emailService;

        public RegisterRequestCommandHandler(IRegistrationRequestWriteRepo registrationRequestRepo, IEmailService emailService)
        {
            _registrationRequestRepo = registrationRequestRepo;
            _emailService = emailService;
        }
        public async Task Execute(RegisterRequestCommand registerCommand)
        {
            try
            { 
                string verificationcode = VerificationCodeGenerator.Generate();
                RegistrationRequest registrationRequest = RegistrationRequest.Create(registerCommand.Name, registerCommand.Email
                    , registerCommand.Address, registerCommand.contactinfoemail, registerCommand.contactinfophonenumber, verificationcode);
                await _registrationRequestRepo.AddRequest(registrationRequest);
                await _emailService.SendConfirmationEmail(registrationRequest.Email, registrationRequest.Id, registrationRequest.VerificationCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
