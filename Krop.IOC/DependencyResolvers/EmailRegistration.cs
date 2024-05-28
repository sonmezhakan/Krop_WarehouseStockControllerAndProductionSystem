using Krop.Common.Helpers.EmailService;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.IOC.DependencyResolvers
{
    public static class EmailRegistration
    {
        public static IServiceCollection AddEmailRegistration(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
