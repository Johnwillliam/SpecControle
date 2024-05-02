using EntityFrameworkModelV2.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuestPDF.Infrastructure;
using SpecificationsTesting.Forms;
using System.Diagnostics;

namespace SpecificationsTestingV2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();
                new SpecificationsDatabaseModel().Database.EnsureCreated();
                QuestPDF.Settings.License = LicenseType.Community;
                ApplicationConfiguration.Initialize();
                var host = CreateHostBuilder().Build();
                ServiceProvider = host.Services;

                Application.Run(ServiceProvider.GetRequiredService<MainForm>());
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception: {0}", ex);
            }
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// Create a host builder to build the service provider
        /// </summary>
        /// <returns></returns>
        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<MainForm>();
                });
        }
    }
}