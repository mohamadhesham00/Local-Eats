using MediatR;
using RestaurantManagementSystem.Core.RestaurantRequest.Entities;
using RestaurantManagementSystem.Infrastructure.Common.Db;

namespace RestaurantManagementSystem.Infrastructure.Common.Services.MediatorExtension
{
    static class MediatorExtension
    {
        public static async Task DispatchDomainEventAsync(this IMediator mediator,ApplicationDbContext db)
        {
            var DomainEntities = db.ChangeTracker.Entries<RegistrationRequest>()
             .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());
            var DomainEvents = DomainEntities.SelectMany(x => x.Entity.DomainEvents).ToList();
            DomainEntities.ToList().ForEach(entity => entity.Entity.ClearDomainEvents());
            foreach (var DomainEvent in DomainEvents)
            {
                await mediator.Publish(DomainEvent); 
            }
        }
    }
}
