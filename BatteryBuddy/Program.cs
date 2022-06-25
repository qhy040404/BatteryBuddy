using System;
using System.Windows.Forms;

namespace BatteryBuddy
{
    static class Program
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TrayIcon trayIcon = new TrayIcon();
            
            Application.Run();
        }
    }
}
