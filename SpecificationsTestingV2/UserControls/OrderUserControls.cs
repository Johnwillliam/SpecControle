using EntityFrameworkModelV2.Context;
using EntityFrameworkModelV2.Models;
using Logic;
using Logic.Business;
using SpecificationsTesting.Entities;
using SpecificationsTesting.Forms;
using SpecificationsTestingV2.Entities;
using System.Data;

namespace SpecificationsTesting.UserControls
{
    public partial class OrderUserControl : UserControl
    {
        public CustomOrder CustomOrder { get; set; }
        public int SelectedVentilatorID { get; set; }

        private CustomOrderVentilator SelectedVentilator => CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == GetSelectedVentilatorID()) ?? CustomOrder.CustomOrderVentilators.First();

        private int GetSelectedVentilatorID() => SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder?.CustomOrderVentilators?.First()?.ID ?? -1 : SelectedVentilatorID;

        public OrderUserControl()
        {
            InitializeComponent();
            AttachEventHandlers();
            InitializeGridColumns();
            InitializeGridData();
            InitializeDefaultValues();
        }

        private void InitializeDefaultValues()
        {
            SelectedVentilatorID = -1;
            btnSaveChanges.Enabled = false;
            btnCreateVentilator.Enabled = false;
            btnRemoveVentilator.Enabled = false;
            btnCopyOrder.Enabled = false;
            btnAtex.Enabled = false;
            btnMotorTypePlate.Enabled = true;
        }

        private void AttachEventHandlers()
        {
            btnCreateCO.Click += (s, e) => BtnCreateCO_Click(s, e);
            btnSearch.Click += (s, e) => BtnSearch_Click(s, e);
            btnClear.Click += (s, e) => BtnClear_Click(s, e);
            btnSaveChanges.Click += (s, e) => BtnSaveChanges_Click(s, e);
            btnCreateVentilator.Click += (s, e) => BtnCreateVentilator_Click(s, e);
            btnRemoveVentilator.Click += (s, e) => BtnRemoveVentilator_Click(s, e);
            btnSelectTemplateMotor.Click += (s, e) => BtnSelectTemplateMotor_Click(s, e);
            btnCopyOrder.Click += (s, e) => BtnCopyOrder_Click(s, e);
            btnMotorTypePlate.Click += (s, e) => BtnMotorTypePlate_Click(s, e);
            btnAtex.Click += (s, e) => BtnAtex_Click(s, e);

            txtCustomOrderNumber.KeyDown += (s, e) =>
            {
                if (e.KeyData == Keys.Enter)
                {
                    SearchOrder();
                }
            };
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
            using SpecificationsDatabaseModel dbContext = new();
            InitializeComboBox(cmbSoundLevelType, dbContext.SoundLevelTypes, nameof(CustomOrderVentilator.SoundLevelTypeID), "ID", "Description", VentilatorDataGrid);
            InitializeComboBox(cmbVentilatorType, dbContext.VentilatorTypes, nameof(CustomOrderVentilator.VentilatorTypeID), "ID", "Description", VentilatorDataGrid);
            InitializeComboBox(cmbGroupType, dbContext.GroupTypes, nameof(CustomOrderVentilator.GroupTypeID), "ID", "Description", ConfigDataGrid);
            InitializeComboBox(cmbTemperatureClassType, dbContext.TemperatureClasses, nameof(CustomOrderVentilator.TemperatureClassID), "ID", "Description", ConfigDataGrid);
            InitializeComboBox(cmbCatType, dbContext.CatTypes, nameof(CustomOrderVentilator.CatTypeID), "ID", "Description", ConfigDataGrid);
            InitializeComboBox(cmbCatOutType, dbContext.CatTypes, nameof(CustomOrderVentilator.CatOutID), "ID", "Description", ConfigDataGrid);

            var yesNoDataSource = new List<YesNoItem>
            {
                new() { Value = true, DisplayText = "Yes" },
                new() { Value = false, DisplayText = "No" }
            }.AsQueryable();
            InitializeComboBox(cmbPTC, yesNoDataSource, nameof(CustomOrderMotor.PTC), nameof(YesNoItem.Value), nameof(YesNoItem.DisplayText), MotorDataGrid);
            InitializeComboBox(cmbHT, yesNoDataSource, nameof(CustomOrderMotor.HT), nameof(YesNoItem.Value), nameof(YesNoItem.DisplayText), MotorDataGrid);

            var ventilator = SelectedVentilator;
            SetComboBoxValue(cmbSoundLevelType, ventilator.SoundLevelTypeID);
            SetComboBoxValue(cmbVentilatorType, ventilator.VentilatorTypeID);
            SetComboBoxValue(cmbGroupType, ventilator.GroupTypeID);
            SetComboBoxValue(cmbCatType, ventilator.CatTypeID);
            SetComboBoxValue(cmbCatOutType, ventilator.CatOutID);
            SetComboBoxValue(cmbTemperatureClassType, ventilator.TemperatureClassID);
            SetComboBoxValue(cmbPTC, ventilator.CustomOrderMotor.PTC);
            SetComboBoxValue(cmbHT, ventilator.CustomOrderMotor.HT);
        }

