using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace Application
{
    public static class ExceptionHandler
    {
        public static void HandleException(ILogger logger, Exception ex)
        {
            logger.LogCritical(ex, "HandleException");

            if (ex.InnerException == null)
                MessageBox.Show(ex.Message);
            else if (ex.InnerException.InnerException == null)
                MessageBox.Show(ex.InnerException.Message);
            else
                MessageBox.Show(ex.InnerException.InnerException.Message);
        }
    }
}
