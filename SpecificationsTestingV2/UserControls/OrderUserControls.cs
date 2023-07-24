using EntityFrameworkModelV2.Context;
using EntityFrameworkModelV2.Models;
using Logic;
using Logic.Business;
using SpecificationsTesting.Entities;
using SpecificationsTesting.Forms;
using System.Data;

namespace SpecificationsTesting.UserControls
{
    public partial class OrderUserControl : UserControl
    {
        public CustomOrder CustomOrder { get; set; }
        public int SelectedVentilatorID { get; set; }
        public OrderUserControl()
        {
            InitializeComponent();
            btnCreateCO.Click += new System.EventHandler(BtnCreateCO_Click);
            btnSearch.Click += new System.EventHandler(BtnSearch_Click);
            btnClear.Click += new System.EventHandler(BtnClear_Click);
            btnSaveChanges.Click += new System.EventHandler(BtnSaveChanges_Click);
            btnCreateVentilator.Click += new System.EventHandler(BtnCreateVentilator_Click);
            btnRemoveVentilator.Click += new System.EventHandler(BtnRemoveVentilator_Click);
            btnSelectTemplateMotor.Click += new System.EventHandler(BtnSelectTemplateMotor_Click);
            btnCopyOrder.Click += new System.EventHandler(BtnCopyOrder_Click);
            btnMotorTypePlate.Click += new System.EventHandler(BtnMotorTypePlate_Click);
            btnAtex.Click += new System.EventHandler(BtnAtex_Click);

            InitializeGridColumns();
            InitializeGridData();
            SelectedVentilatorID = -1;
            btnSaveChanges.Enabled = false;
            btnCreateVentilator.Enabled = false;
            btnRemoveVentilator.Enabled = false;
            btnCopyOrder.Enabled = false;
            btnAtex.Enabled = false;
            btnMotorTypePlate.Enabled = true;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (Visible && !Disposing)
            {
                InitializeComboBoxes();
            }
        }

        private void InitializeComboBoxes()
        {
            using (SpecificationsDatabaseModel dbContext = new SpecificationsDatabaseModel())
            {
                cmbSoundLevelType.DisplayMember = "Description";
                cmbSoundLevelType.ValueMember = "ID";
                cmbSoundLevelType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbSoundLevelType.DataSource = dbContext.SoundLevelTypes.ToList();
                cmbSoundLevelType.SelectedIndex = -1;
                var cell = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("SoundLevelTypeID")).Cells["Value"];
                Show_Combobox(cell, cmbSoundLevelType);

                cmbVentilatorType.DisplayMember = "Description";
                cmbVentilatorType.ValueMember = "ID";
                cmbVentilatorType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbVentilatorType.DataSource = dbContext.VentilatorTypes.ToList();
                cmbVentilatorType.SelectedIndex = -1;
                cell = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("VentilatorTypeID")).Cells["Value"];
                Show_Combobox(cell, cmbVentilatorType);

                cmbGroupType.DisplayMember = "Description";
                cmbGroupType.ValueMember = "ID";
                cmbGroupType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbGroupType.DataSource = dbContext.GroupTypes.ToList();
                cmbGroupType.SelectedIndex = -1;
                cell = ConfigDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("GroupTypeID")).Cells["Value"];
                Show_Combobox(cell, cmbGroupType);

