using Microsoft.Extensions.DependencyInjection;

namespace Krop.IOC.DependencyResolvers
{
    public static class AutoMapperRegistration
    {
        public static IServiceCollection AddAutoMapperRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
