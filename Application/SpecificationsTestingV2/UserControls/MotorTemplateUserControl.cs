using EntityFrameworkModelV2.Context;
using EntityFrameworkModelV2.Extensions;
using EntityFrameworkModelV2.Models;
using Logic.Business;
using Microsoft.Extensions.Logging;
using System.Data;

namespace SpecificationsTesting.UserControls
{
    public partial class MotorTemplateUserControl : UserControl
    {
        public MotorTemplateUserControl(ILogger logger)
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
                if (row.Cells[nameof(TemplateMotor.Name)].Value is null)
                {
                    continue;
                }

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

        private static TemplateMotor CreateTemplateMotorByDataGridViewRow(DataGridViewRow dataRow)
        {
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
                Bearings = dataRow.Cells[nameof(TemplateMotor.Bearings)].Value is null ? new List<int>() : (List<int>)dataRow.Cells[nameof(TemplateMotor.Bearings)].Value
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

        private void MotorTemplatesDataGrid_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.DesiredType == typeof(IEnumerable<int>))
            {
                e.Value = e.Value.ToString().Split('/').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToList();
            }
            e.ParsingApplied = true;
        }

        private void MotorTemplatesDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is not null && e.Value.GetType() == typeof(List<int>))
            {
                var list = (List<int>)e.Value;
                e.Value = string.Join("/", list);
            }
        }
    }
}