using EntityFrameworkModelV2.Context;
using EntityFrameworkModelV2.Extensions;
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
                var motorTemplate = CreateTemplateMotorByDataGridViewRow(row);
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

        private TemplateMotor CreateTemplateMotorByDataGridViewRow(DataGridViewRow dataRow)
        {
            var rows = new List<DataGridViewRow> { dataRow };
            return new TemplateMotor
            {
                ID = (int)dataRow.Cells[nameof(TemplateMotor.ID)].Value,
                Name = dataRow.Cells[nameof(TemplateMotor.Name)].Value.EmptyIfNull(),
                Type = dataRow.Cells[nameof(TemplateMotor.Type)].Value.EmptyIfNull(),
                Version = dataRow.Cells[nameof(TemplateMotor.Version)].Value.EmptyIfNull(),
                IEC = (int?)dataRow.Cells[nameof(TemplateMotor.IEC)].Value,
                IP = (int?)dataRow.Cells[nameof(TemplateMotor.IP)].Value,
                PTC = (bool?)dataRow.Cells[nameof(TemplateMotor.PTC)].Value,
                HT = (bool?)dataRow.Cells[nameof(TemplateMotor.HT)].Value,
                BuildingType = dataRow.Cells[nameof(TemplateMotor.BuildingType)].Value.EmptyIfNull(),
                ISO = dataRow.Cells[nameof(TemplateMotor.ISO)].Value.EmptyIfNull(),
                HighPower = (decimal?)dataRow.Cells[nameof(TemplateMotor.HighPower)].Value,
                LowPower = (decimal?)dataRow.Cells[nameof(TemplateMotor.LowPower)].Value,
                HighRPM = (int?)dataRow.Cells[nameof(TemplateMotor.HighRPM)].Value,
                LowRPM = (int?)dataRow.Cells[nameof(TemplateMotor.LowRPM)].Value,
                HighAmperage = (decimal?)dataRow.Cells[nameof(TemplateMotor.HighAmperage)].Value,
                LowAmperage = (decimal?)dataRow.Cells[nameof(TemplateMotor.LowAmperage)].Value,
                HighStartupAmperage = (decimal?)dataRow.Cells[nameof(TemplateMotor.HighStartupAmperage)].Value,
                LowStartupAmperage = (decimal?)dataRow.Cells[nameof(TemplateMotor.LowStartupAmperage)].Value,
                VoltageType = dataRow.Cells[nameof(TemplateMotor.VoltageType)].Value.EmptyIfNull(),
                Frequency = (int?)dataRow.Cells[nameof(TemplateMotor.Frequency)].Value,
                PowerFactor = (decimal?)dataRow.Cells[nameof(TemplateMotor.PowerFactor)].Value,
                Bearings = DataGridObjectsUtility.ParseSlashSeparatedIntValues(rows, nameof(CustomOrderMotor.Bearings))
            };
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

                    if (CellValidation.CheckValue(value, type) && CellValidation.ValidateNumber(value, type))
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