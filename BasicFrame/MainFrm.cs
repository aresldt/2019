using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Win32;

namespace BasicFrame
{
    public partial class MainFrm : Form
    {
        private List<ToolStripItem> toolStripItems;

        public MainFrm(List<object> objectArgs)
        {
            InitializeComponent();

            this.Text = Application.ProductVersion;
            try
            {
                RegistryKey tempUserRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI\\" +
                    BaseService.BaseService.ConnectionString.Substring(4,
                    BaseService.BaseService.ConnectionString.Length - 5));
                if (tempUserRegistryKey != null && BaseService.BaseService.ApplicationIps.IndexOf(
                    tempUserRegistryKey.GetValue("System").ToString().Trim()) > -1)
                {
                    this.Text = "正式环境 " + Application.ProductVersion;
                }
                else
                {
                    RegistryKey tempMachineRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI\\" +
                        BaseService.BaseService.ConnectionString.Substring(4,
                        BaseService.BaseService.ConnectionString.Length - 5));
                    if (tempMachineRegistryKey != null && BaseService.BaseService.ApplicationIps.IndexOf(
                        tempMachineRegistryKey.GetValue("System").ToString().Trim()) > -1)
                        this.Text = "正式环境 " + Application.ProductVersion;
                }
            }
            catch
            {
            }

            toolStripItems = new List<ToolStripItem>();
            toolStripItems.Clear();
            for (int i = 0; i < tsp_main.Items.Count; i++)
                toolStripItems.Add(tsp_main.Items[i]);

