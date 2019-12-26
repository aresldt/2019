using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Right
{
    public partial class UserRightFrm : Form
    {
        private DataAccess.DataRight dataRight;
        private string userId;

        public UserRightFrm(DataAccess.DataRight right, string user)
        {
            InitializeComponent();

            dataRight = right;
            userId = user;

            DataSet dsModule = dataRight.GetAllModules();
            if (dsModule == null)
            {
                MessageBox.Show("查询数据库出错！", "提示");
                return;
            }
            DataSet dsRight = dataRight.GetUserRight(userId);
            if (dsRight == null)
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
                    for (int j = 0; j < dsRight.Tables[0].Rows.Count; j++)
                    {
                        if (System.Convert.ToInt32(dsModule.Tables[0].Rows[i]["MID"].ToString()) ==
                            System.Convert.ToInt32(dsRight.Tables[0].Rows[j]["RMID"].ToString()) &&
                            dsRight.Tables[0].Rows[j]["RNAME"].ToString().Trim().ToLower() == "*frm")
                        {
                            treeNode.Checked = true;
                            break;
                        }
                    }
                    tvw_right.Nodes.Add(treeNode);

                    AddRightTreeNode(dsModule, dsRight, System.Convert.ToInt32(
                        dsModule.Tables[0].Rows[i]["MID"].ToString()), treeNode);
                }
            }
            tvw_right.ExpandAll();
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
                            System.Convert.ToInt32(dsRight.Tables[0].Rows[j]["RMID"].ToString()) &&
                            dsRight.Tables[0].Rows[j]["RNAME"].ToString().Trim().ToLower() == "*frm")
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            System.DateTime sysDataTime = DataAccess.DataService.GetDateTime();
            if (sysDataTime.ToString("yyyy-MM-dd HH:mm:ss") == "1899-01-01 00:00:00")
            {
                MessageBox.Show("查询数据库时间错误！", "提示");
                return;
            }
            DataSet dsRight = dataRight.GetUserRight(userId);
            if (dsRight == null)
            {
                MessageBox.Show("查询数据库出错！", "提示");
                return;
            }
            List<BaseService.StructRight> structRights = new List<BaseService.StructRight>();
            TreeNode treeNode = tvw_right.Nodes[0];
            while (treeNode != null)
            {
                if (treeNode.Checked == true)
                {
                    bool tempFrmBool = false;
                    for (int i = 0; i < dsRight.Tables[0].Rows.Count; i++)
                    {
                        if (System.Convert.ToInt32(dsRight.Tables[0].Rows[i]["RMID"].ToString().Trim()) ==
                            System.Convert.ToInt32((treeNode.Tag as DataRow)["MID"].ToString().Trim()) &&
                            dsRight.Tables[0].Rows[i]["RNAME"].ToString().Trim().ToLower() == "*frm")
                        {
                            tempFrmBool = true;
                            break;
                        }
                    }
                    BaseService.StructRight structRight;
                    if (tempFrmBool == false)
                    {
                        structRight = new BaseService.StructRight();
                        structRight.RUID = userId;
                        structRight.RMID = System.Convert.ToInt32((treeNode.Tag as DataRow)["MID"].ToString().Trim());
                        structRight.RNAME = "*FRM";
                        structRight.RTEXT = "";
                        structRight.RUSED = 1;
                        structRight.RMNDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                        structRight.RMNTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                        structRight.RMNUS = BaseService.BaseService.ApplicationUser.SUSER;
                        structRight.RENDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                        structRight.RENTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                        structRight.RENUS = BaseService.BaseService.ApplicationUser.SUSER;
                        structRights.Add(structRight);
                        bool tempControlBool = false;
                        for (int i = 0; i < dsRight.Tables[0].Rows.Count; i++)
                        {
                            if (System.Convert.ToInt32(dsRight.Tables[0].Rows[i]["RMID"].ToString().Trim()) ==
                                System.Convert.ToInt32((treeNode.Tag as DataRow)["MID"].ToString().Trim()))
                            {
                                tempControlBool = true;
                                break;
                            }
                        }
                        if (tempControlBool == false)
                        {
                            structRight = new BaseService.StructRight();
                            structRight.RUID = userId;
                            structRight.RMID = System.Convert.ToInt32((treeNode.Tag as DataRow)["MID"].ToString().Trim());
                            structRight.RNAME = "*ALL";
                            structRight.RTEXT = "";
                            structRight.RUSED = 1;
                            structRight.RMNDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                            structRight.RMNTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                            structRight.RMNUS = BaseService.BaseService.ApplicationUser.SUSER;
                            structRight.RENDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                            structRight.RENTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                            structRight.RENUS = BaseService.BaseService.ApplicationUser.SUSER;
                            structRights.Add(structRight);
                        }
                    }
                    for (int i = 0; i < dsRight.Tables[0].Rows.Count; i++)
                    {
                        if (System.Convert.ToInt32(dsRight.Tables[0].Rows[i]["RMID"].ToString().Trim()) ==
                            System.Convert.ToInt32((treeNode.Tag as DataRow)["MID"].ToString().Trim()))
                        {
                            structRight = new BaseService.StructRight();
                            structRight.RUID = userId;
                            structRight.RMID = System.Convert.ToInt32((treeNode.Tag as DataRow)["MID"].ToString().Trim());
                            structRight.RNAME = dsRight.Tables[0].Rows[i]["RNAME"].ToString().Trim();
                            structRight.RTEXT = dsRight.Tables[0].Rows[i]["RTEXT"].ToString().Trim();
                            structRight.RUSED = 1;
                            structRight.RMNDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                            structRight.RMNTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                            structRight.RMNUS = BaseService.BaseService.ApplicationUser.SUSER;
                            structRight.RENDT = System.Convert.ToDecimal(sysDataTime.ToString("yyyyMMdd"));
                            structRight.RENTM = System.Convert.ToDecimal(sysDataTime.ToString("HHmmss"));
                            structRight.RENUS = BaseService.BaseService.ApplicationUser.SUSER;
                            structRights.Add(structRight);
                        }
                    }
                }
                treeNode = treeNode.NextVisibleNode;
            }
            if (dataRight.UpdateUserRight(userId, structRights) == true)
                this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvw_right_AfterCheck(object sender, TreeViewEventArgs e)
        {
            this.tvw_right.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvw_right_AfterCheck);
            TreeNode treeNode = e.Node;
            if (e.Node.Checked == true)
            {
                for (int i = 0; i < e.Node.Level; i++)
                {
                    treeNode.Parent.Checked = true;
                    if (treeNode.Level > 0)
                        treeNode = treeNode.Parent;
                }
            }
            for (int i = 0; i < e.Node.Nodes.Count; i++)
                e.Node.Nodes[i].Checked = e.Node.Checked;
            this.tvw_right.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvw_right_AfterCheck);
        }

        private void tvw_right_DoubleClick(object sender, EventArgs e)
        {
            if (tvw_right.SelectedNode != null)
            {
                ModuleRightFrm moduleRightFrm = new ModuleRightFrm(dataRight, userId, 
                    tvw_right.SelectedNode.Tag as DataRow);
                moduleRightFrm.ShowDialog();
            }
        }
    }
}