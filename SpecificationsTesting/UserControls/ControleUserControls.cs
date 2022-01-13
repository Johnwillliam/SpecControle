using EntityFrameworkModel;
using Microsoft.EntityFrameworkCore.Internal;
using SpecificationsTesting.Business;
using SpecificationsTesting.Entities;
using SpecificationsTesting.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpecificationsTesting.UserControls
{
    public partial class ControleUserControls : UserControl
    {
        public CustomOrder CustomOrder { get; set; }
        public int SelectedVentilatorID { get; set; }
        public int SelectedTestID { get; set; }
        public TemplateMotor SelectedTemplateMotor { get; set; }
        public ControleUserControls()
        {
            InitializeComponent();
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.CustomOrderVentilatorsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomOrderVentilatorsDataGrid_RowEnter);
            this.CustomOrderVentilatorTestDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomOrderVentilatorTestDataGrid_RowEnter);

            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
 
            InitializeGridColumns();
            SelectedVentilatorID = -1;
            SelectedTestID = -1;
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

            CustomOrderVentilatorTestDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description", Name = "Description", ReadOnly = true });
            CustomOrderVentilatorTestDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayValue", Name = "Value", ReadOnly = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            CustomOrderVentilatorTestDataGrid.RowHeadersVisible = false;
            CustomOrderVentilatorTestDataGrid.AutoGenerateColumns = false;
            CustomOrderVentilatorTestDataGrid.AllowUserToResizeRows = false;
        }

        private void CustomOrderVentilatorsDataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void InitializeGridData(bool initVentilatorsGrid = true)
        {
            try
            {
                CustomOrderDataGrid.DataSource = null;
                CustomOrderDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrder), CustomOrder, BCustomOrder.ControleDisplayPropertyNames);
                CustomOrderDataGrid.AutoResizeColumns();

                if (CustomOrder.CustomOrderVentilators.Count == 0)
                    CustomOrder.CustomOrderVentilators.Add(new CustomOrderVentilator());

                var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
                VentilatorDataGrid.DataSource = null;
                VentilatorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilator), ventilator, BCustomOrderVentilator.ControleDisplayPropertyNames);
                VentilatorDataGrid.AutoResizeColumns();

                VentilatorTestsDataGrid.DataSource = null;
                VentilatorTestsDataGrid.DataSource = ventilator.CustomOrderVentilatorTests.Select(x => $"TestID {x.ID}").ToList();
                VentilatorTestsDataGrid.AutoResizeColumns();

                var test = SelectedTestID == 0 ? ventilator.CustomOrderVentilatorTests.First() : ventilator.CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedTestID);
                CustomOrderVentilatorTestDataGrid.DataSource = null;
                CustomOrderVentilatorTestDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilatorTest), test, BCustomOrderVenilatorTest.ControleDisplayPropertyNames);
                CustomOrderVentilatorTestDataGrid.AutoResizeColumns();

                if (ventilator.CustomOrderMotor == null)
                    ventilator.CustomOrderMotor = new CustomOrderMotor();

                MotorDataGrid.DataSource = null;
                MotorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderMotor), ventilator.CustomOrderMotor, BCustomOrderMotor.ControleDisplayPropertyNames);
                MotorDataGrid.AutoResizeColumns();

                if (initVentilatorsGrid)
                {
                    CustomOrderVentilatorsDataGrid.DataSource = null;
                    CustomOrderVentilatorsDataGrid.DataSource = CustomOrder.CustomOrderVentilators.ToList();
                    CustomOrderVentilatorsDataGrid.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
            SelectedVentilatorID = 0;
            SelectedTestID = 0;
            InitializeGridData();
        }

        private void cmbMotorFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CustomOrder = null;
            SelectedVentilatorID = 0;
            SelectedTestID = 0;
            txtCustomOrderNumber.Text = "";
            InitializeGridData();
        }

        private void CustomOrderVentilatorsDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(CustomOrderVentilatorsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int ventilatorID))
            {
                SelectedVentilatorID = ventilatorID;
                InitializeGridData(false);
            }
        }

        private void CustomOrderVentilatorTestDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(CustomOrderVentilatorTestDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int testID))
            {
                SelectedTestID = testID;
                InitializeGridData(false);
            }
        }

        private void btnMotorTypePlate_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null)
            {
                return;
            }
        }

    }
}
