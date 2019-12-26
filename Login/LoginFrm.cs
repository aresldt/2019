using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Login
{
    public partial class LoginFrm : Form
    {
        private string mainNameSpace;
        private string mainClassName;
        private int mainRightId;

        public LoginFrm(string windowNameSpace, string windowClassName, int windowRightId)
        {
            string appPath = Application.StartupPath;
            if (appPath.Substring(appPath.Length - 1, 1) != "\\")
                appPath += "\\";
            BaseService.BaseService.Init(appPath + "DataConfig.xml");
            DataAccess.DataService.Init();

            InitializeComponent();
            this.appUpdater1.UpdateUrl = BaseService.BaseService.UpdateServer;

            this.Text = "登录 " + Application.ProductVersion;

            mainNameSpace = windowNameSpace;
            mainClassName = windowClassName;
            mainRightId = windowRightId;

            BaseService.BaseService.ApplicationPath = appPath;
            BaseService.BaseService.ApplicationUser = new BaseService.StructUser();
            BaseService.BaseService.ApplicationRight = new List<BaseService.StructUserRight>();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                switch (DataAccess.DataService.ConnectDatabase(tbx_username.Text.Trim(), tbx_password.Text.Trim(), 
                    BaseService.BaseService.ApplicationLock))
                {
                    case 1:
                        break;
                    case -1:
                        MessageBox.Show("发生未知错误！");
                        return;
                    case -2:
                        tbx_password.Text = "";
                        MessageBox.Show("用户名密码错误！");
                        return;
                }

                if (mainNameSpace != "Right" || BaseService.BaseService.ApplicationUser.STYPE == 1)
                {
                    Assembly assembly = Assembly.Load(mainNameSpace);
                    Type type = assembly.GetType(mainClassName);
                    List<object> objectArgs = new List<object>();
                    objectArgs.Add(mainRightId);
                    Object form = Activator.CreateInstance(type, objectArgs);
                    this.Hide();
                    if (mainNameSpace == "BasicFrame")
                        BaseService.BaseService.HaveMainFrame = true;
                    else
                        BaseService.BaseService.HaveMainFrame = false;
                    BaseService.BaseService.LoginFrm = this;
                    (form as Form).Show();
                }
                else
                {
                    MessageBox.Show("无法使用该模块！", "提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void appUpdater1_OnUpdateComplete(object sender, Microsoft.Samples.AppUpdater.UpdateCompleteEventArgs e)
        {
            MessageBox.Show("程序已更新，请重新启动程序。");
        }
    }
}