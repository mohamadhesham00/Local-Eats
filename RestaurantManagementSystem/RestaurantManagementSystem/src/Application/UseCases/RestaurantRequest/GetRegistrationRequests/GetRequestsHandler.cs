using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.Common.Db;
using RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest;

namespace RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.GetRegistrationRequests
{
    public class GetRequestsHandler : IGetRequestsHandler
    {
        private readonly IRegistrationRequestRepo _registrationrequestrepo;
        public GetRequestsHandler(IRegistrationRequestRepo registrationrequestrepo)
        {
            _registrationrequestrepo = registrationrequestrepo;
        }

        public async Task<List<RestaurantRegistrationResponseDTO>> GetRequests()
        {
            List<RegistrationRequest> requests = await _registrationrequestrepo.GetRegistrationRequestsAsync();

            return RestaurantRegistrationResponseDTO.from(requests);
        }
    }
}
