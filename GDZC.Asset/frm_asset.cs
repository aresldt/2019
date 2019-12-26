using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace GDZC.Asset
{
    public partial class frm_asset : MdiChild.DataChildFrm
    {
        public frm_asset(List<object> objectArgs)
        {
            InitializeComponent();

            this.Init(tsp_file, null, (int)objectArgs[0]);

            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("GDZC.Asset");
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(assembly.GetManifestResourceStream("GDZC.Asset.xml_asset.xml"));
            this.InitDataTable(pnl_file, dataGridView1, xmlDoc, " WHERE 1=0", new List<string>(), 2);

            dataGridView1.Columns["ZCID"].Frozen = true;
            dataGridView1.Columns["ZCNAME"].Frozen = true;
            dataGridView1.Columns["ZCYZ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["ZCLJZJ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["ZCYZJ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["ZCJC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["ZCCZ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            textBox1.Select();
            dataGridView1.Select();

            bool tempBool = false;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i].RowState == DataRowState.Added ||
                    dataTable.Rows[i].RowState == DataRowState.Modified ||
                    dataTable.Rows[i].RowState == DataRowState.Deleted)
                {
                    tempBool = true;
                    break;
                }
            }
            if (tempBool == true)
            {
                if (MessageBox.Show("数据已经修改，是否保存？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (PrepareSave() == false)
                        return;

                    if (this.SaveData() == false)
                        return;
                }
            }
            MdiChild.DataQuery dataQueryFrm = new MdiChild.DataQuery("GDZC.Asset", "GDZC.Asset.que_asset.xml",
                Application.StartupPath + "\\XML\\" + this.formId.ToString());
            if (dataQueryFrm.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = null;

                System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("GDZC.Asset");
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.Load(assembly.GetManifestResourceStream("GDZC.Asset.xml_asset.xml"));
                this.InitDataTable(pnl_file, dataGridView1, xmlDoc, " WHERE " + dataQueryFrm.QueryText, new List<string>(), 2);

                dataGridView1.Columns["ZCID"].Frozen = true;
                dataGridView1.Columns["ZCNAME"].Frozen = true;
                dataGridView1.Columns["ZCYZ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["ZCLJZJ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["ZCYZJ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["ZCJC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["ZCCZ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application m_objExcel = null;
                object ObjMiss = System.Reflection.Missing.Value;

                m_objExcel = new Microsoft.Office.Interop.Excel.Application();
                if (m_objExcel == null)
                {
                    MessageBox.Show("请安装Excel2002。");
                    return;
                }
                try
                {
                    m_objExcel.Workbooks.Open(openFileDialog1.FileName, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss,
                        ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss);
                }
                catch
                {
                    MessageBox.Show("请安装Excel2002。");
                    m_objExcel.Quit();
                }

                try
                {
                    m_objExcel.Visible = false;
                    (m_objExcel.Sheets[1] as Microsoft.Office.Interop.Excel._Worksheet).Activate();
                    int n = 3;
                    DataRow newRow;
                    try
                    {
                        while (((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString() != "")
                        {
                            string tempstr = "";
                            int tempint = 0;
                            decimal tempdecimal = 0M;
                            DateTime tempdatetime = DateTime.Now;
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            if (tempstr.Length != 10)
                                throw (new Exception("资产编号错误！"));
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 2] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            if (int.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 3] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempint) == false)
                                throw (new Exception("在建工程错误！"));
                            if (tempint < 0 || tempint > 1)
                                throw (new Exception("在建工程错误！"));
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 4] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 5] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 6] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 7] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 8] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 9] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 10] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 11] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 12] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 13] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 14] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            if (int.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 15] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempint) == false)
                                throw (new Exception("折旧值错误！"));
                            if (tempint < 0 || tempint > 9)
                                throw (new Exception("折旧值错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 16] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("折旧增减值错误！"));
                            if (int.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 17] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempint) == false)
                                throw (new Exception("资产年限错误！"));
                            if (int.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 18] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempint) == false)
                                throw (new Exception("使用年限错误！"));
                            if (int.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 19] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempint) == false)
                                throw (new Exception("安装日期错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 20] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("原值错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 21] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("累计折旧错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 22] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("年折旧错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 23] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("月折旧错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 24] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("折旧基础错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 25] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("残值错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 26] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("航天累计折旧错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 27] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("航天年折旧错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 28] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("航天月折旧错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 29] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("航天折旧基础错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 30] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("航天残值错误！"));
                            if (int.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 31] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempint) == false)
                                throw (new Exception("最后折旧日期错误！"));

                            n++;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("检查数据发生错误，数据没有导入，请检查Excel文件第" + n.ToString() + "行数据。" + ex.Message);
                        return;
                    }
                    n = 3;
                    try
                    {
                        while (((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString() != "")
                        {
                            newRow = dataTable.NewRow();
                            newRow["ZCID"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim().ToUpper();
                            newRow["ZCSTAT"] = 1;
                            newRow["ZCNAME"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 2] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCZJGC"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 3] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCBM"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 4] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCCWFL"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 5] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCFL"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 6] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCUF1"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 7] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCUF3"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 8] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCUF4"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 9] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCUF5"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 10] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCUF6"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 11] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCUF7"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 12] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCUF8"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 13] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCUF9"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 14] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCZJZ"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 15] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCZJZZ"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 16] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCNX"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 17] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCSYNX"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 18] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCDTE"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 19] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCYZ"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 20] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCLJZJ"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 21] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCNZJ"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 22] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCYZJ"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 23] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCJC"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 24] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCCZ"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 25] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["HTLJZJ"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 26] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["HTNZJ"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 27] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["HTYZJ"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 28] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["HTJC"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 29] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["HTCZ"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 30] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            newRow["ZCMNTH"] = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 31] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();

                            dataTable.Rows.Add(newRow);
                            n++;
                        }
                        MessageBox.Show("导入" + openFileDialog1.FileName + "文件成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导入数据发生错误，部分数据可能已经导入。" + ex.Message);
                        return;
                    }
                }
                finally
                {
                    m_objExcel.ActiveWorkbook.Saved = true;
                    m_objExcel.ActiveWorkbook.Close(ObjMiss, ObjMiss, ObjMiss);
                    m_objExcel.Quit();
                    int tempExcel = GC.GetGeneration(m_objExcel);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
                    m_objExcel = null;
                    GC.Collect(tempExcel);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DataRow row = dataTable.NewRow();
            dataTable.Rows.Add(row);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("的确要删除所选数据吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (dataTable != null && dataGridView1.ReadOnly == false)
                {
                    for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dataGridView1.Rows[i].Selected == true)
                            dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                    }
                }
            }
        }

        private bool PrepareSave()
        {
            try
            {
                System.DateTime sysDateTime = DataAccess.DataService.GetDateTime();
                if (sysDateTime.ToString("yyyyMMdd") == "18990101")
                {
                    MessageBox.Show("获取服务器时间错误！");
                    return false;
                }

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (dataTable.Rows[i].RowState == DataRowState.Added)
                    {
                        dataTable.Rows[i]["ZCENUSR"] = BaseService.BaseService.ApplicationUser.SUSER;
                        dataTable.Rows[i]["ZCENDT"] = sysDateTime.ToString("yyyyMMdd");
                        dataTable.Rows[i]["ZCENTM"] = sysDateTime.ToString("HHmmss");
                        dataTable.Rows[i]["ZCMNUSR"] = BaseService.BaseService.ApplicationUser.SUSER;
                        dataTable.Rows[i]["ZCMNDT"] = sysDateTime.ToString("yyyyMMdd");
                        dataTable.Rows[i]["ZCMNTM"] = sysDateTime.ToString("HHmmss");
                    }
                    else if (dataTable.Rows[i].RowState == DataRowState.Modified)
                    {
                        dataTable.Rows[i]["ZCMNUSR"] = BaseService.BaseService.ApplicationUser.SUSER;
                        dataTable.Rows[i]["ZCMNDT"] = sysDateTime.ToString("yyyyMMdd");
                        dataTable.Rows[i]["ZCMNTM"] = sysDateTime.ToString("HHmmss");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误！" + ex.Message);
                return false;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            textBox1.Select();
            dataGridView1.Select();

            if (PrepareSave() == false)
                return;

            this.SaveData();
        }

        private void tsb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            textBox1.Select();
            dataGridView1.Select();

            bool tempBool = false;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i].RowState == DataRowState.Added ||
                    dataTable.Rows[i].RowState == DataRowState.Modified ||
                    dataTable.Rows[i].RowState == DataRowState.Deleted)
                {
                    tempBool = true;
                    break;
                }
            }
            if (tempBool == true)
            {
                if (MessageBox.Show("数据已经修改，必须保存后才能导出，是否保存？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (PrepareSave() == false)
                        return;

                    if (this.SaveData() == false)
                        return;
                }
                else
                {
                    return;
                }
            }

            List<Scrap> scrapList = new List<Scrap>();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application m_objExcel = null;
                object ObjMiss = System.Reflection.Missing.Value;

                m_objExcel = new Microsoft.Office.Interop.Excel.Application();
                if (m_objExcel == null)
                {
                    MessageBox.Show("请安装Excel2002。");
                    return;
                }
                try
                {
                    m_objExcel.Workbooks.Open(openFileDialog1.FileName, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss,
                        ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss);
                }
                catch
                {
                    MessageBox.Show("请安装Excel2002。");
                    m_objExcel.Quit();
                }

                try
                {
                    m_objExcel.Visible = false;
                    (m_objExcel.Sheets[1] as Microsoft.Office.Interop.Excel._Worksheet).Activate();
                    int n = 3;
                    DataRow newRow;
                    try
                    {
                        while (((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString() != "")
                        {
                            string tempstr = "";
                            int tempint = 0;
                            decimal tempdecimal = 0M;
                            DateTime tempdatetime = DateTime.Now;
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            if (tempstr.Length != 10)
                                throw (new Exception("资产编号错误！"));
                            if (int.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 2] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempint) == false)
                                throw (new Exception("报废日期错误！"));

                            n++;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("检查数据发生错误，数据没有导入，请检查Excel文件第" + n.ToString() + "行数据。" + ex.Message);
                        return;
                    }
                    n = 3;
                    try
                    {
                        while (((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString() != "")
                        {
                            Scrap tempScrap = new Scrap();
                            tempScrap.ZCID = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim().ToUpper();
                            tempScrap.ZCBFDTE = System.Convert.ToInt32(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 2] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            scrapList.Add(tempScrap);

                            n++;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导入数据发生错误，部分数据可能已经导入。" + ex.Message);
                        return;
                    }
                    for (int i = 0; i < scrapList.Count; i++)
                    {
                        OdbcDataAdapter tempAdapter = new OdbcDataAdapter("SELECT * FROM " + BaseService.BaseService.SmgDatabase + ".GDZC WHERE ZCID='" + scrapList[i].ZCID + "' AND ZCSTAT IN (1, 8)", DataAccess.DataService.ApplicationConnection);
                        DataSet tempDataSet = new DataSet();
                        tempAdapter.Fill(tempDataSet);
                        if (tempDataSet.Tables[0].Rows.Count != 1)
                        {
                            MessageBox.Show("没有发现" + scrapList[i].ZCID);
                            return;
                        }
                    }
                    System.DateTime sysDateTime = DataAccess.DataService.GetDateTime();
                    if (sysDateTime.ToString("yyyyMMdd") == "18990101")
                    {
                        MessageBox.Show("获取服务器时间错误！");
                        return;
                    }
                    OdbcCommand[] tempCommands = new OdbcCommand[scrapList.Count];
                    OdbcCommand[] tempZJCommands = new OdbcCommand[scrapList.Count];
                    if (DataAccess.DataService.ApplicationConnection.State != ConnectionState.Open)
                        DataAccess.DataService.ApplicationConnection.Open();
                    try
                    {
                        OdbcTransaction transaction = DataAccess.DataService.ApplicationConnection.BeginTransaction();
                        try
                        {
                            for (int i = 0; i < scrapList.Count; i++)
                            {
                                tempCommands[i] = new OdbcCommand();
                                tempCommands[i].CommandText = "UPDATE " + BaseService.BaseService.SmgDatabase + ".GDZC SET ZCSTAT=9, ZCBFDTE=" + scrapList[i].ZCBFDTE.ToString().Trim() + ", ZCTNUSR='" + BaseService.BaseService.ApplicationUser.SUSER + "', ZCTNDT=" + sysDateTime.ToString("yyyyMMdd") + ", ZCTNTM=" + sysDateTime.ToString("HHmmss") + " WHERE ZCID='" + scrapList[i].ZCID + "' AND ZCSTAT IN (1, 8)";
                                tempCommands[i].CommandTimeout = 60000;
                                tempCommands[i].Connection = DataAccess.DataService.ApplicationConnection;
                                tempCommands[i].Transaction = transaction;
                                tempZJCommands[i] = new OdbcCommand();
                                tempZJCommands[i].CommandText = "UPDATE " + BaseService.BaseService.SmgDatabase + ".GDZC SET ZCSTAT=39, ZCBFDTE=" + scrapList[i].ZCBFDTE.ToString().Trim() + ", ZCTNUSR='" + BaseService.BaseService.ApplicationUser.SUSER + "', ZCTNDT=" + sysDateTime.ToString("yyyyMMdd") + ", ZCTNTM=" + sysDateTime.ToString("HHmmss") + " WHERE ZCID='" + scrapList[i].ZCID + "' AND ZCSTAT IN (30)";
                                tempZJCommands[i].CommandTimeout = 60000;
                                tempZJCommands[i].Connection = DataAccess.DataService.ApplicationConnection;
                                tempZJCommands[i].Transaction = transaction;
                            }
                            for (int i = 0; i < scrapList.Count; i++)
                            {
                                tempCommands[i].ExecuteNonQuery();
                                tempZJCommands[i].ExecuteNonQuery();
                            }
                            transaction.Commit();
                            MessageBox.Show("导入" + openFileDialog1.FileName + "文件成功！");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("发生错误！" + ex.Message);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发生错误！" + ex.Message);
                    }
                    finally
                    {
                        DataAccess.DataService.ApplicationConnection.Close();
                    }
                }
                finally
                {
                    m_objExcel.ActiveWorkbook.Saved = true;
                    m_objExcel.ActiveWorkbook.Close(ObjMiss, ObjMiss, ObjMiss);
                    m_objExcel.Quit();
                    int tempExcel = GC.GetGeneration(m_objExcel);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
                    m_objExcel = null;
                    GC.Collect(tempExcel);
                }
            }
        }

        public void toolStripButton7_Click(object sender, EventArgs e)
        {

            frm_depreciation tempDepreciation = new frm_depreciation();
            if (tempDepreciation.ShowDialog() == DialogResult.OK)
            {
                OdbcDataAdapter tempAdapterZJY = new OdbcDataAdapter("SELECT * FROM GDZC.GDZJY WHERE GYZJY=" + tempDepreciation.Depreciation, DataAccess.DataService.ApplicationConnection);
                DataSet tempZJY = new DataSet();
                tempAdapterZJY.Fill(tempZJY);
                if (tempZJY.Tables[0].Rows.Count != 1)
                {
                    MessageBox.Show("输入折旧月错误！");
                    return;
                }
                OdbcDataAdapter zjAdapter = new OdbcDataAdapter("SELECT GYZJY FROM " + BaseService.BaseService.SmgDatabase + ".GDZHZJY", DataAccess.DataService.ApplicationConnection);
                DataSet zjDataSet = new DataSet();
                zjAdapter.Fill(zjDataSet);
                if (zjDataSet.Tables[0].Rows.Count != 1)
                {
                    MessageBox.Show("查询折旧月错误！");
                    return;
                }



                #region delete nzj



                ////判断是否为每年的第一个月，是，清空年折旧与航天年折旧

                if (DataAccess.DataService.ApplicationConnection.State != ConnectionState.Open)
                    DataAccess.DataService.ApplicationConnection.Open();
                OdbcTransaction transaction1 = DataAccess.DataService.ApplicationConnection.BeginTransaction();
                try
                {
                    string mnth = System.Convert.ToString(tempDepreciation.Depreciation);
                    mnth= mnth.Substring(4, 2); 

                    if (mnth.Equals("01") )
                    {   

                        OdbcCommand tempCommand1 = new OdbcCommand("UPDATE " + BaseService.BaseService.SmgDatabase + ".GDZC SET ZCNZJ=0, HTNZJ=0");
                        tempCommand1.Connection = DataAccess.DataService.ApplicationConnection;
                        tempCommand1.Transaction = transaction1;
                        tempCommand1.ExecuteNonQuery();
                        transaction1.Commit();

                    }
                }
                catch (Exception ex)
                {
                    transaction1.Rollback();
                    MessageBox.Show("清空年折旧出错！" + ex.Message);
                    return;

                }
                finally
                {
                    DataAccess.DataService.ApplicationConnection.Close();
                }


                #endregion



                #region delete yzj



                //资产状态为8，折旧月份小于输入月份，zcyzj与htyzj置0.

                if (DataAccess.DataService.ApplicationConnection.State != ConnectionState.Open)
                    DataAccess.DataService.ApplicationConnection.Open();
                OdbcTransaction transaction2 = DataAccess.DataService.ApplicationConnection.BeginTransaction();
                try
                {


                 

                        OdbcCommand tempCommand2 = new OdbcCommand("UPDATE " + BaseService.BaseService.SmgDatabase + ".GDZC SET ZCYZJ=0, HTYZJ=0 Where zcstat=8 and zcmnth < " + tempDepreciation.Depreciation);
                        tempCommand2.Connection = DataAccess.DataService.ApplicationConnection;
                        tempCommand2.Transaction = transaction2;
                        tempCommand2.ExecuteNonQuery();
                        transaction2.Commit();

                    
                }
                catch (Exception ex)
                {
                    transaction2.Rollback();
                    MessageBox.Show("清空月折旧出错！" + ex.Message);
                    return;

                }
                finally
                {
                    DataAccess.DataService.ApplicationConnection.Close();
                }
                #endregion




                int t = System.Convert.ToInt32(tempDepreciation.Depreciation % 100);
                int zjInt = System.Convert.ToInt32(zjDataSet.Tables[0].Rows[0][0].ToString().Trim());
                OdbcDataAdapter tempAdapter = new OdbcDataAdapter("SELECT * FROM " + BaseService.BaseService.SmgDatabase + ".GDZC WHERE ZCSTAT=1", DataAccess.DataService.ApplicationConnection);
                DataSet dataSet = new DataSet();
                tempAdapter.Fill(dataSet);

                List<Depreciation> depreciationList = new List<Depreciation>();
                try
                {
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        if (System.Convert.ToInt32(System.Convert.ToInt32(dataSet.Tables[0].Rows[i]["ZCDTE"]) / 100) < tempDepreciation.Depreciation &&
                            System.Convert.ToInt32(dataSet.Tables[0].Rows[i]["ZCMNTH"]) < tempDepreciation.Depreciation)
                        {
                            int tempInt = (System.Convert.ToInt32(tempDepreciation.Depreciation / 100) - System.Convert.ToInt32(dataSet.Tables[0].Rows[i]["ZCMNTH"].ToString().Substring(0, 4))) * 12 +
                                (System.Convert.ToInt32(tempDepreciation.Depreciation % 100) > System.Convert.ToInt32(dataSet.Tables[0].Rows[i]["ZCMNTH"].ToString().Substring(4, 2)) ?
                                System.Convert.ToInt32(tempDepreciation.Depreciation % 100) - System.Convert.ToInt32(dataSet.Tables[0].Rows[i]["ZCMNTH"].ToString().Substring(4, 2)) :
                                (-1) * (System.Convert.ToInt32(dataSet.Tables[0].Rows[i]["ZCMNTH"].ToString().Substring(4, 2)) - System.Convert.ToInt32(tempDepreciation.Depreciation % 100)));

                            if (tempInt > 0)
                                Depreciation(dataSet.Tables[0].Rows[i], tempInt, tempDepreciation.Depreciation, ref depreciationList, t);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("计算折旧错误！" + ex.Message);
                    return;
                }

                System.DateTime sysDateTime = DataAccess.DataService.GetDateTime();
                if (sysDateTime.ToString("yyyyMMdd") == "18990101")
                {
                    MessageBox.Show("获取服务器时间错误！");
                    return;
                }
                if (DataAccess.DataService.ApplicationConnection.State != ConnectionState.Open)
                    DataAccess.DataService.ApplicationConnection.Open();
                try
                {
                    OdbcTransaction transaction = DataAccess.DataService.ApplicationConnection.BeginTransaction();
                    try
                    {
                        OdbcCommand[] tempCommands = new OdbcCommand[depreciationList.Count];
                        if (DataAccess.DataService.ApplicationConnection.State != ConnectionState.Open)
                            DataAccess.DataService.ApplicationConnection.Open();
                        for (int i = 0; i < depreciationList.Count; i++)
                        {
                            tempCommands[i] = new OdbcCommand("UPDATE " + BaseService.BaseService.SmgDatabase + ".GDZC SET ZCLJZJ=" + depreciationList[i].ZCLJZJ.ToString("0.00") + ", ZCNZJ=" + depreciationList[i].ZCNZJ.ToString("0.00") + ", ZCYZJ=" + depreciationList[i].ZCYZJ.ToString("0.00") + ", HTLJZJ=" + depreciationList[i].HTLJZJ.ToString("0.00") + ", HTNZJ=" + depreciationList[i].HTNZJ.ToString("0.00") + ", HTYZJ=" + depreciationList[i].HTYZJ.ToString("0.00") + ", ZCSTAT=" + depreciationList[i].ZCSTAT.ToString() + ", ZCSYNX=" + depreciationList[i].ZCSYNX.ToString() + ", ZCMNTH=" + depreciationList[i].ZCMNTH.ToString() + ", ZCTNUSR='" + BaseService.BaseService.ApplicationUser.SUSER + "', ZCTNDT=" + sysDateTime.ToString("yyyyMMdd") + ", ZCTNTM=" + sysDateTime.ToString("HHmmss") + " WHERE ZCID='" + depreciationList[i].ZCID.Trim() + "' AND ZCZJZ=" + depreciationList[i].ZCZJZ.ToString());
                            tempCommands[i].Connection = DataAccess.DataService.ApplicationConnection;
                            tempCommands[i].Transaction = transaction;
                        }
                        if (zjInt < tempDepreciation.Depreciation)
                        {
                            OdbcCommand tempCommand = new OdbcCommand("UPDATE " + BaseService.BaseService.SmgDatabase + ".GDZC SET ZCYZJ=0, HTYZJ=0");
                            tempCommand.Connection = DataAccess.DataService.ApplicationConnection;
                            tempCommand.Transaction = transaction;
                            OdbcCommand tempUpdateCommand = new OdbcCommand("UPDATE " + BaseService.BaseService.SmgDatabase + ".GDZHZJY SET GYZJY=" + tempDepreciation.Depreciation);
                            tempUpdateCommand.Connection = DataAccess.DataService.ApplicationConnection;
                            tempUpdateCommand.Transaction = transaction;
                            tempCommand.ExecuteNonQuery();
                            tempUpdateCommand.ExecuteNonQuery();
                        }



                        for (int i = 0; i < tempCommands.Length; i++)
                            tempCommands[i].ExecuteNonQuery();
                        transaction.Commit();

                        MessageBox.Show("更新折旧成功。");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("更新折旧错误！" + ex.Message);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发生错误！" + ex.Message);
                }
                finally
                {
                    DataAccess.DataService.ApplicationConnection.Close();
                }
            }
        }

        private void Depreciation(DataRow row, int month, int depreciation, ref List<Depreciation> depreciations, int t)
        {

            Depreciation tempDepreciation = new Depreciation();

            if (System.Convert.ToInt32(row["ZCSYNX"]) <= month)
            {
                tempDepreciation.ZCID = row["ZCID"].ToString().Trim();
                tempDepreciation.ZCZJZ = System.Convert.ToInt32(row["ZCZJZ"]);
                tempDepreciation.ZCLJZJ = System.Convert.ToDecimal(row["ZCJC"]);
                tempDepreciation.HTLJZJ = System.Convert.ToDecimal(row["HTJC"]);
                tempDepreciation.ZCNZJ = System.Convert.ToDecimal(row["ZCNZJ"]) + System.Convert.ToDecimal(row["ZCJC"]) - System.Convert.ToDecimal(row["ZCLJZJ"]);
                tempDepreciation.HTNZJ = System.Convert.ToDecimal(row["HTNZJ"]) + System.Convert.ToDecimal(row["HTJC"]) - System.Convert.ToDecimal(row["HTLJZJ"]);
                tempDepreciation.ZCYZJ = System.Convert.ToDecimal(row["ZCJC"]) - System.Convert.ToDecimal(row["ZCLJZJ"]);
                tempDepreciation.HTYZJ = System.Convert.ToDecimal(row["HTJC"]) - System.Convert.ToDecimal(row["HTLJZJ"]);
                tempDepreciation.ZCSTAT = 8;
                tempDepreciation.ZCSYNX = 0;
                tempDepreciation.ZCMNTH = depreciation;
            }
            else
            {
                tempDepreciation.ZCID = row["ZCID"].ToString().Trim();
                tempDepreciation.ZCZJZ = System.Convert.ToInt32(row["ZCZJZ"]);
                tempDepreciation.ZCYZJ = System.Convert.ToDecimal(System.Convert.ToDecimal(row["ZCJC"]) / System.Convert.ToInt32(System.Convert.ToDecimal(row["ZCNX"]))) * month;
                tempDepreciation.HTYZJ = System.Convert.ToDecimal(System.Convert.ToDecimal(row["HTJC"]) / System.Convert.ToInt32(System.Convert.ToDecimal(row["ZCNX"]))) * month;
                tempDepreciation.ZCLJZJ = System.Convert.ToDecimal(row["ZCLJZJ"]) + tempDepreciation.ZCYZJ;
                tempDepreciation.HTLJZJ = System.Convert.ToDecimal(row["HTLJZJ"]) + tempDepreciation.HTYZJ;
                tempDepreciation.ZCNZJ = System.Convert.ToDecimal(row["ZCNZJ"]) + tempDepreciation.ZCYZJ;
                tempDepreciation.HTNZJ = System.Convert.ToDecimal(row["HTNZJ"]) + tempDepreciation.HTYZJ;
                tempDepreciation.ZCSTAT = 1;
                tempDepreciation.ZCSYNX = System.Convert.ToInt32(row["ZCSYNX"]) - month;
                tempDepreciation.ZCMNTH = depreciation;
            }
            if (t == 1)
            {
                tempDepreciation.ZCNZJ = tempDepreciation.ZCYZJ;
                tempDepreciation.HTNZJ = tempDepreciation.HTYZJ;

            }



            depreciations.Add(tempDepreciation);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            textBox1.Select();
            dataGridView1.Select();

            bool tempBool = false;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i].RowState == DataRowState.Added ||
                    dataTable.Rows[i].RowState == DataRowState.Modified ||
                    dataTable.Rows[i].RowState == DataRowState.Deleted)
                {
                    tempBool = true;
                    break;
                }
            }
            if (tempBool == true)
            {
                if (MessageBox.Show("数据已经修改，必须保存后才能导出，是否保存？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (PrepareSave() == false)
                        return;

                    if (this.SaveData() == false)
                        return;
                }
                else
                {
                    return;
                }
            }

            List<Cost> costList = new List<Cost>();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application m_objExcel = null;
                object ObjMiss = System.Reflection.Missing.Value;

                m_objExcel = new Microsoft.Office.Interop.Excel.Application();
                if (m_objExcel == null)
                {
                    MessageBox.Show("请安装Excel");
                    return;
                }
                try
                {
                    m_objExcel.Workbooks.Open(openFileDialog1.FileName, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss,
                        ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss);
                }
                catch
                {
                    MessageBox.Show("请安装Excel");
                    m_objExcel.Quit();
                }

                try
                {
                    m_objExcel.Visible = false;
                    (m_objExcel.Sheets[1] as Microsoft.Office.Interop.Excel._Worksheet).Activate();
                    int n = 3;
                    DataRow newRow;
                    try
                    {
                        while (((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString() != "")
                        {
                            string tempstr = "";
                            int tempint = 0;
                            decimal tempdecimal = 0M;
                            DateTime tempdatetime = DateTime.Now;
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            if (tempstr.Length != 10)
                                throw (new Exception("资产编号错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 2] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("增减值错误！"));
                            if (int.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 3] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempint) == false)
                                throw (new Exception("年限错误！"));
                            if (int.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 4] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempint) == false)
                                throw (new Exception("使用年限错误！"));
                            if (int.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 5] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempint) == false)
                                throw (new Exception("安装日期错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 6] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("原值错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 7] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("累计折旧错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 8] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("年折旧错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 9] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("月折旧错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 10] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("折旧基础错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 11] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("残值错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 12] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("航天累计折旧错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 13] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("航天年折旧错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 14] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("航天月折旧错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 15] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("航天折旧基础错误！"));
                            if (decimal.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 16] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempdecimal) == false)
                                throw (new Exception("航天残值错误！"));
                            n++;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("检查数据发生错误，数据没有导入，请检查Excel文件第" + n.ToString() + "行数据。" + ex.Message);
                        return;
                    }
                    n = 3;
                    try
                    {
                        while (((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString() != "")
                        {
                            Cost tempCost = new Cost();
                            tempCost.ZCID = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim().ToUpper();
                            tempCost.ZCCOST = System.Convert.ToDecimal(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 2] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            tempCost.ZCNX = System.Convert.ToInt32(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 3] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            tempCost.ZCSYNX = System.Convert.ToInt32(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 4] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            tempCost.ZCDTE = System.Convert.ToInt32(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 5] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            tempCost.ZCYZ = System.Convert.ToDecimal(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 6] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            tempCost.ZCLJZJ = System.Convert.ToDecimal(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 7] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            tempCost.ZCNZJ = System.Convert.ToDecimal(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 8] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            tempCost.ZCYZJ = System.Convert.ToDecimal(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 9] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            tempCost.ZCZJJC = System.Convert.ToDecimal(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 10] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            tempCost.ZCCZ = System.Convert.ToDecimal(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 11] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            tempCost.HTLJZJ = System.Convert.ToDecimal(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 12] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            tempCost.HTNZJ = System.Convert.ToDecimal(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 13] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            tempCost.HTYZJ = System.Convert.ToDecimal(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 14] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            tempCost.HTZJJC = System.Convert.ToDecimal(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 15] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            tempCost.HTCZ = System.Convert.ToDecimal(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 16] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            costList.Add(tempCost);

                            n++;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导入数据发生错误，部分数据可能已经导入。" + ex.Message);
                        return;
                    }
                    for (int i = 0; i < costList.Count; i++)
                    {
                        OdbcDataAdapter tempAdapter = new OdbcDataAdapter("SELECT * FROM " + BaseService.BaseService.SmgDatabase + ".GDZC WHERE ZCID='" + costList[i].ZCID + "' AND ZCSTAT=1", DataAccess.DataService.ApplicationConnection);
                        DataSet tempDataSet = new DataSet();
                        tempAdapter.Fill(tempDataSet);
                        if (tempDataSet.Tables[0].Rows.Count != 1)
                        {
                            MessageBox.Show("没有发现" + costList[i].ZCID);
                            return;
                        }
                    }
                    System.DateTime sysDateTime = DataAccess.DataService.GetDateTime();
                    if (sysDateTime.ToString("yyyyMMdd") == "18990101")
                    {
                        MessageBox.Show("获取服务器时间错误！");
                        return;
                    }
                    if (DataAccess.DataService.ApplicationConnection.State != ConnectionState.Open)
                        DataAccess.DataService.ApplicationConnection.Open();
                    try
                    {
                        OdbcTransaction transaction = DataAccess.DataService.ApplicationConnection.BeginTransaction();
                        try
                        {
                            OdbcCommand[] tempCommands = new OdbcCommand[costList.Count];
                            for (int i = 0; i < costList.Count; i++)
                            {
                                tempCommands[i] = new OdbcCommand();
                                tempCommands[i].CommandText = "UPDATE " + BaseService.BaseService.SmgDatabase + ".GDZC SET ZCSTAT=108, ZCZJZZ=" + costList[i].ZCCOST + " WHERE ZCID='" + costList[i].ZCID + "' AND ZCSTAT=1";
                                tempCommands[i].CommandTimeout = 60000;
                                tempCommands[i].Connection = DataAccess.DataService.ApplicationConnection;
                                tempCommands[i].Transaction = transaction;
                            }
                            OdbcCommand[] insertCommands = new OdbcCommand[costList.Count];
                            for (int i = 0; i < costList.Count; i++)
                            {
                                insertCommands[i] = new OdbcCommand();
                                insertCommands[i].CommandText = "INSERT INTO " + BaseService.BaseService.SmgDatabase + ".GDZC(ZCID, ZCSTAT, ZCNAME, ZCZJGC, ZCBM, ZCCWFL, ZCFL, ZCUF1, ZCUF3, ZCUF4, ZCUF5, ZCUF6, ZCUF7, ZCUF8, ZCUF9, ZCZJZ, ZCZJZZ, ZCNX, ZCSYNX, ZCDTE, ZCYZ, ZCLJZJ, ZCNZJ, ZCYZJ, ZCJC, ZCCZ, HTLJZJ, HTNZJ, HTYZJ, HTJC, HTCZ, ZCMNTH, ZCENUSR, ZCENDT, ZCENTM, ZCMNUSR, ZCMNDT, ZCMNTM) SELECT ZCID, 1, ZCNAME, ZCZJGC, ZCBM, ZCCWFL, ZCFL, ZCUF1, ZCUF3, ZCUF4, ZCUF5, ZCUF6, ZCUF7, ZCUF8, ZCUF9, ZCZJZ + 1, 0, " + costList[i].ZCNX.ToString().Trim() + ", " + costList[i].ZCSYNX.ToString().Trim() + ", " + costList[i].ZCDTE.ToString().Trim() + ", " + costList[i].ZCYZ.ToString().Trim() + ", " + costList[i].ZCLJZJ.ToString().Trim() + ", " + costList[i].ZCNZJ.ToString().Trim() + ", " + costList[i].ZCYZJ.ToString().Trim() + ", " + costList[i].ZCZJJC.ToString().Trim() + ", " + costList[i].ZCCZ.ToString().Trim() + ", " + costList[i].HTLJZJ.ToString().Trim() + ", " + costList[i].HTNZJ.ToString().Trim() + ", " + costList[i].HTYZJ.ToString().Trim() + ", " + costList[i].HTZJJC.ToString().Trim() + ", " + costList[i].HTCZ.ToString().Trim() + ", ZCMNTH, ZCENUSR, ZCENDT, ZCENTM, '" + BaseService.BaseService.ApplicationUser.SUSER + "', " + sysDateTime.ToString("yyyyMMdd") + ", " + sysDateTime.ToString("HHmmss") + " FROM " + BaseService.BaseService.SmgDatabase + ".GDZC WHERE ZCID='" + costList[i].ZCID + "' AND ZCSTAT=108";
                                insertCommands[i].CommandTimeout = 60000;
                                insertCommands[i].Connection = DataAccess.DataService.ApplicationConnection;
                                insertCommands[i].Transaction = transaction;
                            }
                            OdbcCommand[] updateCommands = new OdbcCommand[costList.Count];
                            for (int i = 0; i < costList.Count; i++)
                            {
                                updateCommands[i] = new OdbcCommand();
                                updateCommands[i].CommandText = "UPDATE " + BaseService.BaseService.SmgDatabase + ".GDZC SET ZCSTAT=30, ZCYZ=ZCLJZJ, ZCJC=ZCLJZJ, ZCCZ=0, HTJC=HTLJZJ, HTCZ=0, ZCTNUSR='" + BaseService.BaseService.ApplicationUser.SUSER + "', ZCTNDT=" + sysDateTime.ToString("yyyyMMdd") + ", ZCTNTM=" + sysDateTime.ToString("HHmmss") + " WHERE ZCID='" + costList[i].ZCID + "' AND ZCSTAT=108";
                                updateCommands[i].CommandTimeout = 60000;
                                updateCommands[i].Connection = DataAccess.DataService.ApplicationConnection;
                                updateCommands[i].Transaction = transaction;
                            }
                            for (int i = 0; i < costList.Count; i++)
                            {
                                tempCommands[i].ExecuteNonQuery();
                                if (insertCommands[i].ExecuteNonQuery() != 1)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("插入多条数据，" + insertCommands[i].CommandText);
                                    return;
                                }
                                if (updateCommands[i].ExecuteNonQuery() != 1)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("更新多条数据，" + updateCommands[i].CommandText);
                                    return;
                                }
                            }
                            transaction.Commit();
                            MessageBox.Show("导入" + openFileDialog1.FileName + "文件成功！");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("发生错误！" + ex.Message);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发生错误！" + ex.Message);
                    }
                    finally
                    {
                        DataAccess.DataService.ApplicationConnection.Close();
                    }
                }
                finally
                {
                    m_objExcel.ActiveWorkbook.Saved = true;
                    m_objExcel.ActiveWorkbook.Close(ObjMiss, ObjMiss, ObjMiss);
                    m_objExcel.Quit();
                    int tempExcel = GC.GetGeneration(m_objExcel);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
                    m_objExcel = null;
                    GC.Collect(tempExcel);
                }
            }
        }

        protected override bool WindowClosing()
        {
            return PrepareSave();
        }

        private void frm_asset_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            textBox1.Select();
            dataGridView1.Select();

            bool tempBool = false;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i].RowState == DataRowState.Added ||
                    dataTable.Rows[i].RowState == DataRowState.Modified ||
                    dataTable.Rows[i].RowState == DataRowState.Deleted)
                {
                    tempBool = true;
                    break;
                }
            }
            if (tempBool == true)
            {
                if (MessageBox.Show("数据已经修改，必须保存后才能导出，是否保存？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (PrepareSave() == false)
                        return;

                    if (this.SaveData() == false)
                        return;
                }
                else
                {
                    return;
                }
            }

            List<Scrap> scrapList = new List<Scrap>();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application m_objExcel = null;
                object ObjMiss = System.Reflection.Missing.Value;

                m_objExcel = new Microsoft.Office.Interop.Excel.Application();
                if (m_objExcel == null)
                {
                    MessageBox.Show("请安装Excel");
                    return;
                }
                try
                {
                    m_objExcel.Workbooks.Open(openFileDialog1.FileName, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss,
                        ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss, ObjMiss);
                }
                catch
                {
                    MessageBox.Show("请安装Excel");
                    m_objExcel.Quit();
                }

                try
                {
                    m_objExcel.Visible = false;
                    (m_objExcel.Sheets[1] as Microsoft.Office.Interop.Excel._Worksheet).Activate();
                    int n = 3;
                    DataRow newRow;
                    try
                    {
                        while (((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString() != "")
                        {
                            string tempstr = "";
                            int tempint = 0;
                            decimal tempdecimal = 0M;
                            DateTime tempdatetime = DateTime.Now;
                            tempstr = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim();
                            if (tempstr.Length != 10)
                                throw (new Exception("资产编号错误！"));
                            if (int.TryParse(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 2] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim(), out tempint) == false)
                                throw (new Exception("处置日期错误！"));

                            n++;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("检查数据发生错误，数据没有导入，请检查Excel文件第" + n.ToString() + "行数据。" + ex.Message);
                        return;
                    }
                    n = 3;
                    try
                    {
                        while (((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString() != "")
                        {
                            Scrap tempScrap = new Scrap();
                            tempScrap.ZCID = ((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 1] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim().ToUpper();
                            tempScrap.ZCBFDTE = System.Convert.ToInt32(((m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[n, 2] as Microsoft.Office.Interop.Excel.Range).Text.ToString().Trim());
                            scrapList.Add(tempScrap);

                            n++;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导入数据发生错误，部分数据可能已经导入。" + ex.Message);
                        return;
                    }
                    for (int i = 0; i < scrapList.Count; i++)
                    {
                        OdbcDataAdapter tempAdapter = new OdbcDataAdapter("SELECT * FROM " + BaseService.BaseService.SmgDatabase + ".GDZC WHERE ZCID='" + scrapList[i].ZCID + "' AND ZCSTAT IN (1, 8)", DataAccess.DataService.ApplicationConnection);
                        DataSet tempDataSet = new DataSet();
                        tempAdapter.Fill(tempDataSet);
                        if (tempDataSet.Tables[0].Rows.Count != 1)
                        {
                            MessageBox.Show("没有发现" + scrapList[i].ZCID);
                            return;
                        }
                    }
                    System.DateTime sysDateTime = DataAccess.DataService.GetDateTime();
                    if (sysDateTime.ToString("yyyyMMdd") == "18990101")
                    {
                        MessageBox.Show("获取服务器时间错误！");
                        return;
                    }
                    OdbcCommand[] tempCommands = new OdbcCommand[scrapList.Count];
                    OdbcCommand[] tempZJCommands = new OdbcCommand[scrapList.Count];
                    if (DataAccess.DataService.ApplicationConnection.State != ConnectionState.Open)
                        DataAccess.DataService.ApplicationConnection.Open();
                    try
                    {
                        OdbcTransaction transaction = DataAccess.DataService.ApplicationConnection.BeginTransaction();
                        try
                        {
                            for (int i = 0; i < scrapList.Count; i++)
                            {
                                tempCommands[i] = new OdbcCommand();
                                tempCommands[i].CommandText = "UPDATE " + BaseService.BaseService.SmgDatabase + ".GDZC SET ZCSTAT=10, ZCBFDTE=" + scrapList[i].ZCBFDTE.ToString().Trim() + ", ZCTNUSR='" + BaseService.BaseService.ApplicationUser.SUSER + "', ZCTNDT=" + sysDateTime.ToString("yyyyMMdd") + ", ZCTNTM=" + sysDateTime.ToString("HHmmss") + " WHERE ZCID='" + scrapList[i].ZCID + "' AND ZCSTAT IN (1, 8)";
                                tempCommands[i].CommandTimeout = 60000;
                                tempCommands[i].Connection = DataAccess.DataService.ApplicationConnection;
                                tempCommands[i].Transaction = transaction;
                                tempZJCommands[i] = new OdbcCommand();
                                tempZJCommands[i].CommandText = "UPDATE " + BaseService.BaseService.SmgDatabase + ".GDZC SET ZCSTAT=40, ZCBFDTE=" + scrapList[i].ZCBFDTE.ToString().Trim() + ", ZCTNUSR='" + BaseService.BaseService.ApplicationUser.SUSER + "', ZCTNDT=" + sysDateTime.ToString("yyyyMMdd") + ", ZCTNTM=" + sysDateTime.ToString("HHmmss") + " WHERE ZCID='" + scrapList[i].ZCID + "' AND ZCSTAT IN (30)";
                                tempZJCommands[i].CommandTimeout = 60000;
                                tempZJCommands[i].Connection = DataAccess.DataService.ApplicationConnection;
                                tempZJCommands[i].Transaction = transaction;
                            }
                            for (int i = 0; i < scrapList.Count; i++)
                            {
                                tempCommands[i].ExecuteNonQuery();
                                tempZJCommands[i].ExecuteNonQuery();
                            }
                            transaction.Commit();
                            MessageBox.Show("导入" + openFileDialog1.FileName + "文件成功！");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("发生错误！" + ex.Message);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发生错误！" + ex.Message);
                    }
                    finally
                    {
                        DataAccess.DataService.ApplicationConnection.Close();
                    }
                }
                finally
                {
                    m_objExcel.ActiveWorkbook.Saved = true;
                    m_objExcel.ActiveWorkbook.Close(ObjMiss, ObjMiss, ObjMiss);
                    m_objExcel.Quit();
                    int tempExcel = GC.GetGeneration(m_objExcel);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
                    m_objExcel = null;
                    GC.Collect(tempExcel);
                }
            }
        }
    }
}