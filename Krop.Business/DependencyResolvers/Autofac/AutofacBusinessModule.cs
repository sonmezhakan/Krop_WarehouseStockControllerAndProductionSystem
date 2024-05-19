using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
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
using Krop.Common.Utilits.Interceptors;
using Krop.DataAccess.Repositories.Abstracts;
using Krop.DataAccess.Repositories.Abstracts.BaseRepository;
using Krop.DataAccess.Repositories.Concretes.EntityFramework;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace Krop.Business.DependencyResolvers.Autofac
{

    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager<AppUser>>().SingleInstance();
            builder.RegisterType<SignInManager<AppUser>>().SingleInstance();
            builder.RegisterType<RoleManager<AppUserRole>>().SingleInstance();

            builder.RegisterType<AppUserManager>().As<IAppUserService>().SingleInstance();
            builder.RegisterType<AppUserRoleManager>().As<IAppUserRoleService>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryRepository>().As<ICategoryRepository>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductRepository>().As<IProductRepository>().SingleInstance();

            builder.RegisterType<DepartmentManager>().As<IDepartmentService>().SingleInstance();
            builder.RegisterType<EfDepartmentRepository>().As<IDepartmentRepository>().SingleInstance();

            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<EfEmployeeRepository>().As<IEmployeeRepository>().SingleInstance();

            builder.RegisterType<BranchManager>().As<IBranchService>().SingleInstance();
            builder.RegisterType<EFBranchRepository>().As<IBranchRepository>().SingleInstance();

            builder.RegisterType<StockManager>().As<IStockService>().SingleInstance();
            builder.RegisterType<EfStockRepository>().As<IStockRepository>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandRepository>().As<IBrandRepository>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerRepository>().As<ICustomerRepository>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
