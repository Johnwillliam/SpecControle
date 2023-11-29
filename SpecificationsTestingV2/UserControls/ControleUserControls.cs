using EntityFrameworkModelV2.Context;
using EntityFrameworkModelV2.Models;
using Logic;
using Logic.Business;
using SpecificationsTesting.Entities;
using SpecificationsTesting.Forms;
using System.Configuration;
using System.Data;
using System.IO.Ports;

namespace SpecificationsTesting.UserControls
{
    public partial class ControleUserControl : UserControl
    {
        public CustomOrder CustomOrder { get; set; }
        public int SelectedVentilatorID { get; set; }
        public int SelectedVentilatorTestID { get; set; }
        public TemplateMotor SelectedTemplateMotor { get; set; }
        private readonly SerialPort _serialPort = new SerialPort(ConfigurationManager.AppSettings.Get("SerialPortName"), int.Parse(ConfigurationManager.AppSettings.Get("SerialPortBaudRate")), Parity.None, 8, StopBits.One);

        public ControleUserControl()
        {
            InitializeComponent();
            btnSearch.Click += new System.EventHandler(BtnSearch_Click);
            CustomOrderVentilatorsDataGrid.CellClick += new DataGridViewCellEventHandler(CustomOrderVentilatorsDataGrid_CellClick);
            CustomOrderVentilatorTestsDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(CustomOrderVentilatorTestsDataGrid_CellClick);
            CustomOrderVentilatorsDataGrid.RowPrePaint += new DataGridViewRowPrePaintEventHandler(CustomOrderVentilatorsDataGrid_RowPrePaint);
            btnSaveChanges.Click += new System.EventHandler(BtnSaveChanges_Click);
            btnClear.Click += new System.EventHandler(BtnClear_Click);
            radioButtonMotorHigh.CheckedChanged += new System.EventHandler(RadioButtonMotorHigh_CheckedChanged);
            radioButtonMotorLow.CheckedChanged += new System.EventHandler(RadioButtonMotorLow_CheckedChanged);
            radioButtonVentilatorHigh.CheckedChanged += new System.EventHandler(RadioButtonVentilatorHigh_CheckedChanged);
            radioButtonVentilatorLow.CheckedChanged += new System.EventHandler(RadioButtonVentilatorLow_CheckedChanged);
            btnReadRPM.Click += new System.EventHandler(BtnReadRPM_Click);
            btnMotorTypePlate.Click += new System.EventHandler(BtnMotorTypePlate_Click);
            btnAtex.Click += new System.EventHandler(BtnAtex_Click);

            CustomOrder = null;
            SelectedVentilatorID = 0;
            SelectedVentilatorTestID = 0;
            txtCustomOrderNumber.Text = "";

            InitializeGridColumns();
            InitializeComboBoxes();
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
        }

        private void InitializeComboBoxes()
        {
            using (SpecificationsDatabaseModel dbContext = new SpecificationsDatabaseModel())
            {
                cmbUser.DisplayMember = "Name";
                cmbUser.ValueMember = "ID";
                cmbUser.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbUser.DataSource = dbContext.Users.ToList();
                var cell = CustomOrderVentilatorTestsDataGrid.Rows.Count == 0 ? null : SelectedVentilatorTestDataGrid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value.ToString().Equals("UserID")).Cells["Value"];
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

        private void EnableReportButtons(CustomOrderVentilator ventilator)
        {
            btnAtex.Enabled = ventilator.IsAtex();
            btnMotorTypePlate.Enabled = !ventilator.IsAtex();
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

                var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
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
                ExceptionHandler.HandleException(ex);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
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
            var ventilator = CustomOrder.CustomOrderVentilators.FirstOrDefault();

            SelectedVentilatorID = ventilator.ID;
            SelectedVentilatorTestID = ventilator.CustomOrderVentilatorTests.FirstOrDefault().ID;
            InitializeGridData();

            if (ventilator != null)
            {
                EnableReportButtons(ventilator);
            }
            if (ventilator.LowRPM == null)
            {
                ShowSingleRPMSelection();
            }
            else
            {
                ShowAllRPMSelection();
            }
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

        private void BtnClear_Click(object sender, EventArgs e)
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

        private void CustomOrderVentilatorsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && int.TryParse(CustomOrderVentilatorsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int ventilatorID))
            {
                SelectedVentilatorID = ventilatorID;
                var ventilator = CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
                SelectedVentilatorTestID = ventilator.CustomOrderVentilatorTests.First().ID;
                if (ventilator != null)
                {
                    EnableReportButtons(ventilator);
                }
                InitializeGridData(false, true);
            }
        }

        private void CustomOrderVentilatorTestsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && CustomOrderVentilatorTestsDataGrid.Rows[e.RowIndex].Cells[0].Value != null && int.TryParse(CustomOrderVentilatorTestsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString().Replace("Test ID ", ""), out int testID))
            {
                SelectedVentilatorTestID = testID;
                var ventilator = CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
                if (!ventilator.CustomOrderVentilatorTests.Any(x => x.ID == SelectedVentilatorTestID))
                {
                    SelectedVentilatorTestID = ventilator.CustomOrderVentilatorTests.First().ID;
                }
                if (ventilator != null)
                {
                    EnableReportButtons(ventilator);
                }
                InitializeGridData(false, false);
            }
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomOrderNumber.Text) || CustomOrder == null)
            {
                return;
            }

            try
            {
                var customOrderVentilator = CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
                var customOrderVentilatorTest = customOrderVentilator.CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);
                var lockedTest = customOrderVentilatorTest.Locked;
                if (lockedTest)
                {
                    MessageBox.Show("This test is locked and cannot be changed, please contact IT support if changes has to be done.");
                    return;
                }

                var customOrderVentilatorID = customOrderVentilatorTest.CustomOrderVentilatorID;
                customOrderVentilatorTest = ReadCustomOrderVentilatorTestDataGrid();
                if (customOrderVentilatorTest == null)
                {
                    MessageBox.Show("Please verify the filled in test data.");
                    return;
                }

                customOrderVentilatorTest.ID = SelectedVentilatorTestID;
                customOrderVentilatorTest.CustomOrderVentilatorID = SelectedVentilatorID;
                customOrderVentilatorTest.CustomOrderVentilator = BCustomOrderVentilator.GetById(SelectedVentilatorID);

                if (!BValidateMessage.Validate(customOrderVentilatorTest))
                {
                    MessageBox.Show("Please verify the filled in test data.");
                    return;
                }

                if (!lockedTest)
                {
                    var result = MessageBox.Show("Do you want to lock this test?", "Confirm",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    lockedTest = result == DialogResult.Yes;
                }

                customOrderVentilatorTest.Locked = lockedTest;
                BCustomOrderVentilatorTest.Update(customOrderVentilatorTest);
                CustomOrder = BCustomOrder.ByCustomOrderNumber(CustomOrder.CustomOrderNumber);
                InitializeGridData();
                MessageBox.Show("Sucessful updated");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private CustomOrderVentilatorTest ReadCustomOrderVentilatorTestDataGrid()
        {
            var rows = SelectedVentilatorTestDataGrid.Rows.Cast<DataGridViewRow>().ToList();
            var test = BCustomOrderVentilatorTestUI.CreateObject(rows);
            test.UserID = (int?)cmbUser.SelectedValue;
            return test;
        }

        private void RadioButtonMotorHigh_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                radioButtonMotorLow.Checked = false;
                radioButtonVentilatorHigh.Checked = false;
                radioButtonVentilatorLow.Checked = false;
            }
        }

        private void RadioButtonMotorLow_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                radioButtonMotorHigh.Checked = false;
                radioButtonVentilatorHigh.Checked = false;
                radioButtonVentilatorLow.Checked = false;
            }
        }

        private void RadioButtonVentilatorHigh_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                radioButtonMotorHigh.Checked = false;
                radioButtonMotorLow.Checked = false;
                radioButtonVentilatorLow.Checked = false;
            }
        }

        private void RadioButtonVentilatorLow_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                radioButtonMotorHigh.Checked = false;
                radioButtonMotorLow.Checked = false;
                radioButtonVentilatorHigh.Checked = false;
            }
        }

        private void BtnReadRPM_Click(object sender, EventArgs e)
        {
            try
            {
                _serialPort.Open();
                var bytess = new byte[13] { 0x81, 0x4D, 0x45, 0x41, 0x20, 0x43, 0x48, 0x20, 0x31, 0x20, 0x3F, 0x03, 0x6F };
                _serialPort.Write(bytess, 0, bytess.Length);
            }
            catch (Exception ex)
            {
                _serialPort.Close();
                ExceptionHandler.HandleException(ex);
            }
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var serialPort = (SerialPort)sender;
                var value = serialPort.ReadExisting();
                value = new string(Array.FindAll(value.ToCharArray(), c => char.IsLetterOrDigit(c) || c == '.' || c == ',')).Replace('.', ',');
                if (!double.TryParse(value, out double rpm))
                {
                    MessageBox.Show($"No valid value '{value}' read, please try again.");
                    serialPort.Close();
                    return;
                }

                var ventilator = SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
                var selectedTest = SelectedVentilatorTestID == 0 || SelectedVentilatorTestID == -1 ? ventilator.CustomOrderVentilatorTests.First() : ventilator.CustomOrderVentilatorTests.Single(x => x.ID == SelectedVentilatorTestID);
                if (radioButtonMotorHigh.Checked)
                    selectedTest.MeasuredMotorHighRPM = (int)rpm;
                else if (radioButtonMotorLow.Checked)
                    selectedTest.MeasuredMotorLowRPM = (int)rpm;
                else if (radioButtonVentilatorHigh.Checked)
                    selectedTest.MeasuredVentilatorHighRPM = (int)rpm;
                else if (radioButtonVentilatorLow.Checked)
                    selectedTest.MeasuredVentilatorLowRPM = (int)rpm;

                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                BeginInvoke(new MethodInvoker(delegate
                {
                    InitializeGridData();
                }));
            }
            catch (Exception ex)
            {
                _serialPort.Close();
                ExceptionHandler.HandleException(ex);
            }
        }

        private void BtnMotorTypePlate_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null || CustomOrder.CustomOrderNumber == 0)
            {
                MessageBox.Show("Please search a order first.");
                return;
            }

            var test = BCustomOrderVentilatorTest.GetByID(SelectedVentilatorTestID);
            if (test == null || !BValidateMessage.ValidateForPrinting(test))
            {
                return;
            }

            var mainForm = (MainForm)ParentForm;
            mainForm.TabControl.SelectedIndex = 2;
            mainForm.MotorTypePlateUserControl.SetSelectedVentilatorTest(CustomOrder.CustomOrderNumber, SelectedVentilatorID, SelectedVentilatorTestID);
        }

        private void BtnAtex_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null || CustomOrder.CustomOrderNumber == 0)
            {
                MessageBox.Show("Please search a order first.");
                return;
            }
            var ventilator = CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
            var test = BCustomOrderVentilatorTest.GetByID(SelectedVentilatorTestID);
            if (!ventilator.IsAtex() || test == null || !BValidateMessage.ValidateForPrinting(test))
            {
                return;
            }

            var mainForm = (MainForm)ParentForm;
            mainForm.TabControl.SelectedIndex = 3;
            mainForm.AtexStickerUserControl.SetSelectedVentilatorTest(CustomOrder.CustomOrderNumber, SelectedVentilatorID, SelectedVentilatorTestID);
        }

        private void TxtCustomOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ShowCustomOrder();
            }
        }
    }
}