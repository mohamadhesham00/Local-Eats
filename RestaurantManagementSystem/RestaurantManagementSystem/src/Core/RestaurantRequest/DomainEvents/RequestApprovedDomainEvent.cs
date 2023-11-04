using MediatR;
using RestaurantManagementSystem.src.Core.Entities;

namespace RestaurantManagementSystem.src.Core.RestaurantRequest.DomainEvents
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
