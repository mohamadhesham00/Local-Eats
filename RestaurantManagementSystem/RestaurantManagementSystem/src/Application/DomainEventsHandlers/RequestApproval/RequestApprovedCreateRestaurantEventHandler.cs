using RestaurantManagementSystem.Core.RestaurantManagement.Builder;
using RestaurantManagementSystem.Core.RestaurantManagement.Contracts;
using RestaurantManagementSystem.Core.RestaurantManagement.Entities;
using RestaurantManagementSystem.Core.RestaurantRequest.Contracts.DomainEventHandlers;
using RestaurantManagementSystem.Core.RestaurantRequest.DomainEvents;
using RestaurantManagementSystem.Core.RestaurantRequest.Entities;

namespace RestaurantManagementSystem.Application.DomainEventsHandlers.RequestApproval
{
    public class RequestApprovedCreateRestaurantEventHandler : IRequestApprovedDomainEventHandler
    {
        private readonly RestaurantBuilder _builder;
        private readonly IRestaurantWriteRepo _restaurantWriteRepo;
        public RequestApprovedCreateRestaurantEventHandler(RestaurantBuilder builder
            ,IRestaurantWriteRepo restaurantWriteRepo)
        {
            _builder = builder;
            _restaurantWriteRepo = restaurantWriteRepo;
        }

        public async Task Handle(RequestApprovedDomainEvent notification, CancellationToken cancellationToken)
        {
            RegistrationRequest registrationRequest = notification._registrationRequest;
            Restaurant restaurant = _builder.WithId(registrationRequest.Id).WithName(registrationRequest.Name)
            .WithContactInfo(registrationRequest.ContactInfo).WithAddress(registrationRequest.Address)
             .Build();
            await _restaurantWriteRepo.AddRestaurantAsync(restaurant);
        }
    }
}
