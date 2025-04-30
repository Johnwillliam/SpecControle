namespace SpecControle.UserControls
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
            btnSave = new Button();
            MotorTemplatesDataGrid = new Zuby.ADGV.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)MotorTemplatesDataGrid).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSave.Location = new Point(589, 482);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(270, 43);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // MotorTemplatesDataGrid
            // 
            MotorTemplatesDataGrid.AllowUserToAddRows = false;
            MotorTemplatesDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MotorTemplatesDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MotorTemplatesDataGrid.FilterAndSortEnabled = true;
            MotorTemplatesDataGrid.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            MotorTemplatesDataGrid.Location = new Point(4, 3);
            MotorTemplatesDataGrid.Margin = new Padding(4, 3, 4, 3);
            MotorTemplatesDataGrid.Name = "MotorTemplatesDataGrid";
            MotorTemplatesDataGrid.RightToLeft = RightToLeft.No;
            MotorTemplatesDataGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            MotorTemplatesDataGrid.Size = new Size(1377, 472);
            MotorTemplatesDataGrid.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            MotorTemplatesDataGrid.TabIndex = 2;
            // 
            // MotorTemplateUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(MotorTemplatesDataGrid);
            Controls.Add(btnSave);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MotorTemplateUserControl";
            Size = new Size(1385, 539);
            ((System.ComponentModel.ISupportInitialize)MotorTemplatesDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btnSave;
		private Zuby.ADGV.AdvancedDataGridView MotorTemplatesDataGrid;
	}
}
