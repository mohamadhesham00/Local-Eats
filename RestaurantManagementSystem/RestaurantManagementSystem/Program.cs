using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.Register;
using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Infrastructure.Common.Services;
using RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.EmailConfirmation;
using RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.GetRegistrationRequests;
using RestaurantManagementSystem.src.Application.UseCases.RestaurantRequest.RequestApproval;
using RestaurantManagementSystem.src.Core.RestaurantManagement.Contracts;
using RestaurantManagementSystem.src.Infrastructure.RestaurantManagement.Repositories;
using RestaurantManagementSystem.src.Infrastructure.Common.Db;
using RestaurantManagementSystem.src.Infrastructure.RestaurantRequest.Repositories;
using System.Reflection;
using RestaurantManagementSystem.src.Core.RestaurantManagement.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IRegisterRequestCommandHandler, RegisterRequestCommandHandler>();
builder.Services.AddScoped<IRegistrationRequestRepo, RegistrationRequestRepo>();
builder.Services.AddScoped<IVerifyRequestCommandHandler, VerifyRequestCommandHandler>();
builder.Services.AddScoped<IGetRequestsHandler, GetRequestsHandler>();
builder.Services.AddScoped<IRequestApprovalCommandHandler, RequestApprovalCommandHandler>();
builder.Services.AddScoped<IRestaurantRepo, RestaurantRepo>();
builder.Services.AddScoped<RestaurantBuilder>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
