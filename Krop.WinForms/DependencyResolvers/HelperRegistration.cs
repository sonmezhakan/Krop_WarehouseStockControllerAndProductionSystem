using Krop.WinForms.HelpersClass.BrandHelpers;
using Krop.WinForms.HelpersClass.CategoryHelpers;
using Krop.WinForms.HelpersClass.ProductHelpers;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.WinForms.DependencyResolvers
{
    internal static class HelperRegistration
    {
        internal static IServiceCollection AddHelperRegistration(this IServiceCollection services)
        {
            services.AddScoped<IBrandHelper, BrandHelper>();
            services.AddScoped<ICategoryHelper, CategoryHelper>();
            services.AddScoped<IProductHelper, ProductHelper>();

            return services;
        }
    }
}
