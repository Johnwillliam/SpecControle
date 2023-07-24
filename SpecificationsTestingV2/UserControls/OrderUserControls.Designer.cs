namespace SpecificationsTesting.UserControls
{
    partial class OrderUserControl
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
            cmbVentilatorType = new ComboBox();
            cmbCatOutType = new ComboBox();
            cmbCatType = new ComboBox();
            cmbSoundLevelType = new ComboBox();
            CustomOrderVentilatorsDataGrid = new DataGridView();
            VentilatorDataGrid = new DataGridView();
            cmbTemperatureClassType = new ComboBox();
            label1 = new Label();
            cmbGroupType = new ComboBox();
            label2 = new Label();
            MotorDataGrid = new DataGridView();
            label3 = new Label();
            Create = new GroupBox();
            btnCopyOrder = new Button();
            btnCreateCO = new Button();
            btnSelectTemplateMotor = new Button();
            ConfigDataGrid = new DataGridView();
            groupBox2 = new GroupBox();
            btnSaveChanges = new Button();
            btnCreateVentilator = new Button();
            btnRemoveVentilator = new Button();
            label4 = new Label();
            groupBox1 = new GroupBox();
            txtCustomOrderNumber = new TextBox();
            label5 = new Label();
            btnSearch = new Button();
            btnClear = new Button();
            btnMotorTypePlate = new Button();
            btnAtex = new Button();
            ((System.ComponentModel.ISupportInitialize)CustomOrderDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CustomOrderVentilatorsDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)VentilatorDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MotorDataGrid).BeginInit();
            Create.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ConfigDataGrid).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
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
            CustomOrderDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            CustomOrderDataGrid.Size = new Size(382, 128);
            CustomOrderDataGrid.TabIndex = 33;
            // 
            // cmbVentilatorType
            // 
            cmbVentilatorType.FormattingEnabled = true;
            cmbVentilatorType.Location = new Point(244, 255);
            cmbVentilatorType.Margin = new Padding(4, 3, 4, 3);
            cmbVentilatorType.Name = "cmbVentilatorType";
            cmbVentilatorType.Size = new Size(140, 23);
            cmbVentilatorType.TabIndex = 47;
            // 
            // cmbCatOutType
            // 
            cmbCatOutType.FormattingEnabled = true;
            cmbCatOutType.Location = new Point(632, 679);
            cmbCatOutType.Margin = new Padding(4, 3, 4, 3);
            cmbCatOutType.Name = "cmbCatOutType";
            cmbCatOutType.Size = new Size(140, 23);
            cmbCatOutType.TabIndex = 51;
            // 
            // cmbCatType
            // 
            cmbCatType.FormattingEnabled = true;
            cmbCatType.Location = new Point(632, 648);
            cmbCatType.Margin = new Padding(4, 3, 4, 3);
            cmbCatType.Name = "cmbCatType";
            cmbCatType.Size = new Size(140, 23);
            cmbCatType.TabIndex = 50;
            // 
            // cmbSoundLevelType
            // 
            cmbSoundLevelType.FormattingEnabled = true;
            cmbSoundLevelType.Location = new Point(244, 489);
            cmbSoundLevelType.Margin = new Padding(4, 3, 4, 3);
            cmbSoundLevelType.Name = "cmbSoundLevelType";
            cmbSoundLevelType.Size = new Size(140, 23);
            cmbSoundLevelType.TabIndex = 46;
            // 
            // CustomOrderVentilatorsDataGrid
            // 
            CustomOrderVentilatorsDataGrid.AllowUserToAddRows = false;
            CustomOrderVentilatorsDataGrid.AllowUserToDeleteRows = false;
            CustomOrderVentilatorsDataGrid.AllowUserToResizeColumns = false;
            CustomOrderVentilatorsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorsDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CustomOrderVentilatorsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomOrderVentilatorsDataGrid.Location = new Point(1092, 25);
            CustomOrderVentilatorsDataGrid.Margin = new Padding(4, 3, 4, 3);
            CustomOrderVentilatorsDataGrid.Name = "CustomOrderVentilatorsDataGrid";
            CustomOrderVentilatorsDataGrid.Size = new Size(329, 511);
            CustomOrderVentilatorsDataGrid.TabIndex = 34;
            CustomOrderVentilatorsDataGrid.CellClick += CustomOrderVentilatorsDataGrid_CellClick;
            // 
            // VentilatorDataGrid
            // 
            VentilatorDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            VentilatorDataGrid.Location = new Point(4, 179);
            VentilatorDataGrid.Margin = new Padding(4, 3, 4, 3);
            VentilatorDataGrid.Name = "VentilatorDataGrid";
            VentilatorDataGrid.Size = new Size(382, 546);
            VentilatorDataGrid.TabIndex = 35;
            // 
            // cmbTemperatureClassType
            // 
            cmbTemperatureClassType.FormattingEnabled = true;
            cmbTemperatureClassType.Location = new Point(632, 617);
            cmbTemperatureClassType.Margin = new Padding(4, 3, 4, 3);
            cmbTemperatureClassType.Name = "cmbTemperatureClassType";
            cmbTemperatureClassType.Size = new Size(140, 23);
            cmbTemperatureClassType.TabIndex = 49;
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
            // cmbGroupType
            // 
            cmbGroupType.FormattingEnabled = true;
            cmbGroupType.Location = new Point(632, 586);
            cmbGroupType.Margin = new Padding(4, 3, 4, 3);
            cmbGroupType.Name = "cmbGroupType";
            cmbGroupType.Size = new Size(140, 23);
            cmbGroupType.TabIndex = 48;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(5, 157);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 16);
            label2.TabIndex = 37;
            label2.Text = "Ventilator";
            // 
            // MotorDataGrid
            // 
            MotorDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MotorDataGrid.Location = new Point(392, 25);
            MotorDataGrid.Margin = new Padding(4, 3, 4, 3);
            MotorDataGrid.Name = "MotorDataGrid";
            MotorDataGrid.Size = new Size(382, 526);
            MotorDataGrid.TabIndex = 38;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(393, 3);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(46, 16);
            label3.TabIndex = 39;
            label3.Text = "Motor";
            // 
            // Create
            // 
            Create.Controls.Add(btnCopyOrder);
            Create.Controls.Add(btnCreateCO);
            Create.Controls.Add(btnSelectTemplateMotor);
            Create.Location = new Point(780, 270);
            Create.Margin = new Padding(4, 3, 4, 3);
            Create.Name = "Create";
            Create.Padding = new Padding(4, 3, 4, 3);
            Create.Size = new Size(302, 125);
            Create.TabIndex = 45;
            Create.TabStop = false;
            Create.Text = "Create";
            // 
            // btnCopyOrder
            // 
            btnCopyOrder.Location = new Point(7, 89);
            btnCopyOrder.Margin = new Padding(4, 3, 4, 3);
            btnCopyOrder.Name = "btnCopyOrder";
            btnCopyOrder.Size = new Size(288, 27);
            btnCopyOrder.TabIndex = 26;
            btnCopyOrder.Text = "Copy Order";
            btnCopyOrder.UseVisualStyleBackColor = true;
            // 
            // btnCreateCO
            // 
            btnCreateCO.Location = new Point(7, 55);
            btnCreateCO.Margin = new Padding(4, 3, 4, 3);
            btnCreateCO.Name = "btnCreateCO";
            btnCreateCO.Size = new Size(288, 27);
            btnCreateCO.TabIndex = 0;
            btnCreateCO.Text = "Create";
            btnCreateCO.UseVisualStyleBackColor = true;
            // 
            // btnSelectTemplateMotor
            // 
            btnSelectTemplateMotor.Location = new Point(7, 22);
            btnSelectTemplateMotor.Margin = new Padding(4, 3, 4, 3);
            btnSelectTemplateMotor.Name = "btnSelectTemplateMotor";
            btnSelectTemplateMotor.Size = new Size(288, 27);
            btnSelectTemplateMotor.TabIndex = 21;
            btnSelectTemplateMotor.Text = "Copy From Template Motor";
            btnSelectTemplateMotor.UseVisualStyleBackColor = true;
            // 
            // ConfigDataGrid
            // 
            ConfigDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ConfigDataGrid.Location = new Point(390, 573);
            ConfigDataGrid.Margin = new Padding(4, 3, 4, 3);
            ConfigDataGrid.Name = "ConfigDataGrid";
            ConfigDataGrid.Size = new Size(382, 152);
            ConfigDataGrid.TabIndex = 40;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnSaveChanges);
            groupBox2.Controls.Add(btnCreateVentilator);
            groupBox2.Controls.Add(btnRemoveVentilator);
            groupBox2.Location = new Point(780, 132);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(302, 132);
            groupBox2.TabIndex = 44;
            groupBox2.TabStop = false;
            groupBox2.Text = "Edit";
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(7, 22);
            btnSaveChanges.Margin = new Padding(4, 3, 4, 3);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(288, 27);
            btnSaveChanges.TabIndex = 18;
            btnSaveChanges.Text = "Overwrite Order/Ventilator";
            btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // btnCreateVentilator
            // 
            btnCreateVentilator.Location = new Point(7, 55);
            btnCreateVentilator.Margin = new Padding(4, 3, 4, 3);
            btnCreateVentilator.Name = "btnCreateVentilator";
            btnCreateVentilator.Size = new Size(288, 27);
            btnCreateVentilator.TabIndex = 19;
            btnCreateVentilator.Text = "Copy Selected Ventilator";
            btnCreateVentilator.UseVisualStyleBackColor = true;
            // 
            // btnRemoveVentilator
            // 
            btnRemoveVentilator.Location = new Point(7, 89);
            btnRemoveVentilator.Margin = new Padding(4, 3, 4, 3);
            btnRemoveVentilator.Name = "btnRemoveVentilator";
            btnRemoveVentilator.Size = new Size(288, 27);
            btnRemoveVentilator.TabIndex = 20;
            btnRemoveVentilator.Text = "Remove Selected Ventilator";
            btnRemoveVentilator.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(393, 554);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(86, 16);
            label4.TabIndex = 41;
            label4.Text = "Configurate";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCustomOrderNumber);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Location = new Point(780, 9);
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
            btnClear.Location = new Point(788, 402);
            btnClear.Margin = new Padding(4, 3, 4, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(288, 27);
            btnClear.TabIndex = 42;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnMotorTypePlate
            // 
            btnMotorTypePlate.Location = new Point(788, 435);
            btnMotorTypePlate.Margin = new Padding(4, 3, 4, 3);
            btnMotorTypePlate.Name = "btnMotorTypePlate";
            btnMotorTypePlate.Size = new Size(288, 27);
            btnMotorTypePlate.TabIndex = 52;
            btnMotorTypePlate.Text = "Type Plate";
            btnMotorTypePlate.UseVisualStyleBackColor = true;
            // 
            // btnAtex
            // 
            btnAtex.Location = new Point(788, 468);
            btnAtex.Margin = new Padding(4, 3, 4, 3);
            btnAtex.Name = "btnAtex";
            btnAtex.Size = new Size(288, 27);
            btnAtex.TabIndex = 57;
            btnAtex.Text = "Atex Sticker";
            btnAtex.UseVisualStyleBackColor = true;
            // 
            // OrderUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAtex);
            Controls.Add(btnMotorTypePlate);
            Controls.Add(CustomOrderDataGrid);
            Controls.Add(cmbVentilatorType);
            Controls.Add(cmbCatOutType);
            Controls.Add(cmbCatType);
            Controls.Add(cmbSoundLevelType);
            Controls.Add(CustomOrderVentilatorsDataGrid);
            Controls.Add(VentilatorDataGrid);
            Controls.Add(cmbTemperatureClassType);
            Controls.Add(label1);
            Controls.Add(cmbGroupType);
            Controls.Add(label2);
            Controls.Add(MotorDataGrid);
            Controls.Add(label3);
            Controls.Add(Create);
            Controls.Add(ConfigDataGrid);
            Controls.Add(groupBox2);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(btnClear);
            Margin = new Padding(4, 3, 4, 3);
            Name = "OrderUserControl";
            Size = new Size(1424, 730);
            Load += OrderUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)CustomOrderDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)CustomOrderVentilatorsDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)VentilatorDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)MotorDataGrid).EndInit();
            Create.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ConfigDataGrid).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView CustomOrderDataGrid;
        private ComboBox cmbVentilatorType;
        private ComboBox cmbCatOutType;
        private ComboBox cmbCatType;
        private ComboBox cmbSoundLevelType;
        private DataGridView CustomOrderVentilatorsDataGrid;
        private DataGridView VentilatorDataGrid;
        private ComboBox cmbTemperatureClassType;
        private Label label1;
        private ComboBox cmbGroupType;
        private Label label2;
        private DataGridView MotorDataGrid;
        private Label label3;
        private GroupBox Create;
        private Button btnCopyOrder;
        private Button btnCreateCO;
        private Button btnSelectTemplateMotor;
        private DataGridView ConfigDataGrid;
        private GroupBox groupBox2;
        private Button btnSaveChanges;
        private Button btnCreateVentilator;
        private Button btnRemoveVentilator;
        private Label label4;
        private GroupBox groupBox1;
        private TextBox txtCustomOrderNumber;
        private Label label5;
        private Button btnSearch;
        private Button btnClear;
        private Button btnMotorTypePlate;
        private Button btnAtex;
    }
}
