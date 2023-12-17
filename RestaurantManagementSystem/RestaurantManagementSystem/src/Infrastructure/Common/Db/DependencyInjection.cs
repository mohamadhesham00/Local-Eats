using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Infrastructure.Common.Services.SendEmail;
using RestaurantManagementSystem.Core.Common.Contracts.Services.EmailService;

namespace RestaurantManagementSystem.Infrastructure.Common.Db
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
