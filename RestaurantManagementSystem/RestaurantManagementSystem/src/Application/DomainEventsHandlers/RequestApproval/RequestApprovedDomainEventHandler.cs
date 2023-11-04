using MediatR;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Core.RestaurantManagement.Entities;
using RestaurantManagementSystem.src.Core.RestaurantManagement.Builder;
using RestaurantManagementSystem.src.Core.RestaurantManagement.Contracts;
using RestaurantManagementSystem.src.Core.RestaurantRequest.DomainEvents;

namespace RestaurantManagementSystem.src.Application.DomainEventsHandlers.RequestApproval
{
    public class RequestApprovedDomainEventHandler : INotificationHandler<RequestApprovedDomainEvent>
    {
        private readonly RestaurantBuilder _builder;
        private readonly IRestaurantRepo _restaurantrepo;
        public RequestApprovedDomainEventHandler(RestaurantBuilder builder
            ,IRestaurantRepo restaurantRepo)
        {
            _builder = builder;
            _restaurantrepo = restaurantRepo;
        }
        
        Task INotificationHandler<RequestApprovedDomainEvent>.Handle(RequestApprovedDomainEvent notification, CancellationToken cancellationToken)
        {

            RegistrationRequest registrationRequest = notification._registrationRequest;
            Restaurant restaurant = _builder.WithId(registrationRequest.Id).WithName(registrationRequest.Name)
            .WithContactInfo(registrationRequest.ContactInfo).WithAddress(registrationRequest.Address)
             .Build();
            return _restaurantrepo.AddRestaurantAsync(restaurant);
        }
    }
}
