using EntityFrameworkModelV2.Context;
using EntityFrameworkModelV2.Models;
using SpecificationsTesting.Business;
using System.Data;

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
			var templates = new SpecificationsDatabaseModel().TemplateMotors.ToList();
			templates.Add(new TemplateMotor());
			MotorTemplatesDataGrid.DataSource = templates;
			MotorTemplatesDataGrid.Columns[0].Visible = false;
		}

		private void btnSave_Click(object sender, EventArgs e)
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
					if (IsNumericType(type) && !e.FormattedValue.ToString().All(char.IsDigit))
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

		private bool IsNumericType(Type type)
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				return IsNumericType(Nullable.GetUnderlyingType(type));
			}

			switch (Type.GetTypeCode(type))
			{
				case TypeCode.Byte:
				case TypeCode.SByte:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
				case TypeCode.Decimal:
				case TypeCode.Double:
				case TypeCode.Single:
					return true;
				default:
					return false;
			}
		}

		private void MotorTemplateDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(e.Exception.Message);
		}
	}
}
