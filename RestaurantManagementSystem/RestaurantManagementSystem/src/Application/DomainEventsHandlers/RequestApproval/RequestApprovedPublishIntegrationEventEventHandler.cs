using RestaurantManagementSystem.Core.Common.Contracts.Services.MessagePublisher;
using RestaurantManagementSystem.Core.RestaurantRequest.Contracts.DomainEventHandlers;
using RestaurantManagementSystem.Core.RestaurantRequest.DomainEvents;

namespace RestaurantManagementSystem.Application.DomainEventsHandlers.RequestApproval
{
    public class RequestApprovedPublishIntegrationEventEventHandler : IRequestApprovedDomainEventHandler
    {

        private readonly IMessagePublisher _messagepublisher;

        public RequestApprovedPublishIntegrationEventEventHandler(IMessagePublisher messagePublisher)
        {
            _messagepublisher = messagePublisher;
            
        }
        public Task Handle(RequestApprovedDomainEvent notification, CancellationToken cancellationToken)
        {
            _messagepublisher.PublishRquestApproved(notification._registrationRequest.Email);
            return Task.CompletedTask;
        }
    }
}
