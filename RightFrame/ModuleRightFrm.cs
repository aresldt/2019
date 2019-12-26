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
    public partial class ModuleRightFrm : Form
    {
        private DataAccess.DataRight dataRight;
        private string userId;
        private DataRow dataRow;

        public ModuleRightFrm(DataAccess.DataRight right, string user, DataRow row)
        {
            InitializeComponent();

            dataRight = right;
            userId = user;
            dataRow = row;

            DataSet dsRight = dataRight.GetUserRight(userId);
            if (dsRight == null)
            {
                MessageBox.Show("查询数据库出错！", "提示");
                return;
            }
            Assembly assembly = Assembly.Load(dataRow["MSPAC"].ToString());
            Type type = assembly.GetType(dataRow["MCLAS"].ToString());
            List<object> objectArgs = new List<object>();
            objectArgs.Add(0);
            Object form = Activator.CreateInstance(type, objectArgs);
            lvw_right.Items.Clear();
            ListViewItem listViewItem = new ListViewItem("");
            listViewItem.SubItems.Add("*ALL");
            listViewItem.SubItems.Add("所有");
            for (int i = 0; i < dsRight.Tables[0].Rows.Count; i++)
            {
                if (System.Convert.ToInt32(dsRight.Tables[0].Rows[i]["RMID"].ToString().Trim()) == 
                    System.Convert.ToInt32(dataRow["MID"].ToString().Trim()) &&
                    dsRight.Tables[0].Rows[i]["RNAME"].ToString().Trim().ToLower() == "*all")
                {
                    listViewItem.Checked = true;
                    break;
                }
            }
            lvw_right.Items.Add(listViewItem);
            for (int i = 0; i < (form as MdiChild.MdiChildFrm).ToolStripItems.Count; i++)
            {
                listViewItem = new ListViewItem("");
                listViewItem.SubItems.Add((form as MdiChild.MdiChildFrm).ToolStripItems[i].Name);
                listViewItem.SubItems.Add((form as MdiChild.MdiChildFrm).ToolStripItems[i].Text);
                for (int j = 0; j < dsRight.Tables[0].Rows.Count; j++)
                {
                    if (System.Convert.ToInt32(dsRight.Tables[0].Rows[j]["RMID"].ToString()) ==
                        System.Convert.ToInt32(dataRow["MID"].ToString().Trim()) &&
                        dsRight.Tables[0].Rows[j]["RNAME"].ToString().Trim().ToLower() ==
                        (form as MdiChild.MdiChildFrm).ToolStripItems[i].Name.ToLower())
                    {
                        listViewItem.Checked = true;
                        break;
                    }
                }
                lvw_right.Items.Add(listViewItem);
            }
            for (int i = 0; i < (form as MdiChild.MdiChildFrm).ControlItems.Count; i++)
            {
                listViewItem = new ListViewItem("");
                listViewItem.SubItems.Add((form as MdiChild.MdiChildFrm).ControlItems[i].Name);
                listViewItem.SubItems.Add((form as MdiChild.MdiChildFrm).ControlItems[i].Text);
                for (int j = 0; j < dsRight.Tables[0].Rows.Count; j++)
                {
                    if (System.Convert.ToInt32(dsRight.Tables[0].Rows[j]["RMID"].ToString()) ==
                        System.Convert.ToInt32(dataRow["MID"].ToString().Trim()) &&
                        dsRight.Tables[0].Rows[j]["RNAME"].ToString().Trim().ToLower() ==
                        (form as MdiChild.MdiChildFrm).ControlItems[i].Name.ToLower())
                    {
                        listViewItem.Checked = true;
                        break;
                    }
                }
                lvw_right.Items.Add(listViewItem);
            }

            (form as MdiChild.MdiChildFrm).Dispose();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            System.DateTime sysDataTime = DataAccess.DataService.GetDateTime();
            if (sysDataTime.ToString("yyyy-MM-dd HH:mm:ss") == "1899-01-01 00:00:00")
            {
                MessageBox.Show("查询数据库时间错误！", "提示");
                return;
            }
            List<BaseService.StructRight> structRights = new List<BaseService.StructRight>();
            for (int i = 0; i < lvw_right.Items.Count; i++)
            {
                if (lvw_right.Items[i].Checked == true)
                {
                    BaseService.StructRight structRight = new BaseService.StructRight();
                    structRight.RUID = userId;
                    structRight.RMID = System.Convert.ToInt32(dataRow["MID"].ToString().Trim());
                    structRight.RNAME = lvw_right.Items[i].SubItems[1].Text;
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
            if (dataRight.UpdateModuleRight(userId, System.Convert.ToInt32(dataRow["MID"].ToString().Trim()),
                structRights) == true)
                this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}