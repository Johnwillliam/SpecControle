namespace SpecControle.UserControls
{
    partial class TestDocumentGenerationUserControl
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
            CustomOrderVentilatorsDataGrid = new DataGridView();
            groupBox1 = new GroupBox();
            txtCustomOrderNumber = new TextBox();
            label5 = new Label();
            btnSearch = new Button();
            label1 = new Label();
            label2 = new Label();
            CustomOrderVentilatorTestsDataGrid = new DataGridView();
            btnPrintSelectedTest = new Button();
            btnPrintAll = new Button();
            CustomOrderDataGrid = new DataGridView();
            VentilatorDataGrid = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            MotorDataGrid = new DataGridView();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)CustomOrderVentilatorsDataGrid).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CustomOrderVentilatorTestsDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CustomOrderDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VentilatorDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MotorDataGrid).BeginInit();
            SuspendLayout();
            // 
            // CustomOrderVentilatorsDataGrid
            // 
            CustomOrderVentilatorsDataGrid.AllowUserToAddRows = false;
            CustomOrderVentilatorsDataGrid.AllowUserToDeleteRows = false;
            CustomOrderVentilatorsDataGrid.AllowUserToResizeColumns = false;
            CustomOrderVentilatorsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomOrderVentilatorsDataGrid.Location = new Point(313, 25);
            CustomOrderVentilatorsDataGrid.Margin = new Padding(4, 3, 4, 3);
            CustomOrderVentilatorsDataGrid.Name = "CustomOrderVentilatorsDataGrid";
            CustomOrderVentilatorsDataGrid.Size = new Size(244, 395);
            CustomOrderVentilatorsDataGrid.TabIndex = 47;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCustomOrderNumber);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Location = new Point(4, 3);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(302, 115);
            groupBox1.TabIndex = 46;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(314, 5);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 48;
            label1.Text = "Ventilators";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(565, 5);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 50;
            label2.Text = "Tests";
            // 
            // CustomOrderVentilatorTestsDataGrid
            // 
            CustomOrderVentilatorTestsDataGrid.AllowUserToAddRows = false;
            CustomOrderVentilatorTestsDataGrid.AllowUserToDeleteRows = false;
            CustomOrderVentilatorTestsDataGrid.AllowUserToResizeColumns = false;
            CustomOrderVentilatorTestsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorTestsDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CustomOrderVentilatorTestsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CustomOrderVentilatorTestsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomOrderVentilatorTestsDataGrid.Location = new Point(568, 25);
            CustomOrderVentilatorTestsDataGrid.Margin = new Padding(4, 3, 4, 3);
            CustomOrderVentilatorTestsDataGrid.Name = "CustomOrderVentilatorTestsDataGrid";
            CustomOrderVentilatorTestsDataGrid.Size = new Size(154, 395);
            CustomOrderVentilatorTestsDataGrid.TabIndex = 51;
            // 
            // btnPrintSelectedTest
            // 
            btnPrintSelectedTest.Location = new Point(10, 126);
            btnPrintSelectedTest.Margin = new Padding(4, 3, 4, 3);
            btnPrintSelectedTest.Name = "btnPrintSelectedTest";
            btnPrintSelectedTest.Size = new Size(288, 27);
            btnPrintSelectedTest.TabIndex = 52;
            btnPrintSelectedTest.Text = "Print Selected Test";
            btnPrintSelectedTest.UseVisualStyleBackColor = true;
            // 
            // btnPrintAll
            // 
            btnPrintAll.Location = new Point(10, 159);
            btnPrintAll.Margin = new Padding(4, 3, 4, 3);
            btnPrintAll.Name = "btnPrintAll";
            btnPrintAll.Size = new Size(288, 27);
            btnPrintAll.TabIndex = 53;
            btnPrintAll.Text = "Print All Tests";
            btnPrintAll.UseVisualStyleBackColor = true;
            // 
            // CustomOrderDataGrid
            // 
            CustomOrderDataGrid.AllowUserToAddRows = false;
            CustomOrderDataGrid.AllowUserToDeleteRows = false;
            CustomOrderDataGrid.AllowUserToResizeColumns = false;
            CustomOrderDataGrid.AllowUserToResizeRows = false;
            CustomOrderDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomOrderDataGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            CustomOrderDataGrid.Location = new Point(729, 21);
            CustomOrderDataGrid.Margin = new Padding(4, 3, 4, 3);
            CustomOrderDataGrid.MultiSelect = false;
            CustomOrderDataGrid.Name = "CustomOrderDataGrid";
            CustomOrderDataGrid.ReadOnly = true;
            CustomOrderDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            CustomOrderDataGrid.Size = new Size(382, 113);
            CustomOrderDataGrid.TabIndex = 54;
            // 
            // VentilatorDataGrid
            // 
            VentilatorDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            VentilatorDataGrid.Location = new Point(729, 159);
            VentilatorDataGrid.Margin = new Padding(4, 3, 4, 3);
            VentilatorDataGrid.Name = "VentilatorDataGrid";
            VentilatorDataGrid.ReadOnly = true;
            VentilatorDataGrid.Size = new Size(382, 130);
            VentilatorDataGrid.TabIndex = 55;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(730, -1);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(101, 16);
            label3.TabIndex = 56;
            label3.Text = "Custom Order";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(730, 137);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(73, 16);
            label4.TabIndex = 57;
            label4.Text = "Ventilator";
            // 
            // MotorDataGrid
            // 
            MotorDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MotorDataGrid.Location = new Point(729, 315);
            MotorDataGrid.Margin = new Padding(4, 3, 4, 3);
            MotorDataGrid.Name = "MotorDataGrid";
            MotorDataGrid.ReadOnly = true;
            MotorDataGrid.Size = new Size(382, 380);
            MotorDataGrid.TabIndex = 58;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(730, 293);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(46, 16);
            label6.TabIndex = 59;
            label6.Text = "Motor";
            // 
            // TestDocumentGenerationUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CustomOrderDataGrid);
            Controls.Add(VentilatorDataGrid);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(MotorDataGrid);
            Controls.Add(label6);
            Controls.Add(btnPrintAll);
            Controls.Add(btnPrintSelectedTest);
            Controls.Add(CustomOrderVentilatorTestsDataGrid);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CustomOrderVentilatorsDataGrid);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "TestDocumentGenerationUserControl";
            Size = new Size(1416, 698);
            ((System.ComponentModel.ISupportInitialize)CustomOrderVentilatorsDataGrid).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CustomOrderVentilatorTestsDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)CustomOrderDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)VentilatorDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)MotorDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView CustomOrderVentilatorsDataGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustomOrderNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView CustomOrderVentilatorTestsDataGrid;
        private System.Windows.Forms.Button btnPrintSelectedTest;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.DataGridView CustomOrderDataGrid;
        private System.Windows.Forms.DataGridView VentilatorDataGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView MotorDataGrid;
        private System.Windows.Forms.Label label6;
    }
}
