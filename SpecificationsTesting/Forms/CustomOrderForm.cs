using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using EntityFrameworkModel;
using Microsoft.EntityFrameworkCore.Internal;
using SpecificationsTesting.Business;
using SpecificationsTesting.Entities;
using SpecificationsTesting.Forms;

namespace SpecificationsTesting
{
  public partial class CustomOrderForm : Form
  {
    public CustomOrder CustomOrder { get; set; }
    public int SelectedVentilatorID { get; set; }
    public TemplateMotor SelectedTemplateMotor { get; set; }
   
    public CustomOrderForm()
    {
      InitializeComponent();
      InitializeGridColumns();
      InitializeGridData();
      SelectedVentilatorID = -1;
      btnSaveChanges.Enabled = false;
      btnCreateVentilator.Enabled = false;
      btnRemoveVentilator.Enabled = false;
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

      if (CustomOrder == null || CustomOrder.ID == -1)
      {
        CustomOrder = new CustomOrder { ID = -1 };
        btnSaveChanges.Enabled = false;
        btnCreateVentilator.Enabled = false;
        btnRemoveVentilator.Enabled = false;
      }
      else
      {
        txtCustomOrderNumber.Text = CustomOrder.CustomOrderNumber.ToString();
        btnSaveChanges.Enabled = true;
        btnCreateVentilator.Enabled = true;
        btnRemoveVentilator.Enabled = true;
      }

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

      if (initVentilatorsGrid)
      {
        CustomOrderVentilatorsDataGrid.DataSource = null;
        CustomOrderVentilatorsDataGrid.DataSource = CustomOrder.CustomOrderVentilators.ToList();
        CustomOrderVentilatorsDataGrid.AutoResizeColumns();
      }
    }

