using MediatR;
using RestaurantManagementSystem.Core.RestaurantRequest.Contracts;
using RestaurantManagementSystem.Core.RestaurantRequest.Entities;
using RestaurantManagementSystem.Infrastructure.Common.Db;
using RestaurantManagementSystem.Infrastructure.Common.Services.MediatorExtension;

namespace RestaurantManagementSystem.Infrastructure.RestaurantRequest.Repositories
{
    public class RegistrationRequestWriteRepo : IRegistrationRequestWriteRepo
    {
        private readonly ApplicationDbContext _db;
        private readonly IMediator _mediator;

        public RegistrationRequestWriteRepo(ApplicationDbContext db,IMediator mediator)
        {
            _db = db;
            _mediator = mediator;
        }
        public async Task AddRequest(RegistrationRequest waitingListRestaurant)
        {
            await _db.RegistrationRequests.AddAsync(waitingListRestaurant);
            await _db.SaveChangesAsync();


        }
        public async Task Update(RegistrationRequest registrationRequest)
        {
            try
            {
                await _db.SaveChangesAsync();
                await _mediator.DispatchDomainEventAsync(_db);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        

    }
}
