using Microsoft.AspNetCore.Mvc.Filters;
using RestaurantManagementSystem.src.Core.Entities;

namespace RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.Register
{
    public interface IRegisterRequestCommandHandler
    {
        void Execute(RegisterRequestCommand registerCommand);

    }
}