    private void btnCreateCO_Click(object sender, EventArgs e)
    {
      if (SelectedTemplateMotor != null)
      {
        CustomOrder = ReadCustomOrderDataGrid();
        var copiedMotor = new CustomOrderMotor() { Name = SelectedTemplateMotor.Name, Amperage = SelectedTemplateMotor.Amperage, BuildingType = SelectedTemplateMotor.BuildingType, Frequency = SelectedTemplateMotor.Frequency, IEC = SelectedTemplateMotor.IEC, IP = SelectedTemplateMotor.IP, ISO = SelectedTemplateMotor.ISO, Power = SelectedTemplateMotor.Power, PowerFactor = SelectedTemplateMotor.PowerFactor, RPM = SelectedTemplateMotor.RPM, StartupAmperage = SelectedTemplateMotor.StartupAmperage, Type = SelectedTemplateMotor.Type, Version = SelectedTemplateMotor.Version, VoltageType = SelectedTemplateMotor.VoltageType, VoltageTypeID = SelectedTemplateMotor.VoltageTypeID };
        var newVentilator = ReadCustomOrderVentilatorDataGrid();
        if(newVentilator == null)
        {
          MessageBox.Show("Creation failed. Please check the filled in data.");
          return;
        }
        CustomOrder = BCustomOrder.Create(CustomOrder);
        newVentilator.CustomOrderMotor = copiedMotor;
        newVentilator.CustomOrderID = CustomOrder.ID;
        BCustomOrderVentilator.Create(newVentilator);
        CustomOrder = BCustomOrder.ByCustomOrderNumber(CustomOrder.CustomOrderNumber);
        txtCustomOrderNumber.Text = CustomOrder.CustomOrderNumber.ToString();
        InitializeGridData();
      }
      else
      {
        CustomOrder = ReadCustomOrderDataGrid();
        if (CustomOrder == null)
          return;

        if (BCustomOrder.ByCustomOrderNumber(CustomOrder.CustomOrderNumber) != null)
          return;

        var customOrderVentilator = ReadCustomOrderVentilatorDataGrid();
        if (customOrderVentilator == null)
        {
          MessageBox.Show("Creation failed. Please check the filled in data.");
          return;
        }

        CustomOrder = BCustomOrder.Create(CustomOrder);
        var customOrderMotor = ReadCustomOrderMotorDataGrid();
        customOrderMotor = BCustomOrderMotor.Create(customOrderMotor);
        customOrderVentilator.CustomOrderID = CustomOrder.ID;
        customOrderVentilator.CustomOrderMotorID = customOrderMotor.ID;
        BCustomOrderVentilator.Create(customOrderVentilator);
        CustomOrder = BCustomOrder.ByCustomOrderNumber(CustomOrder.CustomOrderNumber);
        txtCustomOrderNumber.Text = CustomOrder.CustomOrderNumber.ToString();
        InitializeGridData();
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
            if (!int.TryParse(row.Cells[1].Value.ToString(), out value))
              return null;

            customOrder.CustomOrderNumber = value;
            break;
          case 1:
            customOrder.Debtor = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            break;
          case 2:
            customOrder.Reference = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            break;
          case 3:
            customOrder.Remarks = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
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
            if (!int.TryParse(row.Cells[1].Value?.ToString(), out int value))
              return null;

            newCustomOrderVentilator.Amount = value;
            break;
          case 1:
            newCustomOrderVentilator.Name = row.Cells[1].Value.ToString();
            break;
          case 2:
            newCustomOrderVentilator.AirVolume = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            break;
          case 32:
            newCustomOrderVentilator.PressureTotal = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            break;
          case 4:
            newCustomOrderVentilator.PressureStatic = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            break;
          case 5:
            if (string.IsNullOrEmpty(newCustomOrderVentilator.PressureTotal) || string.IsNullOrEmpty(newCustomOrderVentilator.PressureStatic))
              continue;

            var pressureTotals = newCustomOrderVentilator.PressureTotal.Split('/');
            var pressureStatics = newCustomOrderVentilator.PressureStatic.Split('/');
            if (pressureTotals.Length != pressureStatics.Length)
              return null;

            var result = new string[pressureTotals.Length];
            for (int i = 0; i < pressureTotals.Length; i++)
            {
              if (!int.TryParse(pressureTotals[i], out int totalPressure) || !int.TryParse(pressureStatics[i], out int staticPressure))
                return null;

              result[i] = $"{totalPressure - staticPressure}";
            }
            newCustomOrderVentilator.PressureDynamic = string.Join(" / ", result);
            break;
          case 6:
            newCustomOrderVentilator.RPM = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            break;
          case 7:
            newCustomOrderVentilator.Efficiency = DataHelper.ToNullableInt(row.Cells[1].Value?.ToString());
            break;
          case 8:
            newCustomOrderVentilator.ShaftPower = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            break;
          case 9:
            newCustomOrderVentilator.SoundLevel = DataHelper.ToNullableInt(row.Cells[1].Value?.ToString());
            break;
          case 10:
            //newCustomOrderVentilator.SoundLevelTypeID = int.Parse(row.Cells[1].Value.ToString());
            break;
          case 11:
            newCustomOrderVentilator.BladeAngle = DataHelper.ToNullableInt(row.Cells[1].Value?.ToString());
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
            newCustomOrderMotor.Type = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            break;
          case 2:
            newCustomOrderMotor.Version = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            break;
          case 3:
            newCustomOrderMotor.IEC = DataHelper.ToNullableInt(row.Cells[1].Value.ToString());
            break;
          case 4:
            newCustomOrderMotor.IP = DataHelper.ToNullableInt(row.Cells[1].Value.ToString());
            break;
          case 5:
            newCustomOrderMotor.BuildingType = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            break;
          case 6:
            newCustomOrderMotor.ISO = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            break;
          case 7:
            newCustomOrderMotor.Power = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            break;
          case 8:
            newCustomOrderMotor.RPM = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            break;
          case 9:
            newCustomOrderMotor.Amperage = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            break;
          case 10:
            newCustomOrderMotor.StartupAmperage = DataHelper.ToNullableInt(row.Cells[1].Value?.ToString());
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
        if (ex.InnerException == null)
          MessageBox.Show(ex.Message);
        else if (ex.InnerException.InnerException == null)
          MessageBox.Show(ex.InnerException.Message);
        else
          MessageBox.Show(ex.InnerException.InnerException.Message);
      }
    }

