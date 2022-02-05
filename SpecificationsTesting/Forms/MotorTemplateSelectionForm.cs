using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // TODO: This line of code loads data into the 'templateMotors._TemplateMotors' table. You can move, or remove it, as needed.
            this.templateMotorsTableAdapter.Fill(this.templateMotors._TemplateMotors);
        }

        private void btnSelectTemplateMotor_Click(object sender, EventArgs e)
        {
            if (DataGridViewTemplateMotor.Rows.Any() && !DataGridViewTemplateMotor.SelectedRows.Any())
                DataGridViewTemplateMotor.Rows[0].Selected = true;

            SelectedRow = DataGridViewTemplateMotor.SelectedRows[0];
            this.Close();
        }
    }
}
