using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecificationsTesting.Forms
{
  public partial class CopyOrderForm : Form
  {
    public int CustomOrderNumber { get; set; }

    public CopyOrderForm()
    {
      InitializeComponent();
      CustomOrderNumber = -1;
    }

    private void btnCopy_Click(object sender, EventArgs e)
    {
      if(!int.TryParse(txtCustomOrderNumber.Text, out int customOrderNumber))
      {
        return;
      }

      CustomOrderNumber = customOrderNumber;
      this.Close();
    }
  }
}
