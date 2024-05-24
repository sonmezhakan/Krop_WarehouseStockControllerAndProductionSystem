using Krop.WinForms.Brands;
using Krop.WinForms.Categories;
using Krop.WinForms.Products;
using Krop.WinForms.Suppliers;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.WinForms.DependencyResolvers
{
    internal static class FormRegistration
    {
        internal static IServiceCollection AddFormRegistration(this IServiceCollection services)
        {
            // MainForm'u kaydet
            services.AddTransient<Panel>();

            services.AddTransient<frmBrandAdd>();
            services.AddTransient<frmBrandUpdate>();
            services.AddTransient<frmBrandDelete>();
            services.AddTransient<frmBrandCart>();
            services.AddTransient<frmBrandList>();

            services.AddTransient<frmCategoryAdd>();
            services.AddTransient<frmCategoryAddRange>();
            services.AddTransient<frmCategoryUpdate>();
            services.AddTransient<frmCategoryDelete>();
            services.AddTransient<frmCategoryList>();
            services.AddTransient<frmCategoryCart>();

            services.AddTransient<frmProductAdd>();
            services.AddTransient<frmProductUpdate>();
            services.AddTransient<frmProductDelete>();
            services.AddTransient<frmProductList>();
            services.AddTransient<frmProductCart>();
            services.AddTransient<frmProductReceipt>();

            services.AddTransient<frmSupplierAdd>();
            services.AddTransient<frmSupplierUpdate>();
            services.AddTransient<frmSupplierDelete>();
            services.AddTransient<frmSupplierList>();
            services.AddTransient<frmSupplierCart>();

            return services;
        }
    }
}
