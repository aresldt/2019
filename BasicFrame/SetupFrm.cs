using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace BasicFrame
{
    public partial class SetupFrm : Form
    {
        public SetupFrm()
        {
            InitializeComponent();
        }

        private void SetupFrm_Load(object sender, EventArgs e)
        {
            cbb_querywindow.SelectedIndex = BaseService.BaseService.QueryWindow;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            BaseService.BaseService.QueryWindow = cbb_querywindow.SelectedIndex;

            string appPath = Application.StartupPath;
            if (appPath.Substring(appPath.Length - 1, 1) != "\\")
                appPath += "\\";
            File.Copy(appPath + "DataConfig.xml", appPath + "DataConfig1.xml", true);
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(appPath + "DataConfig.xml");
                for (int i = 0; i < xmldoc.ChildNodes[1].ChildNodes.Count; i++)
                {
                    switch (xmldoc.ChildNodes[1].ChildNodes[i].Name)
                    {
                        case "QueryWindow":
                            xmldoc.ChildNodes[1].ChildNodes[i].InnerText = BaseService.BaseService.QueryWindow.ToString();
                            break;
                    }
                }
                xmldoc.Save(appPath + "DataConfig.xml");
                MessageBox.Show("保存成功。");
            }
            catch(Exception ex)
            {
                File.Copy(appPath + "DataConfig1.xml", appPath + "DataConfig.xml", true);
                MessageBox.Show("保存失败！" + ex.Message);
            }

            DialogResult = DialogResult.OK;
        }
    }
}