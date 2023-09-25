using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.Services;

namespace RestaurantManagementSystem.src.UseCases.Email_Confirmation
{
    public class EmailConfirmationHandler : IEmailConfirmationHandler
    {
        private readonly IRestaurantRepo _restaurantRepo;
        private readonly IEmailService _emailservice;
        public EmailConfirmationHandler (IRestaurantRepo restaurantRepo,IEmailService emailservice)
        {
            _restaurantRepo = restaurantRepo;
            _emailservice = emailservice;
        }
        public async Task<bool> Confirm(ConfirmationCommand confirmationCommand)
        {
            Guid id = new Guid(confirmationCommand.RequestId);
            RegistrationRequest obj = await _restaurantRepo.FindByIdAsync(id);
            if (obj.Status == RequestStatus.Status.PendingVerification)
            {
                RegistrationRequest Updated = RegistrationRequest.VertifyCode(confirmationCommand.ConfirmationCode, obj);
                if (Updated.Status == RequestStatus.Status.WaitingForAdminResponse)
                {
                    _restaurantRepo.Update(Updated);
                    _emailservice.SendEmail(Updated.Email, "Email Confirmed", "Email Confirmed Successfullly \n Your Restaurant is now on the waiting list");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
    }
}
