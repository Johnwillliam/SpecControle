﻿namespace SpecificationsTesting.Forms
{
    partial class AtexStickerUserControl
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LogosListBox = new System.Windows.Forms.ListBox();
            this.MotorTypePlateImage = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustomOrderNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.CustomOrderVentilatorsDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.MotorTypePlateImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomOrderVentilatorsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(3, 564);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(157, 47);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(659, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Logo\'s";
            // 
            // LogosListBox
            // 
            this.LogosListBox.FormattingEnabled = true;
            this.LogosListBox.Location = new System.Drawing.Point(662, 120);
            this.LogosListBox.Name = "LogosListBox";
            this.LogosListBox.Size = new System.Drawing.Size(130, 225);
            this.LogosListBox.TabIndex = 7;
            // 
            // MotorTypePlateImage
            // 
            this.MotorTypePlateImage.Location = new System.Drawing.Point(3, 3);
            this.MotorTypePlateImage.Name = "MotorTypePlateImage";
            this.MotorTypePlateImage.Size = new System.Drawing.Size(650, 557);
            this.MotorTypePlateImage.TabIndex = 6;
            this.MotorTypePlateImage.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCustomOrderNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(662, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 100);
            this.groupBox1.TabIndex = 44;
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
            // CustomOrderVentilatorsDataGrid
            // 
            this.CustomOrderVentilatorsDataGrid.AllowUserToAddRows = false;
            this.CustomOrderVentilatorsDataGrid.AllowUserToDeleteRows = false;
            this.CustomOrderVentilatorsDataGrid.AllowUserToResizeColumns = false;
            this.CustomOrderVentilatorsDataGrid.AllowUserToResizeRows = false;
            this.CustomOrderVentilatorsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomOrderVentilatorsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomOrderVentilatorsDataGrid.Location = new System.Drawing.Point(927, 3);
            this.CustomOrderVentilatorsDataGrid.Name = "CustomOrderVentilatorsDataGrid";
            this.CustomOrderVentilatorsDataGrid.Size = new System.Drawing.Size(209, 342);
            this.CustomOrderVentilatorsDataGrid.TabIndex = 45;
            // 
            // AtexStickerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.CustomOrderVentilatorsDataGrid);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogosListBox);
            this.Controls.Add(this.MotorTypePlateImage);
            this.Name = "AtexStickerUserControl";
            this.Size = new System.Drawing.Size(1139, 627);
            ((System.ComponentModel.ISupportInitialize)(this.MotorTypePlateImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomOrderVentilatorsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox LogosListBox;
        private System.Windows.Forms.PictureBox MotorTypePlateImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustomOrderNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView CustomOrderVentilatorsDataGrid;
    }
}
