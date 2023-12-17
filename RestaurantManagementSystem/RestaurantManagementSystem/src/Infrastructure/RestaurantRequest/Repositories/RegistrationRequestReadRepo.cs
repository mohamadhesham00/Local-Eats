using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Core.RestaurantRequest.Contracts;
using RestaurantManagementSystem.Core.RestaurantRequest.Entities;
using RestaurantManagementSystem.Core.RestaurantRequest.Exceptions;
using RestaurantManagementSystem.Infrastructure.Common.Db;

namespace RestaurantManagementSystem.Infrastructure.RestaurantRequest.Repositories
{
    public class RegistrationRequestReadRepo : IRegistrationRequestReadRepo
    {
        private readonly ApplicationDbContext _db;

        public RegistrationRequestReadRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<RegistrationRequest> FindByIdAsync(string ID)
        {
            Guid id = new Guid(ID);
            RegistrationRequest? registrationRequest = await _db.RegistrationRequests.FirstOrDefaultAsync(u => u.Id == id);
            if (registrationRequest == null)
            {

                throw new RegistrationRequestNotFoundException();
            }
            return registrationRequest;

        }
        public Task<List<RegistrationRequest>> GetRegistrationRequestsAsync()
        {
            var list = _db.RegistrationRequests.Where(r => r.Status == RegistrationRequestStatus.WaitingForAdminResponse).ToListAsync();
            return list;
        }


    }
}
