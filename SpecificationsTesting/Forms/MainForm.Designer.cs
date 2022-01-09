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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.MotorTypePlateTabPage = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.OrderTabPage);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.MotorTypePlateTabPage);
            this.tabControl.Location = new System.Drawing.Point(1, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(906, 977);
            this.tabControl.TabIndex = 34;
            // 
            // OrderTabPage
            // 
            this.OrderTabPage.Location = new System.Drawing.Point(4, 22);
            this.OrderTabPage.Name = "OrderTabPage";
            this.OrderTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.OrderTabPage.Size = new System.Drawing.Size(898, 951);
            this.OrderTabPage.TabIndex = 0;
            this.OrderTabPage.Text = "Invoeren";
            this.OrderTabPage.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(898, 951);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Controle";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MotorTypePlateTabPage
            // 
            this.MotorTypePlateTabPage.Location = new System.Drawing.Point(4, 22);
            this.MotorTypePlateTabPage.Name = "MotorTypePlateTabPage";
            this.MotorTypePlateTabPage.Size = new System.Drawing.Size(898, 951);
            this.MotorTypePlateTabPage.TabIndex = 2;
            this.MotorTypePlateTabPage.Text = "Print";
            this.MotorTypePlateTabPage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 982);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage OrderTabPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage MotorTypePlateTabPage;
    }
}