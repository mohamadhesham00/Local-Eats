using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.Db;
using RestaurantManagementSystem.src.UseCases.Email_Confirmation;

namespace RestaurantManagementSystem.src.Infrastructure.Services.Repositories
{
    public class RestaurantRepo : IRestaurantRepo
    {
        private readonly ApplicationDbContext _db;

        public RestaurantRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<RegistrationRequest> FindByIdAsync(Guid id)
        {
            RegistrationRequest obj = await _db.RegistrationRequests.FirstOrDefaultAsync(u => u.Id == id);
            return obj;


        }

        public void Update(RegistrationRequest registrationRequest)
        {
            _db.RegistrationRequests.Update(registrationRequest);
            _db.SaveChanges();
        }
    }
}
