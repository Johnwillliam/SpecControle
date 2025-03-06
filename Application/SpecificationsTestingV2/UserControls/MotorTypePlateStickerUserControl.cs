using EntityFrameworkModelV2.Models;
using Logic;
using Logic.Business;
using SpecificationsTesting.Entities;
using System.Drawing.Printing;
using System.ComponentModel;

namespace SpecificationsTesting.Forms
{
    public partial class MotorTypePlateStickerUserControl : UserControl
    {
        private CustomOrder CustomOrder { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedVentilatorID { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string StickerPrinterName { get; set; }
        private ImageSize SelectedImageSize { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedVentilatorTestID { get; private set; }

        private const int _normalImageWidthInMM = 150;
        private const int _normalImageHeightInMM = 100;
        private const int _smallImageWidthInMM = 100;
        private const int _smallImageHeightInMM = 80;
        private const int _displayNormalFontSize = 12;
        private const int _displaySmallFontSize = 8;

        private enum ImageSize
        {
            Small = 0,
            Normal = 1,
            Large = 2
        }

        public MotorTypePlateStickerUserControl()
        {
            InitializeComponent();
            CustomOrderVentilatorsDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(CustomOrderVentilatorsDataGrid_CellClick);
            CustomOrderVentilatorTestsDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(CustomOrderVentilatorTestsDataGrid_CellClick);
            LogosListBox.SelectedIndexChanged += new System.EventHandler(LogosListBox_SelectedIndexChanged);
            ArrowsListBox.SelectedIndexChanged += new System.EventHandler(ArrowsListBox_SelectedIndexChanged);
            btnSearch.Click += new System.EventHandler(BtnSearch_Click);
            btnPrint.Click += new System.EventHandler(BtnPrint_Click);

            PopulateListBox(LogosListBox, Environment.CurrentDirectory + "\\Resources\\Logos", "*.jpg");
            PopulateListBox(ArrowsListBox, Environment.CurrentDirectory + "\\Resources\\Arrows", "*.jpg");
            LogosListBox.SelectedIndex = 0;
            ArrowsListBox.SelectedIndex = 0;
            SelectedImageSize = ImageSize.Normal;
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
            if (e.RowIndex >= 0 && int.TryParse(CustomOrderVentilatorsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int ventilatorID))
            {
                SelectedVentilatorID = ventilatorID;
                SelectedVentilatorTestID = CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID).CustomOrderVentilatorTests.First().ID;
                var ventilator = CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
                if (ventilator != null)
                {
                    EnableReportButtons(ventilator);
                }
                InitializeGridData(false);
                ShowTable(SelectedImageSize);
            }
        }

        private void CustomOrderVentilatorTestsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && CustomOrderVentilatorTestsDataGrid.Rows[e.RowIndex].Cells[0].Value != null && int.TryParse(CustomOrderVentilatorTestsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString().Replace("Test ID ", ""), out int testID))
            {
                SelectedVentilatorTestID = testID;
                InitializeGridData(false, false);
                ShowTable(SelectedImageSize);
            }
        }

        private void EnableReportButtons(CustomOrderVentilator ventilator)
        {
            btnPrint.Enabled = true;// !ventilator.IsAtex();
        }

