using EntityFrameworkModel;
using SpecificationsTesting.Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace SpecificationsTesting.UserControls
{
    public partial class MotorTemplateUserControl : UserControl
    {
        public MotorTemplateUserControl()
        {
            InitializeComponent();
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.Load += new System.EventHandler(this.MotorTemplateSelection_Load);
        }

        private void MotorTemplateSelection_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'templateMotors._TemplateMotors' table. You can move, or remove it, as needed.
            this.templateMotorsTableAdapter.Fill(this.templateMotors._TemplateMotors);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in this.templateMotors._TemplateMotors.Rows)
            {
                var motorTemplate = DataHelper.ToObject<TemplateMotor>(row);
                if (motorTemplate.ID < 0)
                {
                    BTemplateMotor.Create(motorTemplate);
                }
                else
                {
                    BTemplateMotor.Update(motorTemplate);
                }
            }
            this.templateMotorsTableAdapter.Fill(this.templateMotors._TemplateMotors);
        }

        private void MotorTemplateDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
    }
}
