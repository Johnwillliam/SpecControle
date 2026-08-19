using Infrastructure.Context;
using Microsoft.Extensions.Logging;
using SpecControle.UserControls;
using System.ComponentModel;
using System.Drawing.Printing;

namespace SpecControle.Forms
{
    public partial class MainForm : Form
    {
        private readonly ILogger logger;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MotorTypePlateStickerUserControl MotorTypePlateUserControl { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AtexStickerUserControl AtexStickerUserControl { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MotorTemplateUserControl MotorTemplateUserControl { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OrderUserControl OrderUserControl { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ControleUserControl ControleUserControl { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestDocumentGenerationUserControl TestDocumentGenerationUserControl { get; set; }

        public TabControl TabControl { get => tabControl; }

        public MainForm(ILogger<MainForm> logger)
        {
            this.logger = logger;
            this.Width = 1400;
            this.Height = 700;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            if (DatabaseIsAvailable())
            {
                InitializeOrderUserControls();
                InitializeControleUserControls();
                InitializeMotorTypePlateUserControl();
                InitializeAtexStickerUserControl();
                InitializeMotorTemplateUserControl();
                InitializeTestDocumentGenerationUserControl();
                InitializePrinters();

                // Bij het aanmaken staat het venster nog niet op zijn uiteindelijke (gemaximaliseerde) grootte,
                // dus centreren we opnieuw zodra het venster echt getoond en/of geresized wordt. Niet-geselecteerde
                // tabbladen krijgen hun juiste afmetingen pas zodra ze zichtbaar worden, dus ook dan hercentreren.
                Shown += (s, e) => RecenterAllUserControls();
                Resize += (s, e) => RecenterAllUserControls();
                tabControl.SelectedIndexChanged += (s, e) => RecenterAllUserControls();
            }
            else
            {
                logger.LogError("Database is not available.");
                MessageBox.Show("Could not connect to the database. Please check your network connection and try again.", "Database unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LastUsedStickerPrinter = cmbStickerPrinters.SelectedItem?.ToString();
            Properties.Settings.Default.LastUsedPrinter = cmbPrinters.SelectedItem?.ToString();
            Properties.Settings.Default.Save();
        }

        private void InitializePrinters()
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cmbStickerPrinters.Items.Add(printer);
                cmbPrinters.Items.Add(printer);
            }
            cmbPrinters.SelectedIndex = 0;

            var lastUsedPrinter = Properties.Settings.Default.LastUsedPrinter;
            if (PrinterSettings.InstalledPrinters.Contains(lastUsedPrinter) && !string.IsNullOrEmpty(lastUsedPrinter))
            {
                cmbPrinters.SelectedItem = lastUsedPrinter;
            }

            var lastUsedStickerPrinter = Properties.Settings.Default.LastUsedStickerPrinter;
            if (PrinterSettings.InstalledPrinters.Contains(lastUsedStickerPrinter) && !string.IsNullOrEmpty(lastUsedStickerPrinter))
            {
                cmbStickerPrinters.SelectedItem = lastUsedStickerPrinter;
            }
            SetPrinter();
            SetStickerPrinter();
        }

        private static bool DatabaseIsAvailable()
        {
            try
            {
                if (!new SpecificationsDatabaseModel().Database.CanConnect())
                {
                    DatabaseOffline();
                    return false;
                }
            }
            catch (Exception)
            {
                DatabaseOffline();
                return false;
            }
            return true;
        }

        private static void DatabaseOffline()
        {
            MessageBox.Show("Database cannot be reached, please check if the SQL server is running.");
        }

        private void InitializeOrderUserControls()
        {
            OrderUserControl = new OrderUserControl(logger);
            AddCenteredToTabPage(OrderUserControl, OrderTabPage);
        }

        private void InitializeControleUserControls()
        {
            ControleUserControl = new ControleUserControl(logger);
            AddCenteredToTabPage(ControleUserControl, ControleTabPage);
        }

        private void InitializeMotorTypePlateUserControl()
        {
            MotorTypePlateUserControl = new MotorTypePlateStickerUserControl();
            AddCenteredToTabPage(MotorTypePlateUserControl, MotorTypePlateTabPage);
        }

        private void InitializeAtexStickerUserControl()
        {
            AtexStickerUserControl = new AtexStickerUserControl(logger);
            AddCenteredToTabPage(AtexStickerUserControl, AtexStickerTabPage);
        }

        private void InitializeMotorTemplateUserControl()
        {
            MotorTemplateUserControl = new MotorTemplateUserControl(logger);
            AddCenteredToTabPage(MotorTemplateUserControl, TemplateMotorTabPage);
        }

        private void InitializeTestDocumentGenerationUserControl()
        {
            TestDocumentGenerationUserControl = new TestDocumentGenerationUserControl(logger);
            AddCenteredToTabPage(TestDocumentGenerationUserControl, RunningTestTabPage);
        }

        /// <summary>
        /// Voegt de user control toe aan de tabpagina, zonder de vaste ontwerp-lay-out van de user control zelf te verstoren.
        /// Centrering gebeurt via RecenterAllUserControls (bij Shown/Resize van het hoofdvenster).
        /// </summary>
        private static void AddCenteredToTabPage(Control userControl, TabPage tabPage)
        {
            userControl.Anchor = AnchorStyles.None;
            tabPage.Controls.Add(userControl);
            CenterControlInParent(userControl);
        }

        private void RecenterAllUserControls()
        {
            CenterControlInParent(OrderUserControl);
            CenterControlInParent(ControleUserControl);
            CenterControlInParent(MotorTypePlateUserControl);
            CenterControlInParent(AtexStickerUserControl);
            CenterControlInParent(MotorTemplateUserControl);
            CenterControlInParent(TestDocumentGenerationUserControl);
        }

        private static void CenterControlInParent(Control control)
        {
            if (control?.Parent == null)
            {
                return;
            }

            control.Left = Math.Max(0, (control.Parent.ClientSize.Width - control.Width) / 2);
            control.Top = Math.Max(0, (control.Parent.ClientSize.Height - control.Height) / 2);
        }

        private void CmbStickerPrinters_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetStickerPrinter();
        }

        private void SetStickerPrinter()
        {
            if (cmbStickerPrinters.SelectedItem == null)
            {
                return;
            }

            if (MotorTypePlateUserControl != null)
            {
                MotorTypePlateUserControl.StickerPrinterName = cmbStickerPrinters.SelectedItem.ToString();
            }

            if (AtexStickerUserControl != null)
            {
                AtexStickerUserControl.StickerPrinterName = cmbStickerPrinters.SelectedItem.ToString();
            }
        }

        private void SetPrinter()
        {
            if (cmbPrinters.SelectedItem == null)
            {
                return;
            }

            if (AtexStickerUserControl != null)
            {
                AtexStickerUserControl.PrinterName = cmbPrinters.SelectedItem.ToString();
            }

            if (TestDocumentGenerationUserControl != null)
            {
                TestDocumentGenerationUserControl.PrinterName = cmbPrinters.SelectedItem.ToString();
            }
        }

        private void CmbPrinters_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetPrinter();
        }
    }
}