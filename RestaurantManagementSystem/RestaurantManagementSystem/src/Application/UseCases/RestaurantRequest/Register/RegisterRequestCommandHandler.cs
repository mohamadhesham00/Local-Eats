using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.src.Infrastructure.Common.Services;
using shortid.Configuration;
using shortid;
using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.RestaurantRequest.Services.CodeGenerator;

namespace RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.Register
{
    public class RegisterRequestCommandHandler : IRegisterRequestCommandHandler
    {
        private readonly IRegistrationRequestRepo _registrationRequestRepo;
        private readonly IEmailService _emailService;

        public RegisterRequestCommandHandler(IRegistrationRequestRepo registrationRequestRepo, IEmailService emailService)
        {
            _registrationRequestRepo = registrationRequestRepo;
            _emailService = emailService;
        }
        public async Task Execute(RegisterRequestCommand registerCommand)
        {
            string verificationcode = VerificationCodeGenerator.Generate();
            RegistrationRequest registrationRequest = RegistrationRequest.Create(registerCommand.Name, registerCommand.Email
                , registerCommand.Address, registerCommand.contactinfoemail, registerCommand.contactinfophonenumber, verificationcode);
            await _registrationRequestRepo.AddRequest(registrationRequest);
            _emailService.SendConfirmationEmail(registrationRequest.Email, registrationRequest.Id, registrationRequest.VerificationCode);

        }
    }
}
