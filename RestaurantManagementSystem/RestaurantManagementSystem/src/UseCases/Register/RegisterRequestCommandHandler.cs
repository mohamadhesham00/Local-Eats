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
        private readonly IRequestRestaurant _requestRestaurant;
        private readonly IEmailService _emailService;

        public RegisterRequestCommandHandler(IRequestRestaurant requestRestaurant, IEmailService emailService)
        {
            _requestRestaurant = requestRestaurant;
            _emailService = emailService;
        }
        public void Execute(string name, string email
            , string address, ContactInfo contact)
        {
            //for specifing what random code contains
            var options = new GenerationOptions(useNumbers: true, useSpecialCharacters: false, length: 8);
            string verificationcode = ShortId.Generate(options);
            RegistrationRequest obj = RegistrationRequest.Create(name,email,address,contact,RequestStatus.Status.PendingVerification,verificationcode);
            _requestRestaurant.Add(obj);
            string MessageBody = "You need to vertify your Email to Complete Your Request \n Your Request ID is : " + obj.Id + "\n" + " Your code is " + obj.VerificationCode;
            _emailService.SendEmail(obj.Email, "Email Confirmation", MessageBody);

        }
    }
}
