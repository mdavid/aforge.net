using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ImageCutDemo
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
