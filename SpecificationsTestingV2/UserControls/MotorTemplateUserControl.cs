using EntityFrameworkModelV2.Context;
using EntityFrameworkModelV2.Models;
using Logic.Business;
using System.Data;

namespace SpecificationsTesting.UserControls
{
    public partial class MotorTemplateUserControl : UserControl
	{
		public MotorTemplateUserControl()
		{
			InitializeComponent();
			btnSave.Click += new System.EventHandler(BtnSave_Click);
			Load += new System.EventHandler(MotorTemplateSelection_Load);
		}

		private void MotorTemplateSelection_Load(object sender, EventArgs e)
		{
			var templates = new SpecificationsDatabaseModel().TemplateMotors.ToList();
			templates.Add(new TemplateMotor());
			MotorTemplatesDataGrid.DataSource = templates;
			MotorTemplatesDataGrid.Columns[0].Visible = false;
		}

        private void BtnSave_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in MotorTemplatesDataGrid.Rows)
			{
				var motorTemplate = new TemplateMotor(row);
				if (motorTemplate.ID == 0)
				{
					BTemplateMotor.Create(motorTemplate);
				}
				else
				{
					BTemplateMotor.Update(motorTemplate);
				}
			}
			var templates = new SpecificationsDatabaseModel().TemplateMotors.ToList();
			templates.Add(new TemplateMotor());
			MotorTemplatesDataGrid.DataSource = templates;
		}

		private void MotorTemplatesDataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			var row = MotorTemplatesDataGrid.Rows[e.RowIndex];
			if (row != null)
			{
				var index = e.ColumnIndex;
				var cell = row.Cells[index];
				if (cell != null)
				{
					var properties = typeof(TemplateMotor).GetProperties();
					var types = properties.Select(property => property.PropertyType).ToList();
					var type = types[e.ColumnIndex];
					var value = e.FormattedValue?.ToString();

					if(CellValidation.CheckValue(value, type) && CellValidation.ValidateNumber(value, type))
					{
						MotorTemplatesDataGrid.Rows[e.RowIndex].ErrorText = $"{cell.OwningColumn.Name} should be a number.";
						e.Cancel = true;
					}
					else
					{
						MotorTemplatesDataGrid.Rows[e.RowIndex].ErrorText = string.Empty;
					}
				}
			}
		}

		private void MotorTemplateDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(e.Exception.Message);
		}
	}
}
