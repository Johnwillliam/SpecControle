namespace SpecificationsTesting.Forms
{
    partial class MainForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.OrderTabPage = new System.Windows.Forms.TabPage();
            this.ControleTabPage = new System.Windows.Forms.TabPage();
            this.MotorTypePlateTabPage = new System.Windows.Forms.TabPage();
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TemplateMotorTabPage = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.OrderTabPage);
            this.tabControl.Controls.Add(this.ControleTabPage);
            this.tabControl.Controls.Add(this.MotorTypePlateTabPage);
            this.tabControl.Controls.Add(this.TemplateMotorTabPage);
            this.tabControl.Location = new System.Drawing.Point(1, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1333, 637);
            this.tabControl.TabIndex = 34;
            // 
            // OrderTabPage
            // 
            this.OrderTabPage.Location = new System.Drawing.Point(4, 22);
            this.OrderTabPage.Name = "OrderTabPage";
            this.OrderTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.OrderTabPage.Size = new System.Drawing.Size(1325, 611);
            this.OrderTabPage.TabIndex = 0;
            this.OrderTabPage.Text = "Invoeren";
            this.OrderTabPage.UseVisualStyleBackColor = true;
            // 
            // ControleTabPage
            // 
            this.ControleTabPage.Location = new System.Drawing.Point(4, 22);
            this.ControleTabPage.Name = "ControleTabPage";
            this.ControleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ControleTabPage.Size = new System.Drawing.Size(1325, 611);
            this.ControleTabPage.TabIndex = 1;
            this.ControleTabPage.Text = "Controle";
            this.ControleTabPage.UseVisualStyleBackColor = true;
            // 
            // MotorTypePlateTabPage
            // 
            this.MotorTypePlateTabPage.Location = new System.Drawing.Point(4, 22);
            this.MotorTypePlateTabPage.Name = "MotorTypePlateTabPage";
            this.MotorTypePlateTabPage.Size = new System.Drawing.Size(1325, 611);
            this.MotorTypePlateTabPage.TabIndex = 2;
            this.MotorTypePlateTabPage.Text = "Print";
            this.MotorTypePlateTabPage.UseVisualStyleBackColor = true;
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(690, 1);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(240, 21);
            this.cmbPrinters.TabIndex = 0;
            this.cmbPrinters.SelectedIndexChanged += new System.EventHandler(this.cmbPrinters_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(615, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Printer:";
            // 
            // TemplateMotorTagPage
            // 
            this.TemplateMotorTabPage.Location = new System.Drawing.Point(4, 22);
            this.TemplateMotorTabPage.Name = "TemplateMotorTagPage";
            this.TemplateMotorTabPage.Size = new System.Drawing.Size(1325, 611);
            this.TemplateMotorTabPage.TabIndex = 3;
            this.TemplateMotorTabPage.Text = "Motor Templates";
            this.TemplateMotorTabPage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 641);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPrinters);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage OrderTabPage;
        private System.Windows.Forms.TabPage ControleTabPage;
        private System.Windows.Forms.TabPage MotorTypePlateTabPage;
        private System.Windows.Forms.ComboBox cmbPrinters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage TemplateMotorTabPage;
    }
}