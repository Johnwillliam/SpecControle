using System.ComponentModel;

namespace SpecControle.Forms
{
    public partial class CopyOrderForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CustomOrderNumber { get; set; }

        public CopyOrderForm()
        {
            InitializeComponent();
            CustomOrderNumber = -1;
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void Copy()
        {
            if (!int.TryParse(txtCustomOrderNumber.Text, out int customOrderNumber))
            {
                return;
            }

            CustomOrderNumber = customOrderNumber;
            this.Close();
        }

        private void TxtCustomOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Copy();
            }
        }
    }
}