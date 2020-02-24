using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INIEditor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args != null
                && args.Length == 2)
            {
                Application.Run(new MainForm(args[0], args[1]));
            }
            else
            {
                Application.Run(new MainForm(string.Empty, string.Empty));
            }
        }
    }
}
