
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
            this.DataGridViewTemplateMotor = new ADGV.AdvancedDataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iECDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startupAmperageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voltageTypeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.powerFactorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.templateMotorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.templateMotors = new SpecificationsTesting.TemplateMotors();
            this.templateMotorsTableAdapter = new SpecificationsTesting.TemplateMotorsTableAdapters.TemplateMotorsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTemplateMotor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateMotorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateMotors)).BeginInit();
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
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.startupAmperageDataGridViewTextBoxColumn,
            this.voltageTypeIDDataGridViewTextBoxColumn,
            this.frequencyDataGridViewTextBoxColumn,
            this.powerFactorDataGridViewTextBoxColumn});
            this.DataGridViewTemplateMotor.DataSource = this.templateMotorsBindingSource;
            this.DataGridViewTemplateMotor.DateWithTime = false;
            this.DataGridViewTemplateMotor.Location = new System.Drawing.Point(20, 19);
            this.DataGridViewTemplateMotor.MultiSelect = false;
            this.DataGridViewTemplateMotor.Name = "DataGridViewTemplateMotor";
            this.DataGridViewTemplateMotor.ReadOnly = true;
            this.DataGridViewTemplateMotor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewTemplateMotor.Size = new System.Drawing.Size(757, 451);
            this.DataGridViewTemplateMotor.TabIndex = 2;
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "HighPower";
            this.dataGridViewTextBoxColumn1.HeaderText = "HighPower";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LowPower";
            this.dataGridViewTextBoxColumn2.HeaderText = "LowPower";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "HighRPM";
            this.dataGridViewTextBoxColumn3.HeaderText = "HighRPM";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "LowRPM";
            this.dataGridViewTextBoxColumn4.HeaderText = "LowRPM";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "HighAmperage";
            this.dataGridViewTextBoxColumn5.HeaderText = "HighAmperage";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "LowAmperage";
            this.dataGridViewTextBoxColumn6.HeaderText = "LowAmperage";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            // templateMotorsBindingSource
            // 
            this.templateMotorsBindingSource.DataMember = "TemplateMotors";
            this.templateMotorsBindingSource.DataSource = this.templateMotors;
            // 
            // templateMotors
            // 
            this.templateMotors.DataSetName = "TemplateMotors";
            this.templateMotors.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // templateMotorsTableAdapter
            // 
            this.templateMotorsTableAdapter.ClearBeforeFill = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.templateMotorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateMotors)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Button btnSelectTemplateMotor;
        private ADGV.AdvancedDataGridView DataGridViewTemplateMotor;
        private TemplateMotors templateMotors;
        private System.Windows.Forms.BindingSource templateMotorsBindingSource;
        private TemplateMotorsTableAdapters.TemplateMotorsTableAdapter templateMotorsTableAdapter;
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
    }
}