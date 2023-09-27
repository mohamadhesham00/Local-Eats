using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.Services;
using shortid.Configuration;
using shortid;
using RestaurantManagementSystem.src.Infrastructure.Services.CodeGenerator;

namespace RestaurantManagementSystem.src.UseCases.Register
{
    public class RegisterRequestCommandHandler : IRegisterRequestCommandHandler
    {
        private readonly IRegistrationRequestRepo _registrationRequestRepo;
        private readonly IEmailService _emailService;

        public RegisterRequestCommandHandler(IRegistrationRequestRepo registrationRequestRepo, IEmailService emailService)
        {
            _registrationRequestRepo = _registrationRequestRepo;
            _emailService = emailService;
        }
        public void Execute(string name, string email
            , string address, string contactinfoemail, string contactinfophonenumber)
        {
            string verificationcode = GenerateVerificationCode.Generate();
            RegistrationRequest registrationRequest = RegistrationRequest.Create(name,email,address,contactinfoemail, contactinfophonenumber,verificationcode);
            _registrationRequestRepo.AddRequest(registrationRequest);
            _emailService.SendConfirmationEmail(registrationRequest.Email, registrationRequest.Id, registrationRequest.VerificationCode);

        }
    }
}
