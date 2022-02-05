using EntityFrameworkModel;
using SpecificationsTesting.Business;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SpecificationsTesting.Forms
{
    public partial class MotorTypePlateUserControl : UserControl
    {
        private CustomOrder CustomOrder { get; set; }
        public int SelectedVentilatorID { get; set; }
        public string PrinterName { get; set; }
        private ImageSize SelectedImageSize { get; set; }
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
        public MotorTypePlateUserControl()
        {
            InitializeComponent();
            this.CustomOrderVentilatorsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomOrderVentilatorsDataGrid_RowEnter);
            this.LogosListBox.SelectedIndexChanged += new System.EventHandler(this.LogosListBox_SelectedIndexChanged);
            this.ArrowsListBox.SelectedIndexChanged += new System.EventHandler(this.ArrowsListBox_SelectedIndexChanged);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            PopulateListBox(LogosListBox, @"D:\Projecten\Fiverr\joitsys\SpecificationsTesting\SpecificationsTesting\Images\Logos", "*.jpg");
            PopulateListBox(ArrowsListBox, @"D:\Projecten\Fiverr\joitsys\SpecificationsTesting\SpecificationsTesting\Images\Arrows", "*.jpg");
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

        private void InitializeGridData(bool initVentilatorsGrid = true)
        {
            if (CustomOrder != null && initVentilatorsGrid)
            {
                CustomOrderVentilatorsDataGrid.DataSource = null;
                CustomOrderVentilatorsDataGrid.DataSource = CustomOrder.CustomOrderVentilators.ToList();
                CustomOrderVentilatorsDataGrid.AutoResizeColumns();
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
                case ImageSize.Medium:
                    imageWidth = NormalImageWidth;
                    imageHeight = NormalImageHeight;
                    break;
                default:
                    imageWidth = NormalImageWidth;
                    imageHeight = NormalImageHeight;
                    break;
            }
            var image = GenerateTable(imageWidth, imageHeight);
            if (image != null)
            {
                MotorTypePlateImage.Image = (Image)image;
                MotorTypePlateImage.Width = imageWidth;
                MotorTypePlateImage.Height = imageHeight;
            }
        }

        private Image GenerateTable(int imageWidth, int imageHeight)
        {
            if (LogosListBox.SelectedItem == null || ArrowsListBox.SelectedItem == null)
                return null;

            if (CustomOrder == null || CustomOrder.CustomOrderVentilators.Count == 0)
                return null;

            var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);

            var rows = 13;
            var colWidth = (imageWidth / 2) - 70;
            var rowHeight = 15;
            var startX = 40;
            var startY = 100;
            var pen = new Pen(Color.Black, 2.0F);
            var font = new Font("Tahoma", 8, FontStyle.Bold);

            var logoFile = (FileInfo)LogosListBox.SelectedItem;
            var logo = Image.FromFile(logoFile.FullName);

            var arrowFile = (FileInfo)ArrowsListBox.SelectedItem;
            var arrows = Image.FromFile(arrowFile.FullName);

            var image = new Bitmap(imageWidth, imageHeight);
            using (Graphics graph = Graphics.FromImage(image))
            {
                graph.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), image.Size));
                graph.DrawImage(arrows, new Rectangle(startX / 2, startY - 20, imageWidth - 100, (rowHeight * rows)));
                graph.DrawImage(logo, new Rectangle(startX, 0, 550, 85));

                for (int row = 0; row < rows + 1; row++)
                {
                    var columns = new List<Column>();
                    switch (row)
                    {
                        case 1:
                            columns.Add(new Column() { LeftText = "RO Nummer", MiddleText = CustomOrder?.CustomOrderNumber.ToString() });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns);
                            break;
                        case 2:
                            columns.Add(new Column() { LeftText = "Serienummer", MiddleText = ventilator.Name });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 1, colWidth * 2, columns);
                            break;
                        case 3:
                            columns.Add(new Column() { LeftText = "Bouwjaar", MiddleText = "2021" });
                            columns.Add(new Column() { LeftText = "Gewicht", MiddleText = "70", RightText = "kg" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 4:
                            columns.Add(new Column() { LeftText = "VENTILATOR" });
                            columns.Add(new Column() { LeftText = "MOTOR", MiddleText = ventilator.CustomOrderMotor.Name });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 5:
                            columns.Add(new Column() { LeftText = "Type", MiddleText = ventilator.Name });
                            columns.Add(new Column() { LeftText = "Frequentie", MiddleText = ventilator.CustomOrderMotor.Frequency.ToString() });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 6:
                            columns.Add(new Column() { LeftText = "V", MiddleText = $"{ventilator.HighAirVolume} / {ventilator.LowAirVolume}", RightText = "m3/h" });
                            columns.Add(new Column() { LeftText = "Uitv.", MiddleText = ventilator.CustomOrderMotor.Type });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 7:
                            columns.Add(new Column() { LeftText = "Ptot", MiddleText = $"{ventilator.HighPressureTotal} / {ventilator.LowPressureTotal}", RightText = "Pa" });
                            columns.Add(new Column() { LeftText = "P", MiddleText = $"{ventilator.CustomOrderMotor.HighPower} / {ventilator.CustomOrderMotor.LowPower}", RightText = "kW" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 8:
                            columns.Add(new Column() { LeftText = "Pst", MiddleText = $"{ventilator.HighPressureStatic} / {ventilator.LowPressureStatic}", RightText = "Pa" });
                            columns.Add(new Column() { LeftText = "U", MiddleText = ventilator.CustomOrderMotor.VoltageType?.Voltage, RightText = "V" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 9:
                            columns.Add(new Column() { LeftText = "Pdyn", MiddleText = $"{ventilator.HighPressureDynamic} / {ventilator.LowPressureDynamic}", RightText = "Pa" });
                            columns.Add(new Column() { LeftText = "Inom", MiddleText = $"{ventilator.CustomOrderMotor.HighPower} / {ventilator.CustomOrderMotor.LowPower}", RightText = "A" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 10:
                            columns.Add(new Column() { LeftText = "Nvent", MiddleText = $"{ventilator.HighRPM} / {ventilator.LowRPM}", RightText = "rpm" });
                            columns.Add(new Column() { LeftText = "Istart", MiddleText = ventilator.CustomOrderMotor.StartupAmperage.ToString(), RightText = "A" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 11:
                            columns.Add(new Column() { LeftText = "Schoephoek", MiddleText = ventilator.BladeAngle.ToString(), RightText = "°" });
                            columns.Add(new Column() { LeftText = "Nmotor", MiddleText = $"{ventilator.CustomOrderMotor.HighRPM} / {ventilator.CustomOrderMotor.LowRPM}", RightText = "rpm" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 12:
                            columns.Add(new Column() { LeftText = "Geluidsvermogen", MiddleText = ventilator.SoundLevel.ToString(), RightText = ventilator.SoundLevelType?.UOM });
                            columns.Add(new Column() { LeftText = "nr", MiddleText = "abc" });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 2, colWidth, columns);
                            break;
                        case 13:
                            columns.Add(new Column() { LeftText = "T", MiddleText = ventilator.TemperatureClass?.Description, RightText = "°C" });
                            columns.Add(new Column() { LeftText = "p", MiddleText = "abc", RightText = "kg/m3" });
                            columns.Add(new Column() { LeftText = "IP", MiddleText = ventilator.CustomOrderMotor.IP.ToString() });
                            columns.Add(new Column() { LeftText = "ISO", MiddleText = ventilator.CustomOrderMotor.ISO });
                            CreateSingleRow(graph, rowHeight, startX, ref startY, 4, colWidth / 2, columns);
                            break;
                        default:
                            break;
                    }
                }
            }
            return (Image)image;
        }

        private void CreateSingleRow(Graphics graph, int rowHeight, int startX, ref int startY, int columnCount, int columnWidth, List<Column> columns)
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

        public void SelectCustomOrder(int customOrderNumber)
        {
            txtCustomOrderNumber.Text = customOrderNumber.ToString();
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
                return;
            }
            InitializeGridData();
            ShowTable(SelectedImageSize);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = PrinterName;
            pd.PrintPage += PrintPage;
            pd.Print();
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            var imageWidth = 650;
            var imageHeight = 340;
            var image = GenerateTable(imageWidth, imageHeight);
            Point loc = new Point(0, 0);
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
    }
    public class Column
    {
        public string LeftText { get; set; }
        public string MiddleText { get; set; }
        public string RightText { get; set; }
    }
}
