using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Core.RestaurantRequest.Exceptions;

namespace RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.RequestApproval
{
    public class RequestApprovalCommandHandler : IRequestApprovalCommandHandler
    {
        private readonly IRegistrationRequestRepo _registrationRequestRepo;
        public RequestApprovalCommandHandler(IRegistrationRequestRepo registrationRequestRepo)
        {
            _registrationRequestRepo = registrationRequestRepo;
        }
        public async Task ApproveRequest(string id)
        {
            try
            {

                RegistrationRequest registrationRequest = await _registrationRequestRepo.FindByIdAsync(id);
                registrationRequest.ApproveRequest();
                await _registrationRequestRepo.Update(registrationRequest);
            }catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }
    }
}
