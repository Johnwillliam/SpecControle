using System.Windows.Forms;

namespace Logic
{
    public static class ExceptionHandler
    {
        public static void HandleException(Exception ex)
        {
            if (ex.InnerException == null)
                MessageBox.Show(ex.Message);
            else if (ex.InnerException.InnerException == null)
                MessageBox.Show(ex.InnerException.Message);
            else
                MessageBox.Show(ex.InnerException.InnerException.Message);
        }
    }
}