                cmbTemperatureClassType.DisplayMember = "Description";
                cmbTemperatureClassType.ValueMember = "ID";
                cmbTemperatureClassType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbTemperatureClassType.DataSource = dbContext.TemperatureClasses.ToList();
                cmbTemperatureClassType.SelectedIndex = -1;
                cell = ConfigDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("TemperatureClassID")).Cells["Value"];
                Show_Combobox(cell, cmbTemperatureClassType);

                cmbCatType.DisplayMember = "Description";
                cmbCatType.ValueMember = "ID";
                cmbCatType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbCatType.DataSource = dbContext.CatTypes.ToList();
                cmbCatType.SelectedIndex = -1;
                cell = ConfigDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("CatID")).Cells["Value"];
                Show_Combobox(cell, cmbCatType);

                cmbCatOutType.DisplayMember = "Description";
                cmbCatOutType.ValueMember = "ID";
                cmbCatOutType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbCatOutType.DataSource = dbContext.CatTypes.ToList();
                cmbCatOutType.SelectedIndex = -1;
                cell = ConfigDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("CatOutID")).Cells["Value"];
                Show_Combobox(cell, cmbCatOutType);
            }
            SelectedVentilatorID = SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder.CustomOrderVentilators.First().ID : SelectedVentilatorID;
            var ventilator = CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
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
            var pressureDynamic = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("HighPressureDynamic")).Cells["Value"];
            pressureDynamic.ReadOnly = true;
            pressureDynamic.Style.BackColor = Color.LightGray;

            pressureDynamic = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("LowPressureDynamic")).Cells["Value"];
            pressureDynamic.ReadOnly = true;
            pressureDynamic.Style.BackColor = Color.LightGray;

            var shaftPower = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("HighShaftPower")).Cells["Value"];
            shaftPower.ReadOnly = true;
            shaftPower.Style.BackColor = Color.LightGray;

            shaftPower = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("LowShaftPower")).Cells["Value"];
            shaftPower.ReadOnly = true;
            shaftPower.Style.BackColor = Color.LightGray;

            var atex = ConfigDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("Atex")).Cells["Value"];
            atex.ReadOnly = true;
            atex.Style.BackColor = Color.LightGray;

            var lowAirvolume = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("LowAirVolume")).Cells["Value"];
            lowAirvolume.ReadOnly = true;
            lowAirvolume.Style.BackColor = Color.LightGray;

            var lowPressureTotal = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("LowPressureTotal")).Cells["Value"];
            lowPressureTotal.ReadOnly = true;
            lowPressureTotal.Style.BackColor = Color.LightGray;

            var lowPressureStatic = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("LowPressureStatic")).Cells["Value"];
            lowPressureStatic.ReadOnly = true;
            lowPressureStatic.Style.BackColor = Color.LightGray;

            var lowShaftPower = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("LowShaftPower")).Cells["Value"];
            lowShaftPower.ReadOnly = true;
            lowShaftPower.Style.BackColor = Color.LightGray;

            var lowRPM = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("LowRPM")).Cells["Value"];
            lowRPM.ReadOnly = true;
            lowRPM.Style.BackColor = Color.LightGray;
        }

        private void InitializeGridData(bool initVentilatorsGrid = true, bool validateVentilator = false)
        {
            try
            {
                CustomOrderDataGrid.DataSource = null;
                CustomOrderDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrder), CustomOrder, BCustomOrder.OrderDisplayPropertyNames);
                CustomOrderDataGrid.AutoResizeColumns();

                if (CustomOrder == null)
                {
                    CustomOrder = new CustomOrder { ID = -1 };
                    btnSaveChanges.Enabled = false;
                    btnCreateVentilator.Enabled = false;
                    btnRemoveVentilator.Enabled = false;
                    btnCreateCO.Enabled = true;
                }
                else if (CustomOrder.ID != -1)
                {
                    txtCustomOrderNumber.Text = CustomOrder.CustomOrderNumber.ToString();
                    btnSaveChanges.Enabled = true;
                    btnCreateVentilator.Enabled = true;
                    btnRemoveVentilator.Enabled = true;
                    btnCreateCO.Enabled = false;
                }

                if (CustomOrder.CustomOrderVentilators.Count == 0)
                {
                    CustomOrder.CustomOrderVentilators.Add(new CustomOrderVentilator());
                }

                SelectedVentilatorID = SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder.CustomOrderVentilators.First().ID : SelectedVentilatorID;
                var ventilator = CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);

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
                    if (SelectedVentilatorID > 0)
                    {
                        CustomOrderVentilatorsDataGrid.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => (int)x.Cells[0].Value == SelectedVentilatorID).Selected = true;
                    }
                }

                InitializeComboBoxes();
                DisableCalculatedRows();
                if (validateVentilator)
                {
                    BCustomOrderVentilator.Validate(ventilator);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void BtnCreateCO_Click(object sender, EventArgs e)
        {
            try
            {
                CustomOrder = ReadCustomOrderDataGrid();
                if (!BCustomOrder.Validate(CustomOrder))
                {
                    MessageBox.Show("Please check the filled in data. Order is not saved.");
                    return;
                }

                var customOrderVentilator = ReadCustomOrderVentilatorDataGrid();
                if (customOrderVentilator == null)
                {
                    MessageBox.Show("Please check the filled in ventilator data. Order is not saved.");
                    return;
                }

                CustomOrderMotor customOrderMotor = ReadCustomOrderMotorDataGrid();
                if (!BCustomOrderMotor.Validate(customOrderMotor))
                {
                    MessageBox.Show("Please check the filled in motor data. Order is not saved.");
                    return;
                }

                customOrderVentilator.CustomOrderMotor = customOrderMotor;
                BCustomOrderVentilator.Calculate(customOrderVentilator);
                if (!BCustomOrderVentilator.Validate(customOrderVentilator))
                {
                    MessageBox.Show("Please check the filled in ventilator and motor data. Order is not saved.");
                    return;
                }

                CustomOrder = BCustomOrder.Create(CustomOrder);
                if (CustomOrder != null)
                {
                    customOrderVentilator.CustomOrderID = CustomOrder.ID;
                    BCustomOrderMotor.Create(customOrderVentilator.CustomOrderMotor);
                    customOrderVentilator.CustomOrderMotorID = customOrderVentilator.CustomOrderMotor.ID;
                    customOrderVentilator.CustomOrderMotor = null;
                    customOrderVentilator.VentilatorType = null;
                    BCustomOrderVentilator.Create(customOrderVentilator);
                    CustomOrder = BCustomOrder.ByCustomOrderNumber(CustomOrder.CustomOrderNumber);
                    txtCustomOrderNumber.Text = CustomOrder.CustomOrderNumber.ToString();
                    SelectedVentilatorID = CustomOrder.CustomOrderVentilators.First().ID;
                    InitializeGridData();
                    MessageBox.Show("Order succesfully created.");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                var customOrder = ReadCustomOrderDataGrid();
                if (!BCustomOrder.Validate(customOrder))
                {
                    MessageBox.Show("Please check the filled in data. Order is not saved.");
                    return;
                }

                customOrder.ID = CustomOrder.ID;
                SelectedVentilatorID = SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder.CustomOrderVentilators.First().ID : SelectedVentilatorID;
                var customOrderVentilator = CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);

                var ventilatorID = customOrderVentilator.ID;
                var motorID = customOrderVentilator.CustomOrderMotorID;
                customOrderVentilator = ReadCustomOrderVentilatorDataGrid();
                var motor = ReadCustomOrderMotorDataGrid();
                motor.ID = motorID;
                customOrderVentilator.CustomOrderMotorID = motorID;
                customOrderVentilator.CustomOrderMotor = motor;

                if (!BCustomOrderMotor.Validate(motor))
                {
                    MessageBox.Show("Please check the filled in motor data. Order is not saved.");
                    return;
                }

                BCustomOrderVentilator.Calculate(customOrderVentilator);
                if (!BCustomOrderVentilator.Validate(customOrderVentilator))
                {
                    MessageBox.Show("Please check the filled in ventilator and motor data. Order is not saved.");
                    return;
                }

                customOrderVentilator.ID = ventilatorID;
                BCustomOrder.Update(customOrder);
                BCustomOrderVentilator.Update(customOrderVentilator);
                BCustomOrderMotor.Update(customOrderVentilator.CustomOrderMotor);
                CustomOrder = BCustomOrder.ByCustomOrderNumber(customOrder.CustomOrderNumber);
                InitializeGridData();
                SearchOrder();
                MessageBox.Show("Sucessful updated");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
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
            };
        }

        private CustomOrderMotor ReadCustomOrderMotorDataGrid()
        {
            var rows = MotorDataGrid.Rows.Cast<DataGridViewRow>().ToList();
            return BCustomOrderMotor.CreateObject(rows);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchOrder();
        }

        private void SearchOrder()
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
            SelectedVentilatorID = CustomOrder.CustomOrderVentilators.Count > 0 ? CustomOrder.CustomOrderVentilators.First().ID : -1;
            InitializeGridData(validateVentilator: true);
            btnCopyOrder.Enabled = true;

            var ventilator = CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
            if (ventilator != null)
            {
                EnableReportButtons(ventilator);
            }
        }

        private void CmbMotorFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            CustomOrder = null;
            SelectedVentilatorID = -1;
            txtCustomOrderNumber.Text = "";
            cmbSoundLevelType.SelectedValue = -1;
            cmbVentilatorType.SelectedValue = -1;
            btnCopyOrder.Enabled = false;
            InitializeGridData();
        }

        private void BtnCreateVentilator_Click(object sender, EventArgs e)
        {
            var ventilator = SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
            ventilator = BCustomOrderVentilator.Copy(ventilator);
            CustomOrder = BCustomOrder.ByCustomOrderNumber(CustomOrder.CustomOrderNumber);
            SelectedVentilatorID = ventilator.ID;
            InitializeGridData();
        }

        private void BtnRemoveVentilator_Click(object sender, EventArgs e)
        {
            if (CustomOrderVentilatorsDataGrid.SelectedRows.Count == 0)
                return;

            if ((MessageBox.Show("Are you sure you want to remove this ventilator?", "Confirm Deletion",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                var customOrderVentilatorId = int.Parse(CustomOrderVentilatorsDataGrid.SelectedRows[0].Cells[0].Value.ToString());
                BCustomOrderVentilator.DeleteById(customOrderVentilatorId);
                CustomOrder = BCustomOrder.ByCustomOrderNumber(CustomOrder.CustomOrderNumber);
                SelectedVentilatorID = CustomOrder.CustomOrderVentilators.First().ID;
                InitializeGridData();
            }
        }

        private void BtnSelectTemplateMotor_Click(object sender, EventArgs e)
        {
            var templateMotorSelectionDialog = new MotorTemplateSelection();
            templateMotorSelectionDialog.ShowDialog();
            if (templateMotorSelectionDialog.SelectedRow == null)
                return;

            if (int.TryParse(templateMotorSelectionDialog.SelectedRow.Cells[0].Value.ToString(), out int motorTemplateId))
            {
                var templateMotor = BTemplateMotor.GetById(motorTemplateId);
                var existingVentilator = CustomOrder.CustomOrderVentilators.First();
                if (CustomOrder.CustomOrderVentilators.Any(x => x.ID == SelectedVentilatorID))
                {
                    existingVentilator = CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
                }

                BCustomOrderMotor.UpdateFromTemplate(existingVentilator.CustomOrderMotor, templateMotor);
                InitializeGridData();
            }
        }

        private void BtnCopyOrder_Click(object sender, EventArgs e)
        {
            if (CustomOrder?.ID == -1)
            {
                MessageBox.Show("Please search the order to copy first before copying.");
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
                    CustomOrder = BCustomOrder.ByCustomOrderNumber(customOrder.CustomOrderNumber);
                    SelectedVentilatorID = customOrder.CustomOrderVentilators.First().ID;
                }
                InitializeGridData();
                btnCreateCO.Enabled = true;
            }
        }

        private void BtnMotorTypePlate_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null || CustomOrder.CustomOrderNumber == 0)
            {
                MessageBox.Show("Please search a order first.");
                return;
            }

            if (!BValidateMessage.ValidateForPrinting(CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID)))
            {
                return;
            }

            var mainForm = (MainForm)ParentForm;
            mainForm.TabControl.SelectedIndex = 2;
            mainForm.MotorTypePlateUserControl.SetSelectedVentilator(CustomOrder.CustomOrderNumber, SelectedVentilatorID);
        }

        private void BtnAtex_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null || CustomOrder.CustomOrderNumber == 0)
            {
                MessageBox.Show("Please search a order first.");
                return;
            }

            var ventilator = CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
            if (!ventilator.IsAtex() || !BValidateMessage.ValidateForPrinting(ventilator))
            {
                return;
            }

            var mainForm = (MainForm)ParentForm;
            mainForm.TabControl.SelectedIndex = 3;
            mainForm.AtexStickerUserControl.SetSelectedVentilator(CustomOrder.CustomOrderNumber, SelectedVentilatorID);
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

        private void OrderUserControl_Load(object sender, EventArgs e)
        {
            DisableCalculatedRows();
        }

        private void TxtCustomOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SearchOrder();
            }
        }

        private void CustomOrderVentilatorsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && int.TryParse(CustomOrderVentilatorsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int ventilatorID))
            {
                SelectedVentilatorID = ventilatorID;
                var ventilator = CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
                if (ventilator != null)
                {
                    EnableReportButtons(ventilator);
                    InitializeGridData(false);
                }
            }
        }

        private void EnableReportButtons(CustomOrderVentilator ventilator)
        {
            btnAtex.Enabled = ventilator.IsAtex();
            btnMotorTypePlate.Enabled = !ventilator.IsAtex();
        }
    }
}