    private void btnCreateVentilator_Click(object sender, EventArgs e)
    {
      var templateMotorSelectionDialog = new MotorTemplateSelection();
      templateMotorSelectionDialog.ShowDialog();
      var motorTemplateId = int.Parse(templateMotorSelectionDialog.SelectedRow.Cells[0].Value.ToString());
      CreateVentilatorByTemplateMotorId(motorTemplateId);
    }

    private void CreateVentilatorByTemplateMotorId(int motorTemplateId)
    {
      var selectedMotor = BTemplateMotor.GetById(motorTemplateId);
      if (selectedMotor != null)
      {
        int customOrderNumber = int.Parse(txtCustomOrderNumber.Text);
        CustomOrder = BCustomOrder.ByCustomOrderNumber(customOrderNumber);
        var copiedMotor = new CustomOrderMotor() { Name = selectedMotor.Name, Amperage = selectedMotor.Amperage, BuildingType = selectedMotor.BuildingType, Frequency = selectedMotor.Frequency, IEC = selectedMotor.IEC, IP = selectedMotor.IP, ISO = selectedMotor.ISO, Power = selectedMotor.Power, PowerFactor = selectedMotor.PowerFactor, RPM = selectedMotor.RPM, StartupAmperage = selectedMotor.StartupAmperage, Type = selectedMotor.Type, Version = selectedMotor.Version, VoltageType = selectedMotor.VoltageType, VoltageTypeID = selectedMotor.VoltageTypeID };
        var newVentilator = ReadCustomOrderVentilatorDataGrid();
        if (newVentilator == null)
        {
          MessageBox.Show("Creation failed. Please check the filled in data.");
          return;
        }
        newVentilator.CustomOrderMotor = copiedMotor;
        newVentilator.CustomOrderID = CustomOrder.ID;
        BCustomOrderVentilator.Create(newVentilator);
        InitializeGridData();
      }
    }

    private void btnRemoveVentilator_Click(object sender, EventArgs e)
    {
      if (!CustomOrderVentilatorsDataGrid.SelectedRows.Any())
        return;

      if ((MessageBox.Show("Are you sure you want to remove this ventilator?", "Confirm Deletion",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
      {
        var customOrderVentilatorId = int.Parse(CustomOrderVentilatorsDataGrid.SelectedRows[0].Cells[0].Value.ToString());
        BCustomOrderVentilator.DeleteById(customOrderVentilatorId);
        SelectedVentilatorID = 0;
        InitializeGridData();
      }
    }

    private void btnSelectTemplateMotor_Click(object sender, EventArgs e)
    {
      var templateMotorSelectionDialog = new MotorTemplateSelection();
      templateMotorSelectionDialog.ShowDialog();
      var motorTemplateId = int.Parse(templateMotorSelectionDialog.SelectedRow.Cells[0].Value.ToString());
      SelectedTemplateMotor = BTemplateMotor.GetById(motorTemplateId);
      txtSelectedMotor.Text = SelectedTemplateMotor.Name;
    }

    private void CustomOrderDataGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
      //CustomOrderDataGrid.Rows[e.RowIndex]
    }

    private void btnCopyOrder_Click(object sender, EventArgs e)
    {
      if (CustomOrder == null)
      {
        return;
      }

      var copyOrderForm = new CopyOrderForm();
      copyOrderForm.ShowDialog();
      if(copyOrderForm.CustomOrderNumber != -1)
      {
        CustomOrder = BCustomOrder.Copy(CustomOrder.ID, copyOrderForm.CustomOrderNumber);
        SelectedVentilatorID = 0;
        InitializeGridData();
      }
    }
  }
}
