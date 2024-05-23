using Microsoft.Extensions.Configuration;
using Krop.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.IOC.DependencyResolvers
{
    public static class DbContextRegistration
    {
        public static IServiceCollection AddDbContextRegistration(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            var configuration = provider.GetService<IConfiguration>();

            services.AddDbContext<KropContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MSSQLConnection"));
            });

            return services;
        }
    }
}
