using EntityFrameworkModelV2.Context;
using EntityFrameworkModelV2.Models;
using Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QuestPDF.Infrastructure;
using SpecificationsTesting.Forms;
using System.Reflection;

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
                //new SpecificationsDatabaseModel().Database.EnsureCreated();
                QuestPDF.Settings.License = LicenseType.Community;

                var assembly = Assembly.GetExecutingAssembly();
                var version = assembly
                    .GetCustomAttribute<AssemblyFileVersionAttribute>()?
                    .Version ?? "unknown";

                var builder = CreateHostBuilder(version);
                var host = builder.Build();

                var loggerFactory = host.Services.GetRequiredService<ILoggerFactory>();
                logger = loggerFactory.CreateLogger<Program>();

                ApplyMigrations(host.Services);

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
        private static IHostBuilder CreateHostBuilder(string version)
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
                    l.AddSentry(options =>
                    {
                        options.Release = version;
                    }
                    );
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<MainForm>();
                    services.AddDbContext<SpecificationsDatabaseModel>(options =>
                        options.UseSqlServer(context.Configuration.GetConnectionString("SpecificationsDatabase")));
                });
        }

        private static void ApplyMigrations(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SpecificationsDatabaseModel>();
            try
            {
                dbContext.Database.Migrate();
                SeedDatabase(dbContext);
            }
            catch (Exception ex)
            {
                var scopedLogger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                scopedLogger.LogError(ex, "An error occurred while applying migrations.");
            }
        }

        private static void SeedDatabase(SpecificationsDatabaseModel dbContext)
        {
            // Seed ATEXTypes
            if (!dbContext.ATEXTypes.Any())
            {
                dbContext.ATEXTypes.AddRange(
                [
                    new ATEXType { Description = "N.V.T." },
                    new ATEXType { Description = "II 2 G" },
                    new ATEXType { Description = "II 2 G" },
                    new ATEXType { Description = "II 2 GD" },
                    new ATEXType { Description = "II 3 D" },
                    new ATEXType { Description = "II 3 G" },
                    new ATEXType { Description = "N.A." },
                    new ATEXType { Description = "Ex II 3/3G Ex h IIB+H2 T4 Gc/Gc" },
                    new ATEXType { Description = "Ex II 2/2G Ex h IIB+H2 T4 Gb/Gb" },
                    new ATEXType { Description = "Ex II 2/2G Ex h IIB+H2 T3 Gb/Gb" },
                    new ATEXType { Description = "Ex II 2/2G Ex h IIB T3 Gb/Gb" }
                ]);
            }

            // Seed CatTypes
            if (!dbContext.CatTypes.Any())
            {
                dbContext.CatTypes.AddRange(
                [
                    new CatType { Description = "N.V.T." },
                    new CatType { Description = "II 2 G" },
                    new CatType { Description = "II 2 G" },
                    new CatType { Description = "II 2 GD" },
                    new CatType { Description = "II 3 D" },
                    new CatType { Description = "II 3 G" },
                    new CatType { Description = "N.A." },
                    new CatType { Description = "Ex II 3/3G Ex h IIB+H2 T4 Gc/Gc" },
                    new CatType { Description = "Ex II 2/2G Ex h IIB+H2 T4 Gb/Gb" },
                    new CatType { Description = "Ex II 2/2G Ex h IIB+H2 T3 Gb/Gb" },
                    new CatType { Description = "Ex II 2/2G Ex h IIB T3 Gb/Gb" }
                ]);
            }

            // Seed GroupTypes
            if (!dbContext.GroupTypes.Any())
            {
                dbContext.GroupTypes.AddRange(
                [
                    new GroupType { Description = "EEx" },
                    new GroupType { Description = "EEx e II" },
                    new GroupType { Description = "IIB" },
                    new GroupType { Description = "IIC" },
                    new GroupType { Description = "N.V.T." }
                ]);
            }

            // Seed SoundLevelTypes
            if (!dbContext.SoundLevelTypes.Any())
            {
                dbContext.SoundLevelTypes.AddRange(
                [
                    new SoundLevelType { Description = "No indication", UOM = "" },
                    new SoundLevelType { Description = "Sound power", UOM = "dB" },
                    new SoundLevelType { Description = "Sound level at 1.5 m", UOM = "dB(A)" },
                    new SoundLevelType { Description = "Sound power", UOM = "dB(A)" }
                ]);
            }

            // Seed TemperatureClasses
            if (!dbContext.TemperatureClasses.Any())
            {
                dbContext.TemperatureClasses.AddRange(
                [
                    new TemperatureClass { Description = "No indication" },
                    new TemperatureClass { Description = "N.V.T." },
                    new TemperatureClass { Description = "T3" },
                    new TemperatureClass { Description = "T4" },
                    new TemperatureClass { Description = "T5" },
                    new TemperatureClass { Description = "T6" },
                    new TemperatureClass { Description = "T 125°C" }
                ]);
            }

            // Seed Users
            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(new User { Name = "Admin" });
            }

            // Seed VentilatorTypes
            if (!dbContext.VentilatorTypes.Any())
            {
                dbContext.VentilatorTypes.AddRange(
                [
                    new VentilatorType { Description = "No Indication" },
                    new VentilatorType { Description = "Centrifugal fans direct driven" },
                    new VentilatorType { Description = "Axial fan direct driven" },
                    new VentilatorType { Description = "Thrust fan" },
                    new VentilatorType { Description = "Centrifugal fan V-belt driven" },
                    new VentilatorType { Description = "Axial fan V-belt driven" }
                ]);
            }

            dbContext.SaveChanges();
        }
    }
}