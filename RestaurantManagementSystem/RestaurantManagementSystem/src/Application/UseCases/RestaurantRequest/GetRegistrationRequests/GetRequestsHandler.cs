using RestaurantManagementSystem.Core.RestaurantRequest.Contracts;
using RestaurantManagementSystem.Core.RestaurantRequest.Entities;

namespace RestaurantManagementSystem.Application.UseCases.RestaurantRequest.GetRegistrationRequests
{
    public class GetRequestsHandler : IGetRequestsHandler
    {
        private readonly IRegistrationRequestReadRepo _registrationrequestReadrepo;
        public GetRequestsHandler(IRegistrationRequestReadRepo registrationrequestReadrepo)
        {
            _registrationrequestReadrepo = registrationrequestReadrepo;
        }

        public async Task<List<RestaurantRegistrationResponseDTO>> GetRequests()
        {
            List<RegistrationRequest> requests = await _registrationrequestReadrepo.GetRegistrationRequestsAsync();

            return RestaurantRegistrationResponseDTO.From(requests);
        }
    }
}
