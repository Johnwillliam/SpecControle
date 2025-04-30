namespace SpecControle.UserControls
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
            CustomOrderDataGrid = new DataGridView();
            CustomOrderVentilatorsDataGrid = new DataGridView();
            VentilatorDataGrid = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            MotorDataGrid = new DataGridView();
            label3 = new Label();
            SelectedVentilatorTestDataGrid = new DataGridView();
            label4 = new Label();
            groupBox1 = new GroupBox();
            txtCustomOrderNumber = new TextBox();
            label5 = new Label();
            btnSearch = new Button();
            btnClear = new Button();
            CustomOrderVentilatorTestsDataGrid = new DataGridView();
            btnSaveChanges = new Button();
            cmbUser = new ComboBox();
            radioButtonMotorHigh = new RadioButton();
            groupBox2 = new GroupBox();
            btnReadRPM = new Button();
            radioButtonVentilatorLow = new RadioButton();
            radioButtonVentilatorHigh = new RadioButton();
            radioButtonMotorLow = new RadioButton();
            btnMotorTypePlate = new Button();
            btnAtex = new Button();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)CustomOrderDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CustomOrderVentilatorsDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VentilatorDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MotorDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SelectedVentilatorTestDataGrid).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CustomOrderVentilatorTestsDataGrid).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // CustomOrderDataGrid
            // 
            CustomOrderDataGrid.AllowUserToAddRows = false;
            CustomOrderDataGrid.AllowUserToDeleteRows = false;
            CustomOrderDataGrid.AllowUserToResizeColumns = false;
            CustomOrderDataGrid.AllowUserToResizeRows = false;
            CustomOrderDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomOrderDataGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            CustomOrderDataGrid.Location = new Point(4, 25);
            CustomOrderDataGrid.Margin = new Padding(4, 3, 4, 3);
            CustomOrderDataGrid.MultiSelect = false;
            CustomOrderDataGrid.Name = "CustomOrderDataGrid";
            CustomOrderDataGrid.ReadOnly = true;
            CustomOrderDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            CustomOrderDataGrid.Size = new Size(382, 113);
            CustomOrderDataGrid.TabIndex = 33;
            // 
            // CustomOrderVentilatorsDataGrid
            // 
            CustomOrderVentilatorsDataGrid.AllowUserToAddRows = false;
            CustomOrderVentilatorsDataGrid.AllowUserToDeleteRows = false;
            CustomOrderVentilatorsDataGrid.AllowUserToResizeColumns = false;
            CustomOrderVentilatorsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorsDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CustomOrderVentilatorsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomOrderVentilatorsDataGrid.Location = new Point(1093, 25);
            CustomOrderVentilatorsDataGrid.Margin = new Padding(4, 3, 4, 3);
            CustomOrderVentilatorsDataGrid.Name = "CustomOrderVentilatorsDataGrid";
            CustomOrderVentilatorsDataGrid.Size = new Size(170, 702);
            CustomOrderVentilatorsDataGrid.TabIndex = 34;
            // 
            // VentilatorDataGrid
            // 
            VentilatorDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            VentilatorDataGrid.Location = new Point(4, 164);
            VentilatorDataGrid.Margin = new Padding(4, 3, 4, 3);
            VentilatorDataGrid.Name = "VentilatorDataGrid";
            VentilatorDataGrid.ReadOnly = true;
            VentilatorDataGrid.Size = new Size(382, 130);
            VentilatorDataGrid.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(5, 3);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(101, 16);
            label1.TabIndex = 36;
            label1.Text = "Custom Order";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(5, 142);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 16);
            label2.TabIndex = 37;
            label2.Text = "Ventilator";
            // 
            // MotorDataGrid
            // 
            MotorDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MotorDataGrid.Location = new Point(4, 320);
            MotorDataGrid.Margin = new Padding(4, 3, 4, 3);
            MotorDataGrid.Name = "MotorDataGrid";
            MotorDataGrid.ReadOnly = true;
            MotorDataGrid.Size = new Size(382, 407);
            MotorDataGrid.TabIndex = 38;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(5, 298);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(46, 16);
            label3.TabIndex = 39;
            label3.Text = "Motor";
            // 
            // SelectedVentilatorTestDataGrid
            // 
            SelectedVentilatorTestDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SelectedVentilatorTestDataGrid.Location = new Point(392, 25);
            SelectedVentilatorTestDataGrid.Margin = new Padding(4, 3, 4, 3);
            SelectedVentilatorTestDataGrid.Name = "SelectedVentilatorTestDataGrid";
            SelectedVentilatorTestDataGrid.Size = new Size(382, 459);
            SelectedVentilatorTestDataGrid.TabIndex = 40;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(393, 3);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(38, 16);
            label4.TabIndex = 41;
            label4.Text = "Test";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCustomOrderNumber);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Location = new Point(780, 25);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(302, 115);
            groupBox1.TabIndex = 43;
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
            // btnClear
            // 
            btnClear.Location = new Point(788, 148);
            btnClear.Margin = new Padding(4, 3, 4, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(288, 27);
            btnClear.TabIndex = 42;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // CustomOrderVentilatorTestsDataGrid
            // 
            CustomOrderVentilatorTestsDataGrid.AllowUserToAddRows = false;
            CustomOrderVentilatorTestsDataGrid.AllowUserToDeleteRows = false;
            CustomOrderVentilatorTestsDataGrid.AllowUserToResizeColumns = false;
            CustomOrderVentilatorTestsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorTestsDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CustomOrderVentilatorTestsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CustomOrderVentilatorTestsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomOrderVentilatorTestsDataGrid.Location = new Point(1271, 25);
            CustomOrderVentilatorTestsDataGrid.Margin = new Padding(4, 3, 4, 3);
            CustomOrderVentilatorTestsDataGrid.Name = "CustomOrderVentilatorTestsDataGrid";
            CustomOrderVentilatorTestsDataGrid.Size = new Size(154, 702);
            CustomOrderVentilatorTestsDataGrid.TabIndex = 44;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(788, 181);
            btnSaveChanges.Margin = new Padding(4, 3, 4, 3);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(288, 27);
            btnSaveChanges.TabIndex = 45;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // cmbUser
            // 
            cmbUser.FormattingEnabled = true;
            cmbUser.Location = new Point(632, 284);
            cmbUser.Margin = new Padding(4, 3, 4, 3);
            cmbUser.Name = "cmbUser";
            cmbUser.Size = new Size(140, 23);
            cmbUser.TabIndex = 52;
            // 
            // radioButtonMotorHigh
            // 
            radioButtonMotorHigh.AutoSize = true;
            radioButtonMotorHigh.Location = new Point(7, 22);
            radioButtonMotorHigh.Margin = new Padding(4, 3, 4, 3);
            radioButtonMotorHigh.Name = "radioButtonMotorHigh";
            radioButtonMotorHigh.Size = new Size(115, 19);
            radioButtonMotorHigh.TabIndex = 53;
            radioButtonMotorHigh.TabStop = true;
            radioButtonMotorHigh.Text = "Motor High RPM";
            radioButtonMotorHigh.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnReadRPM);
            groupBox2.Controls.Add(radioButtonVentilatorLow);
            groupBox2.Controls.Add(radioButtonVentilatorHigh);
            groupBox2.Controls.Add(radioButtonMotorLow);
            groupBox2.Controls.Add(radioButtonMotorHigh);
            groupBox2.Location = new Point(463, 518);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(233, 171);
            groupBox2.TabIndex = 54;
            groupBox2.TabStop = false;
            groupBox2.Text = "RPM Measurements";
            // 
            // btnReadRPM
            // 
            btnReadRPM.Location = new Point(7, 137);
            btnReadRPM.Margin = new Padding(4, 3, 4, 3);
            btnReadRPM.Name = "btnReadRPM";
            btnReadRPM.Size = new Size(219, 27);
            btnReadRPM.TabIndex = 57;
            btnReadRPM.Text = "Read";
            btnReadRPM.UseVisualStyleBackColor = true;
            // 
            // radioButtonVentilatorLow
            // 
            radioButtonVentilatorLow.AutoSize = true;
            radioButtonVentilatorLow.Location = new Point(7, 102);
            radioButtonVentilatorLow.Margin = new Padding(4, 3, 4, 3);
            radioButtonVentilatorLow.Name = "radioButtonVentilatorLow";
            radioButtonVentilatorLow.Size = new Size(128, 19);
            radioButtonVentilatorLow.TabIndex = 56;
            radioButtonVentilatorLow.TabStop = true;
            radioButtonVentilatorLow.Text = "Ventilator Low RPM";
            radioButtonVentilatorLow.UseVisualStyleBackColor = true;
            // 
            // radioButtonVentilatorHigh
            // 
            radioButtonVentilatorHigh.AutoSize = true;
            radioButtonVentilatorHigh.Location = new Point(7, 75);
            radioButtonVentilatorHigh.Margin = new Padding(4, 3, 4, 3);
            radioButtonVentilatorHigh.Name = "radioButtonVentilatorHigh";
            radioButtonVentilatorHigh.Size = new Size(132, 19);
            radioButtonVentilatorHigh.TabIndex = 55;
            radioButtonVentilatorHigh.TabStop = true;
            radioButtonVentilatorHigh.Text = "Ventilator High RPM";
            radioButtonVentilatorHigh.UseVisualStyleBackColor = true;
            // 
            // radioButtonMotorLow
            // 
            radioButtonMotorLow.AutoSize = true;
            radioButtonMotorLow.Location = new Point(7, 48);
            radioButtonMotorLow.Margin = new Padding(4, 3, 4, 3);
            radioButtonMotorLow.Name = "radioButtonMotorLow";
            radioButtonMotorLow.Size = new Size(111, 19);
            radioButtonMotorLow.TabIndex = 54;
            radioButtonMotorLow.TabStop = true;
            radioButtonMotorLow.Text = "Motor Low RPM";
            radioButtonMotorLow.UseVisualStyleBackColor = true;
            // 
            // btnMotorTypePlate
            // 
            btnMotorTypePlate.Location = new Point(788, 215);
            btnMotorTypePlate.Margin = new Padding(4, 3, 4, 3);
            btnMotorTypePlate.Name = "btnMotorTypePlate";
            btnMotorTypePlate.Size = new Size(288, 27);
            btnMotorTypePlate.TabIndex = 55;
            btnMotorTypePlate.Text = "Type Plate Sticker";
            btnMotorTypePlate.UseVisualStyleBackColor = true;
            // 
            // btnAtex
            // 
            btnAtex.Location = new Point(788, 248);
            btnAtex.Margin = new Padding(4, 3, 4, 3);
            btnAtex.Name = "btnAtex";
            btnAtex.Size = new Size(288, 27);
            btnAtex.TabIndex = 56;
            btnAtex.Text = "Atex Sticker";
            btnAtex.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(1090, 3);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(81, 16);
            label6.TabIndex = 57;
            label6.Text = "Ventilators";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(1268, 3);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(116, 16);
            label7.TabIndex = 58;
            label7.Text = "Ventilator Tests";
            // 
            // ControleUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btnAtex);
            Controls.Add(btnMotorTypePlate);
            Controls.Add(groupBox2);
            Controls.Add(cmbUser);
            Controls.Add(btnSaveChanges);
            Controls.Add(CustomOrderVentilatorTestsDataGrid);
            Controls.Add(CustomOrderDataGrid);
            Controls.Add(CustomOrderVentilatorsDataGrid);
            Controls.Add(VentilatorDataGrid);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(MotorDataGrid);
            Controls.Add(label3);
            Controls.Add(SelectedVentilatorTestDataGrid);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(btnClear);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ControleUserControl";
            Size = new Size(1429, 730);
            ((System.ComponentModel.ISupportInitialize)CustomOrderDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)CustomOrderVentilatorsDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)VentilatorDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)MotorDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)SelectedVentilatorTestDataGrid).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CustomOrderVentilatorTestsDataGrid).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView CustomOrderDataGrid;
        private DataGridView CustomOrderVentilatorsDataGrid;
        private DataGridView VentilatorDataGrid;
        private Label label1;
        private Label label2;
        private DataGridView MotorDataGrid;
        private Label label3;
        private DataGridView SelectedVentilatorTestDataGrid;
        private Label label4;
        private GroupBox groupBox1;
        private TextBox txtCustomOrderNumber;
        private Label label5;
        private Button btnSearch;
        private Button btnClear;
        private DataGridView CustomOrderVentilatorTestsDataGrid;
        private Button btnSaveChanges;
        private ComboBox cmbUser;
        private RadioButton radioButtonMotorHigh;
        private GroupBox groupBox2;
        private RadioButton radioButtonVentilatorLow;
        private RadioButton radioButtonVentilatorHigh;
        private RadioButton radioButtonMotorLow;
        private Button btnReadRPM;
        private Button btnMotorTypePlate;
        private Button btnAtex;
        private Label label6;
        private Label label7;
    }
}