        private void InitializeGridData(bool initVentilatorsGrid = true, bool initVentilatorTestsGrid = true)
        {
            if (CustomOrder != null && initVentilatorsGrid)
            {
                CustomOrderVentilatorsDataGrid.DataSource = null;
                CustomOrderVentilatorsDataGrid.DataSource = CustomOrder.CustomOrderVentilators.ToList();
                CustomOrderVentilatorsDataGrid.AutoResizeColumns();
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

        private Bitmap GenerateTable(int imageWidthInMM, int imageHeightInMM, Graphics printerGraphics = null)
        {
            if (LogosListBox.SelectedItem == null || ArrowsListBox.SelectedItem == null || CustomOrder == null || CustomOrder.CustomOrderVentilators.Count == 0)
            {
                return null;
            }

            var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
            var ventilatorTest = SelectedVentilatorTestID == 0 ? ventilator.CustomOrderVentilatorTests.First() : ventilator.CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);

            // Convert image size from mm to pixels
            float dpiX = printerGraphics?.DpiX ?? 300;  // Default to 300 DPI if printerGraphics is null
            int imageWidthInPixels = (int)((imageWidthInMM / 25.4) * dpiX);
            int imageHeightInPixels = (int)((imageHeightInMM / 25.4) * dpiX);

            var rows = 14;
            var colWidth = (int)((imageWidthInPixels * 0.9) / 2);
            var rowHeight = (imageHeightInPixels / 21);
            var startX = 30;
            var startY = rowHeight * 4;

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
                graph.DrawImage(arrows, new Rectangle(0, startY, imageWidthInPixels, (rowHeight * rows) + startX + rowHeight));
                graph.DrawImage(logo, new Rectangle(startX, 0, colWidth * 2, rowHeight * 4));
                var printing = printerGraphics is not null;
                var font = CalculateFontSize(printing);

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
                            columns.Add(new StickerRowColumn() { LeftText = "Serial number", MiddleText = ventilatorTest.SerialNumber });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns, font);
                            break;

                        case 3:
                            columns.Add(new StickerRowColumn() { LeftText = "Year built", MiddleText = CustomOrder.CreateDate.GetValueOrDefault().Year.ToString() });
                            columns.Add(new StickerRowColumn() { LeftText = "Weight", MiddleText = ventilatorTest?.Weight.ToString(), RightText = "kg" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 4:
                            columns.Add(new StickerRowColumn() { LeftText = "FAN" });
                            columns.Add(new StickerRowColumn() { LeftText = "MOTOR", MiddleText = "Brand", RightText = ventilator.CustomOrderMotor.Name });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 5:
                            columns.Add(new StickerRowColumn() { LeftText = "Type", RightText = ventilator.Name });
                            columns.Add(new StickerRowColumn() { LeftText = "Frequency", MiddleText = ventilator.CustomOrderMotor.Frequency.ToString(), RightText = "Hz" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 6:
                            columns.Add(new StickerRowColumn() { LeftText = "V", MiddleText = DataHelper.CreateHighLowText(ventilator.HighAirVolume.ToString(), ventilator.LowAirVolume.ToString()), RightText = "m3/h" });
                            columns.Add(new StickerRowColumn() { LeftText = "Model", MiddleText = ventilator.CustomOrderMotor.Version });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 7:
                            columns.Add(new StickerRowColumn() { LeftText = "Ptot", MiddleText = DataHelper.CreateHighLowText(ventilator.HighPressureTotal.ToString(), ventilator.LowPressureTotal.ToString()), RightText = "Pa" });
                            columns.Add(new StickerRowColumn() { LeftText = "P", MiddleText = DataHelper.CreateHighLowText(ventilator.CustomOrderMotor.HighPower.ToString(), ventilator.CustomOrderMotor.LowPower.ToString()), RightText = "kW" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 8:
                            columns.Add(new StickerRowColumn() { LeftText = "Pst", MiddleText = DataHelper.CreateHighLowText(ventilator.HighPressureStatic.ToString(), ventilator.LowPressureStatic.ToString()), RightText = "Pa" });
                            columns.Add(new StickerRowColumn() { LeftText = "U", MiddleText = ventilator.CustomOrderMotor.VoltageType, RightText = "V" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 9:
                            columns.Add(new StickerRowColumn() { LeftText = "Pdyn", MiddleText = DataHelper.CreateHighLowText(ventilator.HighPressureDynamic.ToString(), ventilator.LowPressureDynamic.ToString()), RightText = "Pa" });
                            columns.Add(new StickerRowColumn() { LeftText = "Inom", MiddleText = DataHelper.CreateHighLowText(ventilator.CustomOrderMotor.HighPower.ToString(), ventilator.CustomOrderMotor.LowPower.ToString()), RightText = "A" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 10:
                            columns.Add(new StickerRowColumn() { LeftText = "Nfan", MiddleText = DataHelper.CreateHighLowText(ventilator.HighRPM.ToString(), ventilator.LowRPM.ToString()), RightText = "rpm" });
                            columns.Add(new StickerRowColumn() { LeftText = "Istart", MiddleText = DataHelper.CreateHighLowText(ventilator.CustomOrderMotor.HighStartupAmperage.ToString(), ventilator.CustomOrderMotor.LowStartupAmperage.ToString()), RightText = "A" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 11:
                            columns.Add(new StickerRowColumn() { LeftText = "Blade angle", MiddleText = ventilator.BladeAngle.ToString(), RightText = "°" });
                            columns.Add(new StickerRowColumn() { LeftText = "Nmotor", MiddleText = DataHelper.CreateHighLowText(ventilator.CustomOrderMotor.HighRPM.ToString(), ventilator.CustomOrderMotor.LowRPM.ToString()), RightText = "rpm" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 12:
                            columns.Add(new StickerRowColumn() { LeftText = "Sound power", MiddleText = ventilator.SoundLevel.ToString(), RightText = ventilator.SoundLevelType?.UOM });
                            columns.Add(new StickerRowColumn() { LeftText = "nr", MiddleText = ventilatorTest?.MotorNumber });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns, font);
                            break;

                        case 13:
                            columns.Add(new StickerRowColumn() { LeftText = "T", MiddleText = ventilator.TemperatureClass?.Description, RightText = "°C" });
                            columns.Add(new StickerRowColumn() { LeftText = "ρ", MiddleText = "1,20", RightText = "kg/m3" });
                            columns.Add(new StickerRowColumn() { LeftText = "IP", MiddleText = ventilator.CustomOrderMotor.IP.ToString() });
                            columns.Add(new StickerRowColumn() { LeftText = "ISO", MiddleText = ventilator.CustomOrderMotor.ISO });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 4, colWidth / 2, columns, font);
                            break;

                        case 14:
                            columns.Add(new StickerRowColumn());
                            columns.Add(new StickerRowColumn());
                            columns.Add(new StickerRowColumn() { LeftText = $"PTC", MiddleText = DataHelper.NullableBooleanToYesNo(ventilator.CustomOrderMotor.PTC) });
                            columns.Add(new StickerRowColumn() { LeftText = $"HT", MiddleText = DataHelper.NullableBooleanToYesNo(ventilator.CustomOrderMotor.HT) });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 4, colWidth / 2, columns, font);
                            break;

                        default:
                            break;
                    }
                }
            }
            return image;
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

        private Font CalculateFontSize(bool printing)
        {
            var fontSize = SelectedImageSize is ImageSize.Normal ? 3 : 2;
            if (!printing)
            {
                fontSize = SelectedImageSize is ImageSize.Normal ? _displayNormalFontSize : _displaySmallFontSize;
            }

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

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (CustomOrder == null)
            {
                MessageBox.Show("Please search a order first.");
                return;
            }

            var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
            var ventilatorTest = SelectedVentilatorTestID == 0 ? ventilator.CustomOrderVentilatorTests.First() : ventilator.CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);
            if (!BValidateMessage.ValidateForPrinting(ventilatorTest))
            {
                return;
            }

            var pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = StickerPrinterName;
            pd.PrintPage += PrintPage;
            pd.Print();
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            DetermineLabelSizeInMM(SelectedImageSize, out int imageWidthInMM, out int imageHeightInMM);
            var image = GenerateTable(imageWidthInMM, imageHeightInMM, e.Graphics);
            var loc = new Point(0, 0);
            if (SelectedImageSize is not ImageSize.Small)
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            e.Graphics.DrawImage(image, loc);
        }

        private void BtnSize_Click(object sender, EventArgs e)
        {
            if (btnSize.Text == ImageSize.Small.ToString())
            {
                btnSize.Text = "Normal";
                SelectedImageSize = ImageSize.Small;
            }
            else
            {
                btnSize.Text = ImageSize.Small.ToString();
                SelectedImageSize = ImageSize.Normal;
            }
            ShowTable(SelectedImageSize);
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