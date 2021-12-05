using System;
using System.Collections;
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
  public partial class CustomOrderForm : Form
  {
    public CustomOrder CustomOrder { get; set; }
    public int SelectedVentilatorID { get; set; }

    public CustomOrderForm()
    {
      InitializeComponent();
      InitializeGridColumns();
      InitializeGridData();
      var motorItems = new List<TemplateMotor>() { new TemplateMotor() { ID = -1, Name = "" } };
      motorItems.AddRange(BTemplateMotor.GetAll());
      cmbMotorFilter.DataSource = motorItems;
      cmbMotorFilter.ValueMember = "ID";
      cmbMotorFilter.DisplayMember = "Name";
      cmbMotorFilter.SelectedIndex = -1;
      SelectedVentilatorID = -1;
    }

    private void InitializeGridColumns()
    {
      CustomOrderDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description", ReadOnly = true });
      CustomOrderDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayValue", ReadOnly = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
      CustomOrderDataGrid.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
      CustomOrderDataGrid.RowHeadersVisible = false;
      CustomOrderDataGrid.AutoGenerateColumns = false;
      CustomOrderDataGrid.AllowUserToResizeRows = false;

      VentilatorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description", ReadOnly = true });
      VentilatorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayValue", ReadOnly = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
      VentilatorDataGrid.RowHeadersVisible = false;
      VentilatorDataGrid.AutoGenerateColumns = false;
      VentilatorDataGrid.AllowUserToResizeRows = false;

      MotorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description", ReadOnly = true });
      MotorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayValue", ReadOnly = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
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
    }

    private void CustomOrderVentilatorsDataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
      e.PaintParts &= ~DataGridViewPaintParts.Focus;
    }

    private void InitializeGridData(bool initVentilatorsGrid = true)
    {
      CustomOrderDataGrid.DataSource = null;
      CustomOrderDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrder), CustomOrder, BCustomOrder.DisplayPropertyNames);
      CustomOrderDataGrid.AutoResizeColumns();

      if (CustomOrder == null)
        CustomOrder = new CustomOrder();

      if (CustomOrder.CustomOrderVentilators.Count == 0)
        CustomOrder.CustomOrderVentilators.Add(new CustomOrderVentilator());

      var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);

      VentilatorDataGrid.DataSource = null;
      VentilatorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilator), ventilator, BCustomOrderVentilator.DisplayPropertyNames);
      VentilatorDataGrid.AutoResizeColumns();

      if (ventilator.CustomOrderMotor == null)
        ventilator.CustomOrderMotor = new CustomOrderMotor();

      MotorDataGrid.DataSource = null;
      MotorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderMotor), ventilator.CustomOrderMotor, BCustomOrderMotor.EditDisplayPropertyNames);
      MotorDataGrid.AutoResizeColumns();

      if(initVentilatorsGrid)
      {
        CustomOrderVentilatorsDataGrid.DataSource = null;
        CustomOrderVentilatorsDataGrid.DataSource = CustomOrder.CustomOrderVentilators.ToList();
        CustomOrderVentilatorsDataGrid.AutoResizeColumns();
      } 
    }

    private void btnCreateCO_Click(object sender, EventArgs e)
    {
      var selectedMotor = (TemplateMotor)cmbMotorFilter.SelectedItem;
      if (selectedMotor != null && selectedMotor.ID != -1)
      {
        if (string.IsNullOrEmpty(txtCustomOrderNumber.Text))
          return;

        var customOrderNumber = int.Parse(txtCustomOrderNumber.Text);
        var copiedMotor = new CustomOrderMotor() { Name = selectedMotor.Name, Amperage = selectedMotor.Amperage, BuildingType = selectedMotor.BuildingType, Frequency = selectedMotor.Frequency, IEC = selectedMotor.IEC, IP = selectedMotor.IP, ISO = selectedMotor.ISO, Power = selectedMotor.Power, PowerFactor = selectedMotor.PowerFactor, RPM = selectedMotor.RPM, StartupAmperage = selectedMotor.StartupAmperage, Type = selectedMotor.Type, Version = selectedMotor.Version, VoltageType = selectedMotor.VoltageType, VoltageTypeID = selectedMotor.VoltageTypeID };
        var newVentilator = ReadCustomOrderVentilatorDataGrid();
        newVentilator.CustomOrderMotor = copiedMotor;
        var customOrder = BCustomOrder.Create(customOrderNumber, 1, 10);
        newVentilator.CustomOrderID = customOrder.ID;
        BCustomOrderVentilator.Create(newVentilator);
      }
      else
      {
        CustomOrder = ReadCustomOrderDataGrid();
        if (CustomOrder == null)
          return;

        CustomOrder = BCustomOrder.Create(CustomOrder);

        for (int i = 0; i < CustomOrder.Amount; i++)
        {
          var customOrderMotor = ReadCustomOrderMotorDataGrid();
          customOrderMotor = BCustomOrderMotor.Create(customOrderMotor);

          var customOrderVentilator = ReadCustomOrderVentilatorDataGrid();
          customOrderVentilator.CustomOrderID = CustomOrder.ID;
          customOrderVentilator.CustomOrderMotorID = customOrderMotor.ID;
          BCustomOrderVentilator.Create(customOrderVentilator);
        }
      }
    }

    private CustomOrder ReadCustomOrderDataGrid()
    {
      var customOrder = new CustomOrder();
      foreach (DataGridViewRow row in CustomOrderDataGrid.Rows)
      {
        int value;
        switch (row.Index)
        {
          case 0:
            if (int.TryParse(row.Cells[1].Value.ToString(), out value))
              customOrder.CustomOrderNumber = value;
            else
              return null;
            break;
          case 1:
            if (int.TryParse(row.Cells[1].Value.ToString(), out value))
              customOrder.Amount = value;
            else
              return null;
            break;
          case 2:
            customOrder.Debtor = row.Cells[1].Value.ToString();
            break;
          case 3:
            customOrder.Reference = row.Cells[1].Value.ToString();
            break;
          case 4:
            customOrder.Remarks = row.Cells[1].Value.ToString();
            break;
          default:
            break;
        }
      }
      return customOrder;
    }

    private CustomOrderVentilator ReadCustomOrderVentilatorDataGrid()
    {
      var newCustomOrderVentilator = new CustomOrderVentilator();
      foreach (DataGridViewRow row in VentilatorDataGrid.Rows)
      {
        switch (row.Index)
        {
          case 0:
            newCustomOrderVentilator.Name = row.Cells[1].Value.ToString();
            break;
          case 1:
            newCustomOrderVentilator.AirVolume = row.Cells[1].Value.ToString();
            break;
          case 2:
            newCustomOrderVentilator.PressureTotal = row.Cells[1].Value.ToString();
            break;
          case 3:
            newCustomOrderVentilator.PressureStatic = row.Cells[1].Value.ToString();
            break;
          case 4:
            //newCustomOrderVentilator.PressureDynamic = newCustomOrderVentilator.PressureTotal - newCustomOrderVentilator.PressureStatic;
            break;
          case 5:
            newCustomOrderVentilator.RPM = row.Cells[1].Value.ToString();
            break;
          case 6:
            newCustomOrderVentilator.Efficiency = DataHelper.ToNullableInt(row.Cells[1].Value.ToString());
            break;
          case 7:
            newCustomOrderVentilator.ShaftPower = row.Cells[1].Value.ToString();
            break;
          case 8:
            newCustomOrderVentilator.SoundLevel = DataHelper.ToNullableInt(row.Cells[1].Value.ToString());
            break;
          case 9:
            //newCustomOrderVentilator.SoundLevelTypeID = int.Parse(row.Cells[1].Value.ToString());
            break;
          case 10:
            newCustomOrderVentilator.BladeAngle = DataHelper.ToNullableInt(row.Cells[1].Value.ToString());
            break;
          default:
            break;
        }
      }
      return newCustomOrderVentilator;
    }

    private CustomOrderMotor ReadCustomOrderMotorDataGrid()
    {
      var newCustomOrderMotor = new CustomOrderMotor();
      foreach (DataGridViewRow row in MotorDataGrid.Rows)
      {
        switch (row.Index)
        {
          case 0:
            newCustomOrderMotor.Name = row.Cells[1].Value.ToString();
            break;
          case 1:
            newCustomOrderMotor.Type = row.Cells[1].Value.ToString();
            break;
          case 2:
            newCustomOrderMotor.Version = row.Cells[1].Value.ToString();
            break;
          case 3:
            newCustomOrderMotor.IEC = DataHelper.ToNullableInt(row.Cells[1].Value.ToString());
            break;
          case 4:
            newCustomOrderMotor.IP = DataHelper.ToNullableInt(row.Cells[1].Value.ToString());
            break;
          case 5:
            newCustomOrderMotor.BuildingType = row.Cells[1].Value.ToString();
            break;
          case 6:
            newCustomOrderMotor.ISO = row.Cells[1].Value.ToString();
            break;
          case 7:
            newCustomOrderMotor.Power = row.Cells[1].Value.ToString();
            break;
          case 8:
            newCustomOrderMotor.RPM = row.Cells[1].Value.ToString();
            break;
          case 9:
            newCustomOrderMotor.Amperage = row.Cells[1].Value.ToString();
            break;
          case 10:
            newCustomOrderMotor.StartupAmperage = DataHelper.ToNullableInt(row.Cells[1].Value.ToString());
            break;
          case 11:
            //newCustomOrderMotor.VoltageTypeID = int.Parse(row.Cells[1].Value.ToString());
            break;
          case 12:
            newCustomOrderMotor.Frequency = DataHelper.ToNullableInt(row.Cells[1].Value.ToString());
            break;
          case 13:
            newCustomOrderMotor.PowerFactor = int.Parse(row.Cells[1].Value.ToString());
            break;
          default:
            break;
        }
      }
      return newCustomOrderMotor;
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      var customOrderNumber = int.Parse(txtCustomOrderNumber.Text);
      CustomOrder = BCustomOrder.ByCustomOrderNumber(customOrderNumber);
      if (CustomOrder == null)
      {
        MessageBox.Show($"No order found for number: {customOrderNumber}");
        return;
      }

      InitializeGridData();
    }

    private void cmbMotorFilter_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = true;
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      CustomOrder = null;
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

    private void btnSaveChanges_Click(object sender, EventArgs e)
    {
      try
      {
        var index = CustomOrder.CustomOrderVentilators.ToList().FindIndex(x => x.ID == SelectedVentilatorID);
        var ventilator = CustomOrder.CustomOrderVentilators.ToList()[index];
        var ventilatorID = ventilator.ID;
        var motorID = ventilator.CustomOrderMotorID;
        ventilator = ReadCustomOrderVentilatorDataGrid();
        ventilator.ID = ventilatorID;

        var motor = ReadCustomOrderMotorDataGrid();
        motor.ID = motorID;
        ventilator.CustomOrderMotorID = motorID;
        ventilator.CustomOrderMotor = motor;

        BCustomOrderVentilator.Update(ventilator);
        var customOrderNumber = int.Parse(txtCustomOrderNumber.Text);
        CustomOrder = BCustomOrder.ByCustomOrderNumber(customOrderNumber);
        InitializeGridData();
        MessageBox.Show("Sucessful updated");
      }
      catch (Exception ex)
      {
        if(ex.InnerException == null)
          MessageBox.Show(ex.Message);
        else if(ex.InnerException.InnerException == null)
          MessageBox.Show(ex.InnerException.Message);
        else
          MessageBox.Show(ex.InnerException.InnerException.Message);
      }
    }
  }
}
