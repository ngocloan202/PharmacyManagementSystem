using System;
using System.Windows.Forms;

namespace PharmacyManagement
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        public static void ForceApplicationExit()
        {
            Application.Exit();
            Environment.Exit(0); 
        }
    }
}
