using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Right
{
    public partial class RightFrm : MdiChild.MdiChildFrm
    {
        private DataAccess.DataRight dataRight;
        private BaseService.UpdateState updateState;

        public RightFrm(List<object> objectArgs)
        {
            InitializeComponent();

            if (BaseService.BaseService.ApplicationUser.STYPE != 1)
            {
                for (int i = 0; i < this.tsp_user.Items.Count; i++)
                    if (this.tsp_user.Items[i] is ToolStripButton)
                        this.tsp_user.Items[i].Enabled = false;
            }
            Init(this.tsp_user, null, (int)objectArgs[0]);
            if (BaseService.BaseService.HaveMainFrame == false)
            {

            }

            dataRight = new DataAccess.DataRight();
            updateState = BaseService.UpdateState.NoneState;

            RefreshUser();
            RefreshModule();            
        }

        private void RefreshUser()
        {
            tvw_user.Nodes.Clear();
            DataSet userDs = dataRight.GetAllUsers();
            if (userDs == null)
            {
                MessageBox.Show("查询数据库出错！", "提示");
                return;
            }
            string tempDept = "";
            TreeNode treeNode = null;
            for (int i = 0; i < userDs.Tables[0].Rows.Count; i++)
            {
                if (treeNode == null ||
                    tempDept != userDs.Tables[0].Rows[i]["SDEPT"].ToString().Trim())
                {
                    treeNode = new TreeNode(userDs.Tables[0].Rows[i]["SDEPT"].ToString().Trim());
                    treeNode.Tag = null;
                    tempDept = userDs.Tables[0].Rows[i]["SDEPT"].ToString().Trim();
                    tvw_user.Nodes.Add(treeNode);
                }
                TreeNode treeChildNode = new TreeNode(userDs.Tables[0].Rows[i]["SNAME"].ToString().Trim() +
                    "(" + userDs.Tables[0].Rows[i]["SUSER"].ToString().Trim() + ")");
                treeChildNode.Tag = userDs.Tables[0].Rows[i];
                treeNode.Nodes.Add(treeChildNode);
            }
            tvw_user.ExpandAll();
        }

        private void AddTreeNode(DataSet dsModule, int ParantId, TreeNode treeNode)
        {
            for (int i = 0; i < dsModule.Tables[0].Rows.Count; i++)
            {
                if (System.Convert.ToInt32(dsModule.Tables[0].Rows[i]["MPID"].ToString()) == ParantId)
                {
                    TreeNode treeChildNode = new TreeNode();
                    treeChildNode.Text = dsModule.Tables[0].Rows[i]["MNAME"].ToString();
                    treeChildNode.Tag = dsModule.Tables[0].Rows[i];
                    treeNode.Nodes.Add(treeChildNode);

                    if (System.Convert.ToInt32(dsModule.Tables[0].Rows[i]["MTYPE"].ToString()) == 0)
                        AddTreeNode(dsModule, System.Convert.ToInt32(
                            dsModule.Tables[0].Rows[i]["MID"].ToString()), treeChildNode);
                }
            }
        }

        private void RefreshModule()
        {
            tvw_module.Nodes.Clear();
            DataSet dsModule = dataRight.GetAllModules();
            if (dsModule == null)
            {
                MessageBox.Show("查询数据库出错！", "提示");
                return;
            }
            for (int i = 0; i < dsModule.Tables[0].Rows.Count; i++)
            {
                if (System.Convert.ToInt32(dsModule.Tables[0].Rows[i]["MPID"].ToString()) == 0 &&
                    (System.Convert.ToInt32(dsModule.Tables[0].Rows[i]["MTYPE"].ToString()) == 0 ||
                    System.Convert.ToInt32(dsModule.Tables[0].Rows[i]["MTYPE"].ToString()) == 1))
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = dsModule.Tables[0].Rows[i]["MNAME"].ToString();
                    treeNode.Tag = dsModule.Tables[0].Rows[i];
                    tvw_module.Nodes.Add(treeNode);

                    AddTreeNode(dsModule, System.Convert.ToInt32(
                        dsModule.Tables[0].Rows[i]["MID"].ToString()), treeNode);
                }
            }
            tvw_module.ExpandAll();
        }

        private void AddRightTreeNode(DataSet dsModule, DataSet dsRight, int ParantId, TreeNode treeNode)
        {
            for (int i = 0; i < dsModule.Tables[0].Rows.Count; i++)
            {
                if (System.Convert.ToInt32(dsModule.Tables[0].Rows[i]["MPID"].ToString()) == ParantId)
                {
                    TreeNode treeChildNode = new TreeNode();
                    treeChildNode.Text = dsModule.Tables[0].Rows[i]["MNAME"].ToString();
                    treeChildNode.Tag = dsModule.Tables[0].Rows[i];
                    for (int j = 0; j < dsRight.Tables[0].Rows.Count; j++)
                    {
                        if (System.Convert.ToInt32(dsModule.Tables[0].Rows[i]["MID"].ToString()) ==
                            System.Convert.ToInt32(dsRight.Tables[0].Rows[j]["RMID"].ToString()))
                        {
                            treeChildNode.Checked = true;
                            break;
                        }
                    }
                    treeNode.Nodes.Add(treeChildNode);

                    if (System.Convert.ToInt32(dsModule.Tables[0].Rows[i]["MTYPE"].ToString()) == 0 ||
                        System.Convert.ToInt32(dsModule.Tables[0].Rows[i]["MTYPE"].ToString()) == 1)
                        AddRightTreeNode(dsModule, dsRight, System.Convert.ToInt32(
                            dsModule.Tables[0].Rows[i]["MID"].ToString()), treeChildNode);
                }
            }
        }

        private void tvw_user_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                tbx_user.Text = (e.Node.Tag as DataRow)["SUSER"].ToString().Trim();
                tbx_user.Enabled = false;
                tbx_name.Text = (e.Node.Tag as DataRow)["SNAME"].ToString().Trim();
                cbb_department.Text = (e.Node.Tag as DataRow)["SDEPT"].ToString().Trim();
                cbb_usertype.SelectedIndex = System.Convert.ToInt32(
                    (e.Node.Tag as DataRow)["STYPE"].ToString().Trim());
                tbx_usertext.Text = (e.Node.Tag as DataRow)["STEXT"].ToString().Trim();
                if (System.Convert.ToInt32((e.Node.Tag as DataRow)["SUSED"].ToString().Trim()) == 1)
                    cbx_used.Checked = true;
                else
                    cbx_used.Checked = false;
                updateState = BaseService.UpdateState.EditState;
            }
            else
            {
                tbx_user.Text = "";
                tbx_user.Enabled = true;
                tbx_name.Text = "";
                cbb_department.Text = "";
                cbb_usertype.SelectedIndex = 0;
                tbx_usertext.Text = "";
                cbx_used.Checked = false;
                updateState = BaseService.UpdateState.NoneState;
            }
        }

        private void tvw_user_DoubleClick(object sender, EventArgs e)
        {
            if (tvw_user.SelectedNode != null && tvw_user.SelectedNode.Tag != null)
            {
                UserRightFrm userRightFrm = new UserRightFrm(dataRight,
                    (tvw_user.SelectedNode.Tag as DataRow)["SUSER"].ToString().Trim());
                userRightFrm.ShowDialog();
            }
        }

        private void tcl_right_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tcl_right.SelectedIndex)
            {
                case 0:
                    tsb_refreshuser.Visible = true;
                    tss_1.Visible = true;
                    tsb_adduser.Visible = true;
                    tsb_copyuser.Visible = true;
                    tsb_deleteuser.Visible = true;
                    tsb_saveuser.Visible = true;
                    tss_2.Visible = true;
                    tsb_userright.Visible = true;
                    tsb_refreshmodule.Visible = false;
                    tss_3.Visible = false;
                    tsb_addmodule.Visible = false;
                    tsb_savemodule.Visible = false;
                    tsb_deletemodule.Visible = false;
                    break;
                case 1:
                    tsb_refreshuser.Visible = false;
                    tss_1.Visible = false;
                    tsb_adduser.Visible = false;
                    tsb_copyuser.Visible = false;
                    tsb_saveuser.Visible = false;
                    tsb_deleteuser.Visible = false;
                    tss_2.Visible = false;
                    tsb_userright.Visible = false;
                    tsb_refreshmodule.Visible = true;
                    tss_3.Visible = true;
                    tsb_addmodule.Visible = true;
                    tsb_savemodule.Visible = true;
                    tsb_deletemodule.Visible = true;
                    break;
            }
        }

        private void tsb_adduser_Click(object sender, EventArgs e)
        {
            tvw_user.SelectedNode = null;
            tbx_user.Text = "";
            tbx_user.Enabled = true;
            tbx_name.Text = "";
            cbb_department.Text = "";
            cbb_usertype.SelectedIndex = 0;
            tbx_usertext.Text = "";
            cbx_used.Checked = true;
            updateState = BaseService.UpdateState.NewState;
        }

        private void tsb_refreshuser_Click(object sender, EventArgs e)
        {
            RefreshUser();
        }

        private void tsb_copyuser_Click(object sender, EventArgs e)
        {
            tbx_user.Text = "";
            tbx_user.Enabled = true;
            updateState = BaseService.UpdateState.CopyState;
        }

        private void tsb_deleteuser_Click(object sender, EventArgs e)
        {
            if (tvw_user.SelectedNode != null && tvw_user.SelectedNode.Tag != null)
            {
                dataRight.DeleteUser((tvw_user.SelectedNode.Tag as DataRow)["SUSER"].ToString().Trim());
            }
        }

        private void tvw_module_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                rbn_samelevel.Checked = true;
                tbx_id.Text = (e.Node.Tag as DataRow)["MID"].ToString().Trim();
                tbx_modulename.Text = (e.Node.Tag as DataRow)["MNAME"].ToString().Trim();
                tbx_namespace.Text = (e.Node.Tag as DataRow)["MSPAC"].ToString().Trim();
                tbx_classname.Text = (e.Node.Tag as DataRow)["MCLAS"].ToString().Trim();
                cbb_moduletype.SelectedIndex = System.Convert.ToInt32((e.Node.Tag as DataRow)["MTYPE"].ToString().Trim());
                tbx_bubb.Text = (e.Node.Tag as DataRow)["MBUBB"].ToString().Trim();
                tbx_moduletext.Text = (e.Node.Tag as DataRow)["MTEXT"].ToString().Trim();
                updateState = BaseService.UpdateState.EditState;
            }
            else
            {
                rbn_nextlevel.Checked = true;
                tbx_id.Text = "";
                tbx_modulename.Text = "";
                tbx_namespace.Text = "";
                tbx_classname.Text = "";
                cbb_moduletype.SelectedIndex = 1;
                tbx_bubb.Text = "0";
                tbx_moduletext.Text = "";
                updateState = BaseService.UpdateState.NoneState;
            }
        }

        private void tsb_refreshmodule_Click(object sender, EventArgs e)
        {
            RefreshModule();
        }

        private void tsb_addmodule_Click(object sender, EventArgs e)
        {
            rbn_nextlevel.Checked = true;
            tbx_id.Text = "新建";
            tbx_modulename.Text = "";
            tbx_namespace.Text = "";
            tbx_classname.Text = "";
            cbb_moduletype.SelectedIndex = 2;
            tbx_bubb.Text = "0";
            tbx_moduletext.Text = "";
            updateState = BaseService.UpdateState.NewState;
        }

        private void tsb_deletemodule_Click(object sender, EventArgs e)
        {
            if (tvw_module.SelectedNode != null)
            {
                dataRight.DeleteModule(System.Convert.ToInt32(
                    (tvw_module.SelectedNode.Tag as DataRow)["MID"].ToString().Trim()));
            }
        }

        private void tsb_saveuser_Click(object sender, EventArgs e)
        {
            if (tbx_user.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名！", "提示");
                return;
            }
            System.DateTime sysDataTime = DataAccess.DataService.GetDateTime();
            if (sysDataTime.ToString("yyyy-MM-dd HH:mm:ss") == "1899-01-01 00:00:00")
            {
                MessageBox.Show("查询数据库时间错误！", "提示");
                return;
            }
            BaseService.StructUser structUser = new BaseService.StructUser();
            switch (updateState)
            {
                case BaseService.UpdateState.NewState:
                    structUser.SUSER = tbx_user.Text.Trim();
                    structUser.SNAME = tbx_name.Text.Trim();
                    structUser.SPWD = "MQ==";
                    structUser.STYPE = 0;
                    structUser.SDEPT = cbb_department.Text.Trim();
                    structUser.STEXT = tbx_usertext.Text.Trim();
                    if (cbx_used.Checked == true)
                        structUser.SUSED = 1;
                    else
                        structUser.SUSED = 0;
                    structUser.SMNDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                    structUser.SMNTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                    structUser.SMNUS = BaseService.BaseService.ApplicationUser.SUSER;
                    structUser.SENDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                    structUser.SENTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                    structUser.SENUS = BaseService.BaseService.ApplicationUser.SUSER;
                    dataRight.InsertUser(structUser);

                    break;
                case BaseService.UpdateState.EditState:
                    structUser.SUSER = tbx_user.Text.Trim();
                    structUser.SNAME = tbx_name.Text.Trim();
                    structUser.SPWD = "";
                    structUser.STYPE = 0;
                    structUser.SDEPT = cbb_department.Text.Trim();
                    structUser.STEXT = tbx_usertext.Text.Trim();
                    if (cbx_used.Checked == true)
                        structUser.SUSED = 1;
                    else
                        structUser.SUSED = 0;
                    structUser.SMNDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                    structUser.SMNTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                    structUser.SMNUS = BaseService.BaseService.ApplicationUser.SUSER;
                    structUser.SENDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                    structUser.SENTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                    structUser.SENUS = BaseService.BaseService.ApplicationUser.SUSER;
                    dataRight.ModifyUser(structUser);

                    break;
                case BaseService.UpdateState.CopyState:
                    structUser.SUSER = tbx_user.Text.Trim();
                    structUser.SNAME = tbx_name.Text.Trim();
                    structUser.SPWD = "";
                    structUser.STYPE = 0;
                    structUser.SDEPT = cbb_department.Text.Trim();
                    structUser.STEXT = tbx_usertext.Text.Trim();
                    if (cbx_used.Checked == true)
                        structUser.SUSED = 1;
                    else
                        structUser.SUSED = 0;
                    structUser.SMNDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                    structUser.SMNTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                    structUser.SMNUS = BaseService.BaseService.ApplicationUser.SUSER;
                    structUser.SENDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                    structUser.SENTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                    structUser.SENUS = BaseService.BaseService.ApplicationUser.SUSER;
                    dataRight.CopyUser(structUser, (tvw_user.SelectedNode.Tag as DataRow)["SUSER"].ToString().Trim());

                    break;
            }

            RefreshUser();
        }

        private void tsb_savemodule_Click(object sender, EventArgs e)
        {
            if (tvw_module.SelectedNode == null)
            {
                MessageBox.Show("请选择模块！", "提示");
                return;
            }
            if (tbx_modulename.Text.Trim() == "")
            {
                MessageBox.Show("请输入模块名！", "提示");
                return;
            }
            System.DateTime sysDataTime = DataAccess.DataService.GetDateTime();
            if (sysDataTime.ToString("yyyy-MM-dd HH:mm:ss") == "1899-01-01 00:00:00")
            {
                MessageBox.Show("查询数据库时间错误！", "提示");
                return;
            }
            BaseService.StructModule structModule = new BaseService.StructModule();
            switch (updateState)
            {
                case BaseService.UpdateState.NewState:
                    structModule.MNAME = tbx_modulename.Text.Trim();
                    if (rbn_samelevel.Checked == true)
                        structModule.MPID = System.Convert.ToInt32(
                            (tvw_module.SelectedNode.Tag as DataRow)["MPID"].ToString().Trim());
                    else
                        structModule.MPID = System.Convert.ToInt32(
                            (tvw_module.SelectedNode.Tag as DataRow)["MID"].ToString().Trim());
                    structModule.MSPAC = tbx_namespace.Text.Trim();
                    structModule.MCLAS = tbx_classname.Text.Trim();
                    structModule.MTYPE = cbb_moduletype.SelectedIndex;
                    structModule.MBUBB = System.Convert.ToInt32(tbx_bubb.Text.Trim());
                    structModule.MTEXT = tbx_moduletext.Text.Trim();
                    structModule.MUSED = 1;
                    structModule.MMNDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                    structModule.MMNTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                    structModule.MMNUS = BaseService.BaseService.ApplicationUser.SUSER;
                    structModule.MENDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                    structModule.MENTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                    structModule.MENUS = BaseService.BaseService.ApplicationUser.SUSER;
                    dataRight.InsertModule(structModule);

                    break;
                case BaseService.UpdateState.EditState:
                    structModule.MID = System.Convert.ToInt32(
                        (tvw_module.SelectedNode.Tag as DataRow)["MID"].ToString().Trim());
                    structModule.MNAME = tbx_modulename.Text.Trim();
                    structModule.MPID = System.Convert.ToInt32(
                        (tvw_module.SelectedNode.Tag as DataRow)["MPID"].ToString().Trim());
                    structModule.MSPAC = tbx_namespace.Text.Trim();
                    structModule.MCLAS = tbx_classname.Text.Trim();
                    structModule.MTYPE = cbb_moduletype.SelectedIndex;
                    structModule.MBUBB = System.Convert.ToInt32(tbx_bubb.Text.Trim());
                    structModule.MTEXT = tbx_moduletext.Text.Trim();
                    structModule.MUSED = 1;
                    structModule.MMNDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                    structModule.MMNTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                    structModule.MMNUS = BaseService.BaseService.ApplicationUser.SUSER;
                    structModule.MENDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                    structModule.MENTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                    structModule.MENUS = BaseService.BaseService.ApplicationUser.SUSER;
                    dataRight.ModifyModule(structModule);

                    break;
            }

            RefreshModule();    
        }
    }
}