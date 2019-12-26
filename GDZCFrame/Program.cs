using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GDZCFrame
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
          //Application.Run(new Login.LoginFrm("BasicFrame", "BasicFrame.MainFrm", -1));
          Application.Run(new Login.Loginnew("BasicFrame", "BasicFrame.MainFrm", -1));
        }
    }
}