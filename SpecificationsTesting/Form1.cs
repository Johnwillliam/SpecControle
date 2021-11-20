using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using EntityFrameworkModel;
using SpecificationsTesting.Business;
using SpecificationsTesting.Entities;

namespace SpecificationsTesting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CustomOrderDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description" });
            CustomOrderDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayedValue" } );
            CustomOrderDataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CustomOrderDataGrid.RowHeadersVisible = false;
            CustomOrderDataGrid.AutoGenerateColumns = false;
            CustomOrderDataGrid.AllowUserToResizeRows = false;

            VentilatorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description" });
            VentilatorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayedValue" });
            VentilatorDataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            VentilatorDataGrid.RowHeadersVisible = false;
            VentilatorDataGrid.AutoGenerateColumns = false;
            VentilatorDataGrid.AllowUserToResizeRows = false;

            MotorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description" });
            MotorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayedValue" });
            MotorDataGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MotorDataGrid.RowHeadersVisible = false;
            MotorDataGrid.AutoGenerateColumns = false;
            MotorDataGrid.AllowUserToResizeRows = false;
        }

        private void btnCreateCO_Click(object sender, EventArgs e)
        {
            var customOrderNumber = int.Parse(txtCustomOrderNumber.Text);
            BCustomOrder.Create(customOrderNumber, 1, 10);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var customOrderNumber = int.Parse(txtCustomOrderNumber.Text);
            var customOrder = BCustomOrder.ByCustomOrderNumber(customOrderNumber);
            CustomOrderDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrder), customOrder, BCustomOrder.DisplayPropertyNames).ToList();
            CustomOrderDataGrid.AutoResizeColumns();

            VentilatorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(Ventilator), customOrder.Ventilator, BVentilator.DisplayPropertyNames).ToList();
            VentilatorDataGrid.AutoResizeColumns();

            MotorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(Motor), customOrder.Ventilator.Motor, BMotor.DisplayPropertyNames).ToList();
            MotorDataGrid.AutoResizeColumns();
        }
    }

    
}
