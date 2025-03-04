using EntityFrameworkModelV2.Models;
using Logic.Business;
using Logic.PdfGenerators;
using Microsoft.Extensions.Logging;
using SpecificationsTesting.Entities;
using System.Data;
using System.ComponentModel;

namespace SpecificationsTesting.UserControls
{
    public partial class TestDocumentGenerationUserControl : UserControl
    {
        private readonly ILogger logger;

        private CustomOrder CustomOrder { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedVentilatorID { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedVentilatorTestID { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PrinterName { get; set; }

        private int GetSelectedVentilatorID() => SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder?.CustomOrderVentilators?.First()?.ID ?? -1 : SelectedVentilatorID;

        public TestDocumentGenerationUserControl(ILogger logger)
        {
            InitializeComponent();
            CustomOrderVentilatorsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(CustomOrderVentilatorsDataGrid_RowEnter);
            CustomOrderVentilatorTestsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(CustomOrderVentilatorTestsDataGrid_RowEnter);
            btnSearch.Click += new System.EventHandler(BtnSearch_Click);
            btnPrintSelectedTest.Click += new System.EventHandler(BtnPrintSelectedTest_Click);
            btnPrintAll.Click += new System.EventHandler(BtnPrintAll_Click);

            InitializeGridColumns();
            SelectedVentilatorID = 0;
            SelectedVentilatorTestID = 0;
            this.logger = logger;
        }

        private void InitializeGridColumns()
        {
            CustomOrderDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description", Name = "Description", ReadOnly = true });
            CustomOrderDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayValue", Name = "Value", ReadOnly = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            CustomOrderDataGrid.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            CustomOrderDataGrid.RowHeadersVisible = false;
            CustomOrderDataGrid.AutoGenerateColumns = false;
            CustomOrderDataGrid.AllowUserToResizeRows = false;

            VentilatorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description", Name = "Description", ReadOnly = true });
            VentilatorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayValue", Name = "Value", ReadOnly = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            VentilatorDataGrid.RowHeadersVisible = false;
            VentilatorDataGrid.AutoGenerateColumns = false;
            VentilatorDataGrid.AllowUserToResizeRows = false;

            MotorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description", Name = "Description", ReadOnly = true });
            MotorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayValue", Name = "Value", ReadOnly = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            MotorDataGrid.RowHeadersVisible = false;
            MotorDataGrid.AutoGenerateColumns = false;
            MotorDataGrid.AllowUserToResizeRows = false;

            CustomOrderVentilatorsDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "ID", ReadOnly = true });
            CustomOrderVentilatorsDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Name", DataPropertyName = "Name", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            CustomOrderVentilatorsDataGrid.RowHeadersVisible = false;
            CustomOrderVentilatorsDataGrid.AutoGenerateColumns = false;
            CustomOrderVentilatorsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomOrderVentilatorsDataGrid.MultiSelect = false;
            CustomOrderVentilatorsDataGrid.RowPrePaint += new DataGridViewRowPrePaintEventHandler(CustomOrderVentilatorsDataGrid_RowPrePaint);

            CustomOrderVentilatorTestsDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "Value", ReadOnly = true });
            CustomOrderVentilatorTestsDataGrid.RowHeadersVisible = false;
            CustomOrderVentilatorTestsDataGrid.AutoGenerateColumns = false;
            CustomOrderVentilatorTestsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorTestsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomOrderVentilatorTestsDataGrid.MultiSelect = false;
        }

