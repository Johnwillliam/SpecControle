using EntityFrameworkModelV2.Context;
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
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                new SpecificationsDatabaseModel().Database.EnsureCreated();
                QuestPDF.Settings.License = LicenseType.Community;
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception: {0}", ex);
            }
        }
    }
}