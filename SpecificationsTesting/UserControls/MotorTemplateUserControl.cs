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
            btnSave.Click += new System.EventHandler(btnSave_Click);
            Load += new System.EventHandler(MotorTemplateSelection_Load);
        }

        private void MotorTemplateSelection_Load(object sender, EventArgs e)
        {
            templateMotorsTableAdapter.Fill(templateMotors._TemplateMotors);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in templateMotors._TemplateMotors.Rows)
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
            templateMotorsTableAdapter.Fill(templateMotors._TemplateMotors);
        }

        private void MotorTemplateDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
    }
}
