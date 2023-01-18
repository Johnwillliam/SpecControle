using EntityFrameworkModel;
using SpecificationsTesting.Business;
using SpecificationsTesting.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace SpecificationsTesting.Forms
{
    public partial class AtexStickerUserControl : UserControl
    {
        private CustomOrder CustomOrder { get; set; }
        public int SelectedVentilatorID { get; set; }
        public string PrinterName { get; set; }
        private ImageSize SelectedImageSize { get; set; }
        public int SelectedVentilatorTestID { get; private set; }

        private const int NormalImageWidth = 500;
        private const int NormalImageHeight = 700;
        private const int SmallImageWidth = 580;
        private const int SmallImageHeight = 400;
        private bool InitGrid = false;
        const int TableFontSize = 8;
        const int TableRowHeight = 10;

        private enum ImageSize
        {
            Small = 0,
            Medium = 1,
            Large = 2
        }
        public AtexStickerUserControl()
        {
            InitializeComponent();
            CustomOrderVentilatorsDataGrid.CellClick += new DataGridViewCellEventHandler(CustomOrderVentilatorsDataGrid_CellClick);
            CustomOrderVentilatorTestsDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(CustomOrderVentilatorTestsDataGrid_CellClick);
            LogosListBox.SelectedIndexChanged += new EventHandler(LogosListBox_SelectedIndexChanged);
            btnSearch.Click += new EventHandler(btnSearch_Click);
            btnPrint.Click += new EventHandler(btnPrint_Click);

            PopulateListBox(LogosListBox, Environment.CurrentDirectory + "\\Resources\\Logos", "*.jpg");
            LogosListBox.SelectedIndex = 0;
            SelectedImageSize = ImageSize.Medium;
            ShowTable(SelectedImageSize);
            InitializeGridColumns();
            InitializeGridData();
        }

        private void InitializeGridColumns()
        {
            CustomOrderVentilatorsDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "ID", ReadOnly = true });
            CustomOrderVentilatorsDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Name", DataPropertyName = "Name", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            CustomOrderVentilatorsDataGrid.RowHeadersVisible = false;
            CustomOrderVentilatorsDataGrid.AutoGenerateColumns = false;
            CustomOrderVentilatorsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomOrderVentilatorsDataGrid.MultiSelect = false;
            CustomOrderVentilatorsDataGrid.RowPrePaint += new DataGridViewRowPrePaintEventHandler(CustomOrderVentilatorsDataGrid_RowPrePaint);

            CustomOrderVentilatorTestsDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "ID", ReadOnly = true });
            CustomOrderVentilatorTestsDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Name", DataPropertyName = "Name", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            CustomOrderVentilatorTestsDataGrid.RowHeadersVisible = false;
            CustomOrderVentilatorTestsDataGrid.AutoGenerateColumns = false;
            CustomOrderVentilatorTestsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorTestsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomOrderVentilatorTestsDataGrid.MultiSelect = false;
        }

        private void CustomOrderVentilatorsDataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void CustomOrderVentilatorsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(CustomOrderVentilatorsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int ventilatorID))
            {
                SelectedVentilatorID = ventilatorID;
                var ventilator = SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
                SelectedVentilatorTestID = ventilator.CustomOrderVentilatorTests.First().ID;
                EnableReportButtons(ventilator);
                if (!InitGrid)
                {
                    InitializeGridData(false);
                }
            }
        }

        private void CustomOrderVentilatorTestsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CustomOrderVentilatorTestsDataGrid.Rows[e.RowIndex].Cells[0].Value != null && int.TryParse(CustomOrderVentilatorTestsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString().Replace("Test ID ", ""), out int testID))
            {
                SelectedVentilatorTestID = testID;
                var test = CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID).CustomOrderVentilatorTests.Single(x => x.ID == SelectedVentilatorTestID);
                InitializeGridData(false, false);
                ShowTable(SelectedImageSize);
            }
        }

        private void InitializeGridData(bool initVentilatorsGrid = true, bool initVentilatorTestsGrid = true)
        {
            InitGrid = true;
            if (CustomOrder != null && initVentilatorsGrid)
            {
                CustomOrderVentilatorsDataGrid.DataSource = CustomOrder.CustomOrderVentilators.ToList();
                CustomOrderVentilatorsDataGrid.AutoResizeColumns();
            }
            else
            {
                ShowTable(SelectedImageSize);
            }

            if (CustomOrder != null && initVentilatorTestsGrid)
            {
                CustomOrderVentilatorTestsDataGrid.DataSource = null;
                var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
                if (ventilator.CustomOrderVentilatorTests.Count >= 1 && ventilator.CustomOrderVentilatorTests.First().ID != 0)
                {
                    CustomOrderVentilatorTestsDataGrid.DataSource = ventilator.CustomOrderVentilatorTests.Select(x => new { x.ID, x.CustomOrderVentilator.Name }).ToList();
                }
                CustomOrderVentilatorTestsDataGrid.AutoResizeColumns();
            }
            InitGrid = false;
        }

        private void ShowTable(ImageSize imageSize)
        {
            int imageWidth, imageHeight;
            switch (imageSize)
            {
                case ImageSize.Small:
                    imageWidth = SmallImageWidth;
                    imageHeight = SmallImageHeight;
                    break;
                default:
                    imageWidth = NormalImageWidth;
                    imageHeight = NormalImageHeight;
                    break;
            }
            MotorTypePlateImage.Image = GenerateTable(imageWidth, imageHeight);
            MotorTypePlateImage.Width = imageWidth;
            MotorTypePlateImage.Height = imageHeight;
        }

        private Image GenerateTable(int imageWidth, int imageHeight)
       {
            if (LogosListBox.SelectedItem == null)
                return null;

            if (CustomOrder == null || CustomOrder.CustomOrderVentilators.Count == 0)
                return null;

            var ventilator = SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
            var ventilatorTest = SelectedVentilatorTestID == 0 ? ventilator.CustomOrderVentilatorTests.First() : ventilator.CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);

            var rows = 20;
            var colWidth = (imageWidth / 2) - 70;
            var rowHeight = 20;
            var startX = 40;
            var startY = 80;

            var logoFile = (FileInfo)LogosListBox.SelectedItem;
            var logo = Image.FromFile(logoFile.FullName);

            var image = new Bitmap(imageWidth, imageHeight);
            using (Graphics graph = Graphics.FromImage(image))
            {
                graph.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), image.Size));
                graph.DrawImage(logo, new Rectangle(startX, 0, colWidth * 2, 70));

                for (int row = 0; row < rows + 1; row++)
                {
                    var columns = new List<StickerRowColumn>();
                    switch (row)
                    {
                        case 1:
                            columns.Add(new StickerRowColumn() { LeftText = CustomOrder.Reference });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns);
                            break;
                        case 2:
                            columns.Add(new StickerRowColumn() { LeftText = "Order", MiddleText = CustomOrder.CustomOrderNumber.ToString() });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns);
                            break;
                        case 3:
                            columns.Add(new StickerRowColumn() { LeftText = "Serienummer", MiddleText = CustomOrder.CustomOrderNumber.ToString() });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns);
                            break;
                        case 4:
                            columns.Add(new StickerRowColumn() { LeftText = "Bouwjaar", MiddleText = CustomOrder.CreateDate.GetValueOrDefault().Year.ToString() });
                            //TODO: get selected test
                            columns.Add(new StickerRowColumn() { LeftText = "Weight", MiddleText = ventilatorTest.Weight.ToString() });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 5:
                            columns.Add(new StickerRowColumn() { LeftText = "VENTILATOR" });
                            columns.Add(new StickerRowColumn() { LeftText = "MOTOR", MiddleText = ventilator.CustomOrderMotor.Name});
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 6:
                            columns.Add(new StickerRowColumn() { LeftText = "Type", MiddleText = ventilator.Name });
                            columns.Add(new StickerRowColumn() { LeftText = "Frequentie", MiddleText = ventilator.CustomOrderMotor.Frequency.ToString() });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 7:
                            columns.Add(new StickerRowColumn() { LeftText = "V", MiddleText = DataHelper.CreateHighLowText(ventilator.HighAirVolume.ToString(), ventilator.LowAirVolume.ToString()), RightText = "m3/h" });
                            columns.Add(new StickerRowColumn() { LeftText = "Uitv.", MiddleText = ventilator.CustomOrderMotor.Type });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 8:
                            columns.Add(new StickerRowColumn() { LeftText = "Ptot", MiddleText = DataHelper.CreateHighLowText(ventilator.HighPressureTotal.ToString(), ventilator.LowPressureTotal.ToString()), RightText = "Pa" });
                            columns.Add(new StickerRowColumn() { LeftText = "P", MiddleText = DataHelper.CreateHighLowText(ventilator.CustomOrderMotor.HighPower.ToString(), ventilator.CustomOrderMotor.LowPower.ToString()), RightText = "kW" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 9:
                            columns.Add(new StickerRowColumn() { LeftText = "Pst", MiddleText = DataHelper.CreateHighLowText(ventilator.HighPressureStatic.ToString(), ventilator.LowPressureStatic.ToString()), RightText = "Pa" });
                            columns.Add(new StickerRowColumn() { LeftText = "U", MiddleText = ventilator.CustomOrderMotor.VoltageType, RightText = "V" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 10:
                            columns.Add(new StickerRowColumn() { LeftText = "Pdyn", MiddleText = DataHelper.CreateHighLowText(ventilator.HighPressureDynamic.ToString(), ventilator.LowPressureDynamic.ToString()), RightText = "Pa" });
                            columns.Add(new StickerRowColumn() { LeftText = "Inom", MiddleText = DataHelper.CreateHighLowText(ventilator.CustomOrderMotor.HighPower.ToString(), ventilator.CustomOrderMotor.LowPower.ToString()), RightText = "A" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 11:
                            columns.Add(new StickerRowColumn() { LeftText = "Nvent", MiddleText = DataHelper.CreateHighLowText(ventilator.HighRPM.ToString(), ventilator.LowRPM.ToString()), RightText = "rpm" });
                            columns.Add(new StickerRowColumn() { LeftText = "Istart", MiddleText = ventilator.CustomOrderMotor.StartupAmperage.ToString(), RightText = "A" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 12:
                            columns.Add(new StickerRowColumn() { LeftText = "Schoephoek", RightText = $"{ventilator.BladeAngle}°" });
                            columns.Add(new StickerRowColumn() { LeftText = "Nmotor", MiddleText = DataHelper.CreateHighLowText(ventilator.CustomOrderMotor.HighRPM.ToString(), ventilator.CustomOrderMotor.LowRPM.ToString()), RightText = "rpm" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 13:
                            columns.Add(new StickerRowColumn() { LeftText = "Geluidsvermogen", RightText = $"{ventilator.SoundLevel} {ventilator.SoundLevelType?.UOM}" });
                            columns.Add(new StickerRowColumn() { LeftText = "nr", MiddleText = ventilatorTest.MotorNumber });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 14:
                            columns.Add(new StickerRowColumn() { LeftText = "T", MiddleText = ventilator.TemperatureClass?.Description, RightText = "°C" });
                            columns.Add(new StickerRowColumn() { LeftText = "ρ", RightText = "1,20 kg/m3" });
                            columns.Add(new StickerRowColumn() { LeftText = $"IP {ventilator.CustomOrderMotor.IP}" });
                            columns.Add(new StickerRowColumn() { LeftText = $"ISO {ventilator.CustomOrderMotor.ISO}" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 4, colWidth / 2, columns);
                            break;
                        case 15:
                            columns.Add(new StickerRowColumn() { LeftText = "Maximum toerental", RightText = $"{ventilator.HighRPM} rpm" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns);
                            break;
                        case 16:
                            columns.Add(new StickerRowColumn() { LeftText = "Maximum Inlaattemperatuur", RightText = "40 °C" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns);
                            break;
                        case 17:
                            columns.Add(new StickerRowColumn() { LeftText = "Temperatureklasse", RightText = ventilator.TemperatureClass?.Description });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns);
                            break;
                        case 18:
                            columns.Add(new StickerRowColumn());
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns);
                            break;
                        case 19:
                            columns.Add(new StickerRowColumn() { LeftText = "ATEX markering", RightText = ventilator.Atex });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns);
                            break;
                        case 20:
                            columns.Add(new StickerRowColumn() { LeftText = "Omgevingstemperatuurbereik", RightText = "-20 - +40 °C" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns);
                            break;
                        default:
                            break;
                    }
                }
            }
            return (Image)image;
        }

        private void CreateSingleRow(Graphics graph, int rowHeight, int startX, ref int startY, int columnCount, int columnWidth, List<StickerRowColumn> columns)
        {
            var pen = new Pen(Color.Black, 2.0F);
            var font = new Font("Tahoma", 8, FontStyle.Bold);
            var columnStart = startX;
            for (int i = 0; i < columnCount; i++)
            {
                var row = new Rectangle(columnStart, startY, columnWidth, rowHeight);
                graph.DrawRectangle(pen, row);

                StringFormat stringFormat = new StringFormat();
                if(!string.IsNullOrEmpty(columns[i].LeftText))
                {
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    graph.DrawString(columns[i].LeftText, font, Brushes.Black, row, stringFormat);
                }
                if (!string.IsNullOrEmpty(columns[i].MiddleText))
                {
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    graph.DrawString(columns[i].MiddleText, font, Brushes.Black, row, stringFormat);
                }
                if (!string.IsNullOrEmpty(columns[i].RightText))
                {
                    stringFormat.Alignment = StringAlignment.Far;
                    stringFormat.LineAlignment = StringAlignment.Far;
                    graph.DrawString(columns[i].RightText, font, Brushes.Black, row, stringFormat);
                }

                columnStart += columnWidth;
            }
            startY += rowHeight;
        }

        private void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            lsb.DisplayMember = "Name";
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file);
            }
        }

        private void LogosListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowTable(SelectedImageSize);
        }

        private void ArrowsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowTable(SelectedImageSize);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowCustomOrder();
        }

        public void SetSelectedVentilator(int customOrderNumber, int selectedVentilatorID)
        {
            txtCustomOrderNumber.Text = customOrderNumber.ToString();
            SelectedVentilatorID = selectedVentilatorID;
            if (ShowCustomOrder(false))
            {
                CustomOrderVentilatorsDataGrid.Rows.OfType<DataGridViewRow>()
             .Where(x => (int)x.Cells[0].Value == selectedVentilatorID).First().Selected = true;
                ShowTable(SelectedImageSize);
            }
        }

        public void SetSelectedVentilatorTest(int customOrderNumber, int selectedVentilatorID, int selectedVentilatorTestID)
        {
            txtCustomOrderNumber.Text = customOrderNumber.ToString();
            SelectedVentilatorID = selectedVentilatorID;
            SelectedVentilatorTestID = selectedVentilatorTestID;
            if (ShowCustomOrder(false))
            {
                CustomOrderVentilatorsDataGrid.Rows.OfType<DataGridViewRow>()
                .Where(x => (int)x.Cells[0].Value == selectedVentilatorID).First().Selected = true;
                CustomOrderVentilatorTestsDataGrid.Rows.OfType<DataGridViewRow>()
                .Where(x => (int)x.Cells[0].Value == selectedVentilatorTestID).First().Selected = true;
                ShowTable(SelectedImageSize);
            }
        }

        private bool ShowCustomOrder(bool showTable = true)
        {
            if (string.IsNullOrEmpty(txtCustomOrderNumber.Text))
            {
                return false;
            }

            var customOrderNumber = int.Parse(txtCustomOrderNumber.Text);
            CustomOrder = BCustomOrder.ByCustomOrderNumber(customOrderNumber);
            if (CustomOrder == null)
            {
                MessageBox.Show($"No order found for number: {customOrderNumber}");
                CustomOrder = null;
                InitializeGridData();
                ShowTable(SelectedImageSize);
                return false;
            }
        
            InitializeGridData();
            if (showTable)
            {
                ShowTable(SelectedImageSize);
            }

            var ventilator = SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
            EnableReportButtons(ventilator);
            return true;
        }

        private void EnableReportButtons(CustomOrderVentilator ventilator)
        {
            btnPrint.Enabled = ventilator.IsAtex();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null)
            {
                MessageBox.Show("No valid order selected.");
                return;
            }

            var ventilator = SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
            if (!ventilator.IsAtex())
            {
                MessageBox.Show("Selected order is not atex.");
                return;
            }

            var ventilatorTest = SelectedVentilatorTestID == 0 ? ventilator.CustomOrderVentilatorTests.First() : ventilator.CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);
            if (!BValidateMessage.ValidateForPrinting(ventilatorTest))
            {
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = PrinterName;
            pd.PrintPage += PrintSticker;
            pd.Print();

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var fileName = $"ATEX-{CustomOrder.CustomOrderNumber}_{DateTime.Now:yyyy-dd-M--HH-mm-ss}.docx";
                    var fullPath = $"{fbd.SelectedPath}\\{fileName}";
                    CreateTableInWordDocument(new List<CustomOrderVentilatorTest> { ventilatorTest }, fullPath);
                }
            }
        }

        private void PrintSticker(object o, PrintPageEventArgs e)
        {
            var image = GenerateTable(NormalImageWidth, NormalImageHeight);
            Point loc = new Point(0, 0);
            e.Graphics.DrawImage(image, loc);
        }

        private void CreateTableInWordDocument(List<CustomOrderVentilatorTest> tests, string fullPath)
        {
            try
            {
                Document doc = new Document();
                foreach (var test in tests)
                {
                    Section section = doc.AddSection();
                    Paragraph paragraph = section.AddParagraph();
                    paragraph.AppendPicture(SpecificationsTesting.Properties.Resources.AtexDocumentHeader);

                    AddSpecificationText(section);
                    CreateOrderTable(section, test);
                    CreateVentilatorTable(section, test);
                    CreateMotorTable(section, test);
                    AddDateAndSignature(section);
                }

                doc.SaveToFile(fullPath, FileFormat.Docx);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddDateAndSignature(Section section)
        {
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
            TextRange text = paragraph.AppendText($"Datum            {DateTime.Now:dd-MM-yyyy}                                                          Handtekening");
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
            TextRange text = paragraph.AppendText("SPECIFICATIE");
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
            try
            {
                Table table = section.AddTable(true);
                int rows = 8;
                int columns = 2;
                //Add Cells
                table.ResetCells(rows, columns);

                var ventilator = BCustomOrderVentilator.GetById(test.CustomOrderVentilatorID);
                var order = BCustomOrder.ByID(ventilator.CustomOrderID);
                //Data Row
                for (int r = 0; r < rows; r++)
                {
                    TableRow DataRow = table.Rows[r];
                    switch (r)
                    {
                        case 0:
                            AddDataRow(DataRow, new List<string>() { "Serienummer", order.CustomOrderNumber.ToString() });
                            break;
                        case 1:
                            AddDataRow(DataRow, new List<string>() { "Motornummer", ventilator.CustomOrderMotor.Type });
                            break;
                        case 2:
                            AddDataRow(DataRow, new List<string>() { "Systemair order", order.CustomOrderNumber.ToString() });
                            break;
                        case 3:
                            AddDataRow(DataRow, new List<string>() { "Bouwjaar", test.Date.GetValueOrDefault().Year.ToString() });
                            break;
                        case 4:
                            AddDataRow(DataRow, new List<string>() { "ATEX Markering", ventilator.Atex });
                            break;
                        case 5:
                            AddDataRow(DataRow, new List<string>() { "Temperatuur bereik", "-20 - +40 °C" });
                            break;
                        case 6:
                            AddDataRow(DataRow, new List<string>() { "Temperatuurklasse", ventilator.TemperatureClass.Description });
                            break;
                        case 7:
                            AddDataRow(DataRow, new List<string>() { "Referentie", order.Reference });
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
                int rows = 11;
                int columns = 3;
                //Add Cells
                table.ResetCells(rows, columns);

                var ventilator = BCustomOrderVentilator.GetById(test.CustomOrderVentilatorID);
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
                            AddDataRow(DataRow, new List<string>() { "Type", ventilator.Name, "DUMMY" });
                            break;
                        case 2:
                            AddDataRow(DataRow, new List<string>() { "Luchthoeveelheid", ventilator.HighAirVolume.ToString(), "m3/h" });
                            break;
                        case 3:
                            AddDataRow(DataRow, new List<string>() { "Opvoerhoogte totaal", ventilator.HighPressureTotal.ToString(), "Pa" });
                            break;
                        case 4:
                            AddDataRow(DataRow, new List<string>() { "Opvoerhoogte statisch", ventilator.HighPressureStatic.ToString(), "Pa" });
                            break;
                        case 5:
                            AddDataRow(DataRow, new List<string>() { "Opvoerhoogte dynamisch", ventilator.HighPressureDynamic.ToString(), "Pa" });
                            break;
                        case 6:
                            AddDataRow(DataRow, new List<string>() { "Toerental", ventilator.HighRPM.ToString(), "rpm" });
                            break;
                        case 7:
                            AddDataRow(DataRow, new List<string>() { "Rendement", ventilator.Efficiency.ToString(), "%" });
                            break;
                        case 8:
                            AddDataRow(DataRow, new List<string>() { "Asvermogen", ventilator.HighShaftPower.ToString(), "kW" });
                            break;
                        case 9:
                            AddDataRow(DataRow, new List<string>() { "Geluidsvermogen", ventilator.SoundLevel.ToString(), "dB" });
                            break;
                        case 10:
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
                int rows = 11;
                int columns = 3;
                //Add Cells
                table.ResetCells(rows, columns);

                var ventilator = BCustomOrderVentilator.GetById(test.CustomOrderVentilatorID);
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
                            AddDataRow(DataRow, new List<string>() { "Fabrikaat", ventilator.CustomOrderMotor.Name, "DUMMY" });
                            break;
                        case 2:
                            AddDataRow(DataRow, new List<string>() { "Type", ventilator.CustomOrderMotor.Type, "DUMMY" });
                            break;
                        case 3:
                            AddDataRow(DataRow, new List<string>() { "Uitvoering", ventilator.CustomOrderMotor.Version, "DUMMY" });
                            break;
                        case 4:
                            AddDataRow(DataRow, new List<string>() { "Bouwgrootte", test.BuildSize.ToString(), "DUMMY" });
                            break;
                        case 5:
                            AddDataRow(DataRow, new List<string>() { "Bouwvorm", ventilator.CustomOrderMotor.BuildingType, "DUMMY" });
                            break;
                        case 6:
                            AddDataRow(DataRow, new List<string>() { "Beschermklasse", "55", "DUMMY" });
                            break;
                        case 7:
                            AddDataRow(DataRow, new List<string>() { "Isolatieklasse", "F", "DUMMY" });
                            break;
                        case 8:
                            AddDataRow(DataRow, new List<string>() { "Nominaal vermogen", ventilator.CustomOrderMotor.HighPower.ToString(), "kW" });
                            break;
                        case 9:
                            AddDataRow(DataRow, new List<string>() { "Toerental", ventilator.CustomOrderMotor.HighRPM.ToString(), "rpm" });
                            break;
                        case 10:
                            AddDataRow(DataRow, new List<string>() { "Nominaal stroom", ventilator.CustomOrderMotor.HighAmperage.ToString(), "A" });
                            break;
                        case 11:
                            AddDataRow(DataRow, new List<string>() { "Arbeidsfactor", ventilator.CustomOrderMotor.PowerFactor.ToString() });
                            break;
                        case 12:
                            AddDataRow(DataRow, new List<string>() { "Aanloopstroom", ventilator.CustomOrderMotor.StartupAmperage.ToString(), "A" });
                            break;
                        case 13:
                            AddDataRow(DataRow, new List<string>() { "Aansluitspanning", ventilator.CustomOrderMotor.VoltageType, "V" });
                            break;
                        case 14:
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

        private void AddDataRow(TableRow DataRow, List<string> values)
        {
            try
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
