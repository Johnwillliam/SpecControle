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

namespace SpecificationsTesting.Forms
{
    public partial class MotorTypePlateStickerUserControl : UserControl
    {
        private CustomOrder CustomOrder { get; set; }
        public int SelectedVentilatorID { get; set; }
        public string StickerPrinterName { get; set; }
        private ImageSize SelectedImageSize { get; set; }
        public int SelectedVentilatorTestID { get; private set; }

        private const int NormalImageWidth = 650;
        private const int NormalImageHeight = 400;
        private const int SmallImageWidth = 580;
        private const int SmallImageHeight = 400;

        private enum ImageSize
        {
            Small = 0,
            Medium = 1,
            Large = 2
        }
        public MotorTypePlateStickerUserControl()
        {
            InitializeComponent();
            CustomOrderVentilatorsDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(CustomOrderVentilatorsDataGrid_CellClick);
            CustomOrderVentilatorTestsDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(CustomOrderVentilatorTestsDataGrid_CellClick);
            LogosListBox.SelectedIndexChanged += new System.EventHandler(LogosListBox_SelectedIndexChanged);
            ArrowsListBox.SelectedIndexChanged += new System.EventHandler(ArrowsListBox_SelectedIndexChanged);
            btnSearch.Click += new System.EventHandler(btnSearch_Click);
            btnPrint.Click += new System.EventHandler(btnPrint_Click);

            PopulateListBox(LogosListBox, Environment.CurrentDirectory + "\\Resources\\Logos", "*.jpg");
            PopulateListBox(ArrowsListBox, Environment.CurrentDirectory + "\\Resources\\Arrows", "*.jpg");
            LogosListBox.SelectedIndex = 0;
            ArrowsListBox.SelectedIndex = 0;
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
            if (e.RowIndex >= 0 && int.TryParse(CustomOrderVentilatorsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int ventilatorID))
            {
                SelectedVentilatorID = ventilatorID;
                SelectedVentilatorTestID = CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID).CustomOrderVentilatorTests.First().ID;
                var ventilator = CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
                EnableReportButtons(ventilator);
                InitializeGridData(false);
                ShowTable(SelectedImageSize);
            }
        }

        private void CustomOrderVentilatorTestsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CustomOrderVentilatorTestsDataGrid.Rows[e.RowIndex].Cells[0].Value != null && int.TryParse(CustomOrderVentilatorTestsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString().Replace("Test ID ", ""), out int testID))
            {
                SelectedVentilatorTestID = testID;
                InitializeGridData(false, false); 
                ShowTable(SelectedImageSize);
            }
        }

        private void EnableReportButtons(CustomOrderVentilator ventilator)
        {
            btnPrint.Enabled = !ventilator.IsAtex();
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
            var image = GenerateTable(imageWidth, imageHeight);
            if (image != null)
            {
                MotorTypePlateImage.Image = image;
                MotorTypePlateImage.Width = imageWidth;
                MotorTypePlateImage.Height = imageHeight;
            }
        }

        private Bitmap GenerateTable(int imageWidth, int imageHeight, Graphics printerGraphics = null)
        {
            if (LogosListBox.SelectedItem == null || ArrowsListBox.SelectedItem == null)
                return null;

            if (CustomOrder == null || CustomOrder.CustomOrderVentilators.Count == 0)
                return null;

            var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
            var ventilatorTest = SelectedVentilatorTestID == 0 ? ventilator.CustomOrderVentilatorTests.First() : ventilator.CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);

            var rows = 13;
            var colWidth = (int)((imageWidth * 0.9) / 2);
            var rowHeight = (imageHeight / 21);
            var startX = 30;
            var startY = rowHeight * 4;

            var logoFile = (FileInfo)LogosListBox.SelectedItem;
            var logo = Image.FromFile(logoFile.FullName);

            var arrowFile = (FileInfo)ArrowsListBox.SelectedItem;
            var arrows = Image.FromFile(arrowFile.FullName);

            var image = new Bitmap(imageWidth, imageHeight); 
            if (printerGraphics != null)
            {
                image.SetResolution(printerGraphics.DpiX, printerGraphics.DpiY);
            }
            using (Graphics graph = Graphics.FromImage(image))
            {
                graph.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), image.Size));
                graph.DrawImage(arrows, new Rectangle(0, startY, imageWidth, (rowHeight * rows) + startX + rowHeight));
                graph.DrawImage(logo, new Rectangle(startX, 0, colWidth * 2, rowHeight * 4));

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
                            columns.Add(new StickerRowColumn() { LeftText = "Serienummer", MiddleText = CustomOrder?.CustomOrderNumber.ToString() });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns);
                            break;
                        case 3:
                            columns.Add(new StickerRowColumn() { LeftText = "Bouwjaar", MiddleText = CustomOrder.CreateDate.GetValueOrDefault().Year.ToString() });
                            columns.Add(new StickerRowColumn() { LeftText = "Gewicht", MiddleText = ventilatorTest?.Weight.ToString(), RightText = "kg" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 4:
                            columns.Add(new StickerRowColumn() { LeftText = "VENTILATOR" });
                            columns.Add(new StickerRowColumn() { LeftText = "MOTOR", MiddleText = "Merk", RightText = ventilator.CustomOrderMotor.Name });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 5:
                            columns.Add(new StickerRowColumn() { LeftText = "Type", MiddleText = ventilator.Name });
                            columns.Add(new StickerRowColumn() { LeftText = "Frequentie", MiddleText = ventilator.CustomOrderMotor.Frequency.ToString(), RightText = "Hz" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 6:
                            columns.Add(new StickerRowColumn() { LeftText = "V", MiddleText = DataHelper.CreateHighLowText(ventilator.HighAirVolume.ToString(), ventilator.LowAirVolume.ToString()), RightText = "m3/h" });
                            columns.Add(new StickerRowColumn() { LeftText = "Uitv.", MiddleText = ventilator.CustomOrderMotor.Version });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 7:
                            columns.Add(new StickerRowColumn() { LeftText = "Ptot", MiddleText = DataHelper.CreateHighLowText(ventilator.HighPressureTotal.ToString(), ventilator.LowPressureTotal.ToString()), RightText = "Pa" });
                            columns.Add(new StickerRowColumn() { LeftText = "P", MiddleText = DataHelper.CreateHighLowText(ventilator.CustomOrderMotor.HighPower.ToString(), ventilator.CustomOrderMotor.LowPower.ToString()), RightText = "kW" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 8:
                            columns.Add(new StickerRowColumn() { LeftText = "Pst", MiddleText = DataHelper.CreateHighLowText(ventilator.HighPressureStatic.ToString(), ventilator.LowPressureStatic.ToString()), RightText = "Pa" });
                            columns.Add(new StickerRowColumn() { LeftText = "U", MiddleText = ventilator.CustomOrderMotor.VoltageType, RightText = "V" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 9:
                            columns.Add(new StickerRowColumn() { LeftText = "Pdyn", MiddleText = DataHelper.CreateHighLowText(ventilator.HighPressureDynamic.ToString(), ventilator.LowPressureDynamic.ToString()), RightText = "Pa" });
                            columns.Add(new StickerRowColumn() { LeftText = "Inom", MiddleText = DataHelper.CreateHighLowText(ventilator.CustomOrderMotor.HighPower.ToString(), ventilator.CustomOrderMotor.LowPower.ToString()), RightText = "A" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 10:
                            columns.Add(new StickerRowColumn() { LeftText = "Nvent", MiddleText = DataHelper.CreateHighLowText(ventilator.HighRPM.ToString(), ventilator.LowRPM.ToString()), RightText = "rpm" });
                            columns.Add(new StickerRowColumn() { LeftText = "Istart", MiddleText = ventilator.CustomOrderMotor.StartupAmperage.ToString(), RightText = "A" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 11:
                            columns.Add(new StickerRowColumn() { LeftText = "Schoephoek", MiddleText = ventilator.BladeAngle.ToString(), RightText = "°" });
                            columns.Add(new StickerRowColumn() { LeftText = "Nmotor", MiddleText = DataHelper.CreateHighLowText(ventilator.CustomOrderMotor.HighRPM.ToString(), ventilator.CustomOrderMotor.LowRPM.ToString()), RightText = "rpm" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 12:
                            columns.Add(new StickerRowColumn() { LeftText = "Geluidsvermogen", MiddleText = ventilator.SoundLevel.ToString(), RightText = ventilator.SoundLevelType?.UOM });
                            columns.Add(new StickerRowColumn() { LeftText = "nr", MiddleText = ventilatorTest?.MotorNumber });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 13:
                            columns.Add(new StickerRowColumn() { LeftText = "T", MiddleText = ventilator.TemperatureClass?.Description, RightText = "°C" });
                            columns.Add(new StickerRowColumn() { LeftText = "ρ", MiddleText = "1,20", RightText = "kg/m3" });
                            columns.Add(new StickerRowColumn() { LeftText = "IP", MiddleText = ventilator.CustomOrderMotor.IP.ToString() });
                            columns.Add(new StickerRowColumn() { LeftText = "ISO", MiddleText = ventilator.CustomOrderMotor.ISO });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 4, colWidth / 2, columns);
                            break;
                        default:
                            break;
                    }
                }
            }
            return image;
        }

        private void CreateSingleRow(Graphics graph, int rowHeight, int startX, ref int startY, int columnCount, int columnWidth, List<StickerRowColumn> columns)
        {
            var pen = new Pen(Color.Black, 2.0F);
            var fontPoints = (double)8 / 72;
            var sizeInPixels = (float)(fontPoints * graph.DpiX);
            var font = new Font("Tahoma", sizeInPixels, FontStyle.Bold, GraphicsUnit.Pixel);
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
            if(ShowCustomOrder(false))
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
            if(showTable)
            {
                ShowTable(SelectedImageSize);
            }

            var ventilator = SelectedVentilatorID == 0 || SelectedVentilatorID == -1 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.Single(x => x.ID == SelectedVentilatorID);
            EnableReportButtons(ventilator);
            return true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
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
            pd.PrinterSettings.DefaultPageSettings.PrinterResolution.X = 300;
            pd.PrinterSettings.DefaultPageSettings.PrinterResolution.Y = 300;
            pd.PrintPage += PrintPage;
            pd.Print();
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            var imageWidth = 150;
            var imageHeight = 100;
            //pixel = dpi * mm / 25.4 mm (1 in)
            var widthPixels = (int)((e.Graphics.DpiX / 25.4) * imageWidth);
            var heightPixels = (int)((e.Graphics.DpiX / 25.4) * imageHeight);
            var image = GenerateTable(widthPixels, heightPixels, e.Graphics);
            Point loc = new Point(0, 0);
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            e.Graphics.DrawImage(image, loc);
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            if (btnSize.Text == "Small")
            {
                btnSize.Text = "Large";
                SelectedImageSize = ImageSize.Small;
            }
            else
            {
                btnSize.Text = "Small";
                SelectedImageSize = ImageSize.Medium;
            }
            ShowTable(SelectedImageSize);
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
