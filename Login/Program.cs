using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Login
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginFrm("", "", -1));
            Application.Run(new Loginnew("", "", -1));
        }
    }
}