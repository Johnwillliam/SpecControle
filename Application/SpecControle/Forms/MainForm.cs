using Microsoft.Extensions.Logging;
using System.Drawing.Printing;
using System.ComponentModel;
using Infrastructure.Context;
using SpecControle.Forms;
using SpecControle.UserControls;

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
            }
            else
            {
                logger.LogError("Database is not available.");
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
            OrderUserControl = new OrderUserControl(logger)
            {
                AutoSize = true
            };
            OrderTabPage.Controls.Add(OrderUserControl);
        }

        private void InitializeControleUserControls()
        {
            ControleUserControl = new ControleUserControl(logger)
            {
                AutoSize = true
            };
            ControleTabPage.Controls.Add(ControleUserControl);
        }

        private void InitializeMotorTypePlateUserControl()
        {
            MotorTypePlateUserControl = new MotorTypePlateStickerUserControl()
            {
                AutoSize = true
            };
            MotorTypePlateTabPage.Controls.Add(MotorTypePlateUserControl);
        }

        private void InitializeAtexStickerUserControl()
        {
            AtexStickerUserControl = new AtexStickerUserControl(logger)
            {
                AutoSize = true
            };
            AtexStickerTabPage.Controls.Add(AtexStickerUserControl);
        }

        private void InitializeMotorTemplateUserControl()
        {
            MotorTemplateUserControl = new MotorTemplateUserControl(logger)
            {
                AutoSize = true,
                Width = 1430,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            TemplateMotorTabPage.Controls.Add(MotorTemplateUserControl);
        }

        private void InitializeTestDocumentGenerationUserControl()
        {
            TestDocumentGenerationUserControl = new TestDocumentGenerationUserControl(logger)
            {
                AutoSize = true
            };
            RunningTestTabPage.Controls.Add(TestDocumentGenerationUserControl);
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
