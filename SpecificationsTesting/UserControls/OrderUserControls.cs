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
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            this.btnCreateVentilator.Click += new System.EventHandler(this.btnCreateVentilator_Click);
            this.btnRemoveVentilator.Click += new System.EventHandler(this.btnRemoveVentilator_Click);
            this.btnSelectTemplateMotor.Click += new System.EventHandler(this.btnSelectTemplateMotor_Click);
            this.btnCopyOrder.Click += new System.EventHandler(this.btnCopyOrder_Click);
            this.btnMotorTypePlate.Click += new System.EventHandler(this.btnMotorTypePlate_Click);
            this.CustomOrderVentilatorsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomOrderVentilatorsDataGrid_RowEnter);

            InitializeGridColumns();
            InitializeGridData();
            SelectedVentilatorID = -1;
            btnSaveChanges.Enabled = false;
            btnCreateVentilator.Enabled = false;
            btnRemoveVentilator.Enabled = false;
            btnCopyOrder.Enabled = false;
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
            var pressureDynamic = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().ToList().First(x => x.Cells["Description"].Value.ToString().Equals("HighPressureDynamic")).Cells["Value"];
            pressureDynamic.ReadOnly = true;
            pressureDynamic.Style.BackColor = Color.LightGray;

            pressureDynamic = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().ToList().First(x => x.Cells["Description"].Value.ToString().Equals("LowPressureDynamic")).Cells["Value"];
            pressureDynamic.ReadOnly = true;
            pressureDynamic.Style.BackColor = Color.LightGray;

            var shaftPower = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().ToList().First(x => x.Cells["Description"].Value.ToString().Equals("HighShaftPower")).Cells["Value"];
            shaftPower.ReadOnly = true;
            shaftPower.Style.BackColor = Color.LightGray;

            shaftPower = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().ToList().First(x => x.Cells["Description"].Value.ToString().Equals("LowShaftPower")).Cells["Value"];
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
                CustomOrderDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrder), CustomOrder, BCustomOrder.OrderDisplayPropertyNames);
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
                VentilatorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilator), ventilator, BCustomOrderVentilator.OrderDisplayPropertyNames);
                VentilatorDataGrid.AutoResizeColumns();

                ConfigDataGrid.DataSource = null;
                ConfigDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilator), ventilator, BCustomOrderVentilator.ConfigurationDisplayPropertyNames);
                ConfigDataGrid.AutoResizeColumns();

                if (ventilator.CustomOrderMotor == null)
                    ventilator.CustomOrderMotor = new CustomOrderMotor();

                MotorDataGrid.DataSource = null;
                MotorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderMotor), ventilator.CustomOrderMotor, BCustomOrderMotor.OrderDisplayPropertyNames);
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
            CustomOrder = ReadCustomOrderDataGrid();
            if (!BCustomOrder.Validate(CustomOrder))
                return;

            var customOrderVentilator = ReadCustomOrderVentilatorDataGrid();

            CustomOrderMotor customOrderMotor;
            if (SelectedTemplateMotor != null)
                customOrderMotor = new CustomOrderMotor() { Name = SelectedTemplateMotor.Name, HighAmperage = SelectedTemplateMotor.HighAmperage, LowAmperage = SelectedTemplateMotor.LowAmperage, 
                    BuildingType = SelectedTemplateMotor.BuildingType, Frequency = SelectedTemplateMotor.Frequency, IEC = SelectedTemplateMotor.IEC, IP = SelectedTemplateMotor.IP, 
                    ISO = SelectedTemplateMotor.ISO, HighPower = SelectedTemplateMotor.HighPower, LowPower = SelectedTemplateMotor.LowPower, PowerFactor = SelectedTemplateMotor.PowerFactor, 
                    HighRPM = SelectedTemplateMotor.HighRPM, LowRPM = SelectedTemplateMotor.LowRPM, StartupAmperage = SelectedTemplateMotor.StartupAmperage, Type = SelectedTemplateMotor.Type, 
                    Version = SelectedTemplateMotor.Version, VoltageType = SelectedTemplateMotor.VoltageType, VoltageTypeID = SelectedTemplateMotor.VoltageTypeID };
            else
                customOrderMotor = ReadCustomOrderMotorDataGrid();

            if (!BCustomOrderMotor.Validate(customOrderMotor))
                return;

            customOrderVentilator.CustomOrderMotor = customOrderMotor;
            BCustomOrderVentilator.Calculate(customOrderVentilator);
            if (!BCustomOrderVentilator.Validate(customOrderVentilator))
                return;

            CustomOrder = BCustomOrder.Create(CustomOrder);
            if(CustomOrder != null)
            {
                customOrderVentilator.CustomOrderID = CustomOrder.ID;
                BCustomOrderMotor.Create(customOrderVentilator.CustomOrderMotor);
                customOrderVentilator.CustomOrderMotorID = customOrderVentilator.CustomOrderMotor.ID;
                customOrderVentilator.CustomOrderMotor = null;
                customOrderVentilator.VentilatorType = null;
                BCustomOrderVentilator.Create(customOrderVentilator);
                CustomOrder = BCustomOrder.ByCustomOrderNumber(CustomOrder.CustomOrderNumber);
                txtCustomOrderNumber.Text = CustomOrder.CustomOrderNumber.ToString();
                InitializeGridData();
            }
        }


        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                var customOrder = ReadCustomOrderDataGrid();
                if (!BCustomOrder.Validate(customOrder))
                    return;

                customOrder.ID = CustomOrder.ID;
                var index = CustomOrder.CustomOrderVentilators.ToList().FindIndex(x => x.ID == SelectedVentilatorID);
                var customOrderVentilator = CustomOrder.CustomOrderVentilators.ToList()[index];
                var ventilatorID = customOrderVentilator.ID;
                var motorID = customOrderVentilator.CustomOrderMotorID;
                customOrderVentilator = ReadCustomOrderVentilatorDataGrid();
                var motor = ReadCustomOrderMotorDataGrid();
                motor.ID = motorID;
                customOrderVentilator.CustomOrderMotorID = motorID;
                customOrderVentilator.CustomOrderMotor = motor;

                if (!BCustomOrderMotor.Validate(motor))
                    return;

                BCustomOrderVentilator.Calculate(customOrderVentilator);
                if (!BCustomOrderVentilator.Validate(customOrderVentilator))
                    return;

                customOrderVentilator.ID = ventilatorID;
                BCustomOrder.Update(customOrder);
                BCustomOrderVentilator.Update(customOrderVentilator);
                BCustomOrderMotor.Update(customOrderVentilator.CustomOrderMotor);
                CustomOrder = BCustomOrder.ByCustomOrderNumber(customOrder.CustomOrderNumber);
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
                var newCustomOrderVentilator = ReadCustomOrderVentilatorComboboxes();
                return BCustomOrderVentilator.CreateObject(newCustomOrderVentilator, rows);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private CustomOrderVentilator ReadCustomOrderVentilatorComboboxes()
        {
            return new CustomOrderVentilator
            {
                SoundLevelTypeID = (int?)cmbSoundLevelType.SelectedValue,
                VentilatorTypeID = (int?)cmbVentilatorType.SelectedValue,
                GroupTypeID = (int?)cmbGroupType.SelectedValue,
                TemperatureClassID = (int?)cmbTemperatureClassType.SelectedValue,
                CatID = (int?)cmbCatType.SelectedValue,
                CatOutID = (int?)cmbCatOutType.SelectedValue
            }; ;
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
            btnCopyOrder.Enabled = true;
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
            btnCopyOrder.Enabled = false;
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
                var copiedMotor = new CustomOrderMotor() { Name = selectedMotor.Name, HighAmperage = selectedMotor.HighAmperage, LowAmperage = selectedMotor.LowAmperage, 
                    BuildingType = selectedMotor.BuildingType, Frequency = selectedMotor.Frequency, IEC = selectedMotor.IEC, IP = selectedMotor.IP, ISO = selectedMotor.ISO, 
                    HighPower = selectedMotor.HighPower, LowPower = selectedMotor.LowPower, PowerFactor = selectedMotor.PowerFactor, 
                    HighRPM = selectedMotor.HighRPM, LowRPM = selectedMotor.LowRPM, StartupAmperage = selectedMotor.StartupAmperage, Type = selectedMotor.Type, 
                    Version = selectedMotor.Version, VoltageType = selectedMotor.VoltageType, VoltageTypeID = selectedMotor.VoltageTypeID };
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

            if(int.TryParse(templateMotorSelectionDialog.SelectedRow.Cells[0].Value.ToString(), out int motorTemplateId))
            {
                SelectedTemplateMotor = BTemplateMotor.GetById(motorTemplateId);
                txtSelectedMotor.Text = SelectedTemplateMotor.Name;
            }            
        }

        private void btnCopyOrder_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null && CustomOrder.ID == -1)
            {
                MessageBox.Show("Please search the order to copy.");
                return;
            }

            var copyOrderForm = new CopyOrderForm();
            copyOrderForm.ShowDialog();
            if (copyOrderForm.CustomOrderNumber != -1)
            {
                var customOrder = BCustomOrder.Copy(CustomOrder.ID, copyOrderForm.CustomOrderNumber);
                if (customOrder != null)
                {
                    MessageBox.Show($"Data of CustomOrderNumber: {CustomOrder.CustomOrderNumber} copied to new CustomOrderNumber: {customOrder.CustomOrderNumber}.");
                    CustomOrder = customOrder;
                }
                SelectedVentilatorID = 0;
                InitializeGridData();
                btnCreateCO.Enabled = true;
            }
        }

        private void btnMotorTypePlate_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null && CustomOrder.CustomOrderNumber != 0)
            {
                MessageBox.Show("Please search a order first.");
                return;
            }
            var mainForm = (MainForm)this.ParentForm;
            mainForm.TabControl.SelectedIndex = 2;
            mainForm.MotorTypePlateUserControl.SelectCustomOrder(CustomOrder.CustomOrderNumber);
        }
        
        private void Show_Combobox(DataGridViewCell cell, ComboBox comboBox)
        {
            Rectangle rect = cell.DataGridView.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, false);
            int x = rect.X + cell.DataGridView.Left;
            int y = rect.Y + cell.DataGridView.Top;
            comboBox.SetBounds(x, y, rect.Width, rect.Height);
            comboBox.Visible = true;
            comboBox.Focus();
        }
    }
}
