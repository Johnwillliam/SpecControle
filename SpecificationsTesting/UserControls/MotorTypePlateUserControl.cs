using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecificationsTesting.Forms
{
    public partial class MotorTypePlateUserControl : UserControl
    {
        public MotorTypePlateUserControl()
        {
            InitializeComponent();
            PopulateListBox(LogosListBox, @"D:\Projecten\Fiverr\joitsys\SpecificationsTesting\SpecificationsTesting\Images\Logos", "*.jpg");
            PopulateListBox(ArrowsListBox, @"D:\Projecten\Fiverr\joitsys\SpecificationsTesting\SpecificationsTesting\Images\Arrows", "*.jpg");
            LogosListBox.SelectedIndex = 0;
            ArrowsListBox.SelectedIndex = 0;
            GenerateTable();
            this.LogosListBox.SelectedIndexChanged += new System.EventHandler(this.LogosListBox_SelectedIndexChanged);
            this.ArrowsListBox.SelectedIndexChanged += new System.EventHandler(this.ArrowsListBox_SelectedIndexChanged);
        }

        private void GenerateTable()
        {
            var imageWidth = 650;
            var imageHeight = 340;
            var image = new Bitmap(imageWidth, imageHeight);
            var rows = 11;
            var rowOffset = 2;
            var cols = 2;
            var colWidth = 270;
            var rowHeight = 20;
            var totalWidth = 0;
            var totalHeight = 0;
            var startX = 40;
            var startY = 100;
            var pen = new Pen(Color.Black, 2.0F);
            if (LogosListBox.SelectedItem == null || ArrowsListBox.SelectedItem == null)
                return;

            var logoFile = (FileInfo)LogosListBox.SelectedItem;
            var logo = Image.FromFile(logoFile.FullName);

            var arrowFile = (FileInfo)ArrowsListBox.SelectedItem;
            var arrows = Image.FromFile(arrowFile.FullName);
            using (Graphics graph = Graphics.FromImage(image))
            {
                graph.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), image.Size));
                graph.DrawImage(arrows, new Rectangle(startX + 20, startY - 20, 550, 250));

                graph.DrawImage(logo, new Rectangle(startX, 0, logo.Width / 5, logo.Height / 5));

                for (int row = 0; row < rows; row++)
                {
                    totalHeight = row * rowHeight;
                    graph.DrawLine(pen, new Point(startX, totalHeight + startY), new Point(cols * colWidth + startX, totalHeight + startY));
                }
                for (int col = 0; col < cols; col++)
                {
                    totalWidth += col * colWidth;
                    graph.DrawLine(pen, new Point(totalWidth + startX, startY + (rowOffset * rowHeight)), new Point(totalWidth + startX, totalHeight + startY));
                }

                graph.DrawRectangle(pen, new Rectangle(startX, startY, cols * colWidth, totalHeight));
                graph.DrawRectangle(pen, new Rectangle(new Point(0, 0), image.Size));
            }

            MotorTypePlateImage.Image = (Image)image;
            MotorTypePlateImage.Width = imageWidth;
            MotorTypePlateImage.Height = imageHeight;
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
            GenerateTable();
        }

        private void ArrowsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateTable();
        }

    }
}
