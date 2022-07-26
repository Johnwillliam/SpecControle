
namespace SpecificationsTesting
{
  partial class MotorTemplateSelection
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
            this.components = new System.ComponentModel.Container();
            this.btnSelectTemplateMotor = new System.Windows.Forms.Button();
            this.DataGridViewTemplateMotor = new Zuby.ADGV.AdvancedDataGridView();
            this.specificationsTestingDataSet = new SpecificationsTesting.SpecificationsTestingDataSet();
            this.templateMotorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.templateMotorsTableAdapter = new SpecificationsTesting.SpecificationsTestingDataSetTableAdapters.TemplateMotorsTableAdapter();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highPowerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowPowerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highRPMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowRPMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highAmperageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowAmperageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voltageTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTemplateMotor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specificationsTestingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateMotorsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectTemplateMotor
            // 
            this.btnSelectTemplateMotor.Location = new System.Drawing.Point(290, 476);
            this.btnSelectTemplateMotor.Name = "btnSelectTemplateMotor";
            this.btnSelectTemplateMotor.Size = new System.Drawing.Size(192, 23);
            this.btnSelectTemplateMotor.TabIndex = 1;
            this.btnSelectTemplateMotor.Text = "Select";
            this.btnSelectTemplateMotor.UseVisualStyleBackColor = true;
            this.btnSelectTemplateMotor.Click += new System.EventHandler(this.btnSelectTemplateMotor_Click);
            // 
            // DataGridViewTemplateMotor
            // 
            this.DataGridViewTemplateMotor.AllowUserToAddRows = false;
            this.DataGridViewTemplateMotor.AllowUserToDeleteRows = false;
            this.DataGridViewTemplateMotor.AllowUserToOrderColumns = true;
            this.DataGridViewTemplateMotor.AllowUserToResizeRows = false;
            this.DataGridViewTemplateMotor.AutoGenerateColumns = false;
            this.DataGridViewTemplateMotor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewTemplateMotor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.highPowerDataGridViewTextBoxColumn,
            this.lowPowerDataGridViewTextBoxColumn,
            this.highRPMDataGridViewTextBoxColumn,
            this.lowRPMDataGridViewTextBoxColumn,
            this.highAmperageDataGridViewTextBoxColumn,
            this.lowAmperageDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn15,
            this.voltageTypeDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17});
            this.DataGridViewTemplateMotor.DataSource = this.templateMotorsBindingSource;
            this.DataGridViewTemplateMotor.FilterAndSortEnabled = true;
            this.DataGridViewTemplateMotor.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.DataGridViewTemplateMotor.Location = new System.Drawing.Point(20, 19);
            this.DataGridViewTemplateMotor.MultiSelect = false;
            this.DataGridViewTemplateMotor.Name = "DataGridViewTemplateMotor";
            this.DataGridViewTemplateMotor.ReadOnly = true;
            this.DataGridViewTemplateMotor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DataGridViewTemplateMotor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewTemplateMotor.Size = new System.Drawing.Size(757, 451);
            this.DataGridViewTemplateMotor.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.DataGridViewTemplateMotor.TabIndex = 2;
            // 
            // specificationsTestingDataSet
            // 
            this.specificationsTestingDataSet.DataSetName = "SpecificationsTestingDataSet";
            this.specificationsTestingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // templateMotorsBindingSource
            // 
            this.templateMotorsBindingSource.DataMember = "TemplateMotors";
            this.templateMotorsBindingSource.DataSource = this.specificationsTestingDataSet;
            // 
            // templateMotorsTableAdapter
            // 
            this.templateMotorsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn7.HeaderText = "ID";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn8.HeaderText = "Name";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Type";
            this.dataGridViewTextBoxColumn9.HeaderText = "Type";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Version";
            this.dataGridViewTextBoxColumn10.HeaderText = "Version";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "IEC";
            this.dataGridViewTextBoxColumn11.HeaderText = "IEC";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "IP";
            this.dataGridViewTextBoxColumn12.HeaderText = "IP";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "BuildingType";
            this.dataGridViewTextBoxColumn13.HeaderText = "BuildingType";
            this.dataGridViewTextBoxColumn13.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ISO";
            this.dataGridViewTextBoxColumn14.HeaderText = "ISO";
            this.dataGridViewTextBoxColumn14.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // highPowerDataGridViewTextBoxColumn
            // 
            this.highPowerDataGridViewTextBoxColumn.DataPropertyName = "HighPower";
            this.highPowerDataGridViewTextBoxColumn.HeaderText = "HighPower";
            this.highPowerDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.highPowerDataGridViewTextBoxColumn.Name = "highPowerDataGridViewTextBoxColumn";
            this.highPowerDataGridViewTextBoxColumn.ReadOnly = true;
            this.highPowerDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // lowPowerDataGridViewTextBoxColumn
            // 
            this.lowPowerDataGridViewTextBoxColumn.DataPropertyName = "LowPower";
            this.lowPowerDataGridViewTextBoxColumn.HeaderText = "LowPower";
            this.lowPowerDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.lowPowerDataGridViewTextBoxColumn.Name = "lowPowerDataGridViewTextBoxColumn";
            this.lowPowerDataGridViewTextBoxColumn.ReadOnly = true;
            this.lowPowerDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // highRPMDataGridViewTextBoxColumn
            // 
            this.highRPMDataGridViewTextBoxColumn.DataPropertyName = "HighRPM";
            this.highRPMDataGridViewTextBoxColumn.HeaderText = "HighRPM";
            this.highRPMDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.highRPMDataGridViewTextBoxColumn.Name = "highRPMDataGridViewTextBoxColumn";
            this.highRPMDataGridViewTextBoxColumn.ReadOnly = true;
            this.highRPMDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // lowRPMDataGridViewTextBoxColumn
            // 
            this.lowRPMDataGridViewTextBoxColumn.DataPropertyName = "LowRPM";
            this.lowRPMDataGridViewTextBoxColumn.HeaderText = "LowRPM";
            this.lowRPMDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.lowRPMDataGridViewTextBoxColumn.Name = "lowRPMDataGridViewTextBoxColumn";
            this.lowRPMDataGridViewTextBoxColumn.ReadOnly = true;
            this.lowRPMDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // highAmperageDataGridViewTextBoxColumn
            // 
            this.highAmperageDataGridViewTextBoxColumn.DataPropertyName = "HighAmperage";
            this.highAmperageDataGridViewTextBoxColumn.HeaderText = "HighAmperage";
            this.highAmperageDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.highAmperageDataGridViewTextBoxColumn.Name = "highAmperageDataGridViewTextBoxColumn";
            this.highAmperageDataGridViewTextBoxColumn.ReadOnly = true;
            this.highAmperageDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // lowAmperageDataGridViewTextBoxColumn
            // 
            this.lowAmperageDataGridViewTextBoxColumn.DataPropertyName = "LowAmperage";
            this.lowAmperageDataGridViewTextBoxColumn.HeaderText = "LowAmperage";
            this.lowAmperageDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.lowAmperageDataGridViewTextBoxColumn.Name = "lowAmperageDataGridViewTextBoxColumn";
            this.lowAmperageDataGridViewTextBoxColumn.ReadOnly = true;
            this.lowAmperageDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "StartupAmperage";
            this.dataGridViewTextBoxColumn15.HeaderText = "StartupAmperage";
            this.dataGridViewTextBoxColumn15.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // voltageTypeDataGridViewTextBoxColumn
            // 
            this.voltageTypeDataGridViewTextBoxColumn.DataPropertyName = "VoltageType";
            this.voltageTypeDataGridViewTextBoxColumn.HeaderText = "VoltageType";
            this.voltageTypeDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.voltageTypeDataGridViewTextBoxColumn.Name = "voltageTypeDataGridViewTextBoxColumn";
            this.voltageTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.voltageTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Frequency";
            this.dataGridViewTextBoxColumn16.HeaderText = "Frequency";
            this.dataGridViewTextBoxColumn16.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "PowerFactor";
            this.dataGridViewTextBoxColumn17.HeaderText = "PowerFactor";
            this.dataGridViewTextBoxColumn17.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // MotorTemplateSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.DataGridViewTemplateMotor);
            this.Controls.Add(this.btnSelectTemplateMotor);
            this.Name = "MotorTemplateSelection";
            this.Text = "MotorTemplateSelection";
            this.Load += new System.EventHandler(this.MotorTemplateSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTemplateMotor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specificationsTestingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateMotorsBindingSource)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Button btnSelectTemplateMotor;
        private Zuby.ADGV.AdvancedDataGridView DataGridViewTemplateMotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iECDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn startupAmperageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn voltageTypeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn powerFactorDataGridViewTextBoxColumn;
        private SpecificationsTestingDataSet specificationsTestingDataSet;
        private System.Windows.Forms.BindingSource templateMotorsBindingSource;
        private SpecificationsTestingDataSetTableAdapters.TemplateMotorsTableAdapter templateMotorsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn highPowerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowPowerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highRPMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowRPMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highAmperageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowAmperageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn voltageTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
    }
}