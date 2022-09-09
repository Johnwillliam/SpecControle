using EntityFrameworkModel;
using SpecificationsTesting.Business;
using SpecificationsTesting.Entities;
using SpecificationsTesting.Forms;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace SpecificationsTesting.UserControls
{
    public partial class ControleUserControl : UserControl
    {
        public CustomOrder CustomOrder { get; set; }
        public int SelectedVentilatorID { get; set; }
        public int SelectedVentilatorTestID { get; set; }
        public TemplateMotor SelectedTemplateMotor { get; set; }
        private readonly SerialPort SerialPort = new SerialPort(ConfigurationManager.AppSettings.Get("SerialPortName"), int.Parse(ConfigurationManager.AppSettings.Get("SerialPortBaudRate")), Parity.None, 8, StopBits.One);

        public ControleUserControl()
        {
            InitializeComponent();
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.CustomOrderVentilatorsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomOrderVentilatorsDataGrid_RowEnter);
            this.CustomOrderVentilatorTestsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomOrderVentilatorTestsDataGrid_RowEnter);
            this.CustomOrderVentilatorsDataGrid.RowPrePaint += new DataGridViewRowPrePaintEventHandler(CustomOrderVentilatorsDataGrid_RowPrePaint);
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.radioButtonMotorHigh.CheckedChanged += new System.EventHandler(this.radioButtonMotorHigh_CheckedChanged);
            this.radioButtonMotorLow.CheckedChanged += new System.EventHandler(this.radioButtonMotorLow_CheckedChanged);
            this.radioButtonVentilatorHigh.CheckedChanged += new System.EventHandler(this.radioButtonVentilatorHigh_CheckedChanged);
            this.radioButtonVentilatorLow.CheckedChanged += new System.EventHandler(this.radioButtonVentilatorLow_CheckedChanged);
            this.btnReadRPM.Click += new System.EventHandler(this.btnReadRPM_Click);
            this.btnMotorTypePlate.Click += new System.EventHandler(this.btnMotorTypePlate_Click);
            this.btnAtex.Click += new System.EventHandler(this.btnAtex_Click);

            CustomOrder = null;
            SelectedVentilatorID = 0;
            SelectedVentilatorTestID = 0;
            txtCustomOrderNumber.Text = "";

            InitializeGridColumns();
            InitializeComboBoxes();
            SerialPort.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
        }

        private void InitializeComboBoxes()
        {
            using (SpecificationsDatabaseModel dbContext = new SpecificationsDatabaseModel())
            {
                cmbUser.DisplayMember = "Name";
                cmbUser.ValueMember = "ID";
                cmbUser.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbUser.DataSource = dbContext.Users.ToList();
                var cell = CustomOrderVentilatorTestsDataGrid.Rows.Count == 0 ? null : SelectedVentilatorTestDataGrid.Rows.Cast<DataGridViewRow>().ToList().First(x => x.Cells["Description"].Value.ToString().Equals("UserID")).Cells["Value"];
                Show_Combobox(cell, cmbUser);
            }
        }

        private void Show_Combobox(DataGridViewCell cell, ComboBox comboBox)
        {
            if (cell == null)
            {
                comboBox.Visible = false;
                return;
            }

            comboBox.Visible = true;
            Rectangle rect = cell.DataGridView.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, false);
            int x = rect.X + cell.DataGridView.Left;
            int y = rect.Y + cell.DataGridView.Top;
            comboBox.SetBounds(x, y, rect.Width, rect.Height);
            comboBox.Visible = true;
            comboBox.Focus();
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

            CustomOrderVentilatorTestsDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "ID", ReadOnly = true });
            CustomOrderVentilatorTestsDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Name", DataPropertyName = "Name", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            CustomOrderVentilatorTestsDataGrid.RowHeadersVisible = false;
            CustomOrderVentilatorTestsDataGrid.AutoGenerateColumns = false;
            CustomOrderVentilatorTestsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorTestsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomOrderVentilatorTestsDataGrid.MultiSelect = false;

            SelectedVentilatorTestDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description", Name = "Description", ReadOnly = true });
            SelectedVentilatorTestDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayValue", Name = "Value", ReadOnly = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            SelectedVentilatorTestDataGrid.RowHeadersVisible = false;
            SelectedVentilatorTestDataGrid.AutoGenerateColumns = false;
            SelectedVentilatorTestDataGrid.AllowUserToResizeRows = false;
        }

        private void CustomOrderVentilatorsDataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void InitializeGridData(bool initVentilatorsGrid = true, bool initVentilatorTestsGrid = true)
        {
            try
            {
                CustomOrderDataGrid.DataSource = null;
                CustomOrderDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrder), CustomOrder, BCustomOrder.ControleDisplayPropertyNames);
                CustomOrderDataGrid.AutoResizeColumns();

                if (CustomOrder == null)
                    CustomOrder = new CustomOrder { ID = -1 };

                if (CustomOrder.CustomOrderVentilators.Count == 0)
                {
                    var emptyVentilator = new CustomOrderVentilator();
                    emptyVentilator.CustomOrderVentilatorTests.Add(new CustomOrderVentilatorTest());
                    CustomOrder.CustomOrderVentilators.Add(emptyVentilator);
                }

                var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
                VentilatorDataGrid.DataSource = null;
                VentilatorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilator), ventilator, BCustomOrderVentilator.ControleDisplayPropertyNames);
                VentilatorDataGrid.AutoResizeColumns();

                var selectedTest = SelectedVentilatorTestID == 0 ? ventilator.CustomOrderVentilatorTests.First() : ventilator.CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);
                if (selectedTest != null && selectedTest.Date == null)
                    selectedTest.Date = DateTime.Now.Date;

                SelectedVentilatorTestDataGrid.DataSource = null;
                SelectedVentilatorTestDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilatorTest), selectedTest, BCustomOrderVentilatorTest.ControleDisplayPropertyNames);
                SelectedVentilatorTestDataGrid.AutoResizeColumns();

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

                if (initVentilatorTestsGrid)
                {
                    CustomOrderVentilatorTestsDataGrid.DataSource = null;
                    if (ventilator.CustomOrderVentilatorTests.Count >= 1 && ventilator.CustomOrderVentilatorTests.First().ID != 0)
                    {
                        CustomOrderVentilatorTestsDataGrid.DataSource = ventilator.CustomOrderVentilatorTests.Select(x => new { x.ID, x.CustomOrderVentilator.Name }).ToList();
                    }
                    CustomOrderVentilatorTestsDataGrid.AutoResizeColumns();
                }
                InitializeComboBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowCustomOrder();
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
                ClearDataGrids();
                return;
            }
            if (CustomOrder.CustomOrderVentilators.Count == 0)
            {
                MessageBox.Show($"No ventilators found, please create a ventilator first.");
                ClearDataGrids();
                return;
            }
            SelectedVentilatorID = 0;
            SelectedVentilatorTestID = 0;
            InitializeGridData();

            if (CustomOrder.CustomOrderVentilators.FirstOrDefault().LowRPM == null)
                ShowSingleRPMSelection();
            else
                ShowAllRPMSelection();
        }

        private void ShowSingleRPMSelection()
        {
            radioButtonMotorLow.Visible = false;
            radioButtonVentilatorLow.Visible = false;

            radioButtonMotorHigh.Text = "Motor RPM";
            radioButtonVentilatorHigh.Text = "Ventilator RPM";
        }

        private void ShowAllRPMSelection()
        {
            radioButtonMotorLow.Visible = true;
            radioButtonVentilatorLow.Visible = true;

            radioButtonMotorHigh.Text = "Motor High RPM";
            radioButtonVentilatorHigh.Text = "Ventilator High RPM";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearDataGrids();
        }

        private void ClearDataGrids()
        {
            CustomOrder = null;
            SelectedVentilatorID = 0;
            SelectedVentilatorTestID = 0;
            txtCustomOrderNumber.Text = "";
            InitializeGridData();
        }

        private void CustomOrderVentilatorsDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(CustomOrderVentilatorsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int ventilatorID))
            {
                SelectedVentilatorID = ventilatorID;
                InitializeGridData(false, true);
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

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomOrderNumber.Text) || CustomOrder == null)
                return;

            try
            {
                var customOrderVentilatorIndex = CustomOrder.CustomOrderVentilators.ToList().FindIndex(x => x.ID == SelectedVentilatorID);
                var customOrderVentilator = CustomOrder.CustomOrderVentilators.ToList()[customOrderVentilatorIndex];
                var ventilatorTestIndex = customOrderVentilator.CustomOrderVentilatorTests.ToList().FindIndex(x => x.ID == SelectedVentilatorTestID);
                var customOrderVentilatorTest = customOrderVentilator.CustomOrderVentilatorTests.ToList()[ventilatorTestIndex];
                var customOrderVentilatorTestID = customOrderVentilatorTest.ID;
                var customOrderVentilatorID = customOrderVentilatorTest.CustomOrderVentilatorID;
                customOrderVentilatorTest = ReadCustomOrderVentilatorTestDataGrid();
                if (customOrderVentilatorTest == null)
                {
                    MessageBox.Show("Please verify the filled in test data.");
                    return;
                }

                customOrderVentilatorTest.ID = customOrderVentilatorTestID;
                customOrderVentilatorTest.CustomOrderVentilatorID = customOrderVentilatorID;
                customOrderVentilatorTest.CustomOrderVentilator = BCustomOrderVentilator.GetById(customOrderVentilatorID);

                if (!BValidateMessage.Validate(customOrderVentilatorTest))
                {
                    MessageBox.Show("Please verify the filled in test data.");
                    return;
                }

                BCustomOrderVentilatorTest.Update(customOrderVentilatorTest);
                CustomOrder = BCustomOrder.ByCustomOrderNumber(CustomOrder.CustomOrderNumber);
                InitializeGridData();
                MessageBox.Show("Sucessful updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private CustomOrderVentilatorTest ReadCustomOrderVentilatorTestDataGrid()
        {
            var rows = SelectedVentilatorTestDataGrid.Rows.Cast<DataGridViewRow>().ToList();
            var test = BCustomOrderVentilatorTestUI.CreateObject(rows);
            test.UserID = (int?)cmbUser.SelectedValue;
            return test;
        }

        private void radioButtonMotorHigh_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                radioButtonMotorLow.Checked = false;
                radioButtonVentilatorHigh.Checked = false;
                radioButtonVentilatorLow.Checked = false;
            }
        }

        private void radioButtonMotorLow_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                radioButtonMotorHigh.Checked = false;
                radioButtonVentilatorHigh.Checked = false;
                radioButtonVentilatorLow.Checked = false;
            }
        }

        private void radioButtonVentilatorHigh_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                radioButtonMotorHigh.Checked = false;
                radioButtonMotorLow.Checked = false;
                radioButtonVentilatorLow.Checked = false;
            }
        }

        private void radioButtonVentilatorLow_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                radioButtonMotorHigh.Checked = false;
                radioButtonMotorLow.Checked = false;
                radioButtonVentilatorHigh.Checked = false;
            }
        }

        private void btnReadRPM_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPort.Open();
                var bytess = new byte[13] { 0x81, 0x4D, 0x45, 0x41, 0x20, 0x43, 0x48, 0x20, 0x31, 0x20, 0x3F, 0x03, 0x6F };
                SerialPort.Write(bytess, 0, bytess.Length);
            }
            catch (Exception ex)
            {
                SerialPort.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var serialPort = (SerialPort)sender;
                var value = serialPort.ReadExisting();
                if (value.Length < 3)
                {
                    MessageBox.Show("No valid value read, please try again.");
                    serialPort.Close();
                    return;
                }

                value = value.Substring(1, value.Length - 2);
                if (!int.TryParse(value, out int rpm))
                {
                    MessageBox.Show("No valid value read, please try again.");
                    serialPort.Close();
                    return;
                }

                var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
                var selectedTest = SelectedVentilatorTestID == 0 ? ventilator.CustomOrderVentilatorTests.First() : ventilator.CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);
                if (radioButtonMotorHigh.Checked)
                    selectedTest.MeasuredMotorHighRPM = rpm;
                else if (radioButtonMotorLow.Checked)
                    selectedTest.MeasuredMotorLowRPM = rpm;
                else if (radioButtonVentilatorHigh.Checked)
                    selectedTest.MeasuredVentilatorHighRPM = rpm;
                else if (radioButtonVentilatorLow.Checked)
                    selectedTest.MeasuredVentilatorLowRPM = rpm;

                serialPort.Close();
                InitializeGridData();
            }
            catch (Exception ex)
            {
                SerialPort.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMotorTypePlate_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null || CustomOrder.CustomOrderNumber == 0)
            {
                MessageBox.Show("Please search a order first.");
                return;
            }
            if (!BValidateMessage.ValidateForPrinting(CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID)))
            {
                //MessageBox.Show("Not all steps have been completed to be able to print this order.");
                return;
            }

            var mainForm = (MainForm)this.ParentForm;
            mainForm.TabControl.SelectedIndex = 2;
            mainForm.MotorTypePlateUserControl.SelectCustomOrder(CustomOrder.CustomOrderNumber);
        }

        private void btnAtex_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null || CustomOrder.CustomOrderNumber == 0)
            {
                MessageBox.Show("Please search a order first.");
                return;
            }
            var ventilator = CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
            if (string.IsNullOrEmpty(ventilator.Atex) || !BValidateMessage.ValidateForPrinting(ventilator))
            {
                //MessageBox.Show("Not all steps have been completed to be able to print this order.");
                return;
            }

            var mainForm = (MainForm)this.ParentForm;
            mainForm.TabControl.SelectedIndex = 2;
            mainForm.AtexStickerUserControl.SelectCustomOrder(CustomOrder.CustomOrderNumber);
        }

        private void txtCustomOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ShowCustomOrder();
            }
        }
    }
}
