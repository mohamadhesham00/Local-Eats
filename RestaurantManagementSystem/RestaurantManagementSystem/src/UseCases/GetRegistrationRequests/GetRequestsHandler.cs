using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.Db;
using RestaurantManagementSystem.src.UseCases.Register;

namespace RestaurantManagementSystem.src.UseCases.GetRegistrationRequests
{
    public class GetRequestsHandler : IGetRequestsHandler
    {
        private readonly IRegistrationRequestRepo _registrationrequestrepo;
        public GetRequestsHandler(IRegistrationRequestRepo registrationrequestrepo) {
            _registrationrequestrepo = registrationrequestrepo;
        }

        public async Task<List<RestaurantRegistrationResponseDTO>> GetRequests()
        {
            List<RegistrationRequest> requests = await _registrationrequestrepo.GetRegistrationRequestsAsync();
            
            return RestaurantRegistrationResponseDTO.from(requests);
        }
    }
}
