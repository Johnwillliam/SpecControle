using EntityFrameworkModelV2.Context;
using EntityFrameworkModelV2.Models;

namespace SpecificationsTesting
{
    public partial class MotorTemplateSelection : Form
    {
        public DataGridViewRow SelectedRow { get; set; }

        public MotorTemplateSelection()
        {
            InitializeComponent();
            DataGridViewTemplateMotor.MultiSelect = false;
        }

        private void MotorTemplateSelection_Load(object sender, EventArgs e)
        {
            var templates = new SpecificationsDatabaseModel().TemplateMotors.ToList();
            DataGridViewTemplateMotor.DataSource = templates.Any() ? templates : new List<TemplateMotor>();
        }

        private void BtnSelectTemplateMotor_Click(object sender, EventArgs e)
        {
            if (DataGridViewTemplateMotor.Rows.Count == 0 && DataGridViewTemplateMotor.SelectedRows.Count == 0)
                DataGridViewTemplateMotor.Rows[0].Selected = true;

            SelectedRow = DataGridViewTemplateMotor.SelectedRows[0];
            Close();
        }
    }
}