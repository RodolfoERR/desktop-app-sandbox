using System;
using System.Threading;
using System.Windows.Forms;

namespace controlAlmacen
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();
      
                {
                    Application.Run(new login());
                }
               
            }
            catch (AccessViolationException ex)
            {
                // Log the exception details
                MessageBox.Show($"Access Violation: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show($"Unexpected Error: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
