using Krop.IOC.DependencyResolvers;
using Krop.WinForms.DependencyResolvers;
using Krop.WinForms.Forms.Logins;
using Microsoft.Extensions.DependencyInjection;


namespace Krop.WinForms
{
    internal static class Program
	{
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var mainForm = serviceProvider.GetRequiredService<frmLogin>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // HttpClient ve WebApiService'i kaydet
            services.AddHttpClient();

            services.AddAutoMapperRegistration();//AutoMapper
            services.AddWebApiRegistration();//WebApi Service

            // Forms
            services.AddFormRegistration();

            
        }

    }
}