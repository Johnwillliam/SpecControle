using System.ComponentModel;
using System.Data;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SpecControle.Forms
{
    public partial class MotorTemplateSelection : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewRow SelectedRow { get; set; }

        public MotorTemplateSelection()
        {
            InitializeComponent();
            DataGridViewTemplateMotor.MultiSelect = false;
        }

        private void MotorTemplateSelection_Load(object sender, EventArgs e)
        {
            using var db = new SpecificationsDatabaseModel();

            var templates = db.TemplateMotors.ToList();

            var templateDisplayList = templates.Select(t => new
            {
                t.ID,
                t.Name,
                t.Type,
                t.Version,
                t.IEC,
                t.IP,
                PTC = t.PTC.HasValue ? (t.PTC.Value ? "Yes" : "No") : "",
                HT = t.HT.HasValue ? (t.HT.Value ? "Yes" : "No") : "",
                t.BuildingType,
                t.ISO,
                t.HighPower,
                t.LowPower,
                t.HighRPM,
                t.LowRPM,
                t.HighAmperage,
                t.LowAmperage,
                t.HighStartupAmperage,
                t.LowStartupAmperage,
                t.VoltageType,
                t.Frequency,
                t.Poles,
                t.PowerFactor,
                t.Bearings
            }).ToList();

            var bindingSource = new BindingSource
            {
                DataSource = ConvertToDataTable(templateDisplayList)
            };
            DataGridViewTemplateMotor.DataSource = bindingSource;
            DataGridViewTemplateMotor.FilterAndSortEnabled = true;
            DataGridViewTemplateMotor.AutoGenerateColumns = true;

            DataGridViewTemplateMotor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

        private void BtnSelectTemplateMotor_Click(object sender, EventArgs e)
        {
            if (DataGridViewTemplateMotor.Rows.Count == 0)
                return;

            if (DataGridViewTemplateMotor.SelectedRows.Count == 0)
                DataGridViewTemplateMotor.Rows[0].Selected = true;

            SelectedRow = DataGridViewTemplateMotor.SelectedRows[0];
            Close();
        }
    }
}