        private void InitializeGridData(bool initVentilatorsGrid = true, bool initVentilatorTestsGrid = true)
        {
            CustomOrderDataGrid.DataSource = null;
            CustomOrderDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrder), CustomOrder, BCustomOrder.ControleDisplayPropertyNames);
            CustomOrderDataGrid.AutoResizeColumns();

            CustomOrder ??= new CustomOrder { ID = -1 };

            if (CustomOrder.CustomOrderVentilators.Count == 0)
                CustomOrder.CustomOrderVentilators.Add(new CustomOrderVentilator());

            var ventilator = GetSelectedVentilatorID() == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == GetSelectedVentilatorID());
            VentilatorDataGrid.DataSource = null;
            VentilatorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilator), ventilator, BCustomOrderVentilator.ControleDisplayPropertyNames);
            VentilatorDataGrid.AutoResizeColumns();

            var selectedTest = SelectedVentilatorTestID == 0 ? ventilator.CustomOrderVentilatorTests.First() : ventilator.CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);
            if (selectedTest != null && selectedTest.Date == null)
                selectedTest.Date = DateTime.Now.Date;

            ventilator.CustomOrderMotor ??= new CustomOrderMotor();

            MotorDataGrid.DataSource = null;
            MotorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderMotor), ventilator.CustomOrderMotor, BCustomOrderMotor.ControleDisplayPropertyNames);
            MotorDataGrid.AutoResizeColumns();

            if (initVentilatorsGrid)
            {
                CustomOrderVentilatorsDataGrid.DataSource = null;
                CustomOrderVentilatorsDataGrid.DataSource = CustomOrder.CustomOrderVentilators.ToList();
                CustomOrderVentilatorsDataGrid.AutoResizeColumns();
            }
            if (CustomOrder != null && initVentilatorsGrid)
            {
                CustomOrderVentilatorsDataGrid.DataSource = null;
                CustomOrderVentilatorsDataGrid.DataSource = CustomOrder.CustomOrderVentilators.ToList();
                CustomOrderVentilatorsDataGrid.AutoResizeColumns();
            }
            if (initVentilatorTestsGrid)
            {
                CustomOrderVentilatorTestsDataGrid.DataSource = null;
                CustomOrderVentilatorTestsDataGrid.DataSource = ventilator.CustomOrderVentilatorTests.Select(x => new { Value = $"Test ID {x.ID}" }).ToList();
                CustomOrderVentilatorTestsDataGrid.AutoResizeColumns();
            }
        }

        private void CustomOrderVentilatorsDataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void CustomOrderVentilatorsDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(CustomOrderVentilatorsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int ventilatorID))
            {
                SelectedVentilatorID = ventilatorID;
                InitializeGridData(false);
            }
        }

        private void CustomOrderVentilatorTestsDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (CustomOrderVentilatorTestsDataGrid.Rows[e.RowIndex].Cells[0].Value != null && int.TryParse(CustomOrderVentilatorTestsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString().Replace("Test ID ", ""), out int testID))
            {
                SelectedVentilatorTestID = testID;
                InitializeGridData(false, false);
            }
        }

        private void ShowCustomOrder()
        {
            if (string.IsNullOrEmpty(txtCustomOrderNumber.Text))
                return;

            var customOrderNumber = int.Parse(txtCustomOrderNumber.Text);
            CustomOrder = BCustomOrder.ByCustomOrderNumber(customOrderNumber);
            if (CustomOrder == null)
            {
                MessageBox.Show($"No order found for number: {customOrderNumber}");
                return;
            }

            InitializeGridData();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            ShowCustomOrder();
        }

        private void BtnPrintSelectedTest_Click(object sender, EventArgs e)
        {
            var selectedTest = CustomOrder?.CustomOrderVentilators?.FirstOrDefault(x => x.ID == GetSelectedVentilatorID()).CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);
            if (CustomOrder == null || selectedTest == null || !BValidateMessage.ValidateForPrinting(selectedTest))
            {
                return;
            }

            Print(new List<CustomOrderVentilatorTest>() { selectedTest });
        }

        private void BtnPrintAll_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null || !BValidateMessage.ValidateForPrinting(CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == GetSelectedVentilatorID())))
            {
                return;
            }

            Print(CustomOrder.CustomOrderVentilators.SelectMany(x => x.CustomOrderVentilatorTests).ToList());
        }

        private void Print(List<CustomOrderVentilatorTest> tests)
        {
            var generator = new TestDocumentPdfDocumentGenerator(tests, logger);
            var stream = new MemoryStream();
            generator.Generate(stream);
            var document = PdfiumViewer.PdfDocument.Load(stream);
            var printdoc = document.CreatePrintDocument();
            printdoc.PrinterSettings = new System.Drawing.Printing.PrinterSettings()
            {
                PrinterName = PrinterName
            };
            printdoc.Print();
        }

        private void TxtCustomOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ShowCustomOrder();
            }
        }
    }
}