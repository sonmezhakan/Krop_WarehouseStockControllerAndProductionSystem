using FluentValidation;
using Krop.Business.Features.AppUserRoles.ExceptionHelpers;
using Krop.Business.Features.AppUserRoles.Rules;
using Krop.Business.Features.AppUsers.ExceptionHelpers;
using Krop.Business.Features.AppUsers.Rules;
using Krop.Business.Features.Branches.ExceptionHelper;
using Krop.Business.Features.Branches.Rules;
using Krop.Business.Features.Brands.ExceptionHelpers;
using Krop.Business.Features.Brands.Rules;
using Krop.Business.Features.Categories.Dtos;
using Krop.Business.Features.Categories.ExceptionHelpers;
using Krop.Business.Features.Categories.Rules;
using Krop.Business.Features.Categories.Validations;
using Krop.Business.Features.Customers.ExceptionHelpers;
using Krop.Business.Features.Customers.Rules;
using Krop.Business.Features.Departments.ExceptionHelpers;
using Krop.Business.Features.Departments.Rules;
using Krop.Business.Features.Employees.ExceptionHelpers;
using Krop.Business.Features.Employees.Rules;
using Krop.Business.Features.Products.ExceptionHelpers;
using Krop.Business.Features.Products.Rules;
using Krop.Business.Services.AppUserRoles;
using Krop.Business.Services.AppUsers;
using Krop.Business.Services.Branches;
using Krop.Business.Services.Brands;
using Krop.Business.Services.Categories;
using Krop.Business.Services.Customers;
using Krop.Business.Services.Deparments;
using Krop.Business.Services.Employees;
using Krop.Business.Services.Products;
using Krop.Business.Services.Stocks;
using Krop.DataAccess.Context;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.DataAccess.Repositories.Concretes.EntityFramework;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.IOC.DependencyResolvers
{
    public static class SerivcesRegister
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services)
        {
            
            ServiceProvider provider = services.BuildServiceProvider();

            var configuration = provider.GetService<IConfiguration>();

            services.AddDbContext<KropContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MSSQLConnection"));
            });

            //AutoMapper Profile Service
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //FluentValidation Service
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());



            //ExceptionHelpers
            services.AddTransient<CategoryExceptionHelper>();
            services.AddTransient<ProductExceptionHelper>();
            services.AddTransient<DepartmentExceptionHelper>();
            services.AddTransient<BranchExceptionHelper>();
            services.AddTransient<AppUserExceptionHelper>();
            services.AddTransient<AppUserRoleExceptionHelper>();
            services.AddTransient<EmployeeExceptionHelper>();
            services.AddTransient<BrandExceptionHelper>();
            services.AddTransient<CustomerExceptionHelper>();


            //BusinessRules
            services.AddTransient<CategoryBusinessRules>();
            services.AddTransient<ProductBusinessRules>();
            services.AddTransient<DepartmentBusinessRules>();
            services.AddTransient<AppUserBusinessRules>();
            services.AddTransient<AppUserRoleBusinessRules>();
            services.AddTransient<EmployeeBusinessRules>();
            services.AddTransient<BranchBusinessRules>();
            services.AddTransient<BrandBusinessRules>();
            services.AddTransient<CustomerBusinessRules>();

            //Identity Service
            services.AddIdentity<AppUser, AppUserRole>().AddEntityFrameworkStores<KropContext>().AddDefaultTokenProviders();
            /*services.AddScoped<UserManager<AppUser>>();
            services.AddScoped<SignInManager<AppUser>>();
            services.AddScoped<RoleManager<AppUserRole>>();*/

            //Repositories
            /*services.AddScoped(typeof(IBaseRepository<>), typeof(EfBaseRepository<>));
            services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(EfBaseRepository<>));

            services.AddScoped<IBranchRepository, EFBranchRepository>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<IDepartmentRepository, EfDepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EfEmployeeRepository>();
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<IStockRepository, EfStockRepository>();
            services.AddScoped<IBrandRepository, EfBrandRepository>();
            services.AddScoped<ICustomerRepository, EfCustomerRepository>();*/

            //Services
            /*services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IDepartmentService, DepartmentManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IBranchService, BranchManager>();
            services.AddScoped<IStockService, StockManager>();
            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<ICustomerService, CustomerManager>();*/

            return services;
        }
    }
}
