using EntityFrameworkModel;
using Microsoft.EntityFrameworkCore.Internal;
using SpecificationsTesting.Business;
using SpecificationsTesting.Entities;
using SpecificationsTesting.Forms;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpecificationsTesting.UserControls
{
    public partial class OrderUserControls : UserControl
    {
        public CustomOrder CustomOrder { get; set; }
        public int SelectedVentilatorID { get; set; }
        public TemplateMotor SelectedTemplateMotor { get; set; }
        public OrderUserControls()
        {
            InitializeComponent();
            this.btnCreateCO.Click += new System.EventHandler(this.btnCreateCO_Click);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.CustomOrderVentilatorsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomOrderVentilatorsDataGrid_RowEnter);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            this.btnCreateVentilator.Click += new System.EventHandler(this.btnCreateVentilator_Click);
            this.btnRemoveVentilator.Click += new System.EventHandler(this.btnRemoveVentilator_Click);
            this.btnSelectTemplateMotor.Click += new System.EventHandler(this.btnSelectTemplateMotor_Click);
            this.btnCopyOrder.Click += new System.EventHandler(this.btnCopyOrder_Click);
            this.btnMotorTypePlate.Click += new System.EventHandler(this.btnMotorTypePlate_Click);

            InitializeGridColumns();
            InitializeGridData();
            SelectedVentilatorID = -1;
            btnSaveChanges.Enabled = false;
            btnCreateVentilator.Enabled = false;
            btnRemoveVentilator.Enabled = false;
        }

        private void InitializeComboBoxes()
        {
            using (SpecificationsDatabaseModel dbContext = new SpecificationsDatabaseModel())
            {
                cmbSoundLevelType.DisplayMember = "Description";
                cmbSoundLevelType.ValueMember = "ID";
                cmbSoundLevelType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbSoundLevelType.DataSource = dbContext.SoundLevelTypes.ToList();
                var cell = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().ToList().First(x => x.Cells["Description"].Value.ToString().Equals("SoundLevelTypeID")).Cells["Value"];
                Show_Combobox(cell, cmbSoundLevelType);

                cmbVentilatorType.DisplayMember = "Description";
                cmbVentilatorType.ValueMember = "ID";
                cmbVentilatorType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbVentilatorType.DataSource = dbContext.VentilatorTypes.ToList();
                cell = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().ToList().First(x => x.Cells["Description"].Value.ToString().Equals("VentilatorTypeID")).Cells["Value"];
                Show_Combobox(cell, cmbVentilatorType);

                cmbGroupType.DisplayMember = "Description";
                cmbGroupType.ValueMember = "ID";
                cmbGroupType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbGroupType.DataSource = dbContext.GroupTypes.ToList();
                cell = ConfigDataGrid.Rows.Cast<DataGridViewRow>().ToList().First(x => x.Cells["Description"].Value.ToString().Equals("GroupTypeID")).Cells["Value"];
                Show_Combobox(cell, cmbGroupType);

                cmbTemperatureClassType.DisplayMember = "Description";
                cmbTemperatureClassType.ValueMember = "ID";
                cmbTemperatureClassType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbTemperatureClassType.DataSource = dbContext.TemperatureClasses.ToList();
                cell = ConfigDataGrid.Rows.Cast<DataGridViewRow>().ToList().First(x => x.Cells["Description"].Value.ToString().Equals("TemperatureClassID")).Cells["Value"];
                Show_Combobox(cell, cmbTemperatureClassType);

                cmbCatType.DisplayMember = "Description";
                cmbCatType.ValueMember = "ID";
                cmbCatType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbCatType.DataSource = dbContext.CatTypes.ToList();
                cell = ConfigDataGrid.Rows.Cast<DataGridViewRow>().ToList().First(x => x.Cells["Description"].Value.ToString().Equals("CatID")).Cells["Value"];
                Show_Combobox(cell, cmbCatType);

                cmbCatOutType.DisplayMember = "Description";
                cmbCatOutType.ValueMember = "ID";
                cmbCatOutType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbCatOutType.DataSource = dbContext.CatTypes.ToList();
                cell = ConfigDataGrid.Rows.Cast<DataGridViewRow>().ToList().First(x => x.Cells["Description"].Value.ToString().Equals("CatOutID")).Cells["Value"];
                Show_Combobox(cell, cmbCatOutType);
            }
            var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
            cmbSoundLevelType.SelectedValue = ventilator.SoundLevelTypeID == null ? -1 : ventilator.SoundLevelTypeID;
            cmbVentilatorType.SelectedValue = ventilator.VentilatorTypeID == null ? -1 : ventilator.VentilatorTypeID;
            cmbGroupType.SelectedValue = ventilator.GroupTypeID == null ? -1 : ventilator.GroupTypeID;
            cmbCatType.SelectedValue = ventilator.CatID == null ? -1 : ventilator.CatID;
            cmbCatOutType.SelectedValue = ventilator.CatOutID == null ? -1 : ventilator.CatOutID;
            cmbTemperatureClassType.SelectedValue = ventilator.TemperatureClassID == null ? -1 : ventilator.TemperatureClassID;
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

            ConfigDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description", Name = "Description", ReadOnly = true });
            ConfigDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayValue", Name = "Value", ReadOnly = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            ConfigDataGrid.RowHeadersVisible = false;
            ConfigDataGrid.AutoGenerateColumns = false;
            ConfigDataGrid.AllowUserToResizeRows = false;
        }

        private void CustomOrderVentilatorsDataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void DisableCalculatedRows()
        {
            var pressureDynamic = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().ToList().First(x => x.Cells["Description"].Value.ToString().Equals("PressureDynamic")).Cells["Value"];
            pressureDynamic.ReadOnly = true;
            pressureDynamic.Style.BackColor = Color.LightGray;

            var shaftPower = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().ToList().First(x => x.Cells["Description"].Value.ToString().Equals("ShaftPower")).Cells["Value"];
            shaftPower.ReadOnly = true;
            shaftPower.Style.BackColor = Color.LightGray;

            var atex = ConfigDataGrid.Rows.Cast<DataGridViewRow>().ToList().First(x => x.Cells["Description"].Value.ToString().Equals("Atex")).Cells["Value"];
            atex.ReadOnly = true;
            atex.Style.BackColor = Color.LightGray;
        }

        private void InitializeGridData(bool initVentilatorsGrid = true)
        {
            try
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
                    btnCreateCO.Enabled = true;
                }
                else
                {
                    txtCustomOrderNumber.Text = CustomOrder.CustomOrderNumber.ToString();
                    btnSaveChanges.Enabled = true;
                    btnCreateVentilator.Enabled = true;
                    btnRemoveVentilator.Enabled = true;
                    btnCreateCO.Enabled = false;
                }

                if (CustomOrder.CustomOrderVentilators.Count == 0)
                    CustomOrder.CustomOrderVentilators.Add(new CustomOrderVentilator());

                var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);

                VentilatorDataGrid.DataSource = null;
                VentilatorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilator), ventilator, BCustomOrderVentilator.DisplayPropertyNames);
                VentilatorDataGrid.AutoResizeColumns();

                ConfigDataGrid.DataSource = null;
                ConfigDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilator), ventilator, BCustomOrderVentilator.ConfigurationDisplayPropertyNames);
                ConfigDataGrid.AutoResizeColumns();

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

                InitializeComboBoxes();
                DisableCalculatedRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateCO_Click(object sender, EventArgs e)
        {
            CustomOrderMotor customOrderMotor;
            if (SelectedTemplateMotor != null)
                customOrderMotor = new CustomOrderMotor() { Name = SelectedTemplateMotor.Name, Amperage = SelectedTemplateMotor.Amperage, BuildingType = SelectedTemplateMotor.BuildingType, Frequency = SelectedTemplateMotor.Frequency, IEC = SelectedTemplateMotor.IEC, IP = SelectedTemplateMotor.IP, ISO = SelectedTemplateMotor.ISO, Power = SelectedTemplateMotor.Power, PowerFactor = SelectedTemplateMotor.PowerFactor, RPM = SelectedTemplateMotor.RPM, StartupAmperage = SelectedTemplateMotor.StartupAmperage, Type = SelectedTemplateMotor.Type, Version = SelectedTemplateMotor.Version, VoltageType = SelectedTemplateMotor.VoltageType, VoltageTypeID = SelectedTemplateMotor.VoltageTypeID };
            else
                customOrderMotor = ReadCustomOrderMotorDataGrid();

            if (customOrderMotor == null)
            {
                MessageBox.Show("Creation failed. Missing data.");
                return;
            }

            CustomOrder = ReadCustomOrderDataGrid();
            if (CustomOrder == null)
            {
                MessageBox.Show("Creation failed. Missing data.");
                return;
            }

            if (BCustomOrder.ByCustomOrderNumber(CustomOrder.CustomOrderNumber) != null)
            {
                MessageBox.Show("Creation failed. Order number already exists.");
                return;
            }

            var customOrderVentilator = ReadCustomOrderVentilatorDataGrid();
            if (customOrderVentilator == null)
            {
                MessageBox.Show("Creation failed. Missing data.");
                return;
            }
            customOrderVentilator.CustomOrderMotor = customOrderMotor;

            if (!BCustomOrderVentilator.Validate(customOrderVentilator))
                return;

            CustomOrder = BCustomOrder.Create(CustomOrder);
            customOrderVentilator.CustomOrderID = CustomOrder.ID;
            BCustomOrderVentilator.Create(customOrderVentilator);
            CustomOrder = BCustomOrder.ByCustomOrderNumber(CustomOrder.CustomOrderNumber);
            txtCustomOrderNumber.Text = CustomOrder.CustomOrderNumber.ToString();
            InitializeGridData();
        }

        private CustomOrder ReadCustomOrderDataGrid()
        {
            var rows = CustomOrderDataGrid.Rows.Cast<DataGridViewRow>().ToList();
            return BCustomOrder.CreateObject(rows);
        }

        private CustomOrderVentilator ReadCustomOrderVentilatorDataGrid()
        {
            try
            {
                var rows = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().ToList();
                rows.AddRange(ConfigDataGrid.Rows.Cast<DataGridViewRow>().ToList());
                var newCustomOrderVentilator = new CustomOrderVentilator
                {
                    SoundLevelTypeID = cmbSoundLevelType.SelectedValue == null ? -1 : (int)cmbSoundLevelType.SelectedValue,
                    VentilatorTypeID = cmbVentilatorType.SelectedValue == null ? -1 : (int)cmbVentilatorType.SelectedValue,
                    GroupTypeID = cmbGroupType.SelectedValue == null ? -1 : (int)cmbGroupType.SelectedValue,
                    TemperatureClassID = cmbTemperatureClassType.SelectedValue == null ? -1 : (int)cmbTemperatureClassType.SelectedValue,
                    CatID = cmbCatType.SelectedValue == null ? -1 : (int)cmbCatType.SelectedValue,
                    CatOutID = cmbCatOutType.SelectedValue == null ? -1 : (int)cmbCatOutType.SelectedValue
                };
                return BCustomOrderVentilator.CreateObject(newCustomOrderVentilator, rows);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private CustomOrderMotor ReadCustomOrderMotorDataGrid()
        {
            var rows = MotorDataGrid.Rows.Cast<DataGridViewRow>().ToList();
            return BCustomOrderMotor.CreateObject(rows);
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
            cmbSoundLevelType.SelectedValue = -1;
            cmbVentilatorType.SelectedValue = -1;
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

                if (!BCustomOrderVentilator.Validate(ventilator))
                    return;

                BCustomOrderVentilator.Update(ventilator);
                BCustomOrderMotor.Update(ventilator.CustomOrderMotor);
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
            if (templateMotorSelectionDialog.SelectedRow != null)
            {
                var motorTemplateId = int.Parse(templateMotorSelectionDialog.SelectedRow.Cells[0].Value.ToString());
                CreateVentilatorByTemplateMotorId(motorTemplateId);
            }
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
                CustomOrder = BCustomOrder.ByCustomOrderNumber(CustomOrder.CustomOrderNumber);
                SelectedVentilatorID = 0;
                InitializeGridData();
            }
        }

        private void btnSelectTemplateMotor_Click(object sender, EventArgs e)
        {
            var templateMotorSelectionDialog = new MotorTemplateSelection();
            templateMotorSelectionDialog.ShowDialog();
            if (templateMotorSelectionDialog.SelectedRow == null)
                return;
            var motorTemplateId = int.Parse(templateMotorSelectionDialog.SelectedRow.Cells[0].Value.ToString());
            SelectedTemplateMotor = BTemplateMotor.GetById(motorTemplateId);
            txtSelectedMotor.Text = SelectedTemplateMotor.Name;
        }

        private void btnCopyOrder_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null)
            {
                return;
            }

            var copyOrderForm = new CopyOrderForm();
            copyOrderForm.ShowDialog();
            if (copyOrderForm.CustomOrderNumber != -1)
            {
                CustomOrder = BCustomOrder.Copy(CustomOrder.ID, copyOrderForm.CustomOrderNumber);
                SelectedVentilatorID = 0;
                InitializeGridData();
            }
        }

        private void btnMotorTypePlate_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null)
            {
                return;
            }

            
        }
        
        private void Show_Combobox(DataGridViewCell cell, ComboBox comboBox)
        {
            Rectangle rect = cell.DataGridView.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, false);
            int x = rect.X + cell.DataGridView.Left;
            int y = rect.Y + cell.DataGridView.Top;

            int Width = rect.Width;
            int height = rect.Height;

            comboBox.SetBounds(x, y, Width, height);
            comboBox.Visible = true;
            comboBox.Focus();
        }
    }
}