        private static void InitializeComboBox<T>(ComboBox comboBox, IQueryable<T> dataSource, string cellDescription, string valueMember, string displayMember, DataGridView dataGridView)
        {
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.DataSource = dataSource.ToList();
            comboBox.SelectedIndex = -1;

            var cell = dataGridView.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals(cellDescription)).Cells["Value"];
            Show_Combobox(cell, comboBox);
        }

        private static void SetComboBoxValue<T>(ComboBox comboBox, T value)
        {
            comboBox.SelectedValue = object.Equals(value, default(T)) ? -1 : value;
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
            var ventilatorDataGridRows = VentilatorDataGrid.Rows.Cast<DataGridViewRow>().ToList();
            var configDataGridRows = ConfigDataGrid.Rows.Cast<DataGridViewRow>().ToList();

            var rowsToDisable = new List<string>
            {
                nameof(CustomOrderVentilator.HighPressureDynamic), nameof(CustomOrderVentilator.LowPressureDynamic), nameof(CustomOrderVentilator.HighShaftPower),
                nameof(CustomOrderVentilator.LowShaftPower), nameof(CustomOrderVentilator.LowAirVolume), nameof(CustomOrderVentilator.LowPressureTotal),
                nameof(CustomOrderVentilator.LowPressureStatic), nameof(CustomOrderVentilator.LowRPM), nameof(CustomOrderVentilator.Atex)
            };

            foreach (var rowName in rowsToDisable)
            {
                var ventilatorRow = ventilatorDataGridRows.FirstOrDefault(row => row.Cells["Description"].Value?.ToString() == rowName);
                if (ventilatorRow != null)
                {
                    DataGridObjectsUtility.SetRowReadOnlyAndColor(ventilatorRow, true);
                }

                var configRow = configDataGridRows.FirstOrDefault(row => row.Cells["Description"].Value?.ToString() == rowName);
                if (configRow != null)
                {
                    DataGridObjectsUtility.SetRowReadOnlyAndColor(configRow, true);
                }
            }
        }

        private void InitializeGridData(bool initVentilatorsGrid = true, bool validateVentilator = false)
        {
            try
            {
                CustomOrderDataGrid.DataSource = null;
                CustomOrderDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrder), CustomOrder, BCustomOrder.OrderDisplayPropertyNames);
                CustomOrderDataGrid.AutoResizeColumns();

                if (CustomOrder is null)
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

                var ventilator = SelectedVentilator;
                VentilatorDataGrid.DataSource = null;
                VentilatorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilator), ventilator, BCustomOrderVentilator.OrderDisplayPropertyNames);
                VentilatorDataGrid.AutoResizeColumns();

                ConfigDataGrid.DataSource = null;
                ConfigDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilator), ventilator, BCustomOrderVentilator.ConfigurationDisplayPropertyNames);
                ConfigDataGrid.AutoResizeColumns();

                ventilator.CustomOrderMotor ??= new CustomOrderMotor();
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
            CreateOrder();
        }

        private void CreateOrder()
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
                if (customOrderVentilator is null)
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
                var customOrderVentilator = CustomOrder.CustomOrderVentilators.Single(x => x.ID == GetSelectedVentilatorID());

                var ventilatorID = customOrderVentilator.ID;
                var motorID = customOrderVentilator.CustomOrderMotorID;
                customOrderVentilator = ReadCustomOrderVentilatorDataGrid();
                customOrderVentilator.ID = ventilatorID;
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

                if (BCustomOrderVentilator.ShouldAdjustTests(customOrderVentilator) && !BCustomOrderVentilator.CanAdjustTests(customOrderVentilator))
                {
                    MessageBox.Show("Ventilator tests are locked and cannot be changed, please adjust the amount of ventilators or reload the page. Order is not saved.");
                    return;
                }

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
            return BCustomOrder.CreateCustomOrderObject(rows);
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
                CatTypeID = (int?)cmbCatType.SelectedValue,
                CatOutID = (int?)cmbCatOutType.SelectedValue
            };
        }

        private CustomOrderMotor ReadCustomOrderMotorDataGrid()
        {
            var rows = MotorDataGrid.Rows.Cast<DataGridViewRow>().ToList();
            var customOrderMotor = ReadCustomOrderMotorComboboxes();
            return BCustomOrderMotor.CreateObject(customOrderMotor, rows);
        }

        private CustomOrderMotor ReadCustomOrderMotorComboboxes()
        {
            return new CustomOrderMotor
            {
                PTC = (bool?)cmbPTC.SelectedValue,
                HT = (bool?)cmbHT.SelectedValue,
            };
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
            if (CustomOrder is null)
            {
                MessageBox.Show($"No order found for number: {customOrderNumber}");
                return;
            }
            SelectedVentilatorID = CustomOrder.CustomOrderVentilators.Count > 0 ? CustomOrder.CustomOrderVentilators.First().ID : -1;
            InitializeGridData(validateVentilator: true);
            btnCopyOrder.Enabled = true;

            var ventilator = SelectedVentilator;
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
            var ventilator = SelectedVentilator;
            ventilator = BCustomOrderVentilator.Copy(ventilator);
            CustomOrder = BCustomOrder.ByCustomOrderNumber(CustomOrder.CustomOrderNumber);
            SelectedVentilatorID = ventilator.ID;
            InitializeGridData();
        }

        private void BtnRemoveVentilator_Click(object sender, EventArgs e)
        {
            if (CustomOrderVentilatorsDataGrid.SelectedRows.Count == 0)
            {
                return;
            }

            var customOrderVentilatorId = int.Parse(CustomOrderVentilatorsDataGrid.SelectedRows[0].Cells[0].Value.ToString());
            if (CustomOrder.CustomOrderVentilators.Single(x => x.ID == customOrderVentilatorId).CustomOrderVentilatorTests.Any(x => x.Locked))
            {
                MessageBox.Show("One of the tests of the selected ventilator is locked and therefore the ventilator cannot be removed. \n\nPlease contact IT support if changes has to be done.");
                return;
            }

            if ((MessageBox.Show("Are you sure you want to remove this ventilator?", "Confirm Deletion",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question,
              MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
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
            if (templateMotorSelectionDialog.SelectedRow is null)
            {
                return;
            }

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
            if (CustomOrder is null || CustomOrder.CustomOrderNumber == 0)
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
            if (CustomOrder is null || CustomOrder.CustomOrderNumber == 0)
            {
                MessageBox.Show("Please search a order first.");
                return;
            }

            var ventilator = SelectedVentilator;
            if (!ventilator.IsAtex() || !BValidateMessage.ValidateForPrinting(ventilator))
            {
                return;
            }

            var mainForm = (MainForm)ParentForm;
            mainForm.TabControl.SelectedIndex = 3;
            mainForm.AtexStickerUserControl.SetSelectedVentilator(CustomOrder.CustomOrderNumber, SelectedVentilatorID);
        }

        private static void Show_Combobox(DataGridViewCell cell, ComboBox comboBox)
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

        private void CustomOrderVentilatorsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && int.TryParse(CustomOrderVentilatorsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int ventilatorID))
            {
                SelectedVentilatorID = ventilatorID;
                var ventilator = SelectedVentilator;
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