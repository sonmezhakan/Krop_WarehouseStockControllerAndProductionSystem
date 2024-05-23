using Krop.Business.Features.AppUserRoles.ExceptionHelpers;
using Krop.Business.Features.AppUsers.ExceptionHelpers;
using Krop.Business.Features.Branches.ExceptionHelper;
using Krop.Business.Features.Brands.ExceptionHelpers;
using Krop.Business.Features.Categories.ExceptionHelpers;
using Krop.Business.Features.Customers.ExceptionHelpers;
using Krop.Business.Features.Departments.ExceptionHelpers;
using Krop.Business.Features.Employees.ExceptionHelpers;
using Krop.Business.Features.Products.ExceptionHelpers;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.IOC.DependencyResolvers
{
    public static class ExceptionRegistration
    {
        public static IServiceCollection AddExceptionRegistration(this IServiceCollection services)
        {
            services.AddScoped<CategoryExceptionHelper>();
            services.AddScoped<ProductExceptionHelper>();
            services.AddScoped<DepartmentExceptionHelper>();
            services.AddScoped<BranchExceptionHelper>();
            services.AddScoped<AppUserExceptionHelper>();
            services.AddScoped<AppUserRoleExceptionHelper>();
            services.AddScoped<EmployeeExceptionHelper>();
            services.AddScoped<BrandExceptionHelper>();
            services.AddScoped<CustomerExceptionHelper>();

            return services;
        }
    }
}
