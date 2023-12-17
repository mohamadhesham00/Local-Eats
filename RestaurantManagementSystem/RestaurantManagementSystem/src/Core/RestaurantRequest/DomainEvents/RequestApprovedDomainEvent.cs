using MediatR;
using RestaurantManagementSystem.Core.RestaurantRequest.Entities;

namespace RestaurantManagementSystem.Core.RestaurantRequest.DomainEvents
{
    public class RequestApprovedDomainEvent : INotification
    {
        public readonly RegistrationRequest _registrationRequest;
        public RequestApprovedDomainEvent(RegistrationRequest registrationRequest)
        {
            _registrationRequest = registrationRequest;
        }
    }
}
