using EntityFrameworkModelV2.Models;
using Logic;
using Logic.Business;
using Microsoft.Extensions.Logging;
using SpecificationsTesting.Entities;
using System.Drawing.Printing;

namespace SpecificationsTesting.Forms
{
    public partial class AtexStickerUserControl : UserControl
    {
        private CustomOrder CustomOrder { get; set; }
        public int SelectedVentilatorID { get; set; }
        public string StickerPrinterName { get; set; }
        private ImageSize SelectedImageSize { get; set; }
        public int SelectedVentilatorTestID { get; private set; }
        public string PrinterName { get; set; }

        private const int _normalImageWidthInMM = 100;
        private const int _normalImageHeightInMM = 150;
        private const int _smallImageWidthInMM = 80;
        private const int _smallImageHeightInMM = 100;
        private readonly ILogger logger;
        private bool _initGrid = false;

        private enum ImageSize
        {
            Small = 0,
            Normal = 1,
            Large = 2
        }

        public AtexStickerUserControl(ILogger logger)
        {
            InitializeComponent();
            CustomOrderVentilatorsDataGrid.CellClick += new DataGridViewCellEventHandler(CustomOrderVentilatorsDataGrid_CellClick);
            CustomOrderVentilatorTestsDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(CustomOrderVentilatorTestsDataGrid_CellClick);
            LogosListBox.SelectedIndexChanged += new EventHandler(LogosListBox_SelectedIndexChanged);
            ArrowsListBox.SelectedIndexChanged += new System.EventHandler(ArrowsListBox_SelectedIndexChanged);
            btnSearch.Click += new EventHandler(BtnSearch_Click);
            btnPrint.Click += new EventHandler(BtnPrint_Click);

            PopulateListBox(LogosListBox, Environment.CurrentDirectory + "\\Resources\\Logos", "*.jpg");
            PopulateListBox(ArrowsListBox, Environment.CurrentDirectory + "\\Resources\\Arrows", "*.jpg");
            LogosListBox.SelectedIndex = 0;
            ArrowsListBox.SelectedIndex = 0;
            SelectedImageSize = ImageSize.Normal;
            ShowTable(SelectedImageSize);
            InitializeGridColumns();
            InitializeGridData();
            this.logger = logger;
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
            if (e.RowIndex >= 0 && int.TryParse(CustomOrderVentilatorsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int ventilatorID))
            {
                SelectedVentilatorID = ventilatorID;
                var ventilator = SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
                SelectedVentilatorTestID = ventilator.CustomOrderVentilatorTests.First().ID;
                if (ventilator != null)
                {
                    EnableReportButtons(ventilator);
                }
                if (!_initGrid)
                {
                    InitializeGridData(false);
                }
            }
        }

        private void CustomOrderVentilatorTestsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && CustomOrderVentilatorTestsDataGrid.Rows[e.RowIndex].Cells[0].Value != null && int.TryParse(CustomOrderVentilatorTestsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString().Replace("Test ID ", ""), out int testID))
            {
                SelectedVentilatorTestID = testID;
                var ventilator = SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
                var test = ventilator.CustomOrderVentilatorTests.Single(x => x.ID == SelectedVentilatorTestID);
                InitializeGridData(false, false);
                ShowTable(SelectedImageSize);
            }
        }

        private void InitializeGridData(bool initVentilatorsGrid = true, bool initVentilatorTestsGrid = true)
        {
            _initGrid = true;
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
            _initGrid = false;
        }

        private void ShowTable(ImageSize imageSize)
        {
            DetermineLabelSizeInMM(imageSize, out int imageWidthInMM, out int imageHeightInMM);
            var image = GenerateTable(imageWidthInMM, imageHeightInMM);
            if (image != null)
            {
                var scaledImage = ScaleBitmapToFitImageBox(image, MotorTypePlateImage);
                MotorTypePlateImage.Image = scaledImage;
            }
        }

        private static void DetermineLabelSizeInMM(ImageSize imageSize, out int imageWidthInMM, out int imageHeightInMM)
        {
            switch (imageSize)
            {
                case ImageSize.Small:
                    imageWidthInMM = _smallImageWidthInMM;
                    imageHeightInMM = _smallImageHeightInMM;
                    break;

                default:
                    imageWidthInMM = _normalImageWidthInMM;
                    imageHeightInMM = _normalImageHeightInMM;
                    break;
            }
        }

        private static Bitmap ScaleBitmapToFitImageBox(Bitmap originalBitmap, PictureBox imageBox)
        {
            // Get the size of the ImageBox
            int boxWidth = imageBox.Width;
            int boxHeight = imageBox.Height;

            // Calculate the scaling factor while maintaining the aspect ratio
            float scaleWidth = (float)boxWidth / originalBitmap.Width;
            float scaleHeight = (float)boxHeight / originalBitmap.Height;
            float scaleFactor = Math.Min(scaleWidth, scaleHeight);  // Choose the smaller factor to maintain aspect ratio

            // Calculate the new width and height
            int newWidth = (int)(originalBitmap.Width * scaleFactor);
            int newHeight = (int)(originalBitmap.Height * scaleFactor);

            // Create a new bitmap with the new dimensions
            Bitmap scaledBitmap = new Bitmap(originalBitmap, newWidth, newHeight);

            return scaledBitmap;
        }

        private Bitmap GenerateTable(int imageWidthInMM, int imageHeightInMM, Graphics printerGraphics = null)
        {
            if (LogosListBox.SelectedItem == null || CustomOrder == null || CustomOrder.CustomOrderVentilators.Count == 0)
            {
                return null;
            }

            var ventilator = SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
            var ventilatorTest = SelectedVentilatorTestID == 0 ? ventilator.CustomOrderVentilatorTests.First() : ventilator.CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);

            // Convert image size from mm to pixels
            float dpiX = printerGraphics?.DpiX ?? 300;  // Default to 300 DPI if printerGraphics is null
            int imageWidthInPixels = (int)((imageWidthInMM / 25.4) * dpiX);
            int imageHeightInPixels = (int)((imageHeightInMM / 25.4) * dpiX);

            var rows = 21;
            var colWidth = (int)((imageWidthInPixels * 0.9) / 2);
            var rowHeight = (imageHeightInPixels / 30);
            var startX = 40;
            var startY = rowHeight * 5;

            var logoFile = (FileInfo)LogosListBox.SelectedItem;
            var logo = Image.FromFile(logoFile.FullName);

            var arrowFile = (FileInfo)ArrowsListBox.SelectedItem;
            var arrows = Image.FromFile(arrowFile.FullName);

            var image = new Bitmap(imageWidthInPixels, imageHeightInPixels);
            if (printerGraphics != null)
            {
                image.SetResolution(printerGraphics.DpiX, printerGraphics.DpiY);
            }
            using (Graphics graph = Graphics.FromImage(image))
            {
                graph.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), image.Size));
                DrawScaledImage(graph, arrows, 0, 0, imageWidthInPixels, imageHeightInPixels + rowHeight * 14);
                graph.DrawImage(logo, new Rectangle(startX, rowHeight, colWidth * 2, rowHeight * 4));
                var baseFontSizeInPoints = SelectedImageSize is ImageSize.Normal ? 10 : 8;
                var font = CalculateFontSize(rowHeight, baseFontSizeInPoints, graph);

                for (int row = 0; row < rows + 1; row++)
                {
                    var columns = new List<StickerRowColumn>();
                    switch (row)
                    {
                        case 1:
                            columns.Add(new StickerRowColumn() { LeftText = CustomOrder.Reference });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns, font);
                            break;

                        case 2:
                            columns.Add(new StickerRowColumn() { LeftText = "Order", MiddleText = CustomOrder.CustomOrderNumber.ToString() });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns, font);
                            break;

                        case 3:
                            columns.Add(new StickerRowColumn() { LeftText = "Serial number", MiddleText = ventilatorTest.SerialNumber });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns, font);
                            break;

                        case 4:
                            columns.Add(new StickerRowColumn() { LeftText = "Year built", MiddleText = CustomOrder.CreateDate.GetValueOrDefault().Year.ToString() });
                            //TODO: get selected test
                            columns.Add(new StickerRowColumn() { LeftText = "Weight", MiddleText = ventilatorTest.Weight.ToString() });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 5:
                            columns.Add(new StickerRowColumn() { LeftText = "FAN" });
                            columns.Add(new StickerRowColumn() { LeftText = "MOTOR", MiddleText = ventilator.CustomOrderMotor.Name });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 6:
                            columns.Add(new StickerRowColumn() { LeftText = "Type", MiddleText = ventilator.Name });
                            columns.Add(new StickerRowColumn() { LeftText = "Frequency", MiddleText = ventilator.CustomOrderMotor.Frequency.ToString() });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 7:
                            columns.Add(new StickerRowColumn() { LeftText = "V", MiddleText = DataHelper.CreateHighLowText(ventilator.HighAirVolume.ToString(), ventilator.LowAirVolume.ToString()), RightText = "m3/h" });
                            columns.Add(new StickerRowColumn() { LeftText = "Model", MiddleText = ventilator.CustomOrderMotor.Version });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 8:
                            columns.Add(new StickerRowColumn() { LeftText = "Ptot", MiddleText = DataHelper.CreateHighLowText(ventilator.HighPressureTotal.ToString(), ventilator.LowPressureTotal.ToString()), RightText = "Pa" });
                            columns.Add(new StickerRowColumn() { LeftText = "P", MiddleText = DataHelper.CreateHighLowText(ventilator.CustomOrderMotor.HighPower.ToString(), ventilator.CustomOrderMotor.LowPower.ToString()), RightText = "kW" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 9:
                            columns.Add(new StickerRowColumn() { LeftText = "Pst", MiddleText = DataHelper.CreateHighLowText(ventilator.HighPressureStatic.ToString(), ventilator.LowPressureStatic.ToString()), RightText = "Pa" });
                            columns.Add(new StickerRowColumn() { LeftText = "U", MiddleText = ventilator.CustomOrderMotor.VoltageType, RightText = "V" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 10:
                            columns.Add(new StickerRowColumn() { LeftText = "Pdyn", MiddleText = DataHelper.CreateHighLowText(ventilator.HighPressureDynamic.ToString(), ventilator.LowPressureDynamic.ToString()), RightText = "Pa" });
                            columns.Add(new StickerRowColumn() { LeftText = "Inom", MiddleText = DataHelper.CreateHighLowText(ventilator.CustomOrderMotor.HighAmperage.ToString(), ventilator.CustomOrderMotor.LowAmperage.ToString()), RightText = "A" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 11:
                            columns.Add(new StickerRowColumn() { LeftText = "Nfan", MiddleText = DataHelper.CreateHighLowText(ventilator.HighRPM.ToString(), ventilator.LowRPM.ToString()), RightText = "rpm" });
                            columns.Add(new StickerRowColumn() { LeftText = "Istart", MiddleText = DataHelper.CreateHighLowText(ventilator.CustomOrderMotor.HighStartupAmperage.ToString(), ventilator.CustomOrderMotor.LowStartupAmperage.ToString()), RightText = "A" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 12:
                            columns.Add(new StickerRowColumn() { LeftText = "Blade angle", RightText = $"{ventilator.BladeAngle}°" });
                            columns.Add(new StickerRowColumn() { LeftText = "Nmotor", MiddleText = DataHelper.CreateHighLowText(ventilator.CustomOrderMotor.HighRPM.ToString(), ventilator.CustomOrderMotor.LowRPM.ToString()), RightText = "rpm" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 13:
                            columns.Add(new StickerRowColumn() { LeftText = ventilator.SoundLevelType?.Description, RightText = $"{ventilator.SoundLevel} {ventilator.SoundLevelType?.UOM}" });
                            columns.Add(new StickerRowColumn() { LeftText = "nr", MiddleText = ventilatorTest.MotorNumber });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 14:
                            columns.Add(new StickerRowColumn() { LeftText = "T", MiddleText = ventilator.TemperatureClass?.Description, RightText = "°C" });
                            columns.Add(new StickerRowColumn() { LeftText = "ρ", RightText = "1,20 kg/m3" });
                            columns.Add(new StickerRowColumn() { LeftText = $"IP {ventilator.CustomOrderMotor.IP}" });
                            columns.Add(new StickerRowColumn() { LeftText = $"ISO {ventilator.CustomOrderMotor.ISO}" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 4, colWidth / 2, columns, font);
                            break;

                        case 15:
                            columns.Add(new StickerRowColumn());
                            columns.Add(new StickerRowColumn());
                            columns.Add(new StickerRowColumn() { LeftText = $"PTC", MiddleText = DataHelper.NullableBooleanToYesNo(ventilator.CustomOrderMotor.PTC) });
                            columns.Add(new StickerRowColumn() { LeftText = $"HT", MiddleText = DataHelper.NullableBooleanToYesNo(ventilator.CustomOrderMotor.HT) });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 4, colWidth / 2, columns, font);
                            break;

                        case 16:
                            columns.Add(new StickerRowColumn() { LeftText = "Maximum RPM", RightText = $"{ventilator.Atex} rpm" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns, font);
                            break;

                        case 17:
                            columns.Add(new StickerRowColumn() { LeftText = "Maximum inlet temperature", RightText = "40 °C" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns, font);
                            break;

                        case 18:
                            columns.Add(new StickerRowColumn() { LeftText = "Temperature class", RightText = ventilator.TemperatureClass?.Description });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns, font);
                            break;

                        case 19:
                            columns.Add(new StickerRowColumn());
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns, font);
                            break;

                        case 20:
                            columns.Add(new StickerRowColumn() { LeftText = "ATEX marking", RightText = ventilator.CatType?.Description });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns, font);
                            break;

                        case 21:
                            columns.Add(new StickerRowColumn() { LeftText = "Ambient temperature range", RightText = "-20 - +40 °C" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns, font);
                            break;

                        default:
                            break;
                    }
                }
            }
            return image;
        }

        private void DrawScaledImage(Graphics graph, Image arrows, int x, int y, int targetWidth, int targetHeight)
        {
            // Calculate aspect ratio
            float aspectRatio = (float)arrows.Width / arrows.Height;

            // Initialize scaled width and height
            int scaledWidth;
            int scaledHeight;

            // Adjust dimensions based on which is the limiting factor
            if (targetWidth / aspectRatio <= targetHeight)
            {
                // Width is the limiting dimension
                scaledWidth = targetWidth;
                scaledHeight = (int)(targetWidth / aspectRatio);
            }
            else
            {
                // Height is the limiting dimension
                scaledHeight = targetHeight;
                scaledWidth = (int)(targetHeight * aspectRatio);
            }

            // Center image within the target dimensions
            int offsetX = x + (targetWidth - scaledWidth) / 2;
            int offsetY = y + (targetHeight - scaledHeight) / 2;

            // Set high-quality interpolation mode for better scaling
            graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            // Draw the scaled image at the calculated position and size
            graph.DrawImage(arrows, new Rectangle(offsetX, offsetY, scaledWidth, scaledHeight));
        }

        private static void CreateSingleRow(Graphics graph, int rowHeight, int startX, ref int startY, int columnCount, int columnWidth, List<StickerRowColumn> columns, Font font)
        {
            var pen = new Pen(Color.Black, 2.0F);
            var columnStart = startX;
            for (int i = 0; i < columnCount; i++)
            {
                var row = new Rectangle(columnStart, startY, columnWidth, rowHeight);
                graph.DrawRectangle(pen, row);

                var stringFormat = new StringFormat();
                if (!string.IsNullOrEmpty(columns[i].LeftText))
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

        private static Font CalculateFontSize(int rowHeight, float baseFontSizeInPoints, Graphics graphics)
        {
            // Convert scaled font size from points to pixels
            var fontSize = rowHeight <= 59 ? baseFontSizeInPoints : 3;

            // Return the font with the calculated size
            return new Font("Tahoma", fontSize, FontStyle.Bold, GraphicsUnit.Millimeter);
        }

        private static void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            var dinfo = new DirectoryInfo(Folder);
            var Files = dinfo.GetFiles(FileType);
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

        private void BtnSearch_Click(object sender, EventArgs e)
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
            if (ventilator != null)
            {
                EnableReportButtons(ventilator);
            }
            return true;
        }

        private void EnableReportButtons(CustomOrderVentilator ventilator)
        {
            btnPrint.Enabled = ventilator.IsAtex();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
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

            var pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = StickerPrinterName;
            pd.PrintPage += PrintSticker;
            pd.Print();

            var pdfGenerator = new AtexPdfDocumentGenerator(new List<CustomOrderVentilatorTest> { ventilatorTest }, logger);
            var pdf = pdfGenerator.Generate();
            if (pdf == null)
            {
                return;
            }

            PrintByteArray(pdf, PrinterName);
        }

        private static void PrintByteArray(byte[] byteArray, string printerName)
        {
            try
            {
                var document = PdfiumViewer.PdfDocument.Load(new MemoryStream(byteArray));
                var printdoc = document.CreatePrintDocument();
                printdoc.PrinterSettings = new PrinterSettings()
                {
                    PrinterName = printerName
                };
                printdoc.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Printing error: {ex.Message}");
            }
        }

        private void PrintSticker(object o, PrintPageEventArgs e)
        {
            DetermineLabelSizeInMM(SelectedImageSize, out int imageWidthInMM, out int imageHeightInMM);
            var image = GenerateTable(imageWidthInMM, imageHeightInMM, e.Graphics);
            var loc = new Point(0, 0);
            e.Graphics.DrawImage(image, loc);
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