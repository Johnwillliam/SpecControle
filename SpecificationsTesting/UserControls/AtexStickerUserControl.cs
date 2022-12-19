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
            CustomOrderVentilatorsDataGrid.RowEnter += new DataGridViewCellEventHandler(CustomOrderVentilatorsDataGrid_RowEnter);
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
                if(!InitGrid)
                {
                    InitializeGridData(false);
                }
            }
        }

        private void InitializeGridData(bool initVentilatorsGrid = true)
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

            var ventilator = SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);

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
                            columns.Add(new StickerRowColumn() { LeftText = "Weight", MiddleText = ventilator.CustomOrderVentilatorTests.First().Weight.ToString() });
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
                            columns.Add(new StickerRowColumn() { LeftText = "nr", MiddleText = ventilator.CustomOrderVentilatorTests.FirstOrDefault()?.MotorNumber });
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
            ShowCustomOrder();
            SelectedVentilatorID = selectedVentilatorID;
            CustomOrderVentilatorsDataGrid.Rows.OfType<DataGridViewRow>()
             .Where(x => (int)x.Cells[0].Value == selectedVentilatorID).First().Selected = true;
            ShowTable(SelectedImageSize);
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
                CustomOrder = null;
                InitializeGridData();
                ShowTable(SelectedImageSize);
                return;
            }

            var ventilator = CustomOrder.CustomOrderVentilators?.Count > 0 ? CustomOrder.CustomOrderVentilators.First() : null;
            if (ventilator != null && !ventilator.IsAtex())
            {
                MessageBox.Show($"Searched order is not a atex order");
                CustomOrder = null;
                InitializeGridData();
                ShowTable(SelectedImageSize);
                return;
            }
            InitializeGridData();
            ShowTable(SelectedImageSize);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var ventilator = CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
            if (CustomOrder == null || !BValidateMessage.ValidateForPrinting(ventilator))
            {
                MessageBox.Show("No valid order selected.");
                return;
            }

            if(!ventilator.IsAtex())
            {
                MessageBox.Show("Selected order is not atex.");
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
                    CreateTableInWordDocument(ventilator.CustomOrderVentilatorTests.ToList(), fullPath);
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
                            AddDataRow(DataRow, new List<string>() { "Referentie", test.CustomOrderVentilator.CustomOrder.Reference });
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
                            AddDataRow(DataRow, new List<string>() { "Opvoerhoogte totaal", test.CustomOrderVentilator.HighPressureTotal.ToString(), "Pa" });
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
                            AddDataRow(DataRow, new List<string>() { "Bouwgrootte", test.BuildSize.ToString(), "DUMMY" });
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
                            AddDataRow(DataRow, new List<string>() { "Aansluitspanning", test.CustomOrderVentilator.CustomOrderMotor.VoltageType, "V" });
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
