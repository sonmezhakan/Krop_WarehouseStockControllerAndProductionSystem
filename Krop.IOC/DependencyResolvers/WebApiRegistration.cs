using Krop.Common.Helpers.WebApiService;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.IOC.DependencyResolvers
{
    public static class WebApiRegistration
    {
        public static IServiceCollection AddWebApiRegistration(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IWebApiService, WebApiService>();

            return services;
        }
    }
}
