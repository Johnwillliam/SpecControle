
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
            components = new System.ComponentModel.Container();
            btnSelectTemplateMotor = new Button();
            DataGridViewTemplateMotor = new Zuby.ADGV.AdvancedDataGridView();
            templateMotorBindingSource = new BindingSource(components);
            templateMotorsBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)DataGridViewTemplateMotor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)templateMotorBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)templateMotorsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnSelectTemplateMotor
            // 
            btnSelectTemplateMotor.Location = new Point(338, 549);
            btnSelectTemplateMotor.Margin = new Padding(4, 3, 4, 3);
            btnSelectTemplateMotor.Name = "btnSelectTemplateMotor";
            btnSelectTemplateMotor.Size = new Size(224, 27);
            btnSelectTemplateMotor.TabIndex = 1;
            btnSelectTemplateMotor.Text = "Select";
            btnSelectTemplateMotor.UseVisualStyleBackColor = true;
            btnSelectTemplateMotor.Click += btnSelectTemplateMotor_Click;
            // 
            // DataGridViewTemplateMotor
            // 
            DataGridViewTemplateMotor.AllowUserToAddRows = false;
            DataGridViewTemplateMotor.AllowUserToDeleteRows = false;
            DataGridViewTemplateMotor.AllowUserToOrderColumns = true;
            DataGridViewTemplateMotor.AllowUserToResizeRows = false;
            DataGridViewTemplateMotor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewTemplateMotor.FilterAndSortEnabled = true;
            DataGridViewTemplateMotor.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            DataGridViewTemplateMotor.Location = new Point(23, 22);
            DataGridViewTemplateMotor.Margin = new Padding(4, 3, 4, 3);
            DataGridViewTemplateMotor.MultiSelect = false;
            DataGridViewTemplateMotor.Name = "DataGridViewTemplateMotor";
            DataGridViewTemplateMotor.ReadOnly = true;
            DataGridViewTemplateMotor.RightToLeft = RightToLeft.No;
            DataGridViewTemplateMotor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewTemplateMotor.Size = new Size(883, 520);
            DataGridViewTemplateMotor.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            DataGridViewTemplateMotor.TabIndex = 2;
            // 
            // templateMotorBindingSource
            // 
            templateMotorBindingSource.DataSource = typeof(EntityFrameworkModelV2.Models.TemplateMotor);
            // 
            // templateMotorsBindingSource
            // 
            templateMotorsBindingSource.DataMember = "TemplateMotors";
            // 
            // MotorTemplateSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 583);
            Controls.Add(DataGridViewTemplateMotor);
            Controls.Add(btnSelectTemplateMotor);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MotorTemplateSelection";
            Text = "MotorTemplateSelection";
            Load += MotorTemplateSelection_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridViewTemplateMotor).EndInit();
            ((System.ComponentModel.ISupportInitialize)templateMotorBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)templateMotorsBindingSource).EndInit();
            ResumeLayout(false);
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
        private System.Windows.Forms.BindingSource templateMotorsBindingSource;
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
        private BindingSource templateMotorBindingSource;
    }
}