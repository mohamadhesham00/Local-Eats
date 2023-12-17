using RestaurantManagementSystem.Core.RestaurantRequest.Contracts;
using RestaurantManagementSystem.Core.RestaurantRequest.Entities;

namespace RestaurantManagementSystem.Application.UseCases.RestaurantRequest.RequestApproval
{
    public class RequestApprovalCommandHandler : IRequestApprovalCommandHandler
    {
        private readonly IRegistrationRequestReadRepo _registrationRequestReadRepo;
        private readonly IRegistrationRequestWriteRepo _registrationRequestWriteReadRepo;
        public RequestApprovalCommandHandler(IRegistrationRequestReadRepo registrationRequestReadRepo
            , IRegistrationRequestWriteRepo registrationRequestWriteReadRepo)
        {
            _registrationRequestReadRepo = registrationRequestReadRepo;
            _registrationRequestWriteReadRepo = registrationRequestWriteReadRepo;

        }
        public async Task ApproveRequest(string id)
        {
            try
            {

                RegistrationRequest registrationRequest = await _registrationRequestReadRepo.FindByIdAsync(id);
                registrationRequest.ApproveRequest();
                await _registrationRequestWriteReadRepo.Update(registrationRequest);
            }catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }
    }
}
