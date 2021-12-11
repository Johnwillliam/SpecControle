
namespace SpecificationsTesting.Forms
{
  partial class CopyOrderForm
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
      this.txtCustomOrderNumber = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnCopy = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // txtCustomOrderNumber
      // 
      this.txtCustomOrderNumber.Location = new System.Drawing.Point(12, 29);
      this.txtCustomOrderNumber.Name = "txtCustomOrderNumber";
      this.txtCustomOrderNumber.Size = new System.Drawing.Size(241, 20);
      this.txtCustomOrderNumber.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(101, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "New Order Number:";
      // 
      // btnCopy
      // 
      this.btnCopy.Location = new System.Drawing.Point(178, 55);
      this.btnCopy.Name = "btnCopy";
      this.btnCopy.Size = new System.Drawing.Size(75, 23);
      this.btnCopy.TabIndex = 2;
      this.btnCopy.Text = "Copy";
      this.btnCopy.UseVisualStyleBackColor = true;
      this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
      // 
      // CopyOrderForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(265, 85);
      this.Controls.Add(this.btnCopy);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtCustomOrderNumber);
      this.Name = "CopyOrderForm";
      this.Text = "CopyOrder";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtCustomOrderNumber;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnCopy;
  }
}