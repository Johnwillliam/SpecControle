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

        private void txtCustomOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Copy();
            }
        }
    }
}