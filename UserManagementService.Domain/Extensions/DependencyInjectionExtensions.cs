
using Microsoft.Extensions.DependencyInjection;
using UserManagementService.Domain.Services;
using UserManagementService.Domain.Services.Interfaces;

namespace UserManagementService.Domain.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddTransient<IAuthorizationService, AuthorizationService>();

            return services;
        }
    }
}
