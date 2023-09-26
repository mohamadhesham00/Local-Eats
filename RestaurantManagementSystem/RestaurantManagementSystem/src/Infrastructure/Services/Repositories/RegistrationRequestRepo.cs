using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.Db;
using RestaurantManagementSystem.src.UseCases.Email_Confirmation;
using shortid.Configuration;
using shortid;

namespace RestaurantManagementSystem.src.Infrastructure.Services.Repositories
{
    public class RegistrationRequestRepo : IRegistrationRequestRepo
    {
        private readonly ApplicationDbContext _db;

        public RegistrationRequestRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public void AddRequest(RegistrationRequest waitingListRestaurant)
        {
            _db.RegistrationRequests.Add(waitingListRestaurant);
            _db.SaveChanges();


        }
        public async Task<RegistrationRequest> FindByIdAsync(string ID)
        {
            Guid id = new Guid(ID);
            RegistrationRequest obj = await _db.RegistrationRequests.FirstOrDefaultAsync(u => u.Id == id);
            return obj;


        }

        public void Update(RegistrationRequest registrationRequest)
        {
            _db.RegistrationRequests.Update(registrationRequest);
            _db.SaveChanges();
        }

        public string GenerateVerificationCode()
        {
            //for specifing what random code contains
            var options = new GenerationOptions(useNumbers: true, useSpecialCharacters: false, length: 8);
            string verificationcode = ShortId.Generate(options);
            return verificationcode;
        }
    }
}
