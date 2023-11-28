using EntityFrameworkModelV2.Context;
using SpecificationsTesting.UserControls;
using System.Drawing.Printing;

namespace SpecificationsTesting.Forms
{
    public partial class MainForm : Form
    {
        public MotorTypePlateStickerUserControl MotorTypePlateUserControl { get; set; }
        public AtexStickerUserControl AtexStickerUserControl { get; set; }
        public MotorTemplateUserControl MotorTemplateUserControl { get; set; }
        public OrderUserControl OrderUserControl { get; set; }
        public ControleUserControl ControleUserControl { get; set; }
        public TestDocumentGenerationUserControl TestDocumentGenerationUserControl { get; set; }
        public TabControl TabControl { get => tabControl; }

        public MainForm()
        {
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
                Environment.Exit(1);
            }
        }

        private void InitializePrinters()
        {
            var prtdoc = new PrintDocument();
            var defaultPrinter = prtdoc.PrinterSettings.PrinterName;
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cmbStickerPrinters.Items.Add(printer);
                cmbPrinters.Items.Add(printer);
                if (printer == defaultPrinter)
                {
                    cmbStickerPrinters.SelectedIndex = cmbStickerPrinters.Items.IndexOf(printer);
                }
            }
            cmbPrinters.SelectedIndex = 0;
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
            OrderUserControl = new OrderUserControl
            {
                AutoSize = true
            };
            OrderTabPage.Controls.Add(OrderUserControl);
        }

        private void InitializeControleUserControls()
        {
            ControleUserControl = new ControleUserControl
            {
                AutoSize = true
            };
            ControleTabPage.Controls.Add(ControleUserControl);
        }

        private void InitializeMotorTypePlateUserControl()
        {
            MotorTypePlateUserControl = new MotorTypePlateStickerUserControl
            {
                AutoSize = true
            };
            MotorTypePlateTabPage.Controls.Add(MotorTypePlateUserControl);
        }

        private void InitializeAtexStickerUserControl()
        {
            AtexStickerUserControl = new AtexStickerUserControl
            {
                AutoSize = true
            };
            AtexStickerTabPage.Controls.Add(AtexStickerUserControl);
        }

        private void InitializeMotorTemplateUserControl()
        {
            MotorTemplateUserControl = new MotorTemplateUserControl
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowOnly
            };
            TemplateMotorTabPage.Controls.Add(MotorTemplateUserControl);
        }

        private void InitializeTestDocumentGenerationUserControl()
        {
            TestDocumentGenerationUserControl = new TestDocumentGenerationUserControl
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowOnly
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