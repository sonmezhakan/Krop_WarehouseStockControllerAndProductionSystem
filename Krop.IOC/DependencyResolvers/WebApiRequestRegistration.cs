using Krop.Common.Helpers.WebApiRequests.AppUserRoles;
using Krop.Common.Helpers.WebApiRequests.AppUsers;
using Krop.Common.Helpers.WebApiRequests.Branches;
using Krop.Common.Helpers.WebApiRequests.Brands;
using Krop.Common.Helpers.WebApiRequests.Categories;
using Krop.Common.Helpers.WebApiRequests.Customers;
using Krop.Common.Helpers.WebApiRequests.Departments;
using Krop.Common.Helpers.WebApiRequests.Employees;
using Krop.Common.Helpers.WebApiRequests.Productions;
using Krop.Common.Helpers.WebApiRequests.ProductReceipts;
using Krop.Common.Helpers.WebApiRequests.Products;
using Krop.Common.Helpers.WebApiRequests.StockInputs;
using Krop.Common.Helpers.WebApiRequests.StockTransfers;
using Krop.Common.Helpers.WebApiRequests.Suppliers;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.IOC.DependencyResolvers
{
    public static class WebApiRequestRegistration
    {
        public static IServiceCollection AddWebApiRequestRegistration(this IServiceCollection services)
        {
            services.AddScoped<IAppUserRequest, AppUserRequest>();
            services.AddScoped<IAppUserRoleRequest, AppUserRoleRequest>();
            services.AddScoped<IBranchRequest, BranchRequest>();
            services.AddScoped<IBrandRequest, BrandRequest>();
            services.AddScoped<ICategoryRequest, CategoryRequest>();
            services.AddScoped<ICustomerRequest, CustomerRequest>();
            services.AddScoped<IDepartmentRequest, DepartmentRequest>();
            services.AddScoped<IEmployeeRequest, EmployeeRequest>();
            services.AddScoped<IProductionRequest, ProductionRequest>();
            services.AddScoped<IProductReceiptRequest, ProductReceiptRequest>();
            services.AddScoped<IProductRequest, ProductRequest>();
            services.AddScoped<IStockInputRequest, StockInputRequest>();
            services.AddScoped<IStockTransferRequest, StockTransferRequest>();
            services.AddScoped<ISupplierRequest, SupplierRequest>();

            return services;
        }
    }
}
