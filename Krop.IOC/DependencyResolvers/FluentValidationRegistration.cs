using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.IOC.DependencyResolvers
{
    public static class FluentValidationRegistration
    {
        public static IServiceCollection AddFluentValidationRegistration(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
