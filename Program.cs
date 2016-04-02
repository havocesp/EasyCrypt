using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SensibleInfo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static Principal principal;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            principal = new Principal();
            Application.Run(principal);
        }
    }
}
