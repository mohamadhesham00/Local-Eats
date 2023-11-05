using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Migrations;
using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Infrastructure.Common.Services;
using System.Runtime.CompilerServices;

namespace RestaurantManagementSystem.src.Infrastructure.Common.Db
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration‏‏)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IEmailService, EmailService>();
            return services;
        }
    }
}
