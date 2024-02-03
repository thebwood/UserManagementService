using UserManagementService.Api.Extensions;
using UserManagementService.Domain.Extensions;
using UserManagementService.Infrastructure.Extensions;
using UserManagementService.Library.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddDomain()
    .AddInfrastructure(builder.Configuration.GetConnectionString("Database"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapIdentityApi<ApplicationUser>();

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
