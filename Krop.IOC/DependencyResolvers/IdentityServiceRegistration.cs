using Krop.DataAccess.Context;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.IOC.DependencyResolvers
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServiceRegistration(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppUserRole>()
                .AddEntityFrameworkStores<KropContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
