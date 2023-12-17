using MediatR;
using RestaurantManagementSystem.Core.RestaurantRequest.DomainEvents;

namespace RestaurantManagementSystem.Core.RestaurantRequest.Contracts.DomainEventHandlers
{
    public interface IRequestApprovedDomainEventHandler : INotificationHandler<RequestApprovedDomainEvent>
    {
        //void Handle(RequestApprovedDomainEvent notification, CancellationToken cancellationToken);

    }
}
