using EntityFrameworkModel;
using SpecificationsTesting.UserControls;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SpecificationsTesting.Forms
{
    public partial class MainForm : Form
    {
        public MotorTypePlateUserControl MotorTypePlateUserControl { get; set; }
        public OrderUserControls OrderUserControls { get; set; }
        public MainForm()
        {
            InitializeComponent();
            TestDatabase();
            InitializeOrderUserControls();
            InitializeMotorTypePlateUserControl();
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
                    MessageBox.Show("Database cannot be reached, please check if the SQL server is running.");
            }
        }

        private void InitializeOrderUserControls()
        {
            OrderUserControls = new OrderUserControls
            {
                AutoSize = true
            };
            OrderTabPage.Controls.Add(OrderUserControls);
        }

        private void InitializeMotorTypePlateUserControl()
        {
            MotorTypePlateUserControl = new MotorTypePlateUserControl
            {
                AutoSize = true
            };
            MotorTypePlateTabPage.Controls.Add(MotorTypePlateUserControl);
        }

        private void cmbPrinters_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if(MotorTypePlateUserControl != null)
                MotorTypePlateUserControl.PrinterName = cmbPrinters.SelectedItem.ToString();
        }
    }
}
