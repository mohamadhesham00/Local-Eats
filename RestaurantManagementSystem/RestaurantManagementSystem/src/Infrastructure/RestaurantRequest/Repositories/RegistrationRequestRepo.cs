using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.EmailConfirmation;
using shortid.Configuration;
using shortid;
using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Infrastructure.Common.Db;
using RestaurantManagementSystem.src.Core.Entities;
using MediatR;
using RestaurantManagementSystem.src.Infrastructure.Common.Services.MediatorExtension;
using RestaurantManagementSystem.src.Core.RestaurantRequest.Exceptions;

namespace RestaurantManagementSystem.src.Infrastructure.RestaurantRequest.Repositories
{
    public class RegistrationRequestRepo : IRegistrationRequestRepo
    {
        private readonly ApplicationDbContext _db;
        private readonly IMediator _mediator;

        public RegistrationRequestRepo(ApplicationDbContext db,IMediator mediator)
        {
            _db = db;
            _mediator = mediator;
        }
        public async Task AddRequest(RegistrationRequest waitingListRestaurant)
        {
            await _db.RegistrationRequests.AddAsync(waitingListRestaurant);
            await _db.SaveChangesAsync();


        }
        public async Task<RegistrationRequest> FindByIdAsync(string ID)
        {
            Guid id = new Guid(ID);
            RegistrationRequest? registrationRequest = await _db.RegistrationRequests.FirstOrDefaultAsync(u => u.Id == id);
            if(registrationRequest != null)
            {

                throw new RegistrationRequestNotFoundException();
            }
            return registrationRequest;

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
        public Task<List<RegistrationRequest>> GetRegistrationRequestsAsync()
        {
            var list = _db.RegistrationRequests.Where(r => r.Status == RegistrationRequestStatus.WaitingForAdminResponse).ToListAsync();
            return list;
        }

    }
}
