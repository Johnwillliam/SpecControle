
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
            btnSelectTemplateMotor.Click += BtnSelectTemplateMotor_Click;
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
        private System.Windows.Forms.BindingSource templateMotorsBindingSource;
        private BindingSource templateMotorBindingSource;
    }
}