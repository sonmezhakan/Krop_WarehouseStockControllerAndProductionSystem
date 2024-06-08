using Krop.Business.Services.AppUserRoles;
using Krop.Business.Services.AppUsers;
using Krop.Business.Services.Branches;
using Krop.Business.Services.Brands;
using Krop.Business.Services.Categories;
using Krop.Business.Services.Customers;
using Krop.Business.Services.Deparments;
using Krop.Business.Services.Employees;
using Krop.Business.Services.Productions;
using Krop.Business.Services.ProductionStockExits;
using Krop.Business.Services.ProductReceipts;
using Krop.Business.Services.Products;
using Krop.Business.Services.StockInputs;
using Krop.Business.Services.Stocks;
using Krop.Business.Services.StockTransfers;
using Krop.Business.Services.Suppliers;
using Krop.Common.Helpers.WebApiService;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.Repositories.Concretes.EntityFramework;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.IOC.DependencyResolvers
{
    public static class RepositoryServiceRegisteration
    {
        public static IServiceCollection AddRepositoryServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IWebApiService, WebApiService>();

            services.AddScoped<UserManager<AppUser>>();
            services.AddScoped<SignInManager<AppUser>>();
            services.AddScoped<RoleManager<AppUser>>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductRepository, EfProductRepository>();

            services.AddScoped<IDepartmentService, DepartmentManager>();
            services.AddScoped<IDepartmentRepository, EfDepartmentRepository>();

            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IEmployeeRepository, EfEmployeeRepository>();

            services.AddScoped<IBranchService, BranchManager>();
            services.AddScoped<IBranchRepository, EFBranchRepository>();

            services.AddScoped<IStockService, StockManager>();
            services.AddScoped<IStockRepository, EfStockRepository>();

            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IBrandRepository, EfBrandRepository>();

            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<ICustomerRepository, EfCustomerRepository>();

            services.AddScoped<ISupplierService, SupplierManager>();
            services.AddScoped<ISupplierRepository, EfSupplierRepository>();

            services.AddScoped<IProductReceiptService, ProductReceiptManager>();
            services.AddScoped<IProductReceiptRepository, EfProductReceiptRepository>();

            services.AddScoped<IStockInputService, StockInputManager>();
            services.AddScoped<IStockInputRepository, EfStockInputRepository>();

            services.AddScoped<IStockTransferService, StockTransferManager>();
            services.AddScoped<IStockTransferRepository, EfStockTransferRepostiory>();

            services.AddScoped<IProductionService, ProductionManager>();
            services.AddScoped<IProductionRepository, EfProductionRepository>();

            services.AddScoped<IProductionStockExitService, ProductionStockExitManager>();
            services.AddScoped<IProductionStockExitRepository, EfProductionStockExitRepository>();

            return services;
        }
    }
}