            for (int i = 0; i < BaseService.BaseService.ApplicationRight.Count; i++)
            {
                if (BaseService.BaseService.ApplicationRight[i].ModuleParentID == 0 &&
                    BaseService.BaseService.ApplicationRight[i].ModuleType == 
                    BaseService.RightModuleType.RightDirectory)
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = BaseService.BaseService.ApplicationRight[i].ModuleName;
                    treeNode.Tag = BaseService.BaseService.ApplicationRight[i];
                    tvw_main.Nodes.Add(treeNode);

                    AddTreeNode(BaseService.BaseService.ApplicationRight[i].ModuleID, treeNode);
                }
            }
            tvw_main.ExpandAll();
        }

        private void AddTreeNode(int ParantId, TreeNode treeNode)
        {
            for (int i = 0; i < BaseService.BaseService.ApplicationRight.Count; i++)
            {
                if (BaseService.BaseService.ApplicationRight[i].ModuleParentID == ParantId &&
                    (BaseService.BaseService.ApplicationRight[i].ModuleType == 
                    BaseService.RightModuleType.RightDirectory ||
                    BaseService.BaseService.ApplicationRight[i].ModuleType == 
                    BaseService.RightModuleType.RightForm))
                {
                    TreeNode treeChildNode = new TreeNode();
                    treeChildNode.Text = BaseService.BaseService.ApplicationRight[i].ModuleName;
                    treeChildNode.Tag = BaseService.BaseService.ApplicationRight[i];
                    treeNode.Nodes.Add(treeChildNode);

                    if (BaseService.BaseService.ApplicationRight[i].ModuleType == 
                        BaseService.RightModuleType.RightDirectory ||
                        BaseService.BaseService.ApplicationRight[i].ModuleType ==
                        BaseService.RightModuleType.RightForm)
                        AddTreeNode(BaseService.BaseService.ApplicationRight[i].ModuleID, treeChildNode);
                }
            }
        }

        private void MainFrm_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                tvw_main.Visible = true;
                tsp_main.Items.Clear();
                for (int i = 0; i < toolStripItems.Count; i++)
                    tsp_main.Items.Add(toolStripItems[i]);
            }
            else
            {
                tvw_main.Visible = false;
                tsb_tree.Text = "显示";
                if (this.ActiveMdiChild is MdiChild.MdiChildFrm)
                {
                    tsp_main.Items.Clear();
                    tsp_main.Items.Add(toolStripItems[0]);
                    tsp_main.Items.Add(toolStripItems[1]);
                    for (int i = 0; i < (this.ActiveMdiChild as MdiChild.MdiChildFrm).ToolStripItems.Count; i++)
                        tsp_main.Items.Add((this.ActiveMdiChild as MdiChild.MdiChildFrm).ToolStripItems[i]);
                }
            }
        }

        private void tsb_tree_Click(object sender, EventArgs e)
        {
            if (tvw_main.Visible == true)
            {
                tvw_main.Visible = !tvw_main.Visible;
                tsb_tree.Text = "显示";
            }
            else
            {
                tvw_main.Visible = !tvw_main.Visible;
                tsb_tree.Text = "隐藏";
            }
        }

        private void tvw_main_DoubleClick(object sender, EventArgs e)
        {
            if (tvw_main.SelectedNode != null &&
                (tvw_main.SelectedNode.Tag as BaseService.StructUserRight).ModuleType == 
                BaseService.RightModuleType.RightForm)
            {
                System.DateTime sysDataTime = DataAccess.DataService.GetDateTime();
                BaseService.StructAccess access = new BaseService.StructAccess();
                access.ANAME = System.Environment.MachineName;
                access.AUSER = BaseService.BaseService.ApplicationUser.SUSER;
                access.AMNME = (tvw_main.SelectedNode.Tag as BaseService.StructUserRight).ModuleName;
                access.ADATE = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                access.ATIME = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                access.ATEXT = "";
                DataAccess.DataRight dataRight = new DataAccess.DataRight();
                if (dataRight.InsertAccess(access) == true)
                {
                    List<object> objectArgs = new List<object>();
                    objectArgs.Add((tvw_main.SelectedNode.Tag as BaseService.StructUserRight).ModuleID);
                    ShowWindow((tvw_main.SelectedNode.Tag as BaseService.StructUserRight).ModuleNameSpace,
                        (tvw_main.SelectedNode.Tag as BaseService.StructUserRight).ModuleClassName, objectArgs,
                        (tvw_main.SelectedNode.Tag as BaseService.StructUserRight).ModuleName);
                }
            }
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BaseService.BaseService.LoginFrm.Close();
        }

        public void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((sender as ToolStripMenuItem).Tag as Form).WindowState == FormWindowState.Minimized)
            {
                ((sender as ToolStripMenuItem).Tag as Form).Left =
                    ((sender as ToolStripMenuItem).Tag as MdiChild.MdiChildFrm).HideWindowLeft;
                ((sender as ToolStripMenuItem).Tag as Form).Top =
                    ((sender as ToolStripMenuItem).Tag as MdiChild.MdiChildFrm).HideWindowTop;
                ((sender as ToolStripMenuItem).Tag as Form).Width =
                    ((sender as ToolStripMenuItem).Tag as MdiChild.MdiChildFrm).HideWindowWidth;
                ((sender as ToolStripMenuItem).Tag as Form).Height =
                    ((sender as ToolStripMenuItem).Tag as MdiChild.MdiChildFrm).HideWindowHeight;
                ((sender as ToolStripMenuItem).Tag as Form).WindowState =
                    ((sender as ToolStripMenuItem).Tag as MdiChild.MdiChildFrm).HideWindowState;
                ((sender as ToolStripMenuItem).Tag as MdiChild.MdiChildFrm).Show();
            }
            ((sender as ToolStripMenuItem).Tag as Form).Activate();
        }

        public bool ShowWindow(string nameSpace, string className, List<object> objectArgs, string windowText)
        {
            try
            {
                if (nameSpace != "Right" || BaseService.BaseService.ApplicationUser.STYPE == 1)
                {
                    Assembly assembly = Assembly.Load(nameSpace);
                    Type type = assembly.GetType(className);
                    Object form = Activator.CreateInstance(type, objectArgs);
                    if (form is MdiChild.MdiChildFrm)
                    {
                        (form as MdiChild.MdiChildFrm).MdiParent = this;
                        (form as MdiChild.MdiChildFrm).Text = windowText;

                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                        toolStripMenuItem.Text = windowText;
                        toolStripMenuItem.Checked = true;
                        toolStripMenuItem.Tag = form;
                        toolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
                        tmi_window.DropDownItems.Add(toolStripMenuItem);

                        (form as MdiChild.MdiChildFrm).WindowItem = tmi_window;
                        (form as MdiChild.MdiChildFrm).MenuItem = toolStripMenuItem;

                        (form as MdiChild.MdiChildFrm).Show();
                    }
                }
                else
                {
                    MessageBox.Show("无法使用该模块！", "提示");
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private void tmi_hideall_Click(object sender, EventArgs e)
        {
            while (this.ActiveMdiChild != null)
                this.ActiveMdiChild.WindowState = FormWindowState.Minimized;
        }

        private void tsb_password_Click(object sender, EventArgs e)
        {
            tmi_password_Click(tmi_password, e);
        }

        private void tmi_password_Click(object sender, EventArgs e)
        {
            PasswordFrm password = new PasswordFrm();
            password.ShowDialog();
        }

        private void tsb_exit_Click(object sender, EventArgs e)
        {
            tmi_exit_Click(tmi_exit, e);
        }

        private void tmi_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("的确要关闭系统吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }

        private void tsb_setup_Click(object sender, EventArgs e)
        {
            if (BaseService.BaseService.ApplicationUser.STYPE == 1)
            {
                SetupFrm setupFrm = new SetupFrm();
                setupFrm.ShowDialog();
            }
        }

        private void tvw_main_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}