using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Data;
using Application.Business;
using Infrastructure.Context;
using Infrastructure.Extensions;
using SpecControle.Entities;
using Infrastructure.Models;

namespace SpecControle.UserControls
{
    public partial class MotorTemplateUserControl : UserControl
    {
        public MotorTemplateUserControl(ILogger logger)
        {
            InitializeComponent();
            btnSave.Click += new EventHandler(BtnSave_Click);
            Load += new EventHandler(MotorTemplateSelection_Load);
            MotorTemplatesDataGrid.CellValidating += MotorTemplatesDataGrid_CellValidating;
            MotorTemplatesDataGrid.DataError += MotorTemplateDataGridView_DataError;
            MotorTemplatesDataGrid.CellParsing += MotorTemplatesDataGrid_CellParsing;
            MotorTemplatesDataGrid.CellFormatting += MotorTemplatesDataGrid_CellFormatting;
        }

        private void MotorTemplateSelection_Load(object sender, EventArgs e)
        {
            var templates = new SpecificationsDatabaseModel().TemplateMotors.ToList();
            templates.Add(new TemplateMotor());
            var table = ConvertToDataTable(templates);

            MotorTemplatesDataGrid.DataSource = null;
            MotorTemplatesDataGrid.Columns.Clear();
            MotorTemplatesDataGrid.DataSource = table;
            MotorTemplatesDataGrid.Columns[0].Visible = false;

            // Filter functionaliteit inschakelen
            MotorTemplatesDataGrid.FilterAndSortEnabled = true;
            MotorTemplatesDataGrid.AutoGenerateColumns = true;
            MotorTemplatesDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Yes/No datasource
            var yesNoDataSource = new List<YesNoItem>
            {
                new() { Value = true, DisplayText = "Yes" },
                new() { Value = false, DisplayText = "No" }
            };

            // Vervang PTC-kolom door een dropdown
            ReplaceColumnWithYesNoDropdown(nameof(TemplateMotor.PTC), yesNoDataSource);

            // Vervang HT-kolom door een dropdown
            ReplaceColumnWithYesNoDropdown(nameof(TemplateMotor.HT), yesNoDataSource);
        }

        private void ReplaceColumnWithYesNoDropdown(string columnName, List<YesNoItem> yesNoDataSource)
        {
            if (!MotorTemplatesDataGrid.Columns.Contains(columnName))
                return;

            // Bestaande kolom verwijderen
            var oldColIndex = MotorTemplatesDataGrid.Columns[columnName].Index;
            MotorTemplatesDataGrid.Columns.RemoveAt(oldColIndex);

            // Nieuwe dropdown kolom toevoegen op dezelfde positie
            var comboColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = columnName,
                HeaderText = columnName,
                Name = columnName,
                DataSource = yesNoDataSource,
                ValueMember = nameof(YesNoItem.Value),
                DisplayMember = nameof(YesNoItem.DisplayText),
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            MotorTemplatesDataGrid.Columns.Insert(oldColIndex, comboColumn);
        }


        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }

            return table;
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
                ID = Convert.ToInt32(dataRow.Cells[nameof(TemplateMotor.ID)].Value),
                Name = dataRow.Cells[nameof(TemplateMotor.Name)].Value.EmptyIfNull(),
                Type = dataRow.Cells[nameof(TemplateMotor.Type)].Value.EmptyIfNull(),
                Version = dataRow.Cells[nameof(TemplateMotor.Version)].Value.EmptyIfNull(),
                IEC = dataRow.Cells[nameof(TemplateMotor.IEC)].Value.GetNullable<int>(),
                IP = dataRow.Cells[nameof(TemplateMotor.IP)].Value.GetNullable<int>(),
                PTC = ParseYesNoToBool(dataRow.Cells[nameof(TemplateMotor.PTC)].Value),
                HT = ParseYesNoToBool(dataRow.Cells[nameof(TemplateMotor.HT)].Value),
                BuildingType = dataRow.Cells[nameof(TemplateMotor.BuildingType)].Value.EmptyIfNull(),
                ISO = dataRow.Cells[nameof(TemplateMotor.ISO)].Value.EmptyIfNull(),
                HighPower = dataRow.Cells[nameof(TemplateMotor.HighPower)].Value.GetNullable<decimal>(),
                LowPower = dataRow.Cells[nameof(TemplateMotor.LowPower)].Value.GetNullable<decimal>(),
                HighRPM = dataRow.Cells[nameof(TemplateMotor.HighRPM)].Value.GetNullable<int>(),
                LowRPM = dataRow.Cells[nameof(TemplateMotor.LowRPM)].Value.GetNullable<int>(),
                HighAmperage = dataRow.Cells[nameof(TemplateMotor.HighAmperage)].Value.GetNullable<decimal>(),
                LowAmperage = dataRow.Cells[nameof(TemplateMotor.LowAmperage)].Value.GetNullable<decimal>(),
                HighStartupAmperage = dataRow.Cells[nameof(TemplateMotor.HighStartupAmperage)].Value.GetNullable<decimal>(),
                LowStartupAmperage = dataRow.Cells[nameof(TemplateMotor.LowStartupAmperage)].Value.GetNullable<decimal>(),
                VoltageType = dataRow.Cells[nameof(TemplateMotor.VoltageType)].Value.EmptyIfNull(),
                Frequency = dataRow.Cells[nameof(TemplateMotor.Frequency)].Value.GetNullable<int>(),
                PowerFactor = dataRow.Cells[nameof(TemplateMotor.PowerFactor)].Value.GetNullable<decimal>(),
                Bearings = dataRow.Cells[nameof(TemplateMotor.Bearings)].Value.EmptyIfNull()
            };
        }

        private static bool? ParseYesNoToBool(object value)
        {
            if (value is string str)
            {
                return str == "Yes" ? true : str == "No" ? false : null;
            }
            if (value is bool b)
            {
                return b;
            }
            return null;
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
            if (e.DesiredType == typeof(IEnumerable<int>) && e.Value.GetType() != typeof(IEnumerable<int>))
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
