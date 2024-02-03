using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserManagementService.Infrastructure.Data;
using UserManagementService.Infrastructure.Repositories;
using UserManagementService.Infrastructure.Repositories.Interfaces;
using UserManagementService.Library.Models;

namespace UserManagementService.Infrastructure.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string? connectionString)
        {
            // Add authentication and authorization services
            services.AddAuthentication()
                .AddBearerToken(IdentityConstants.BearerScheme);

            // Add authorization services
            services.AddAuthorizationBuilder();

            // Add repositories
            services.AddTransient<IAuthorizationRepository, AuthorizationRepository>();

            // Add database context
            services.AddDbContext<UserManagementDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add identity services
            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<UserManagementDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
