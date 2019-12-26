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
    public partial class Loginnew : Form

    {
        private string mainNameSpace;
        private string mainClassName;
        private int mainRightId;

        public Loginnew(string windowNameSpace, string windowClassName, int windowRightId)
        {
            
            string appPath = Application.StartupPath;
            if (appPath.Substring(appPath.Length - 1, 1) != "\\")
                appPath += "\\";
            BaseService.BaseService.Init(appPath + "DataConfig.xml");
            DataAccess.DataService.Init();

            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            //this.appUpdater1.UpdateUrl = BaseService.BaseService.UpdateServer;

            //this.Text = "登录 " + Application.ProductVersion;

            mainNameSpace = windowNameSpace;
            mainClassName = windowClassName;
            mainRightId = windowRightId;

            BaseService.BaseService.ApplicationPath = appPath;
            BaseService.BaseService.ApplicationUser = new BaseService.StructUser();
            BaseService.BaseService.ApplicationRight = new List<BaseService.StructUserRight>();
        }

        private void Loginnew_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\login.jpg");
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (DataAccess.DataService.ConnectDatabase(textBox1.Text.Trim(), textBox2.Text.Trim(),
                    BaseService.BaseService.ApplicationLock))
                {
                    case 1:
                        break;
                    case -1:
                        MessageBox.Show("发生未知错误！");
                        return;
                    case -2:
                        textBox2.Text = "";
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
                    BaseService.BaseService.Loginnew = this;
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



    }
}