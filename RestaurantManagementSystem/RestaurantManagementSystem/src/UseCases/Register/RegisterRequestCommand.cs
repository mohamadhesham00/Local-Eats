using RestaurantManagementSystem.src.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.src.UseCases.Register
{
    public class RegisterRequestCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string contactinfoemail { get; set; }
        public string contactinfophonenumber { get; set; }
    }
}
