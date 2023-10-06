﻿using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Core.Exceptions;
using RestaurantManagementSystem.src.Infrastructure.Services;

namespace RestaurantManagementSystem.src.UseCases.Email_Confirmation
{
    public class VerifyRequestCommandHandler : IVerifyRequestCommandHandler
    {
        private readonly IRegistrationRequestRepo _registrationRequestRepo;
        private readonly IEmailService _emailservice;
        public VerifyRequestCommandHandler (IRegistrationRequestRepo restaurantRepo,IEmailService emailservice)
        {
            _registrationRequestRepo = restaurantRepo;
            _emailservice = emailservice;
        }
        public async void VerifyRegistrationRequest(VerifyRequestCommand confirmationCommand)
        {
            RegistrationRequest registrationRequest = await _registrationRequestRepo.FindByIdAsync(confirmationCommand.RequestId);
            registrationRequest.VertifyCode(confirmationCommand.VerificationCode);
            _registrationRequestRepo.Update(registrationRequest);
            _emailservice.SendEmailConfirmedEmail(registrationRequest.Email);

            }
        }
    }

