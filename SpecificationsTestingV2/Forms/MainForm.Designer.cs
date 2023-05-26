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
            this.AtexStickerTabPage = new System.Windows.Forms.TabPage();
            this.RunningTestTabPage = new System.Windows.Forms.TabPage();
            this.TemplateMotorTabPage = new System.Windows.Forms.TabPage();
            this.cmbStickerPrinters = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
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
            this.tabControl.Controls.Add(this.AtexStickerTabPage);
            this.tabControl.Controls.Add(this.RunningTestTabPage);
            this.tabControl.Controls.Add(this.TemplateMotorTabPage);
            this.tabControl.Location = new System.Drawing.Point(1, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1234, 637);
            this.tabControl.TabIndex = 34;
            // 
            // OrderTabPage
            // 
            this.OrderTabPage.Location = new System.Drawing.Point(4, 22);
            this.OrderTabPage.Name = "OrderTabPage";
            this.OrderTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.OrderTabPage.Size = new System.Drawing.Size(1226, 611);
            this.OrderTabPage.TabIndex = 0;
            this.OrderTabPage.Text = "Invoeren";
            this.OrderTabPage.UseVisualStyleBackColor = true;
            // 
            // ControleTabPage
            // 
            this.ControleTabPage.Location = new System.Drawing.Point(4, 22);
            this.ControleTabPage.Name = "ControleTabPage";
            this.ControleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ControleTabPage.Size = new System.Drawing.Size(1226, 611);
            this.ControleTabPage.TabIndex = 1;
            this.ControleTabPage.Text = "Controle";
            this.ControleTabPage.UseVisualStyleBackColor = true;
            // 
            // MotorTypePlateTabPage
            // 
            this.MotorTypePlateTabPage.Location = new System.Drawing.Point(4, 22);
            this.MotorTypePlateTabPage.Name = "MotorTypePlateTabPage";
            this.MotorTypePlateTabPage.Size = new System.Drawing.Size(1226, 611);
            this.MotorTypePlateTabPage.TabIndex = 2;
            this.MotorTypePlateTabPage.Text = "Typeplate Sticker";
            this.MotorTypePlateTabPage.UseVisualStyleBackColor = true;
            // 
            // AtexStickerTabPage
            // 
            this.AtexStickerTabPage.Location = new System.Drawing.Point(4, 22);
            this.AtexStickerTabPage.Name = "AtexStickerTabPage";
            this.AtexStickerTabPage.Size = new System.Drawing.Size(1226, 611);
            this.AtexStickerTabPage.TabIndex = 4;
            this.AtexStickerTabPage.Text = "Atex Sticker";
            this.AtexStickerTabPage.UseVisualStyleBackColor = true;
            // 
            // RunningTestTabPage
            // 
            this.RunningTestTabPage.Location = new System.Drawing.Point(4, 22);
            this.RunningTestTabPage.Name = "RunningTestTabPage";
            this.RunningTestTabPage.Size = new System.Drawing.Size(1226, 611);
            this.RunningTestTabPage.TabIndex = 5;
            this.RunningTestTabPage.Text = "Test Document";
            this.RunningTestTabPage.UseVisualStyleBackColor = true;
            // 
            // TemplateMotorTabPage
            // 
            this.TemplateMotorTabPage.Location = new System.Drawing.Point(4, 22);
            this.TemplateMotorTabPage.Name = "TemplateMotorTabPage";
            this.TemplateMotorTabPage.Size = new System.Drawing.Size(1226, 611);
            this.TemplateMotorTabPage.TabIndex = 3;
            this.TemplateMotorTabPage.Text = "Motor Templates";
            this.TemplateMotorTabPage.UseVisualStyleBackColor = true;
            // 
            // cmbStickerPrinters
            // 
            this.cmbStickerPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStickerPrinters.FormattingEnabled = true;
            this.cmbStickerPrinters.Location = new System.Drawing.Point(645, 1);
            this.cmbStickerPrinters.Name = "cmbStickerPrinters";
            this.cmbStickerPrinters.Size = new System.Drawing.Size(240, 21);
            this.cmbStickerPrinters.TabIndex = 0;
            this.cmbStickerPrinters.SelectedIndexChanged += new System.EventHandler(this.cmbStickerPrinters_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(532, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Sticker Printer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(909, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Select Printer:";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(985, 1);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(240, 21);
            this.cmbPrinters.TabIndex = 36;
            this.cmbPrinters.SelectedIndexChanged += new System.EventHandler(this.cmbPrinters_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1234, 641);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStickerPrinters);
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
        private System.Windows.Forms.ComboBox cmbStickerPrinters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage TemplateMotorTabPage;
        private System.Windows.Forms.TabPage AtexStickerTabPage;
        private System.Windows.Forms.TabPage RunningTestTabPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPrinters;
    }
}