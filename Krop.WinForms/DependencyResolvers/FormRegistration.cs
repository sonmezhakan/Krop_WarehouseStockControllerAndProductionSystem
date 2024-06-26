﻿using Krop.WinForms.AppUserRoles;
using Krop.WinForms.Brands;
using Krop.WinForms.Categories;
using Krop.WinForms.Customers;
using Krop.WinForms.Forms.AppUsers;
using Krop.WinForms.Forms.Branches;
using Krop.WinForms.Forms.Departments;
using Krop.WinForms.Forms.Employees;
using Krop.WinForms.Forms.Logins;
using Krop.WinForms.Forms.Productions;
using Krop.WinForms.Forms.ProductNotifications;
using Krop.WinForms.Forms.Settings.AppUserSettings;
using Krop.WinForms.Forms.StockInputs;
using Krop.WinForms.Forms.Stocks;
using Krop.WinForms.Forms.StockTransfers;
using Krop.WinForms.Products;
using Krop.WinForms.Suppliers;
using Microsoft.Extensions.DependencyInjection;

namespace Krop.WinForms.DependencyResolvers
{
    internal static class FormRegistration
    {
        internal static IServiceCollection AddFormRegistration(this IServiceCollection services)
        {
            services.AddTransient<frmLogin>();
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

            services.AddTransient<frmCustomerAdd>();
            services.AddTransient<frmCustomerUpdate>();
            services.AddTransient<frmCustomerDelete>();
            services.AddTransient<frmCustomerList>();
            services.AddTransient<frmCustomerCart>();

            services.AddTransient<frmBranchAdd>();
            services.AddTransient<frmBranchUpdate>();
            services.AddTransient<frmBranchDelete>();
            services.AddTransient<frmBranchList>();
            services.AddTransient<frmBranchCart>();

            services.AddTransient<frmAppUserRoleAdd>();
            services.AddTransient<frmAppUserRoleUpdate>();
            services.AddTransient<frmAppUserRoleDelete>();
            services.AddTransient<frmAppUserRoleList>();

            services.AddTransient<frmAppUserAdd>();
            services.AddTransient<frmAppUserUpdate>();
            services.AddTransient<frmAppUserList>();
            services.AddTransient<frmAppUserCart>();
            services.AddTransient<frmUserUpdateRole>();

            services.AddTransient<frmDepartmentAdd>();
            services.AddTransient<frmDepartmentUpdate>();
            services.AddTransient<frmDepartmentDelete>();
            services.AddTransient<frmDepartmentList>();
            services.AddTransient<frmDepartmentCart>();

            services.AddTransient<frmEmployeeAdd>();
            services.AddTransient<frmEmployeeUpdate>();
            services.AddTransient<frmEmployeeCart>();
            services.AddTransient<frmEmployeeList>();

            services.AddTransient<frmStockInput>();
            services.AddTransient<frmStockTransfer>();

            services.AddTransient<frmProduction>();

            services.AddTransient<frmAppUserSetting>();

            services.AddTransient<frmStockList>();
            services.AddTransient<frmBelowCriticalAmountStockList>();

            services.AddTransient<frmProductNotficationSentList>();
            services.AddTransient<frmProductNotificationInList>();
            services.AddTransient<frmProductNotificationAdd>();
            services.AddTransient<frmProductNotificationUpdate>();
            return services;
        }
    }
}
