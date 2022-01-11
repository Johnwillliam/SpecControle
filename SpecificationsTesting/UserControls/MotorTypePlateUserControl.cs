using EntityFrameworkModel;
using SpecificationsTesting.Business;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace SpecificationsTesting.Forms
{
    public partial class MotorTypePlateUserControl : UserControl
    {
        private CustomOrder CustomOrder { get; set; }
        public string PrinterName { get; set; }
        public MotorTypePlateUserControl()
        {
            InitializeComponent();
            PopulateListBox(LogosListBox, @"D:\Projecten\Fiverr\joitsys\SpecificationsTesting\SpecificationsTesting\Images\Logos", "*.jpg");
            PopulateListBox(ArrowsListBox, @"D:\Projecten\Fiverr\joitsys\SpecificationsTesting\SpecificationsTesting\Images\Arrows", "*.jpg");
            LogosListBox.SelectedIndex = 0;
            ArrowsListBox.SelectedIndex = 0;
            ShowTable();
            this.LogosListBox.SelectedIndexChanged += new System.EventHandler(this.LogosListBox_SelectedIndexChanged);
            this.ArrowsListBox.SelectedIndexChanged += new System.EventHandler(this.ArrowsListBox_SelectedIndexChanged);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
        }

        private void ShowTable()
        {
            var imageWidth = 650;
            var imageHeight = 340;
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

            var rows = 10;
            var rowOffset = 2;
            var cols = 2;
            var colWidth = 270;
            var textOffsetX = 5;
            var rowHeight = 20;
            var totalWidth = 0;
            var totalHeight = 0;
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
                graph.DrawImage(arrows, new Rectangle(startX + 20, startY - 20, 550, 250));
                graph.DrawImage(logo, new Rectangle(startX, 0, 550, 85));

                for (int row = 0; row < rows + 1; row++)
                {
                    totalHeight = row * rowHeight;
                    graph.DrawLine(pen, new Point(startX, totalHeight + startY), new Point(cols * colWidth + startX, totalHeight + startY));
                    if(row < rows)
                    {
                        string value = string.Empty;
                        switch (row)
                        {
                            case 1:
                                graph.DrawString("RO Nummer", font, Brushes.Black, startX, totalHeight + startY + 1);
                                graph.DrawString(CustomOrder?.CustomOrderNumber.ToString(), font, Brushes.Black, startX + colWidth + textOffsetX, totalHeight + startY + 1);

                                break;
                            case 2:
                                graph.DrawString("VENTILATOR", font, Brushes.Black, startX, totalHeight + startY + 1);
                                break;
                            case 3:
                                graph.DrawString("Type", font, Brushes.Black, startX, totalHeight + startY + 1);
                                //graph.DrawString(CustomOrder?.CustomOrderVentilators.ToString(), font, Brushes.Black, startX + colWidth + textOffsetX, totalHeight + startY + 1);
                                break;
                            default:
                                break;
                        }
                        //graph.DrawString(value, font, Brushes.Black, startX, totalHeight + startY + 1);
                    }
                }
                for (int col = 0; col < cols; col++)
                {
                    totalWidth += col * colWidth;
                    graph.DrawLine(pen, new Point(totalWidth + startX, startY + (rowOffset * rowHeight)), new Point(totalWidth + startX, totalHeight + startY));
                }

                graph.DrawRectangle(pen, new Rectangle(startX, startY, cols * colWidth, totalHeight));
                graph.DrawRectangle(pen, new Rectangle(new Point(0, 0), image.Size));
            }
            return (Image)image;
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
            ShowTable();
        }

        private void ArrowsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowTable();
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
            ShowTable();
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
    }
}
