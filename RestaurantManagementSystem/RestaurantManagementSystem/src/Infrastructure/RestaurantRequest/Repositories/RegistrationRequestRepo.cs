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

                return registrationRequest;
            }
            else
            {
                throw new RegistrationRequestNotFoundException();

            }


        }

        public async void Update(RegistrationRequest registrationRequest)
        {
            _db.RegistrationRequests.Update(registrationRequest);
            await _mediator.DispatchDomainEventAsync(_db);
            await _db.SaveChangesAsync();
        }
        public Task<List<RegistrationRequest>> GetRegistrationRequestsAsync()
        {
            var list = _db.RegistrationRequests.Where(r => r.Status == RegistrationRequestStatus.WaitingForAdminResponse).ToListAsync();
            return list;
        }

    }
}
