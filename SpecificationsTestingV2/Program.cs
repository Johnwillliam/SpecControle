using EntityFrameworkModelV2.Context;
using SpecificationsTesting.Forms;

namespace SpecificationsTestingV2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            new SpecificationsDatabaseModel().Database.EnsureCreatedAsync();
            Application.Run(new MainForm());
        }
    }
}