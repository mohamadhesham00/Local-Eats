using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.Services;
using shortid.Configuration;
using shortid;

namespace RestaurantManagementSystem.src.UseCases.Register
{
    public class RegisterRequestCommandHandler : IRegisterRequestCommandHandler
    {
        private readonly IRegistrationRequestRepo registrationRequestRepo;
        private readonly IEmailService _emailService;

        public RegisterRequestCommandHandler(IRegistrationRequestRepo _registrationRequestRepo, IEmailService emailService)
        {
            registrationRequestRepo = _registrationRequestRepo;
            _emailService = emailService;
        }
        public void Execute(string name, string email
            , string address, string contactinfoemail, string contactinfophonenumber)
        {
            string verificationcode = registrationRequestRepo.GenerateVerificationCode();
            RegistrationRequest obj = RegistrationRequest.Create(name,email,address,contactinfoemail, contactinfophonenumber, Status.PendingVerification,verificationcode);
            registrationRequestRepo.AddRequest(obj);
            _emailService.SendConfirmationEmail(obj.Email, obj.Id,obj.VerificationCode);

        }
    }
}
