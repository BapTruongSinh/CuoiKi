using System;
using System.Windows.Forms;

namespace CalendarApp;

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
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            ApplicationConfiguration.Initialize();
            
            var mainForm = new Form1();
            mainForm.WindowState = FormWindowState.Normal;
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            
            Application.Run(mainForm);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}\n\nStack trace:\n{ex.StackTrace}", 
                "Application Error", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }
    }    
}