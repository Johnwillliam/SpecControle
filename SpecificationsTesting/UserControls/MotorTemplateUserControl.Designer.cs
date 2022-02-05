namespace SpecificationsTesting.UserControls
{
    partial class MotorTemplateUserControl
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
            this.components = new System.ComponentModel.Container();
            this.MotorTemplateDataGridView = new ADGV.AdvancedDataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.templateMotors = new SpecificationsTesting.TemplateMotors();
            this.templateMotorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.templateMotorsTableAdapter = new SpecificationsTesting.TemplateMotorsTableAdapters.TemplateMotorsTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iECDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highPowerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowPowerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highRPMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowRPMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highAmperageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowAmperageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startupAmperageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voltageTypeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.powerFactorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MotorTemplateDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateMotors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateMotorsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MotorTemplateDataGridView
            // 
            this.MotorTemplateDataGridView.AllowUserToOrderColumns = true;
            this.MotorTemplateDataGridView.AutoGenerateColumns = false;
            this.MotorTemplateDataGridView.AutoGenerateContextFilters = true;
            this.MotorTemplateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MotorTemplateDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.iECDataGridViewTextBoxColumn,
            this.iPDataGridViewTextBoxColumn,
            this.buildingTypeDataGridViewTextBoxColumn,
            this.iSODataGridViewTextBoxColumn,
            this.highPowerDataGridViewTextBoxColumn,
            this.lowPowerDataGridViewTextBoxColumn,
            this.highRPMDataGridViewTextBoxColumn,
            this.lowRPMDataGridViewTextBoxColumn,
            this.highAmperageDataGridViewTextBoxColumn,
            this.lowAmperageDataGridViewTextBoxColumn,
            this.startupAmperageDataGridViewTextBoxColumn,
            this.voltageTypeIDDataGridViewTextBoxColumn,
            this.frequencyDataGridViewTextBoxColumn,
            this.powerFactorDataGridViewTextBoxColumn});
            this.MotorTemplateDataGridView.DataSource = this.templateMotorsBindingSource;
            this.MotorTemplateDataGridView.DateWithTime = false;
            this.MotorTemplateDataGridView.Location = new System.Drawing.Point(9, 9);
            this.MotorTemplateDataGridView.Name = "MotorTemplateDataGridView";
            this.MotorTemplateDataGridView.Size = new System.Drawing.Size(806, 412);
            this.MotorTemplateDataGridView.TabIndex = 0;
            this.MotorTemplateDataGridView.TimeFilter = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(280, 427);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(250, 37);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // templateMotors
            // 
            this.templateMotors.DataSetName = "TemplateMotors";
            this.templateMotors.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // templateMotorsBindingSource
            // 
            this.templateMotorsBindingSource.DataMember = "TemplateMotors";
            this.templateMotorsBindingSource.DataSource = this.templateMotors;
            // 
            // templateMotorsTableAdapter
            // 
            this.templateMotorsTableAdapter.ClearBeforeFill = true;
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
            // highPowerDataGridViewTextBoxColumn
            // 
            this.highPowerDataGridViewTextBoxColumn.DataPropertyName = "HighPower";
            this.highPowerDataGridViewTextBoxColumn.HeaderText = "HighPower";
            this.highPowerDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.highPowerDataGridViewTextBoxColumn.Name = "highPowerDataGridViewTextBoxColumn";
            this.highPowerDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // lowPowerDataGridViewTextBoxColumn
            // 
            this.lowPowerDataGridViewTextBoxColumn.DataPropertyName = "LowPower";
            this.lowPowerDataGridViewTextBoxColumn.HeaderText = "LowPower";
            this.lowPowerDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.lowPowerDataGridViewTextBoxColumn.Name = "lowPowerDataGridViewTextBoxColumn";
            this.lowPowerDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // highRPMDataGridViewTextBoxColumn
            // 
            this.highRPMDataGridViewTextBoxColumn.DataPropertyName = "HighRPM";
            this.highRPMDataGridViewTextBoxColumn.HeaderText = "HighRPM";
            this.highRPMDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.highRPMDataGridViewTextBoxColumn.Name = "highRPMDataGridViewTextBoxColumn";
            this.highRPMDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // lowRPMDataGridViewTextBoxColumn
            // 
            this.lowRPMDataGridViewTextBoxColumn.DataPropertyName = "LowRPM";
            this.lowRPMDataGridViewTextBoxColumn.HeaderText = "LowRPM";
            this.lowRPMDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.lowRPMDataGridViewTextBoxColumn.Name = "lowRPMDataGridViewTextBoxColumn";
            this.lowRPMDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // highAmperageDataGridViewTextBoxColumn
            // 
            this.highAmperageDataGridViewTextBoxColumn.DataPropertyName = "HighAmperage";
            this.highAmperageDataGridViewTextBoxColumn.HeaderText = "HighAmperage";
            this.highAmperageDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.highAmperageDataGridViewTextBoxColumn.Name = "highAmperageDataGridViewTextBoxColumn";
            this.highAmperageDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // lowAmperageDataGridViewTextBoxColumn
            // 
            this.lowAmperageDataGridViewTextBoxColumn.DataPropertyName = "LowAmperage";
            this.lowAmperageDataGridViewTextBoxColumn.HeaderText = "LowAmperage";
            this.lowAmperageDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.lowAmperageDataGridViewTextBoxColumn.Name = "lowAmperageDataGridViewTextBoxColumn";
            this.lowAmperageDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            // MotorTemplateUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.MotorTemplateDataGridView);
            this.Name = "MotorTemplateUserControl";
            this.Size = new System.Drawing.Size(827, 467);
            ((System.ComponentModel.ISupportInitialize)(this.MotorTemplateDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateMotors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateMotorsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ADGV.AdvancedDataGridView MotorTemplateDataGridView;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iECDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highPowerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowPowerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highRPMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowRPMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highAmperageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowAmperageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startupAmperageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn voltageTypeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn powerFactorDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource templateMotorsBindingSource;
        private TemplateMotors templateMotors;
        private TemplateMotorsTableAdapters.TemplateMotorsTableAdapter templateMotorsTableAdapter;
    }
}
