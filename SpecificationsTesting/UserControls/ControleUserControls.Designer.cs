namespace SpecificationsTesting.UserControls
{
    partial class ControleUserControl
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
            this.CustomOrderDataGrid = new System.Windows.Forms.DataGridView();
            this.CustomOrderVentilatorsDataGrid = new System.Windows.Forms.DataGridView();
            this.VentilatorDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MotorDataGrid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectedVentilatorTestDataGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustomOrderNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.CustomOrderVentilatorTestsDataGrid = new System.Windows.Forms.DataGridView();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.radioButtonMotorHigh = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReadRPM = new System.Windows.Forms.Button();
            this.radioButtonVentilatorLow = new System.Windows.Forms.RadioButton();
            this.radioButtonVentilatorHigh = new System.Windows.Forms.RadioButton();
            this.radioButtonMotorLow = new System.Windows.Forms.RadioButton();
            this.btnMotorTypePlate = new System.Windows.Forms.Button();
            this.btnAtex = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CustomOrderDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomOrderVentilatorsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VentilatorDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MotorDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedVentilatorTestDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomOrderVentilatorTestsDataGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CustomOrderDataGrid
            // 
            this.CustomOrderDataGrid.AllowUserToAddRows = false;
            this.CustomOrderDataGrid.AllowUserToDeleteRows = false;
            this.CustomOrderDataGrid.AllowUserToResizeColumns = false;
            this.CustomOrderDataGrid.AllowUserToResizeRows = false;
            this.CustomOrderDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomOrderDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.CustomOrderDataGrid.Location = new System.Drawing.Point(3, 22);
            this.CustomOrderDataGrid.MultiSelect = false;
            this.CustomOrderDataGrid.Name = "CustomOrderDataGrid";
            this.CustomOrderDataGrid.ReadOnly = true;
            this.CustomOrderDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.CustomOrderDataGrid.Size = new System.Drawing.Size(327, 98);
            this.CustomOrderDataGrid.TabIndex = 33;
            // 
            // CustomOrderVentilatorsDataGrid
            // 
            this.CustomOrderVentilatorsDataGrid.AllowUserToAddRows = false;
            this.CustomOrderVentilatorsDataGrid.AllowUserToDeleteRows = false;
            this.CustomOrderVentilatorsDataGrid.AllowUserToResizeColumns = false;
            this.CustomOrderVentilatorsDataGrid.AllowUserToResizeRows = false;
            this.CustomOrderVentilatorsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomOrderVentilatorsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomOrderVentilatorsDataGrid.Location = new System.Drawing.Point(937, 22);
            this.CustomOrderVentilatorsDataGrid.Name = "CustomOrderVentilatorsDataGrid";
            this.CustomOrderVentilatorsDataGrid.Size = new System.Drawing.Size(147, 575);
            this.CustomOrderVentilatorsDataGrid.TabIndex = 34;
            // 
            // VentilatorDataGrid
            // 
            this.VentilatorDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VentilatorDataGrid.Location = new System.Drawing.Point(3, 142);
            this.VentilatorDataGrid.Name = "VentilatorDataGrid";
            this.VentilatorDataGrid.ReadOnly = true;
            this.VentilatorDataGrid.Size = new System.Drawing.Size(327, 113);
            this.VentilatorDataGrid.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Custom Order";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "Ventilator";
            // 
            // MotorDataGrid
            // 
            this.MotorDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MotorDataGrid.Location = new System.Drawing.Point(3, 277);
            this.MotorDataGrid.Name = "MotorDataGrid";
            this.MotorDataGrid.ReadOnly = true;
            this.MotorDataGrid.Size = new System.Drawing.Size(327, 320);
            this.MotorDataGrid.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "Motor";
            // 
            // SelectedVentilatorTestDataGrid
            // 
            this.SelectedVentilatorTestDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelectedVentilatorTestDataGrid.Location = new System.Drawing.Point(336, 22);
            this.SelectedVentilatorTestDataGrid.Name = "SelectedVentilatorTestDataGrid";
            this.SelectedVentilatorTestDataGrid.Size = new System.Drawing.Size(327, 398);
            this.SelectedVentilatorTestDataGrid.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(337, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "Test";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCustomOrderNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(669, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 100);
            this.groupBox1.TabIndex = 43;
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
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(675, 128);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(247, 23);
            this.btnClear.TabIndex = 42;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // CustomOrderVentilatorTestsDataGrid
            // 
            this.CustomOrderVentilatorTestsDataGrid.AllowUserToAddRows = false;
            this.CustomOrderVentilatorTestsDataGrid.AllowUserToDeleteRows = false;
            this.CustomOrderVentilatorTestsDataGrid.AllowUserToResizeColumns = false;
            this.CustomOrderVentilatorTestsDataGrid.AllowUserToResizeRows = false;
            this.CustomOrderVentilatorTestsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomOrderVentilatorTestsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomOrderVentilatorTestsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomOrderVentilatorTestsDataGrid.Location = new System.Drawing.Point(1090, 22);
            this.CustomOrderVentilatorTestsDataGrid.Name = "CustomOrderVentilatorTestsDataGrid";
            this.CustomOrderVentilatorTestsDataGrid.Size = new System.Drawing.Size(132, 575);
            this.CustomOrderVentilatorTestsDataGrid.TabIndex = 44;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(675, 157);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(247, 23);
            this.btnSaveChanges.TabIndex = 45;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(542, 246);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(121, 21);
            this.cmbUser.TabIndex = 52;
            // 
            // radioButtonMotorHigh
            // 
            this.radioButtonMotorHigh.AutoSize = true;
            this.radioButtonMotorHigh.Location = new System.Drawing.Point(6, 19);
            this.radioButtonMotorHigh.Name = "radioButtonMotorHigh";
            this.radioButtonMotorHigh.Size = new System.Drawing.Size(104, 17);
            this.radioButtonMotorHigh.TabIndex = 53;
            this.radioButtonMotorHigh.TabStop = true;
            this.radioButtonMotorHigh.Text = "Motor High RPM";
            this.radioButtonMotorHigh.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReadRPM);
            this.groupBox2.Controls.Add(this.radioButtonVentilatorLow);
            this.groupBox2.Controls.Add(this.radioButtonVentilatorHigh);
            this.groupBox2.Controls.Add(this.radioButtonMotorLow);
            this.groupBox2.Controls.Add(this.radioButtonMotorHigh);
            this.groupBox2.Location = new System.Drawing.Point(397, 449);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 148);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RPM Measurements";
            // 
            // btnReadRPM
            // 
            this.btnReadRPM.Location = new System.Drawing.Point(6, 119);
            this.btnReadRPM.Name = "btnReadRPM";
            this.btnReadRPM.Size = new System.Drawing.Size(188, 23);
            this.btnReadRPM.TabIndex = 57;
            this.btnReadRPM.Text = "Read";
            this.btnReadRPM.UseVisualStyleBackColor = true;
            // 
            // radioButtonVentilatorLow
            // 
            this.radioButtonVentilatorLow.AutoSize = true;
            this.radioButtonVentilatorLow.Location = new System.Drawing.Point(6, 88);
            this.radioButtonVentilatorLow.Name = "radioButtonVentilatorLow";
            this.radioButtonVentilatorLow.Size = new System.Drawing.Size(119, 17);
            this.radioButtonVentilatorLow.TabIndex = 56;
            this.radioButtonVentilatorLow.TabStop = true;
            this.radioButtonVentilatorLow.Text = "Ventilator Low RPM";
            this.radioButtonVentilatorLow.UseVisualStyleBackColor = true;
            // 
            // radioButtonVentilatorHigh
            // 
            this.radioButtonVentilatorHigh.AutoSize = true;
            this.radioButtonVentilatorHigh.Location = new System.Drawing.Point(6, 65);
            this.radioButtonVentilatorHigh.Name = "radioButtonVentilatorHigh";
            this.radioButtonVentilatorHigh.Size = new System.Drawing.Size(121, 17);
            this.radioButtonVentilatorHigh.TabIndex = 55;
            this.radioButtonVentilatorHigh.TabStop = true;
            this.radioButtonVentilatorHigh.Text = "Ventilator High RPM";
            this.radioButtonVentilatorHigh.UseVisualStyleBackColor = true;
            // 
            // radioButtonMotorLow
            // 
            this.radioButtonMotorLow.AutoSize = true;
            this.radioButtonMotorLow.Location = new System.Drawing.Point(6, 42);
            this.radioButtonMotorLow.Name = "radioButtonMotorLow";
            this.radioButtonMotorLow.Size = new System.Drawing.Size(102, 17);
            this.radioButtonMotorLow.TabIndex = 54;
            this.radioButtonMotorLow.TabStop = true;
            this.radioButtonMotorLow.Text = "Motor Low RPM";
            this.radioButtonMotorLow.UseVisualStyleBackColor = true;
            // 
            // btnMotorTypePlate
            // 
            this.btnMotorTypePlate.Location = new System.Drawing.Point(675, 186);
            this.btnMotorTypePlate.Name = "btnMotorTypePlate";
            this.btnMotorTypePlate.Size = new System.Drawing.Size(247, 23);
            this.btnMotorTypePlate.TabIndex = 55;
            this.btnMotorTypePlate.Text = "Type Plate Sticker";
            this.btnMotorTypePlate.UseVisualStyleBackColor = true;
            // 
            // btnAtex
            // 
            this.btnAtex.Location = new System.Drawing.Point(675, 215);
            this.btnAtex.Name = "btnAtex";
            this.btnAtex.Size = new System.Drawing.Size(247, 23);
            this.btnAtex.TabIndex = 56;
            this.btnAtex.Text = "Atex Sticker";
            this.btnAtex.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(934, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 57;
            this.label6.Text = "Ventilators";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1087, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 16);
            this.label7.TabIndex = 58;
            this.label7.Text = "Ventilator Tests";
            // 
            // ControleUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAtex);
            this.Controls.Add(this.btnMotorTypePlate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.CustomOrderVentilatorTestsDataGrid);
            this.Controls.Add(this.CustomOrderDataGrid);
            this.Controls.Add(this.CustomOrderVentilatorsDataGrid);
            this.Controls.Add(this.VentilatorDataGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MotorDataGrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SelectedVentilatorTestDataGrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClear);
            this.Name = "ControleUserControl";
            this.Size = new System.Drawing.Size(1225, 600);
            ((System.ComponentModel.ISupportInitialize)(this.CustomOrderDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomOrderVentilatorsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VentilatorDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MotorDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedVentilatorTestDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomOrderVentilatorTestsDataGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CustomOrderDataGrid;
        private System.Windows.Forms.DataGridView CustomOrderVentilatorsDataGrid;
        private System.Windows.Forms.DataGridView VentilatorDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView MotorDataGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView SelectedVentilatorTestDataGrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustomOrderNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView CustomOrderVentilatorTestsDataGrid;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.RadioButton radioButtonMotorHigh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonVentilatorLow;
        private System.Windows.Forms.RadioButton radioButtonVentilatorHigh;
        private System.Windows.Forms.RadioButton radioButtonMotorLow;
        private System.Windows.Forms.Button btnReadRPM;
        private System.Windows.Forms.Button btnMotorTypePlate;
        private System.Windows.Forms.Button btnAtex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
