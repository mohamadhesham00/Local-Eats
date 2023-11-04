using MediatR;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.Common.Db;

namespace RestaurantManagementSystem.src.Infrastructure.Common.Services.MediatorExtension
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
