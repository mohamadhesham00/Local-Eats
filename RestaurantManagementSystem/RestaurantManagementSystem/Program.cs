using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.src.Core.Contracts;
using RestaurantManagementSystem.src.Infrastructure.Db;
using RestaurantManagementSystem.src.Infrastructure.Services;
using RestaurantManagementSystem.src.Infrastructure.Services.Repositories;
using RestaurantManagementSystem.src.UseCases.Email_Confirmation;
using RestaurantManagementSystem.src.UseCases.GetRegistrationRequests;
using RestaurantManagementSystem.src.UseCases.Register;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IRegisterRequestCommandHandler, RegisterRequestCommandHandler>();
builder.Services.AddScoped<IRegistrationRequestRepo, RegistrationRequestRepo>();
builder.Services.AddScoped<IVerifyRequestCommandHandler, VerifyRequestCommandHandler>();
builder.Services.AddScoped<IGetRequestsHandler, GetRequestsHandler>();

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
