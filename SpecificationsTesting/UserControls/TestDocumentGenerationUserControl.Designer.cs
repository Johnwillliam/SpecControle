namespace SpecificationsTesting.UserControls
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
            this.CustomOrderVentilatorsDataGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustomOrderNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CustomOrderVentilatorTestsDataGrid = new System.Windows.Forms.DataGridView();
            this.btnPrintSelectedTest = new System.Windows.Forms.Button();
            this.btnPrintAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CustomOrderVentilatorsDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomOrderVentilatorTestsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomOrderVentilatorsDataGrid
            // 
            this.CustomOrderVentilatorsDataGrid.AllowUserToAddRows = false;
            this.CustomOrderVentilatorsDataGrid.AllowUserToDeleteRows = false;
            this.CustomOrderVentilatorsDataGrid.AllowUserToResizeColumns = false;
            this.CustomOrderVentilatorsDataGrid.AllowUserToResizeRows = false;
            this.CustomOrderVentilatorsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomOrderVentilatorsDataGrid.Location = new System.Drawing.Point(268, 22);
            this.CustomOrderVentilatorsDataGrid.Name = "CustomOrderVentilatorsDataGrid";
            this.CustomOrderVentilatorsDataGrid.Size = new System.Drawing.Size(209, 342);
            this.CustomOrderVentilatorsDataGrid.TabIndex = 47;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCustomOrderNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 100);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // txtCustomOrderNumber
            // 
            this.txtCustomOrderNumber.Location = new System.Drawing.Point(6, 35);
            this.txtCustomOrderNumber.Name = "txtCustomOrderNumber";
            this.txtCustomOrderNumber.Size = new System.Drawing.Size(247, 20);
            this.txtCustomOrderNumber.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "RO";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(6, 61);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(247, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Ventilators";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Tests";
            // 
            // CustomOrderVentilatorTestsDataGrid
            // 
            this.CustomOrderVentilatorTestsDataGrid.AllowUserToAddRows = false;
            this.CustomOrderVentilatorTestsDataGrid.AllowUserToDeleteRows = false;
            this.CustomOrderVentilatorTestsDataGrid.AllowUserToResizeColumns = false;
            this.CustomOrderVentilatorTestsDataGrid.AllowUserToResizeRows = false;
            this.CustomOrderVentilatorTestsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomOrderVentilatorTestsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomOrderVentilatorTestsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomOrderVentilatorTestsDataGrid.Location = new System.Drawing.Point(487, 22);
            this.CustomOrderVentilatorTestsDataGrid.Name = "CustomOrderVentilatorTestsDataGrid";
            this.CustomOrderVentilatorTestsDataGrid.Size = new System.Drawing.Size(132, 342);
            this.CustomOrderVentilatorTestsDataGrid.TabIndex = 51;
            // 
            // btnPrintSelectedTest
            // 
            this.btnPrintSelectedTest.Location = new System.Drawing.Point(9, 109);
            this.btnPrintSelectedTest.Name = "btnPrintSelectedTest";
            this.btnPrintSelectedTest.Size = new System.Drawing.Size(247, 23);
            this.btnPrintSelectedTest.TabIndex = 52;
            this.btnPrintSelectedTest.Text = "Print Selected Test";
            this.btnPrintSelectedTest.UseVisualStyleBackColor = true;
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Location = new System.Drawing.Point(9, 138);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(247, 23);
            this.btnPrintAll.TabIndex = 53;
            this.btnPrintAll.Text = "Print All Tests";
            this.btnPrintAll.UseVisualStyleBackColor = true;
            // 
            // TestDocumentGenerationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPrintAll);
            this.Controls.Add(this.btnPrintSelectedTest);
            this.Controls.Add(this.CustomOrderVentilatorTestsDataGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustomOrderVentilatorsDataGrid);
            this.Controls.Add(this.groupBox1);
            this.Name = "TestDocumentGenerationUserControl";
            this.Size = new System.Drawing.Size(1214, 401);
            ((System.ComponentModel.ISupportInitialize)(this.CustomOrderVentilatorsDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomOrderVentilatorTestsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
