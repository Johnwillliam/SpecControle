using EntityFrameworkModel;
using SpecificationsTesting.Business;
using Word = Microsoft.Office.Interop.Word;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SpecificationsTesting.UserControls
{
    public partial class TestDocumentGenerationUserControl : UserControl
    {
        private CustomOrder CustomOrder { get; set; }
        public int SelectedVentilatorID { get; set; }
        public int SelectedVentilatorTestID { get; set; }
        public TestDocumentGenerationUserControl()
        {
            InitializeComponent();
            this.CustomOrderVentilatorsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomOrderVentilatorsDataGrid_RowEnter);
            this.CustomOrderVentilatorTestsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomOrderVentilatorTestsDataGrid_RowEnter);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnPrintSelectedTest.Click += new System.EventHandler(this.btnPrintSelectedTest_Click);
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);

            InitializeGridColumns();
            SelectedVentilatorID = -1;
            SelectedVentilatorTestID = -1;
        }

        private void InitializeGridColumns()
        {
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

            if (CustomOrder != null && initVentilatorsGrid)
            {
                CustomOrderVentilatorsDataGrid.DataSource = null;
                CustomOrderVentilatorsDataGrid.DataSource = CustomOrder.CustomOrderVentilators.ToList();
                CustomOrderVentilatorsDataGrid.AutoResizeColumns();
            }
            if (initVentilatorTestsGrid)
            {
                var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowCustomOrder();
        }

        private void btnPrintSelectedTest_Click(object sender, EventArgs e)
        {
            print();
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            print();
        }

        private void print()
        {
            
        }
    }
}
