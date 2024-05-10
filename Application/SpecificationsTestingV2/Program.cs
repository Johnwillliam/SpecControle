using EntityFrameworkModelV2.Context;
using Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QuestPDF.Infrastructure;
using SpecificationsTesting.Forms;

namespace SpecificationsTestingV2
{
    internal class Program
    {
        private static ILogger<Program> logger;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                new SpecificationsDatabaseModel().Database.EnsureCreated();
                QuestPDF.Settings.License = LicenseType.Community;
                var builder = CreateHostBuilder();
                var host = builder.Build();

                var loggerFactory = host.Services.GetRequiredService<ILoggerFactory>();
                logger = loggerFactory.CreateLogger<Program>();

                // For handling exceptions on the UI thread
                Application.ThreadException += (sender, args) =>
                {
                    ExceptionHandler.HandleException(logger, args.Exception);
                };

                // For handling exceptions on non-UI threads
                AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
                {
                    if (args.ExceptionObject is Exception ex)
                    {
                        ExceptionHandler.HandleException(logger, ex);
                    }
                };

                ApplicationConfiguration.Initialize();

                var mainForm = host.Services.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(logger, ex);
            }
        }

        /// <summary>
        /// Create a host builder to build the service provider
        /// </summary>
        /// <returns></returns>
        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureHostConfiguration(c =>
                {
                    c.SetBasePath(Directory.GetCurrentDirectory());
                    c.AddJsonFile("appsettings.json", optional: false);
                })
                .ConfigureLogging((c, l) =>
                {
                    l.AddConfiguration(c.Configuration);
                    l.AddSentry();
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<MainForm>();
                });
        }
    }
}