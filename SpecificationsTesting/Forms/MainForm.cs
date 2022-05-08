using EntityFrameworkModel;
using SpecificationsTesting.UserControls;
using System.Drawing.Printing;
using System.Windows.Forms;

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
            TestDatabase();
            InitializeOrderUserControls();
            InitializeControleUserControls();
            InitializeMotorTypePlateUserControl();
            InitializeAtexStickerUserControl();
            InitializeMotorTemplateUserControl();
            InitializeTestDocumentGenerationUserControl();
            InitializePrinters();
        }

        private void InitializePrinters()
        {
            PrintDocument prtdoc = new PrintDocument();
            var defaultPrinter = prtdoc.PrinterSettings.PrinterName;
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cmbPrinters.Items.Add(printer);
                if (printer == defaultPrinter)
                    cmbPrinters.SelectedIndex = cmbPrinters.Items.IndexOf(printer);
            }
            MotorTypePlateUserControl.PrinterName = cmbPrinters.SelectedItem.ToString();
        }

        private void TestDatabase()
        {
            using (SpecificationsDatabaseModel dbContext = new SpecificationsDatabaseModel())
            {
                if (!dbContext.Database.Exists())
                {
                    MessageBox.Show("Database cannot be reached, please check if the SQL server is running.");
                    System.Windows.Forms.Application.Exit();
                }
            }
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
                AutoSize = true, AutoSizeMode = AutoSizeMode.GrowOnly
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

        private void cmbPrinters_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if(MotorTypePlateUserControl != null)
                MotorTypePlateUserControl.PrinterName = cmbPrinters.SelectedItem.ToString();
        }
    }
}
