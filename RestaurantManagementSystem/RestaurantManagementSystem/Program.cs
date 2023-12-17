using RestaurantManagementSystem.Application;
using RestaurantManagementSystem.Application.UseCases.RestaurantRequest.EmailConfirmation;
using RestaurantManagementSystem.Application.UseCases.RestaurantRequest.GetRegistrationRequests;
using RestaurantManagementSystem.Application.UseCases.RestaurantRequest.Register;
using RestaurantManagementSystem.Application.UseCases.RestaurantRequest.RequestApproval;
using RestaurantManagementSystem.Core.Common.Contracts.Services.MessagePublisher;
using RestaurantManagementSystem.Core.RestaurantManagement.Builder;
using RestaurantManagementSystem.Core.RestaurantManagement.Contracts;
using RestaurantManagementSystem.Core.RestaurantRequest.Contracts;
using RestaurantManagementSystem.Infrastructure.Common.Db;
using RestaurantManagementSystem.Infrastructure.Common.Services.MessageQueue;
using RestaurantManagementSystem.Infrastructure.RestaurantManagement.Repositories;
using RestaurantManagementSystem.Infrastructure.RestaurantRequest.Repositories;
using RestaurantManagementSystem.web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApi();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddScoped<IRegisterRequestCommandHandler, RegisterRequestCommandHandler>();
builder.Services.AddScoped<IRegistrationRequestReadRepo, RegistrationRequestReadRepo>();
builder.Services.AddScoped<IRegistrationRequestWriteRepo, RegistrationRequestWriteRepo>();
builder.Services.AddScoped<IVerifyRequestCommandHandler, VerifyRequestCommandHandler>();
builder.Services.AddScoped<IMessagePublisher, MessagePublisher>();
builder.Services.AddScoped<IGetRequestsHandler, GetRequestsHandler>();
builder.Services.AddScoped<IRequestApprovalCommandHandler, RequestApprovalCommandHandler>();
builder.Services.AddScoped<IRestaurantWriteRepo, RestaurantWriteRepo>();
builder.Services.AddScoped<RestaurantBuilder>();
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
