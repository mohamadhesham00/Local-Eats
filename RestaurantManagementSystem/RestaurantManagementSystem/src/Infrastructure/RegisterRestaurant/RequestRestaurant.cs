using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Core.Entities;
using RestaurantManagementSystem.src.Infrastructure.Db;
using RestaurantManagementSystem.src.Infrastructure.Services;
using System.ComponentModel;

namespace RestaurantManagementSystem.src.Infrastructure.RegisterRestaurant
{
    public class RequestRestaurant : IRequestRestaurant
    {
        private readonly ApplicationDbContext _db;

        public RequestRestaurant(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(RegistrationRequest waitingListRestaurant)
        {
            _db.RegistrationRequests.Add(waitingListRestaurant);
            _db.SaveChanges();


        }
    }
}
