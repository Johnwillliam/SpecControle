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
            tabControl = new TabControl();
            OrderTabPage = new TabPage();
            ControleTabPage = new TabPage();
            MotorTypePlateTabPage = new TabPage();
            AtexStickerTabPage = new TabPage();
            RunningTestTabPage = new TabPage();
            TemplateMotorTabPage = new TabPage();
            cmbStickerPrinters = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cmbPrinters = new ComboBox();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(OrderTabPage);
            tabControl.Controls.Add(ControleTabPage);
            tabControl.Controls.Add(MotorTypePlateTabPage);
            tabControl.Controls.Add(AtexStickerTabPage);
            tabControl.Controls.Add(RunningTestTabPage);
            tabControl.Controls.Add(TemplateMotorTabPage);
            tabControl.Location = new Point(1, 1);
            tabControl.Margin = new Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1440, 756);
            tabControl.TabIndex = 34;
            // 
            // OrderTabPage
            // 
            OrderTabPage.Location = new Point(4, 24);
            OrderTabPage.Margin = new Padding(4, 3, 4, 3);
            OrderTabPage.Name = "OrderTabPage";
            OrderTabPage.Padding = new Padding(4, 3, 4, 3);
            OrderTabPage.Size = new Size(1432, 728);
            OrderTabPage.TabIndex = 0;
            OrderTabPage.Text = "Invoeren";
            OrderTabPage.UseVisualStyleBackColor = true;
            // 
            // ControleTabPage
            // 
            ControleTabPage.Location = new Point(4, 24);
            ControleTabPage.Margin = new Padding(4, 3, 4, 3);
            ControleTabPage.Name = "ControleTabPage";
            ControleTabPage.Padding = new Padding(4, 3, 4, 3);
            ControleTabPage.Size = new Size(1432, 707);
            ControleTabPage.TabIndex = 1;
            ControleTabPage.Text = "Controle";
            ControleTabPage.UseVisualStyleBackColor = true;
            // 
            // MotorTypePlateTabPage
            // 
            MotorTypePlateTabPage.Location = new Point(4, 24);
            MotorTypePlateTabPage.Margin = new Padding(4, 3, 4, 3);
            MotorTypePlateTabPage.Name = "MotorTypePlateTabPage";
            MotorTypePlateTabPage.Size = new Size(1432, 707);
            MotorTypePlateTabPage.TabIndex = 2;
            MotorTypePlateTabPage.Text = "Typeplate Sticker";
            MotorTypePlateTabPage.UseVisualStyleBackColor = true;
            // 
            // AtexStickerTabPage
            // 
            AtexStickerTabPage.Location = new Point(4, 24);
            AtexStickerTabPage.Margin = new Padding(4, 3, 4, 3);
            AtexStickerTabPage.Name = "AtexStickerTabPage";
            AtexStickerTabPage.Size = new Size(1432, 707);
            AtexStickerTabPage.TabIndex = 4;
            AtexStickerTabPage.Text = "Atex Sticker";
            AtexStickerTabPage.UseVisualStyleBackColor = true;
            // 
            // RunningTestTabPage
            // 
            RunningTestTabPage.Location = new Point(4, 24);
            RunningTestTabPage.Margin = new Padding(4, 3, 4, 3);
            RunningTestTabPage.Name = "RunningTestTabPage";
            RunningTestTabPage.Size = new Size(1432, 707);
            RunningTestTabPage.TabIndex = 5;
            RunningTestTabPage.Text = "Test Document";
            RunningTestTabPage.UseVisualStyleBackColor = true;
            // 
            // TemplateMotorTabPage
            // 
            TemplateMotorTabPage.Location = new Point(4, 24);
            TemplateMotorTabPage.Margin = new Padding(4, 3, 4, 3);
            TemplateMotorTabPage.Name = "TemplateMotorTabPage";
            TemplateMotorTabPage.Size = new Size(1432, 707);
            TemplateMotorTabPage.TabIndex = 3;
            TemplateMotorTabPage.Text = "Motor Templates";
            TemplateMotorTabPage.UseVisualStyleBackColor = true;
            // 
            // cmbStickerPrinters
            // 
            cmbStickerPrinters.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStickerPrinters.FormattingEnabled = true;
            cmbStickerPrinters.Location = new Point(752, 1);
            cmbStickerPrinters.Margin = new Padding(4, 3, 4, 3);
            cmbStickerPrinters.Name = "cmbStickerPrinters";
            cmbStickerPrinters.Size = new Size(279, 23);
            cmbStickerPrinters.TabIndex = 0;
            cmbStickerPrinters.SelectedIndexChanged += cmbStickerPrinters_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(621, 6);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 0;
            label1.Text = "Select Sticker Printer:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1060, 6);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 35;
            label2.Text = "Select Printer:";
            // 
            // cmbPrinters
            // 
            cmbPrinters.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrinters.FormattingEnabled = true;
            cmbPrinters.Location = new Point(1149, 1);
            cmbPrinters.Margin = new Padding(4, 3, 4, 3);
            cmbPrinters.Name = "cmbPrinters";
            cmbPrinters.Size = new Size(279, 23);
            cmbPrinters.TabIndex = 36;
            cmbPrinters.SelectedIndexChanged += cmbPrinters_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1440, 761);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbStickerPrinters);
            Controls.Add(cmbPrinters);
            Controls.Add(tabControl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "MainForm";
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl;
        private TabPage OrderTabPage;
        private TabPage ControleTabPage;
        private TabPage MotorTypePlateTabPage;
        private ComboBox cmbStickerPrinters;
        private Label label1;
        private TabPage TemplateMotorTabPage;
        private TabPage AtexStickerTabPage;
        private TabPage RunningTestTabPage;
        private Label label2;
        private ComboBox cmbPrinters;
    }
}