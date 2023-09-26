using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.Services;

namespace RestaurantManagementSystem.src.UseCases.Email_Confirmation
{
    public class EmailConfirmationHandler : IEmailConfirmationHandler
    {
        private readonly IRegistrationRequestRepo _restaurantRepo;
        private readonly IEmailService _emailservice;
        public EmailConfirmationHandler (IRegistrationRequestRepo restaurantRepo,IEmailService emailservice)
        {
            _restaurantRepo = restaurantRepo;
            _emailservice = emailservice;
        }
        public async Task<bool> VerifyEmail(ConfirmationCommand confirmationCommand)
        {
            RegistrationRequest obj = await _restaurantRepo.FindByIdAsync(confirmationCommand.RequestId);
            obj.VertifyCode(confirmationCommand.VerificationCode);
            if (obj != null && obj.Status == Status.WaitingForAdminResponse)
                {
                    _restaurantRepo.Update(obj);
                    _emailservice.SendAddedToWaitingListEmail(obj.Email);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

