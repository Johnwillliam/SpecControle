
namespace SpecificationsTesting
{
    partial class CustomOrderForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.btnCreateCO = new System.Windows.Forms.Button();
      this.txtCustomOrderNumber = new System.Windows.Forms.TextBox();
      this.btnSearch = new System.Windows.Forms.Button();
      this.CustomOrderDataGrid = new System.Windows.Forms.DataGridView();
      this.CustomOrderVentilatorsDataGrid = new System.Windows.Forms.DataGridView();
      this.VentilatorDataGrid = new System.Windows.Forms.DataGridView();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.MotorDataGrid = new System.Windows.Forms.DataGridView();
      this.label4 = new System.Windows.Forms.Label();
      this.ConfigDataGrid = new System.Windows.Forms.DataGridView();
      this.cmbMotorFilter = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label6 = new System.Windows.Forms.Label();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnSaveChanges = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.CustomOrderDataGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.CustomOrderVentilatorsDataGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.VentilatorDataGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MotorDataGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ConfigDataGrid)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnCreateCO
      // 
      this.btnCreateCO.Location = new System.Drawing.Point(345, 66);
      this.btnCreateCO.Name = "btnCreateCO";
      this.btnCreateCO.Size = new System.Drawing.Size(259, 23);
      this.btnCreateCO.TabIndex = 0;
      this.btnCreateCO.Text = "Create";
      this.btnCreateCO.UseVisualStyleBackColor = true;
      this.btnCreateCO.Click += new System.EventHandler(this.btnCreateCO_Click);
      // 
      // txtCustomOrderNumber
      // 
      this.txtCustomOrderNumber.Location = new System.Drawing.Point(345, 40);
      this.txtCustomOrderNumber.Name = "txtCustomOrderNumber";
      this.txtCustomOrderNumber.Size = new System.Drawing.Size(259, 20);
      this.txtCustomOrderNumber.TabIndex = 1;
      // 
      // btnSearch
      // 
      this.btnSearch.Location = new System.Drawing.Point(345, 277);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(259, 23);
      this.btnSearch.TabIndex = 2;
      this.btnSearch.Text = "Search";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // CustomOrderDataGrid
      // 
      this.CustomOrderDataGrid.AllowUserToAddRows = false;
      this.CustomOrderDataGrid.AllowUserToDeleteRows = false;
      this.CustomOrderDataGrid.AllowUserToResizeColumns = false;
      this.CustomOrderDataGrid.AllowUserToResizeRows = false;
      this.CustomOrderDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.CustomOrderDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.CustomOrderDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
      this.CustomOrderDataGrid.Location = new System.Drawing.Point(12, 31);
      this.CustomOrderDataGrid.MultiSelect = false;
      this.CustomOrderDataGrid.Name = "CustomOrderDataGrid";
      this.CustomOrderDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.CustomOrderDataGrid.Size = new System.Drawing.Size(327, 157);
      this.CustomOrderDataGrid.TabIndex = 3;
      // 
      // CustomOrderVentilatorsDataGrid
      // 
      this.CustomOrderVentilatorsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.CustomOrderVentilatorsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.CustomOrderVentilatorsDataGrid.Location = new System.Drawing.Point(610, 12);
      this.CustomOrderVentilatorsDataGrid.Name = "CustomOrderVentilatorsDataGrid";
      this.CustomOrderVentilatorsDataGrid.Size = new System.Drawing.Size(282, 903);
      this.CustomOrderVentilatorsDataGrid.TabIndex = 4;
      this.CustomOrderVentilatorsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomOrderVentilatorsDataGrid_RowEnter);
      // 
      // VentilatorDataGrid
      // 
      this.VentilatorDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.VentilatorDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.VentilatorDataGrid.Location = new System.Drawing.Point(12, 210);
      this.VentilatorDataGrid.Name = "VentilatorDataGrid";
      this.VentilatorDataGrid.Size = new System.Drawing.Size(327, 266);
      this.VentilatorDataGrid.TabIndex = 5;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(13, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(102, 16);
      this.label1.TabIndex = 6;
      this.label1.Text = "Custom Order";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(9, 191);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(74, 16);
      this.label2.TabIndex = 7;
      this.label2.Text = "Ventilator";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(13, 479);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(47, 16);
      this.label3.TabIndex = 9;
      this.label3.Text = "Motor";
      // 
      // MotorDataGrid
      // 
      this.MotorDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.MotorDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.MotorDataGrid.Location = new System.Drawing.Point(12, 498);
      this.MotorDataGrid.Name = "MotorDataGrid";
      this.MotorDataGrid.Size = new System.Drawing.Size(327, 274);
      this.MotorDataGrid.TabIndex = 8;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(9, 775);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(87, 16);
      this.label4.TabIndex = 11;
      this.label4.Text = "Configurate";
      // 
      // ConfigDataGrid
      // 
      this.ConfigDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ConfigDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.ConfigDataGrid.Location = new System.Drawing.Point(12, 794);
      this.ConfigDataGrid.Name = "ConfigDataGrid";
      this.ConfigDataGrid.Size = new System.Drawing.Size(327, 126);
      this.ConfigDataGrid.TabIndex = 10;
      // 
      // cmbMotorFilter
      // 
      this.cmbMotorFilter.FormattingEnabled = true;
      this.cmbMotorFilter.Location = new System.Drawing.Point(6, 64);
      this.cmbMotorFilter.Name = "cmbMotorFilter";
      this.cmbMotorFilter.Size = new System.Drawing.Size(246, 21);
      this.cmbMotorFilter.TabIndex = 12;
      this.cmbMotorFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMotorFilter_KeyPress);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(346, 24);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(23, 13);
      this.label5.TabIndex = 13;
      this.label5.Text = "RO";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(6, 38);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(246, 20);
      this.textBox1.TabIndex = 15;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.textBox1);
      this.groupBox1.Controls.Add(this.cmbMotorFilter);
      this.groupBox1.Location = new System.Drawing.Point(345, 143);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(259, 99);
      this.groupBox1.TabIndex = 16;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Selecteer Motor";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 19);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(32, 13);
      this.label6.TabIndex = 16;
      this.label6.Text = "Filter:";
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(345, 306);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(259, 23);
      this.btnClear.TabIndex = 17;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // btnSaveChanges
      // 
      this.btnSaveChanges.Location = new System.Drawing.Point(345, 95);
      this.btnSaveChanges.Name = "btnSaveChanges";
      this.btnSaveChanges.Size = new System.Drawing.Size(259, 23);
      this.btnSaveChanges.TabIndex = 18;
      this.btnSaveChanges.Text = "Save Changes";
      this.btnSaveChanges.UseVisualStyleBackColor = true;
      this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(904, 927);
      this.Controls.Add(this.btnSaveChanges);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.ConfigDataGrid);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.MotorDataGrid);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.VentilatorDataGrid);
      this.Controls.Add(this.CustomOrderVentilatorsDataGrid);
      this.Controls.Add(this.CustomOrderDataGrid);
      this.Controls.Add(this.btnSearch);
      this.Controls.Add(this.txtCustomOrderNumber);
      this.Controls.Add(this.btnCreateCO);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.CustomOrderDataGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.CustomOrderVentilatorsDataGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.VentilatorDataGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MotorDataGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ConfigDataGrid)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateCO;
        private System.Windows.Forms.TextBox txtCustomOrderNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView CustomOrderDataGrid;
        private System.Windows.Forms.DataGridView CustomOrderVentilatorsDataGrid;
        private System.Windows.Forms.DataGridView VentilatorDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView MotorDataGrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView ConfigDataGrid;
    private System.Windows.Forms.ComboBox cmbMotorFilter;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnSaveChanges;
  }
}

