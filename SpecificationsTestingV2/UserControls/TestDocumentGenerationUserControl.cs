using SpecificationsTesting.Business;
using System.Data;
using SpecificationsTesting.Entities;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Drawing.Printing;
using EntityFrameworkModelV2.Models;

namespace SpecificationsTesting.UserControls
{
    public partial class TestDocumentGenerationUserControl : UserControl
    {
        private CustomOrder CustomOrder { get; set; }
        public int SelectedVentilatorID { get; set; }
        public int SelectedVentilatorTestID { get; set; }
        public string PrinterName { get; set; }

        const int TableFontSize = 8;
        const int TableRowHeight = 10;

        public TestDocumentGenerationUserControl()
        {
            InitializeComponent();
            CustomOrderVentilatorsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(CustomOrderVentilatorsDataGrid_RowEnter);
            CustomOrderVentilatorTestsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(CustomOrderVentilatorTestsDataGrid_RowEnter);
            btnSearch.Click += new System.EventHandler(btnSearch_Click);
            btnPrintSelectedTest.Click += new System.EventHandler(btnPrintSelectedTest_Click);
            btnPrintAll.Click += new System.EventHandler(btnPrintAll_Click);

            InitializeGridColumns();
            SelectedVentilatorID = 0;
            SelectedVentilatorTestID = 0;
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

            CustomOrderVentilatorTestsDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "Value", ReadOnly = true });
            CustomOrderVentilatorTestsDataGrid.RowHeadersVisible = false;
            CustomOrderVentilatorTestsDataGrid.AutoGenerateColumns = false;
            CustomOrderVentilatorTestsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorTestsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomOrderVentilatorTestsDataGrid.MultiSelect = false;
        }

        private void InitializeGridData(bool initVentilatorsGrid = true, bool initVentilatorTestsGrid = true)
        {
            CustomOrderDataGrid.DataSource = null;
            CustomOrderDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrder), CustomOrder, BCustomOrder.ControleDisplayPropertyNames);
            CustomOrderDataGrid.AutoResizeColumns();

            if (CustomOrder == null)
                CustomOrder = new CustomOrder { ID = -1 };

            if (CustomOrder.CustomOrderVentilators.Count == 0)
                CustomOrder.CustomOrderVentilators.Add(new CustomOrderVentilator());

            var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
            VentilatorDataGrid.DataSource = null;
            VentilatorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilator), ventilator, BCustomOrderVentilator.ControleDisplayPropertyNames);
            VentilatorDataGrid.AutoResizeColumns();

            var selectedTest = SelectedVentilatorTestID == 0 ? ventilator.CustomOrderVentilatorTests.First() : ventilator.CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);
            if (selectedTest != null && selectedTest.Date == null)
                selectedTest.Date = DateTime.Now.Date;

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
            if (CustomOrder != null && initVentilatorsGrid)
            {
                CustomOrderVentilatorsDataGrid.DataSource = null;
                CustomOrderVentilatorsDataGrid.DataSource = CustomOrder.CustomOrderVentilators.ToList();
                CustomOrderVentilatorsDataGrid.AutoResizeColumns();
            }
            if (initVentilatorTestsGrid)
            {
                CustomOrderVentilatorTestsDataGrid.DataSource = null;
                CustomOrderVentilatorTestsDataGrid.DataSource = ventilator.CustomOrderVentilatorTests.Select(x => new { Value = $"Test ID {x.ID}" }).ToList();
                CustomOrderVentilatorTestsDataGrid.AutoResizeColumns();
            }
        }

        private void CustomOrderVentilatorsDataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void CustomOrderVentilatorsDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(CustomOrderVentilatorsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int ventilatorID))
            {
                SelectedVentilatorID = ventilatorID;
                InitializeGridData(false);
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

        private void ShowCustomOrder()
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
            if (SelectedVentilatorID > 0 && !BValidateMessage.ValidateForPrinting(CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID)))
            {
                return;
            }

            InitializeGridData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowCustomOrder();
        }

        private void btnPrintSelectedTest_Click(object sender, EventArgs e)
        {
            var selectedTest = CustomOrder?.CustomOrderVentilators?.FirstOrDefault(x => x.ID == SelectedVentilatorID).CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);
            if (CustomOrder == null || selectedTest == null || !BValidateMessage.ValidateForPrinting(selectedTest))
            {
                return;
            }

            Print(new List<CustomOrderVentilatorTest>() { selectedTest, selectedTest });
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null || !BValidateMessage.ValidateForPrinting(CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID)))
            {
                return;
            }

            Print(CustomOrder.CustomOrderVentilators.SelectMany(x => x.CustomOrderVentilatorTests).ToList());
        }

        private void Print(List<CustomOrderVentilatorTest> tests)
        {
            var document = CreateTableInWordDocument(tests);
            if(document == null)
            { 
                return;
            }

            document.PrinterSettings.PrinterName = PrinterName;
            document.Print();
        }

        private PrintDocument CreateTableInWordDocument(List<CustomOrderVentilatorTest> tests)
        {
            try
            {
                Document doc = new Document();
                foreach (var test in tests)
                {
                    Section section = doc.AddSection();
                    AddHeaderText(section);
                    CreateOrderTable(section, test);
                    CreateVentilatorTable(section, test);
                    CreateMotorTable(section, test);
                    CreateTestTable(section, test);
                    AddFooterText(section, test);
                }

                return doc.PrintDocument;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void AddHeaderText(Section section)
        {
            var paragraph = section.AddParagraph();
            paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
            var text = paragraph.AppendText("RUNNING TEST");
            text.CharacterFormat.TextColor = Color.Black;
            text.CharacterFormat.Bold = true;
            text.CharacterFormat.FontSize = 15;
            text.CharacterFormat.FontName = "Calibri";
            var count = section.Body.ChildObjects.Count - 1;
            section.Body.ChildObjects.Insert(count, paragraph);

            paragraph = section.AddParagraph();
            paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
            text = paragraph.AppendText("Axiaal ventilator direct gedreven");
            text.CharacterFormat.TextColor = Color.Black;
            text.CharacterFormat.Bold = true;
            text.CharacterFormat.FontSize = 15;
            text.CharacterFormat.FontName = "Calibri";
            count = section.Body.ChildObjects.Count - 1;
            section.Body.ChildObjects.Insert(count, paragraph);
        }

        private void AddFooterText(Section section, CustomOrderVentilatorTest test)
        {
            var paragraph = section.AddParagraph();
            paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
            var text = paragraph.AppendText($"Datum assemblage             {test.Date:yyyy-dd-MM}");
            text.CharacterFormat.TextColor = Color.Black;
            text.CharacterFormat.Bold = true;
            text.CharacterFormat.FontSize = 10;
            text.CharacterFormat.FontName = "Calibri";
            var count = section.Body.ChildObjects.Count - 1;
            section.Body.ChildObjects.Insert(count, paragraph);

            paragraph = section.AddParagraph();
            paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
            text = paragraph.AppendText($"Uitgevoerd door                  {test.User?.Name}");
            text.CharacterFormat.TextColor = Color.Black;
            text.CharacterFormat.Bold = true;
            text.CharacterFormat.FontSize = 10;
            text.CharacterFormat.FontName = "Calibri";
            count = section.Body.ChildObjects.Count - 1;
            section.Body.ChildObjects.Insert(count, paragraph);
        }

        private void AddEmptyParagraph(Section section)
        {
            Paragraph paragraph = section.AddParagraph();
            TextRange text = paragraph.AppendText("");
            text.CharacterFormat.TextColor = Color.Blue;
            text.CharacterFormat.FontSize = 15;
            text.CharacterFormat.UnderlineStyle = UnderlineStyle.Dash;
            var count = section.Body.ChildObjects.Count - 1;
            section.Body.ChildObjects.Insert(count, paragraph);
        }

        private void CreateOrderTable(Section section, CustomOrderVentilatorTest test)
        {
            try
            {
                Table table = section.AddTable(true);
                var rows = 4;
                var columns = 2;
                //Add Cells
                table.ResetCells(rows, columns);

                var ventilator = BCustomOrderVentilator.GetById(test.CustomOrderVentilatorID);
                var customOrder = BCustomOrder.ByID(ventilator.CustomOrderID);
                //Data Row
                for (int r = 0; r < rows; r++)
                {
                    TableRow DataRow = table.Rows[r];
                    switch (r)
                    {
                        
                        case 0:
                            AddDataRow(DataRow, new List<string>() { "Systemair order", customOrder.CustomOrderNumber.ToString() });
                            break;
                        case 1:
                            AddDataRow(DataRow, new List<string>() { "Referentie", customOrder.Reference });
                            break;
                        case 2:
                            AddDataRow(DataRow, new List<string>() { "Serienummer", customOrder.CustomOrderNumber.ToString() });
                            break;
                        case 3:
                            AddDataRow(DataRow, new List<string>() { "Motornummer", ventilator.CustomOrderMotor.Type });
                            break;
                        default:
                            break;
                    }
                }
                AddEmptyParagraph(section);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateVentilatorTable(Section section, CustomOrderVentilatorTest test)
        {
            try
            {
                Table table = section.AddTable(true);
                var rows = 4;
                var columns = 3;
                table.ResetCells(rows, columns);

                var ventilator = BCustomOrderVentilator.GetById(test.CustomOrderVentilatorID);
                for (int r = 0; r < rows; r++)
                {
                    TableRow DataRow = table.Rows[r];
                    switch (r)
                    {
                        case 0:
                            AddDataRow(DataRow, new List<string>() { "VENTILATOR GEGEVENS" });
                            break;
                        case 1:
                            AddDataRow(DataRow, new List<string>() { "Type", ventilator.Name, "DUMMY" });
                            break;
                        case 2:
                            AddDataRow(DataRow, new List<string>() { "Toerental", ventilator.HighRPM.ToString(), "rpm" });
                            break;
                        case 3:
                            AddDataRow(DataRow, new List<string>() { "Schoephoek", ventilator.BladeAngle.ToString(), "°" });
                            break;
                        default:
                            break;
                    }
                }
                AddEmptyParagraph(section);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateMotorTable(Section section, CustomOrderVentilatorTest test)
        {
            try
            {
                Table table = section.AddTable(true);
                var rows = 8;
                var columns = 3;
                table.ResetCells(rows, columns);

                var ventilator = BCustomOrderVentilator.GetById(test.CustomOrderVentilatorID);
                for (int r = 0; r < rows; r++)
                {
                    TableRow DataRow = table.Rows[r];
                    switch (r)
                    {
                        case 0:
                            AddDataRow(DataRow, new List<string>() { "MOTOR GEGEVENS" });
                            break;
                        case 1:
                            AddDataRow(DataRow, new List<string>() { "Fabrikaat", ventilator.CustomOrderMotor.Name, "DUMMY" });
                            break;
                        case 2:
                            AddDataRow(DataRow, new List<string>() { "Type", ventilator.CustomOrderMotor.Type, "DUMMY" });
                            break;
                        case 3:
                            AddDataRow(DataRow, new List<string>() { "Bouwgrootte", test.BuildSize.ToString(), "DUMMY" });
                            break;
                        case 4:
                            AddDataRow(DataRow, new List<string>() { "Nominaal vermogen", ventilator.CustomOrderMotor.HighPower.ToString(), "kW" });
                            break;
                        case 5:
                            AddDataRow(DataRow, new List<string>() { "Toerental", ventilator.CustomOrderMotor.HighRPM.ToString(), "rpm" });
                            break;
                        case 6:
                            AddDataRow(DataRow, new List<string>() { "Stroomsterkte", ventilator.CustomOrderMotor.HighAmperage.ToString(), "A" });
                            break;
                        case 7:
                            AddDataRow(DataRow, new List<string>() { "Frequentie", ventilator.CustomOrderMotor.Frequency.ToString(), "Hz" });
                            break;
                        default:
                            break;
                    }
                }
                AddEmptyParagraph(section);
                AddEmptyParagraph(section);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateTestTable(Section section, CustomOrderVentilatorTest test)
        {
            try
            {
                Table table = section.AddTable(true);
                var rows = 7;
                var columns = 3;
                table.ResetCells(rows, columns);

                for (int r = 0; r < rows; r++)
                {
                    TableRow DataRow = table.Rows[r];
                    switch (r)
                    {

                        case 0:
                            AddDataRow(DataRow, new List<string>() { "MEETGEGEVENS"});
                            break;
                        case 1:
                            AddDataRow(DataRow, new List<string>() { "Stroom I1", test.I1High.ToString(), "A" });
                            break;
                        case 2:
                            AddDataRow(DataRow, new List<string>() { "Stroom I2", test.I2High.ToString(), "A" });
                            break;
                        case 3:
                            AddDataRow(DataRow, new List<string>() { "Stroom I3", test.I3High.ToString(), "A" });
                            break;
                        case 4:
                            AddDataRow(DataRow, new List<string>() { "Toerental motor", test.MeasuredMotorHighRPM.ToString(), "rpm" });
                            break;
                        case 5:
                            AddDataRow(DataRow, new List<string>() { "Toerental ventilator", test.MeasuredVentilatorHighRPM.ToString(), "rpm" });
                            break;
                        case 6:
                            AddDataRow(DataRow, new List<string>() { "Schoephoek", test.MeasuredBladeAngle.ToString(), "°" });
                            break;
                        default:
                            break;
                    }
                }
                AddEmptyParagraph(section);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddDataRow(TableRow DataRow, List<string> values)
        {
            try
            {
                DataRow.Height = TableRowHeight;
                for (int i = 0; i < values.Count; i++)
                {
                    DataRow.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    Paragraph p2 = DataRow.Cells[i].AddParagraph();
                    TextRange TR2 = p2.AppendText(values[i]);
                    p2.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
                    TR2.CharacterFormat.FontName = "Calibri";
                    TR2.CharacterFormat.FontSize = TableFontSize;
                    TR2.CharacterFormat.Bold = true;
                    if (values[i] != "DUMMY")
                        TR2.CharacterFormat.TextColor = Color.Black;
                    else
                        TR2.CharacterFormat.TextColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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