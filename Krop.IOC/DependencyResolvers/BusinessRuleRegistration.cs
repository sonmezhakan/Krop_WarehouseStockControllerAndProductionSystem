using Krop.Business.Features.AppUserRoles.Rules;
using Krop.Business.Features.AppUsers.Rules;
using Krop.Business.Features.Branches.Rules;
using Krop.Business.Features.Brands.Rules;
using Krop.Business.Features.Categories.Rules;
using Krop.Business.Features.Customers.Rules;
using Krop.Business.Features.Departments.Rules;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.Productions.Rules;
using Krop.Business.Features.ProductReceipts.Rules;
using Krop.Business.Features.Products.Rules;
using Krop.Business.Features.StockInputs.Rules;
using Krop.Business.Features.Stocks.Rules;
using Krop.Business.Features.StockTransfers.Rules;
using Krop.Business.Features.Suppliers.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.IOC.DependencyResolvers
{
    public static class BusinessRuleRegistration
    {
        public static IServiceCollection AddBusinessRuleRegistration(this IServiceCollection services)
        {
            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<ProductBusinessRules>();
            services.AddScoped<DepartmentBusinessRules>();
            services.AddScoped<AppUserBusinessRules>();
            services.AddScoped<AppUserRoleBusinessRules>();
            services.AddScoped<EmployeeBusinessRules>();
            services.AddScoped<BranchBusinessRules>();
            services.AddScoped<BrandBusinessRules>();
            services.AddScoped<CustomerBusinessRules>();
            services.AddScoped<SupplierBusinessRules>();
            services.AddScoped<ProductReceiptBusinessRules>();
            services.AddScoped<StockBusinessRules>();
            services.AddScoped<StockInputBusinessRules>();
            services.AddScoped<StockTransferBusinessRules>();
            services.AddScoped<ProductionBusinessRules>();
            return services;
        }
    }
}
