
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
      this.specificationsTestingDataSet = new SpecificationsTesting.SpecificationsTestingDataSet();
      this.specificationsTestingDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.templateMotorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.templateMotorsTableAdapter = new SpecificationsTesting.SpecificationsTestingDataSetTableAdapters.TemplateMotorsTableAdapter();
      this.DataGridViewTemplateMotor = new ADGV.AdvancedDataGridView();
      this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.iECDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.iPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.buildingTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.iSODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.powerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.rPMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.amperageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.startupAmperageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.voltageTypeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.frequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.powerFactorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.templateMotorsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
      this.btnSelectTemplateMotor = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.specificationsTestingDataSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.specificationsTestingDataSetBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.templateMotorsBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTemplateMotor)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.templateMotorsBindingSource1)).BeginInit();
      this.SuspendLayout();
      // 
      // specificationsTestingDataSet
      // 
      this.specificationsTestingDataSet.DataSetName = "SpecificationsTestingDataSet";
      this.specificationsTestingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // specificationsTestingDataSetBindingSource
      // 
      this.specificationsTestingDataSetBindingSource.DataSource = this.specificationsTestingDataSet;
      this.specificationsTestingDataSetBindingSource.Position = 0;
      // 
      // templateMotorsBindingSource
      // 
      this.templateMotorsBindingSource.DataMember = "TemplateMotors";
      this.templateMotorsBindingSource.DataSource = this.specificationsTestingDataSetBindingSource;
      // 
      // templateMotorsTableAdapter
      // 
      this.templateMotorsTableAdapter.ClearBeforeFill = true;
      // 
      // DataGridViewTemplateMotor
      // 
      this.DataGridViewTemplateMotor.AllowUserToAddRows = false;
      this.DataGridViewTemplateMotor.AllowUserToDeleteRows = false;
      this.DataGridViewTemplateMotor.AllowUserToResizeRows = false;
      this.DataGridViewTemplateMotor.AutoGenerateColumns = false;
      this.DataGridViewTemplateMotor.AutoGenerateContextFilters = true;
      this.DataGridViewTemplateMotor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DataGridViewTemplateMotor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.iECDataGridViewTextBoxColumn,
            this.iPDataGridViewTextBoxColumn,
            this.buildingTypeDataGridViewTextBoxColumn,
            this.iSODataGridViewTextBoxColumn,
            this.powerDataGridViewTextBoxColumn,
            this.rPMDataGridViewTextBoxColumn,
            this.amperageDataGridViewTextBoxColumn,
            this.startupAmperageDataGridViewTextBoxColumn,
            this.voltageTypeIDDataGridViewTextBoxColumn,
            this.frequencyDataGridViewTextBoxColumn,
            this.powerFactorDataGridViewTextBoxColumn});
      this.DataGridViewTemplateMotor.DataSource = this.templateMotorsBindingSource1;
      this.DataGridViewTemplateMotor.DateWithTime = false;
      this.DataGridViewTemplateMotor.Location = new System.Drawing.Point(12, 12);
      this.DataGridViewTemplateMotor.Name = "DataGridViewTemplateMotor";
      this.DataGridViewTemplateMotor.Size = new System.Drawing.Size(776, 426);
      this.DataGridViewTemplateMotor.TabIndex = 0;
      this.DataGridViewTemplateMotor.TimeFilter = false;
      // 
      // iDDataGridViewTextBoxColumn
      // 
      this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
      this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
      this.iDDataGridViewTextBoxColumn.MinimumWidth = 22;
      this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
      this.iDDataGridViewTextBoxColumn.ReadOnly = true;
      this.iDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // nameDataGridViewTextBoxColumn
      // 
      this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
      this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
      this.nameDataGridViewTextBoxColumn.MinimumWidth = 22;
      this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
      this.nameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // typeDataGridViewTextBoxColumn
      // 
      this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
      this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
      this.typeDataGridViewTextBoxColumn.MinimumWidth = 22;
      this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
      this.typeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // versionDataGridViewTextBoxColumn
      // 
      this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
      this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
      this.versionDataGridViewTextBoxColumn.MinimumWidth = 22;
      this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
      this.versionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // iECDataGridViewTextBoxColumn
      // 
      this.iECDataGridViewTextBoxColumn.DataPropertyName = "IEC";
      this.iECDataGridViewTextBoxColumn.HeaderText = "IEC";
      this.iECDataGridViewTextBoxColumn.MinimumWidth = 22;
      this.iECDataGridViewTextBoxColumn.Name = "iECDataGridViewTextBoxColumn";
      this.iECDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // iPDataGridViewTextBoxColumn
      // 
      this.iPDataGridViewTextBoxColumn.DataPropertyName = "IP";
      this.iPDataGridViewTextBoxColumn.HeaderText = "IP";
      this.iPDataGridViewTextBoxColumn.MinimumWidth = 22;
      this.iPDataGridViewTextBoxColumn.Name = "iPDataGridViewTextBoxColumn";
      this.iPDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // buildingTypeDataGridViewTextBoxColumn
      // 
      this.buildingTypeDataGridViewTextBoxColumn.DataPropertyName = "BuildingType";
      this.buildingTypeDataGridViewTextBoxColumn.HeaderText = "BuildingType";
      this.buildingTypeDataGridViewTextBoxColumn.MinimumWidth = 22;
      this.buildingTypeDataGridViewTextBoxColumn.Name = "buildingTypeDataGridViewTextBoxColumn";
      this.buildingTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // iSODataGridViewTextBoxColumn
      // 
      this.iSODataGridViewTextBoxColumn.DataPropertyName = "ISO";
      this.iSODataGridViewTextBoxColumn.HeaderText = "ISO";
      this.iSODataGridViewTextBoxColumn.MinimumWidth = 22;
      this.iSODataGridViewTextBoxColumn.Name = "iSODataGridViewTextBoxColumn";
      this.iSODataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // powerDataGridViewTextBoxColumn
      // 
      this.powerDataGridViewTextBoxColumn.DataPropertyName = "Power";
      this.powerDataGridViewTextBoxColumn.HeaderText = "Power";
      this.powerDataGridViewTextBoxColumn.MinimumWidth = 22;
      this.powerDataGridViewTextBoxColumn.Name = "powerDataGridViewTextBoxColumn";
      this.powerDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // rPMDataGridViewTextBoxColumn
      // 
      this.rPMDataGridViewTextBoxColumn.DataPropertyName = "RPM";
      this.rPMDataGridViewTextBoxColumn.HeaderText = "RPM";
      this.rPMDataGridViewTextBoxColumn.MinimumWidth = 22;
      this.rPMDataGridViewTextBoxColumn.Name = "rPMDataGridViewTextBoxColumn";
      this.rPMDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // amperageDataGridViewTextBoxColumn
      // 
      this.amperageDataGridViewTextBoxColumn.DataPropertyName = "Amperage";
      this.amperageDataGridViewTextBoxColumn.HeaderText = "Amperage";
      this.amperageDataGridViewTextBoxColumn.MinimumWidth = 22;
      this.amperageDataGridViewTextBoxColumn.Name = "amperageDataGridViewTextBoxColumn";
      this.amperageDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // startupAmperageDataGridViewTextBoxColumn
      // 
      this.startupAmperageDataGridViewTextBoxColumn.DataPropertyName = "StartupAmperage";
      this.startupAmperageDataGridViewTextBoxColumn.HeaderText = "StartupAmperage";
      this.startupAmperageDataGridViewTextBoxColumn.MinimumWidth = 22;
      this.startupAmperageDataGridViewTextBoxColumn.Name = "startupAmperageDataGridViewTextBoxColumn";
      this.startupAmperageDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // voltageTypeIDDataGridViewTextBoxColumn
      // 
      this.voltageTypeIDDataGridViewTextBoxColumn.DataPropertyName = "VoltageTypeID";
      this.voltageTypeIDDataGridViewTextBoxColumn.HeaderText = "VoltageTypeID";
      this.voltageTypeIDDataGridViewTextBoxColumn.MinimumWidth = 22;
      this.voltageTypeIDDataGridViewTextBoxColumn.Name = "voltageTypeIDDataGridViewTextBoxColumn";
      this.voltageTypeIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // frequencyDataGridViewTextBoxColumn
      // 
      this.frequencyDataGridViewTextBoxColumn.DataPropertyName = "Frequency";
      this.frequencyDataGridViewTextBoxColumn.HeaderText = "Frequency";
      this.frequencyDataGridViewTextBoxColumn.MinimumWidth = 22;
      this.frequencyDataGridViewTextBoxColumn.Name = "frequencyDataGridViewTextBoxColumn";
      this.frequencyDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // powerFactorDataGridViewTextBoxColumn
      // 
      this.powerFactorDataGridViewTextBoxColumn.DataPropertyName = "PowerFactor";
      this.powerFactorDataGridViewTextBoxColumn.HeaderText = "PowerFactor";
      this.powerFactorDataGridViewTextBoxColumn.MinimumWidth = 22;
      this.powerFactorDataGridViewTextBoxColumn.Name = "powerFactorDataGridViewTextBoxColumn";
      this.powerFactorDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
      // 
      // templateMotorsBindingSource1
      // 
      this.templateMotorsBindingSource1.DataMember = "TemplateMotors";
      this.templateMotorsBindingSource1.DataSource = this.specificationsTestingDataSetBindingSource;
      // 
      // btnSelectTemplateMotor
      // 
      this.btnSelectTemplateMotor.Location = new System.Drawing.Point(292, 470);
      this.btnSelectTemplateMotor.Name = "btnSelectTemplateMotor";
      this.btnSelectTemplateMotor.Size = new System.Drawing.Size(192, 23);
      this.btnSelectTemplateMotor.TabIndex = 1;
      this.btnSelectTemplateMotor.Text = "Select";
      this.btnSelectTemplateMotor.UseVisualStyleBackColor = true;
      this.btnSelectTemplateMotor.Click += new System.EventHandler(this.btnSelectTemplateMotor_Click);
      // 
      // MotorTemplateSelection
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 505);
      this.Controls.Add(this.btnSelectTemplateMotor);
      this.Controls.Add(this.DataGridViewTemplateMotor);
      this.Name = "MotorTemplateSelection";
      this.Text = "MotorTemplateSelection";
      this.Load += new System.EventHandler(this.MotorTemplateSelection_Load);
      ((System.ComponentModel.ISupportInitialize)(this.specificationsTestingDataSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.specificationsTestingDataSetBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.templateMotorsBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTemplateMotor)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.templateMotorsBindingSource1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.BindingSource specificationsTestingDataSetBindingSource;
    private SpecificationsTestingDataSet specificationsTestingDataSet;
    private System.Windows.Forms.BindingSource templateMotorsBindingSource;
    private SpecificationsTestingDataSetTableAdapters.TemplateMotorsTableAdapter templateMotorsTableAdapter;
    private ADGV.AdvancedDataGridView DataGridViewTemplateMotor;
    private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn iECDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn iPDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn buildingTypeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn iSODataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn powerDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn rPMDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn amperageDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn startupAmperageDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn voltageTypeIDDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn frequencyDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn powerFactorDataGridViewTextBoxColumn;
    private System.Windows.Forms.BindingSource templateMotorsBindingSource1;
    private System.Windows.Forms.Button btnSelectTemplateMotor;
  }
}