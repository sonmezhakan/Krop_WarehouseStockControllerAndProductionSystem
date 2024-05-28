using Krop.WinForms.HelpersClass.AppUserHelpers;
using Krop.WinForms.HelpersClass.AppUserRoleHelpers;
using Krop.WinForms.HelpersClass.BranchHelpers;
using Krop.WinForms.HelpersClass.BrandHelpers;
using Krop.WinForms.HelpersClass.CategoryHelpers;
using Krop.WinForms.HelpersClass.CustomerHelpers;
using Krop.WinForms.HelpersClass.Departments;
using Krop.WinForms.HelpersClass.Employees;
using Krop.WinForms.HelpersClass.ProductHelpers;
using Krop.WinForms.HelpersClass.SupplierHelpers;
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
            services.AddScoped<ISupplierHelper,SupplierHelper>();
            services.AddScoped<ICustomerHelper, CustomerHelper>();
            services.AddScoped<IBranchHelper, BranchHelper>();
            services.AddScoped<IAppUserRoleHelper, AppUserRoleHelper>();
            services.AddScoped<IAppUserHelper, AppUserHelper>();
            services.AddScoped<IDepartmentHelper, DepartmentHelper>();
            services.AddScoped<IEmployeeHelper, EmployeeHelper>();
            return services;
        }
    }
}
