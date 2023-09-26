using Microsoft.AspNetCore.Mvc.Filters;
using RestaurantManagementSystem.src.Core.Entities;

namespace RestaurantManagementSystem.src.UseCases.Register
{
    public interface IRegisterRequestCommandHandler
    {
        void Execute(string name, string email
            , string address, string contactinfoemail, string contactinfophonenumber);

    }
}
