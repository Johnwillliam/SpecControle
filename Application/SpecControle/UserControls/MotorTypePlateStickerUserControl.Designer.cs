namespace SpecControle.UserControls
{
    partial class MotorTypePlateStickerUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPrint = new Button();
            label2 = new Label();
            label1 = new Label();
            ArrowsListBox = new ListBox();
            LogosListBox = new ListBox();
            MotorTypePlateImage = new PictureBox();
            groupBox1 = new GroupBox();
            txtCustomOrderNumber = new TextBox();
            label5 = new Label();
            btnSearch = new Button();
            CustomOrderVentilatorsDataGrid = new DataGridView();
            btnSize = new Button();
            CustomOrderVentilatorTestsDataGrid = new DataGridView();
            label7 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)MotorTypePlateImage).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CustomOrderVentilatorsDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CustomOrderVentilatorTestsDataGrid).BeginInit();
            SuspendLayout();
            // 
            // btnPrint
            // 
            btnPrint.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnPrint.Location = new Point(4, 487);
            btnPrint.Margin = new Padding(4, 3, 4, 3);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(183, 54);
            btnPrint.TabIndex = 11;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(772, 122);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(45, 13);
            label2.TabIndex = 10;
            label2.Text = "Arrows";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(923, 122);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(44, 13);
            label1.TabIndex = 9;
            label1.Text = "Logo's";
            // 
            // ArrowsListBox
            // 
            ArrowsListBox.FormattingEnabled = true;
            ArrowsListBox.ItemHeight = 15;
            ArrowsListBox.Location = new Point(772, 138);
            ArrowsListBox.Margin = new Padding(4, 3, 4, 3);
            ArrowsListBox.Name = "ArrowsListBox";
            ArrowsListBox.Size = new Size(135, 259);
            ArrowsListBox.TabIndex = 8;
            // 
            // LogosListBox
            // 
            LogosListBox.FormattingEnabled = true;
            LogosListBox.ItemHeight = 15;
            LogosListBox.Location = new Point(923, 138);
            LogosListBox.Margin = new Padding(4, 3, 4, 3);
            LogosListBox.Name = "LogosListBox";
            LogosListBox.Size = new Size(151, 259);
            LogosListBox.TabIndex = 7;
            // 
            // MotorTypePlateImage
            // 
            MotorTypePlateImage.Location = new Point(4, 3);
            MotorTypePlateImage.Margin = new Padding(4, 3, 4, 3);
            MotorTypePlateImage.Name = "MotorTypePlateImage";
            MotorTypePlateImage.Size = new Size(760, 480);
            MotorTypePlateImage.TabIndex = 6;
            MotorTypePlateImage.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCustomOrderNumber);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Location = new Point(772, 3);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(302, 115);
            groupBox1.TabIndex = 44;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search";
            // 
            // txtCustomOrderNumber
            // 
            txtCustomOrderNumber.Location = new Point(7, 40);
            txtCustomOrderNumber.Margin = new Padding(4, 3, 4, 3);
            txtCustomOrderNumber.Name = "txtCustomOrderNumber";
            txtCustomOrderNumber.Size = new Size(288, 23);
            txtCustomOrderNumber.TabIndex = 1;
            txtCustomOrderNumber.KeyDown += TxtCustomOrderNumber_KeyDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 22);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(24, 15);
            label5.TabIndex = 13;
            label5.Text = "CO";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(7, 70);
            btnSearch.Margin = new Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(288, 27);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // CustomOrderVentilatorsDataGrid
            // 
            CustomOrderVentilatorsDataGrid.AllowUserToAddRows = false;
            CustomOrderVentilatorsDataGrid.AllowUserToDeleteRows = false;
            CustomOrderVentilatorsDataGrid.AllowUserToResizeColumns = false;
            CustomOrderVentilatorsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorsDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CustomOrderVentilatorsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomOrderVentilatorsDataGrid.Location = new Point(1090, 25);
            CustomOrderVentilatorsDataGrid.Margin = new Padding(4, 3, 4, 3);
            CustomOrderVentilatorsDataGrid.MultiSelect = false;
            CustomOrderVentilatorsDataGrid.Name = "CustomOrderVentilatorsDataGrid";
            CustomOrderVentilatorsDataGrid.Size = new Size(170, 455);
            CustomOrderVentilatorsDataGrid.TabIndex = 45;
            // 
            // btnSize
            // 
            btnSize.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSize.Location = new Point(194, 487);
            btnSize.Margin = new Padding(4, 3, 4, 3);
            btnSize.Name = "btnSize";
            btnSize.Size = new Size(183, 54);
            btnSize.TabIndex = 46;
            btnSize.Text = "Small";
            btnSize.UseVisualStyleBackColor = true;
            btnSize.Click += BtnSize_Click;
            // 
            // CustomOrderVentilatorTestsDataGrid
            // 
            CustomOrderVentilatorTestsDataGrid.AllowUserToAddRows = false;
            CustomOrderVentilatorTestsDataGrid.AllowUserToDeleteRows = false;
            CustomOrderVentilatorTestsDataGrid.AllowUserToResizeColumns = false;
            CustomOrderVentilatorTestsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorTestsDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CustomOrderVentilatorTestsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomOrderVentilatorTestsDataGrid.Location = new Point(1267, 25);
            CustomOrderVentilatorTestsDataGrid.Margin = new Padding(4, 3, 4, 3);
            CustomOrderVentilatorTestsDataGrid.MultiSelect = false;
            CustomOrderVentilatorTestsDataGrid.Name = "CustomOrderVentilatorTestsDataGrid";
            CustomOrderVentilatorTestsDataGrid.Size = new Size(154, 455);
            CustomOrderVentilatorTestsDataGrid.TabIndex = 47;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(1264, 3);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(116, 16);
            label7.TabIndex = 60;
            label7.Text = "Ventilator Tests";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(1085, 3);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(81, 16);
            label6.TabIndex = 59;
            label6.Text = "Ventilators";
            // 
            // MotorTypePlateStickerUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(CustomOrderVentilatorTestsDataGrid);
            Controls.Add(btnSize);
            Controls.Add(CustomOrderVentilatorsDataGrid);
            Controls.Add(groupBox1);
            Controls.Add(btnPrint);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ArrowsListBox);
            Controls.Add(LogosListBox);
            Controls.Add(MotorTypePlateImage);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MotorTypePlateStickerUserControl";
            Size = new Size(1425, 730);
            ((System.ComponentModel.ISupportInitialize)MotorTypePlateImage).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CustomOrderVentilatorsDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)CustomOrderVentilatorTestsDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrint;
        private Label label2;
        private Label label1;
        private ListBox ArrowsListBox;
        private ListBox LogosListBox;
        private PictureBox MotorTypePlateImage;
        private GroupBox groupBox1;
        private TextBox txtCustomOrderNumber;
        private Label label5;
        private Button btnSearch;
        private DataGridView CustomOrderVentilatorsDataGrid;
        private Button btnSize;
        private DataGridView CustomOrderVentilatorTestsDataGrid;
        private Label label7;
        private Label label6;
    }
}
