using EntityFrameworkModel;
using SpecificationsTesting.Business;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SpecificationsTesting.Entities;
using System.Drawing;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Collections.Generic;

namespace SpecificationsTesting.UserControls
{
    public partial class TestDocumentGenerationUserControl : UserControl
    {
        private CustomOrder CustomOrder { get; set; }
        public int SelectedVentilatorID { get; set; }
        public int SelectedVentilatorTestID { get; set; }
        const int TableFontSize = 8;
        const int TableRowHeight = 10;
        public TestDocumentGenerationUserControl()
        {
            InitializeComponent();
            this.CustomOrderVentilatorsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomOrderVentilatorsDataGrid_RowEnter);
            this.CustomOrderVentilatorTestsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomOrderVentilatorTestsDataGrid_RowEnter);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnPrintSelectedTest.Click += new System.EventHandler(this.btnPrintSelectedTest_Click);
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);

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
            if (SelectedVentilatorID > 0)
            {
                if (!BCustomOrderVentilatorTest.ValidateForPrinting(CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID)))
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
            var selectedTest = CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID).CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);
            Print(new List<CustomOrderVentilatorTest>() { selectedTest });
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            Print(CustomOrder.CustomOrderVentilators.SelectMany(x => x.CustomOrderVentilatorTests).ToList());
        }

        private void Print(List<CustomOrderVentilatorTest> tests)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var fileName = $"Running test - Ordernumber {CustomOrder.CustomOrderNumber} - {DateTime.Now:yyyy-dd-M--HH-mm-ss}.docx";
                    var fullPath = $"{fbd.SelectedPath}\\{fileName}";
                    CreateTableInWordDocument(tests, fullPath);
                }
            }
        }

        private void CreateTableInWordDocument(List<CustomOrderVentilatorTest> tests, string fullPath)
        {
            Document doc = new Document();
            foreach (var test in tests)
            {
                Section section = doc.AddSection();
                Image image = Image.FromFile("D:\\Projecten\\Fiverr\\joitsys\\RunningTestHeader2.jpg");
                Paragraph paragraph = section.AddParagraph();
                paragraph.AppendPicture(image);

                AddSpecificationText(section);
                CreateOrderTable(section, test);
                CreateVentilatorTable(section, test);
                CreateMotorTable(section, test);
                AddDateAndSignature(section);
            }
            
            doc.SaveToFile(fullPath, FileFormat.Docx);
        }

        private void AddDateAndSignature(Section section)
        {
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
            TextRange text = paragraph.AppendText($"Datum            {DateTime.Now:MM-dd-yyyy}                                                          Handtekening");
            text.CharacterFormat.TextColor = Color.Black;
            text.CharacterFormat.Bold = true;
            text.CharacterFormat.FontSize = 10;
            text.CharacterFormat.FontName = "Calibri";
            var count = section.Body.ChildObjects.Count - 1;
            section.Body.ChildObjects.Insert(count, paragraph);
        }

        private void AddSpecificationText(Section section)
        {
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
            TextRange text = paragraph.AppendText("SPECIFICATION");
            text.CharacterFormat.TextColor = Color.Black;
            text.CharacterFormat.Bold = true;
            text.CharacterFormat.FontSize = 15;
            text.CharacterFormat.FontName = "Calibri";
            var count = section.Body.ChildObjects.Count - 1;
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
            Table table = section.AddTable(true);
            int rows = 8;
            int columns = 2;
            //Add Cells
            table.ResetCells(rows, columns);

            //Data Row
            for (int r = 0; r < rows; r++)
            {
                TableRow DataRow = table.Rows[r];
                switch (r)
                {
                    case 0:
                        AddDataRow(DataRow, new List<string>() { "Serienummer", test.CustomOrderVentilator.CustomOrder.CustomOrderNumber.ToString() });
                        break;
                    case 1:
                        AddDataRow(DataRow, new List<string>() { "Motornummer", test.CustomOrderVentilator.CustomOrderMotor.Type });
                        break;
                    case 2:
                        AddDataRow(DataRow, new List<string>() { "Systemair order", test.CustomOrderVentilator.CustomOrder.CustomOrderNumber.ToString() });
                        break;
                    case 3:
                        AddDataRow(DataRow, new List<string>() { "Bouwjaar", test.Date.GetValueOrDefault().Year.ToString() });
                        break;
                    case 4:
                        AddDataRow(DataRow, new List<string>() { "ATEX Markering", test.CustomOrderVentilator.Atex });
                        break;
                    case 5:
                        AddDataRow(DataRow, new List<string>() { "Temperatuur bereik", "-20 - +40 °C" });
                        break;
                    case 6:
                        AddDataRow(DataRow, new List<string>() { "Temperatuurklasse", test.CustomOrderVentilator.TemperatureClass.Description });
                        break;
                    case 7:
                        AddDataRow(DataRow, new List<string>() { "Referentie", test.CustomOrderVentilator.CustomOrder.Reference});
                        break;
                    default:
                        break;
                }
            }
            AddEmptyParagraph(section);
        }

        private void CreateVentilatorTable(Section section, CustomOrderVentilatorTest test)
        {
            Table table = section.AddTable(true);
            int rows = 11;
            int columns = 3;
            //Add Cells
            table.ResetCells(rows, columns);

            //Data Row
            for (int r = 0; r < rows; r++)
            {
                TableRow DataRow = table.Rows[r];
                switch (r)
                {
                    case 0:
                        AddDataRow(DataRow, new List<string>() { "VENTILATOR GEGEVENS" });
                        break;
                    case 1:
                        AddDataRow(DataRow, new List<string>() { "Type", test.CustomOrderVentilator.Name, "DUMMY" });
                        break;
                    case 2:
                        AddDataRow(DataRow, new List<string>() { "Luchthoeveelheid", test.CustomOrderVentilator.HighAirVolume.ToString(), "m3/h" });
                        break;
                    case 3:
                        AddDataRow(DataRow, new List<string>() { "Opvoerhoogte totaal", test.CustomOrderVentilator.HighPressureTotal.ToString(), "Pa"});
                        break;
                    case 4:
                        AddDataRow(DataRow, new List<string>() { "Opvoerhoogte statisch", test.CustomOrderVentilator.HighPressureStatic.ToString(), "Pa" });
                        break;
                    case 5:
                        AddDataRow(DataRow, new List<string>() { "Opvoerhoogte dynamisch", test.CustomOrderVentilator.HighPressureDynamic.ToString(), "Pa" });
                        break;
                    case 6:
                        AddDataRow(DataRow, new List<string>() { "Toerental", test.CustomOrderVentilator.HighRPM.ToString(), "rpm" });
                        break;
                    case 7:
                        AddDataRow(DataRow, new List<string>() { "Rendement", test.CustomOrderVentilator.Efficiency.ToString(), "%" });
                        break;
                    case 8:
                        AddDataRow(DataRow, new List<string>() { "Asvermogen", test.CustomOrderVentilator.HighShaftPower.ToString(), "kW" });
                        break;
                    case 9:
                        AddDataRow(DataRow, new List<string>() { "Geluidsvermogen", test.CustomOrderVentilator.SoundLevel.ToString(), "dB" });
                        break;
                    case 10:
                        AddDataRow(DataRow, new List<string>() { "Schoephoek", test.CustomOrderVentilator.BladeAngle.ToString(), "°" });
                        break;
                    default:
                        break;
                }
            }
            AddEmptyParagraph(section);
        }

        private void CreateMotorTable(Section section, CustomOrderVentilatorTest test)
        {
            Table table = section.AddTable(true);
            int rows = 11;
            int columns = 3;
            //Add Cells
            table.ResetCells(rows, columns);

            //Data Row
            for (int r = 0; r < rows; r++)
            {
                TableRow DataRow = table.Rows[r];
                switch (r)
                {
                    case 0:
                        AddDataRow(DataRow, new List<string>() { "MOTOR GEGEVENS" });
                        break;
                    case 1:
                        AddDataRow(DataRow, new List<string>() { "Fabrikaat", test.CustomOrderVentilator.CustomOrderMotor.Name, "DUMMY" });
                        break;
                    case 2:
                        AddDataRow(DataRow, new List<string>() { "Type", test.CustomOrderVentilator.CustomOrderMotor.Type, "DUMMY" });
                        break;
                    case 3:
                        AddDataRow(DataRow, new List<string>() { "Uitvoering", test.CustomOrderVentilator.CustomOrderMotor.Version, "DUMMY" });
                        break;
                    case 4:
                        AddDataRow(DataRow, new List<string>() { "Bouwgrootte", "?", "DUMMY" });
                        break;
                    case 5:
                        AddDataRow(DataRow, new List<string>() { "Bouwvorm", test.CustomOrderVentilator.CustomOrderMotor.BuildingType, "DUMMY" });
                        break;
                    case 6:
                        AddDataRow(DataRow, new List<string>() { "Beschermklasse", "55", "DUMMY" });
                        break;
                    case 7:
                        AddDataRow(DataRow, new List<string>() { "Isolatieklasse", "F", "DUMMY" });
                        break;
                    case 8:
                        AddDataRow(DataRow, new List<string>() { "Nominaal vermogen", test.CustomOrderVentilator.CustomOrderMotor.HighPower.ToString(), "kW" });
                        break;
                    case 9:
                        AddDataRow(DataRow, new List<string>() { "Toerental", test.CustomOrderVentilator.CustomOrderMotor.HighRPM.ToString(), "rpm" });
                        break;
                    case 10:
                        AddDataRow(DataRow, new List<string>() { "Nominaal stroom", test.CustomOrderVentilator.CustomOrderMotor.HighAmperage.ToString(), "A" });
                        break;
                    case 11:
                        AddDataRow(DataRow, new List<string>() { "Arbeidsfactor", test.CustomOrderVentilator.CustomOrderMotor.PowerFactor.ToString() });
                        break;
                    case 12:
                        AddDataRow(DataRow, new List<string>() { "Aanloopstroom", test.CustomOrderVentilator.CustomOrderMotor.StartupAmperage.ToString(), "A" });
                        break;
                    case 13:
                        AddDataRow(DataRow, new List<string>() { "Aansluitspanning", test.CustomOrderVentilator.CustomOrderMotor.VoltageType.Description, "V" });
                        break;
                    case 14:
                        AddDataRow(DataRow, new List<string>() { "Frequentie", test.CustomOrderVentilator.CustomOrderMotor.Frequency.ToString(), "Hz" });
                        break;
                    default:
                        break;
                }
            }
            AddEmptyParagraph(section);
            AddEmptyParagraph(section);
        }

        private void AddDataRow(TableRow DataRow, List<string> values)
        {
            DataRow.Height = TableRowHeight;
            for (int i = 0; i < values.Count; i++)
            {
                //Cell Alignment
                DataRow.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                //Fill Data in Rows
                Paragraph p2 = DataRow.Cells[i].AddParagraph();
                TextRange TR2 = p2.AppendText(values[i]);
                //Format Cells
                p2.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
                TR2.CharacterFormat.FontName = "Calibri";
                TR2.CharacterFormat.FontSize = TableFontSize;
                TR2.CharacterFormat.Bold = true;
                if(values[i] != "DUMMY")
                    TR2.CharacterFormat.TextColor = Color.Black;
                else
                    TR2.CharacterFormat.TextColor = Color.White;
            }
        }

    }
}