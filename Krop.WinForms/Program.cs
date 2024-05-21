using Krop.Common.Helpers.WebApiService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Krop.WinForms
{
    internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var mainForm = serviceProvider.GetRequiredService<Panel>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // HttpClient ve WebApiService'i kaydet
            services.AddHttpClient();
            services.AddTransient<IWebApiService, WebApiService>();

            // MainForm'u kaydet
            services.AddTransient<Panel>();
        }

    }
}