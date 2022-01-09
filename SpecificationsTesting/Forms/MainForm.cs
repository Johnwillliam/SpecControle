using EntityFrameworkModel;
using SpecificationsTesting.UserControls;
using System.Windows.Forms;

namespace SpecificationsTesting.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            TestDatabase();
            InitializeOrderUserControls();
            InitializeMotorTypePlateUserControl();
        }

        private void TestDatabase()
        {
            using (SpecificationsDatabaseModel dbContext = new SpecificationsDatabaseModel())
            {
                if (!dbContext.Database.Exists())
                {
                    MessageBox.Show("Database cannot be reached, please check if the SQL server is running.");
                }
            }
        }

        private void InitializeOrderUserControls()
        {
            var orderUserControl = new OrderUserControls();
            OrderTabPage.Controls.Add(orderUserControl);
        }

        private void InitializeMotorTypePlateUserControl()
        {
            var mtpUserControl = new MotorTypePlateUserControl();
            MotorTypePlateTabPage.Controls.Add(mtpUserControl);
        }
    }
}
