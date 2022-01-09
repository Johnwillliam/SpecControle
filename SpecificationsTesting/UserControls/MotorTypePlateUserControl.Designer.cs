namespace SpecificationsTesting.Forms
{
    partial class MotorTypePlateUserControl
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ArrowsListBox = new System.Windows.Forms.ListBox();
            this.LogosListBox = new System.Windows.Forms.ListBox();
            this.MotorTypePlateImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MotorTypePlateImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(3, 349);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(157, 47);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(659, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Arrows";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(659, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Logo\'s";
            // 
            // ArrowsListBox
            // 
            this.ArrowsListBox.FormattingEnabled = true;
            this.ArrowsListBox.Location = new System.Drawing.Point(662, 198);
            this.ArrowsListBox.Name = "ArrowsListBox";
            this.ArrowsListBox.Size = new System.Drawing.Size(183, 147);
            this.ArrowsListBox.TabIndex = 8;
            // 
            // LogosListBox
            // 
            this.LogosListBox.FormattingEnabled = true;
            this.LogosListBox.Location = new System.Drawing.Point(662, 19);
            this.LogosListBox.Name = "LogosListBox";
            this.LogosListBox.Size = new System.Drawing.Size(183, 160);
            this.LogosListBox.TabIndex = 7;
            // 
            // MotorTypePlateImage
            // 
            this.MotorTypePlateImage.Location = new System.Drawing.Point(3, 3);
            this.MotorTypePlateImage.Name = "MotorTypePlateImage";
            this.MotorTypePlateImage.Size = new System.Drawing.Size(650, 340);
            this.MotorTypePlateImage.TabIndex = 6;
            this.MotorTypePlateImage.TabStop = false;
            // 
            // MotorTypePlateUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ArrowsListBox);
            this.Controls.Add(this.LogosListBox);
            this.Controls.Add(this.MotorTypePlateImage);
            this.Name = "MotorTypePlateUserControl";
            this.Size = new System.Drawing.Size(892, 399);
            ((System.ComponentModel.ISupportInitialize)(this.MotorTypePlateImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ArrowsListBox;
        private System.Windows.Forms.ListBox LogosListBox;
        private System.Windows.Forms.PictureBox MotorTypePlateImage;
    }
}
