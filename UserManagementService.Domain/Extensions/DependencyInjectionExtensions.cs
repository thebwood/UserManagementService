﻿
using Microsoft.Extensions.DependencyInjection;

namespace UserManagementService.Domain.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {

            return services;
        }   
    }
}
