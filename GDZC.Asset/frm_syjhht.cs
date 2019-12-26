using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.IO;

namespace GDZC.Asset
{
    public partial class frm_syjhht : MdiChild.MdiChildFrm
    {
        private int syjhyf;
        private string gyyzj;
        private DateTime tempDatetime;
        private DataSet ds;

        public frm_syjhht(List<object> objectArgs)
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frm_syjhyf tempSYJHYF = new frm_syjhyf();
            if (tempSYJHYF.ShowDialog() == DialogResult.OK)
            {                
                OdbcDataAdapter tempAdapter = new OdbcDataAdapter("SELECT GYZJY FROM " + BaseService.BaseService.SmgDatabase + ".GDZHZJY", DataAccess.DataService.ApplicationConnection);
                DataSet tempDS = new DataSet();
                tempAdapter.Fill(tempDS);
                gyyzj = tempDS.Tables[0].Rows[0][0].ToString();
                tempDatetime = System.Convert.ToDateTime(tempDS.Tables[0].Rows[0][0].ToString().Substring(0,4) + "-" + tempDS.Tables[0].Rows[0][0].ToString().Substring(4,2) + "-01");
                OdbcDataAdapter adapter = new OdbcDataAdapter("SELECT ZCID, ZCSTAT, ZCNAME, ZCFL, GDHZDESC, ZCNX, ZCSYNX, ZCYZ, HTLJZJ, ZCYZ - HTLJZJ AS HTJZ, HTJC, HTCZ, HTYZJ FROM " + BaseService.BaseService.SmgDatabase + ".GDZC LEFT OUTER JOIN " + BaseService.BaseService.LibraryName + ".GDFL ON ZCFL=GDFL WHERE ZCSTAT IN (1, 8, 30) ORDER BY ZCFL, ZCID", DataAccess.DataService.ApplicationConnection);
                ds = new DataSet();
                adapter.Fill(ds);
                syjhyf = tempSYJHYF.syjhyf;
                for (int i = 0; i < tempSYJHYF.syjhyf; i++)
                {
                    DataColumn column = ds.Tables[0].Columns.Add(tempDatetime.AddMonths(i + 1).ToString("yyyyMM"), typeof(String));
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        if (System.Convert.ToInt32(ds.Tables[0].Rows[j]["ZCSTAT"].ToString()) == 1)
                        {
                            if (System.Convert.ToInt32(ds.Tables[0].Rows[j]["ZCSYNX"].ToString()) == i + 1)
                                ds.Tables[0].Rows[j][column] = (System.Convert.ToDecimal(ds.Tables[0].Rows[j]["HTJC"].ToString()) - System.Convert.ToDecimal(ds.Tables[0].Rows[j]["HTLJZJ"].ToString()) - System.Convert.ToDecimal(ds.Tables[0].Rows[j]["HTJC"].ToString()) / System.Convert.ToDecimal(ds.Tables[0].Rows[j]["ZCNX"].ToString()) * i).ToString("0.00");
                            else if (System.Convert.ToInt32(ds.Tables[0].Rows[j]["ZCSYNX"].ToString()) > i + 1)
                                ds.Tables[0].Rows[j][column] = (System.Convert.ToDecimal(ds.Tables[0].Rows[j]["HTJC"].ToString()) / System.Convert.ToDecimal(ds.Tables[0].Rows[j]["ZCNX"].ToString())).ToString("0.00");
                        }
                    }
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["ZCID"].HeaderText = "资产编号";
                dataGridView1.Columns["ZCSTAT"].HeaderText = "状态";
                dataGridView1.Columns["ZCNAME"].HeaderText = "资产名称";
                dataGridView1.Columns["ZCFL"].HeaderText = "分类";
                dataGridView1.Columns["GDHZDESC"].HeaderText = "分类";
                dataGridView1.Columns["ZCNX"].HeaderText = "年限";
                dataGridView1.Columns["ZCSYNX"].HeaderText = "剩余年限";
                dataGridView1.Columns["ZCYZ"].HeaderText = "原值";
                dataGridView1.Columns["HTLJZJ"].HeaderText = "累计折旧";
                dataGridView1.Columns["HTJZ"].HeaderText = "净值";
                dataGridView1.Columns["HTJC"].HeaderText = "折旧基础";
                dataGridView1.Columns["HTCZ"].HeaderText = "残值";
                dataGridView1.Columns["HTYZJ"].HeaderText = gyyzj;
            }
        }

        private void tsb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder tempStrings = new StringBuilder();
                    /*tempStrings.Append("资产编号");
                    tempStrings.Append(",资产名称");
                    tempStrings.Append(",分类");
                    tempStrings.Append(",分类");
                    tempStrings.Append(",年限");
                    tempStrings.Append(",剩余年限");
                    tempStrings.Append(",原值");
                    tempStrings.Append(",累计折旧");
                    tempStrings.Append(",净值");
                    tempStrings.Append(",折旧基础");
                    tempStrings.Append(",残值");
                    tempStrings.Append("," + gyyzj + "月折旧");
                    for (int i = 0; i < syjhyf; i++)
                        tempStrings.Append("," + tempDatetime.AddMonths(i + 1).ToString("yyyyMM") + "月折旧");
                    tempStrings.Append("\r\n");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        tempStrings.Append(ds.Tables[0].Rows[i]["ZCID"].ToString());
                        tempStrings.Append(",\"");
                        tempStrings.Append(ds.Tables[0].Rows[i]["ZCNAME"].ToString());
                        tempStrings.Append("\",");
                        tempStrings.Append(ds.Tables[0].Rows[i]["ZCFL"].ToString());
                        tempStrings.Append(",");
                        tempStrings.Append(ds.Tables[0].Rows[i]["GDHZDESC"].ToString());
                        tempStrings.Append(",");
                        tempStrings.Append(ds.Tables[0].Rows[i]["ZCNX"].ToString());
                        tempStrings.Append(",");
                        tempStrings.Append(ds.Tables[0].Rows[i]["ZCSYNX"].ToString());
                        tempStrings.Append(",");
                        tempStrings.Append(ds.Tables[0].Rows[i]["ZCYZ"].ToString());
                        tempStrings.Append(",");
                        tempStrings.Append(ds.Tables[0].Rows[i]["ZCLJZJ"].ToString());
                        tempStrings.Append(",");
                        tempStrings.Append(ds.Tables[0].Rows[i]["ZCJZ"].ToString());
                        tempStrings.Append(",");
                        tempStrings.Append(ds.Tables[0].Rows[i]["ZCJC"].ToString());
                        tempStrings.Append(",");
                        tempStrings.Append(ds.Tables[0].Rows[i]["ZCCZ"].ToString());
                        tempStrings.Append(",");
                        tempStrings.Append(ds.Tables[0].Rows[i]["ZCYZJ"].ToString());
                        for (int j = 0; j < syjhyf; j++)
                            tempStrings.Append("," + ds.Tables[0].Rows[i][tempDatetime.AddMonths(j + 1).ToString("yyyyMM")].ToString());
                        tempStrings.Append("\r\n");
                    }*/
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        if (i == 0)
                            tempStrings.Append("\"" + dataGridView1.Columns[i].HeaderText + "\"");
                        else
                            tempStrings.Append(",\"" + dataGridView1.Columns[i].HeaderText + "\"");
                    }
                    tempStrings.Append("\r\n");
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (j == 0)
                                tempStrings.Append("\"" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\"");
                            else
                                tempStrings.Append(",\"" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\"");
                        }
                        tempStrings.Append("\r\n");
                    }
                    byte[] tempBytes = System.Text.Encoding.Default.GetBytes(tempStrings.ToString());
                    FileStream tempStream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);
                    tempStream.Write(tempBytes, 0, tempBytes.Length);
                    tempStream.Close();
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frm_syjhyf tempSYJHYF = new frm_syjhyf();
            if (tempSYJHYF.ShowDialog() == DialogResult.OK)
            {
                OdbcDataAdapter tempAdapter = new OdbcDataAdapter("SELECT GYZJY FROM " + BaseService.BaseService.SmgDatabase + ".GDZHZJY", DataAccess.DataService.ApplicationConnection);
                DataSet tempDS = new DataSet();
                tempAdapter.Fill(tempDS);
                gyyzj = tempDS.Tables[0].Rows[0][0].ToString();
                tempDatetime = System.Convert.ToDateTime(tempDS.Tables[0].Rows[0][0].ToString().Substring(0, 4) + "-" + tempDS.Tables[0].Rows[0][0].ToString().Substring(4, 2) + "-01");
                OdbcDataAdapter adapter = new OdbcDataAdapter("SELECT ZCID, ZCSTAT, ZCNAME, ZCFL, GDHZDESC, ZCNX, ZCSYNX, ZCYZ, HTLJZJ, ZCYZ - HTLJZJ AS HTJZ, HTJC, HTCZ, HTYZJ FROM " + BaseService.BaseService.SmgDatabase + ".GDZC LEFT OUTER JOIN " + BaseService.BaseService.LibraryName + ".GDFL ON ZCFL=GDFL WHERE ZCSTAT IN (1, 8, 30) ORDER BY GDHZDESC, ZCID", DataAccess.DataService.ApplicationConnection);
                ds = new DataSet();
                adapter.Fill(ds);
                syjhyf = tempSYJHYF.syjhyf;
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add(new DataColumn("ZCFL", typeof(String)));
                dataTable.Columns.Add(new DataColumn("ZCYZ", typeof(String)));
                dataTable.Columns.Add(new DataColumn("HTLJZJ", typeof(String)));
                dataTable.Columns.Add(new DataColumn("HTJZ", typeof(String)));
                dataTable.Columns.Add(new DataColumn("HTYZJ", typeof(String)));
                for (int i = 0; i < tempSYJHYF.syjhyf; i++)
                {
                    DataColumn column = ds.Tables[0].Columns.Add(tempDatetime.AddMonths(i + 1).ToString("yyyyMM"), typeof(String));
                    dataTable.Columns.Add(tempDatetime.AddMonths(i + 1).ToString("yyyyMM"), typeof(String));
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        if (System.Convert.ToInt32(ds.Tables[0].Rows[j]["ZCSTAT"].ToString()) == 1)
                        {
                            if (System.Convert.ToInt32(ds.Tables[0].Rows[j]["ZCSYNX"].ToString()) == i + 1)
                                ds.Tables[0].Rows[j][column] = (System.Convert.ToDecimal(ds.Tables[0].Rows[j]["HTJC"].ToString()) - System.Convert.ToDecimal(ds.Tables[0].Rows[j]["HTLJZJ"].ToString()) - System.Convert.ToDecimal(ds.Tables[0].Rows[j]["HTJC"].ToString()) / System.Convert.ToDecimal(ds.Tables[0].Rows[j]["ZCNX"].ToString()) * i).ToString("0.00");
                            else if (System.Convert.ToInt32(ds.Tables[0].Rows[j]["ZCSYNX"].ToString()) > i + 1)
                                ds.Tables[0].Rows[j][column] = (System.Convert.ToDecimal(ds.Tables[0].Rows[j]["HTJC"].ToString()) / System.Convert.ToDecimal(ds.Tables[0].Rows[j]["ZCNX"].ToString())).ToString("0.00");
                        }
                    }
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string tempStr = ds.Tables[0].Rows[0]["GDHZDESC"].ToString().Trim();
                    decimal[] tempDecimal = new decimal[4 + tempSYJHYF.syjhyf];
                    for (int j = 0; j < 4 + tempSYJHYF.syjhyf; j++)
                        tempDecimal[j] = 0M;
                    DataRow row;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["GDHZDESC"].ToString().Trim() == tempStr)
                        {
                            tempDecimal[0] += System.Convert.ToDecimal(ds.Tables[0].Rows[i]["ZCYZ"].ToString().Trim());
                            tempDecimal[1] += System.Convert.ToDecimal(ds.Tables[0].Rows[i]["HTLJZJ"].ToString().Trim());
                            tempDecimal[2] += System.Convert.ToDecimal(ds.Tables[0].Rows[i]["HTJZ"].ToString().Trim());
                            tempDecimal[3] += System.Convert.ToDecimal(ds.Tables[0].Rows[i]["HTYZJ"].ToString().Trim());
                            for (int j = 0; j < tempSYJHYF.syjhyf; j++)
                                tempDecimal[j + 4] += System.Convert.ToDecimal((ds.Tables[0].Rows[i][tempDatetime.AddMonths(j + 1).ToString("yyyyMM")].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][tempDatetime.AddMonths(j + 1).ToString("yyyyMM")].ToString().Trim()));
                        }
                        else
                        {
                            row = dataTable.NewRow();
                            row["ZCFL"] = tempStr;
                            row["ZCYZ"] = tempDecimal[0].ToString("0.00");
                            row["HTLJZJ"] = tempDecimal[1].ToString("0.00");
                            row["HTJZ"] = tempDecimal[2].ToString("0.00");
                            row["HTYZJ"] = tempDecimal[3].ToString("0.00");
                            for (int j = 0; j < tempSYJHYF.syjhyf; j++)
                                row[tempDatetime.AddMonths(j + 1).ToString("yyyyMM")] = tempDecimal[4 + j].ToString("0.00");
                            dataTable.Rows.Add(row);
                            tempStr = ds.Tables[0].Rows[i]["GDHZDESC"].ToString().Trim();
                            tempDecimal[0] = System.Convert.ToDecimal(ds.Tables[0].Rows[i]["ZCYZ"].ToString().Trim());
                            tempDecimal[1] = System.Convert.ToDecimal(ds.Tables[0].Rows[i]["HTLJZJ"].ToString().Trim());
                            tempDecimal[2] = System.Convert.ToDecimal(ds.Tables[0].Rows[i]["HTJZ"].ToString().Trim());
                            tempDecimal[3] = System.Convert.ToDecimal(ds.Tables[0].Rows[i]["HTYZJ"].ToString().Trim());
                            for (int j = 0; j < tempSYJHYF.syjhyf; j++)
                                tempDecimal[j + 4] = System.Convert.ToDecimal((ds.Tables[0].Rows[i][tempDatetime.AddMonths(j + 1).ToString("yyyyMM")].ToString().Trim() == "" ? "0" : ds.Tables[0].Rows[i][tempDatetime.AddMonths(j + 1).ToString("yyyyMM")].ToString().Trim()));
                        }
                    }
                    row = dataTable.NewRow();
                    row["ZCFL"] = tempStr;
                    row["ZCYZ"] = tempDecimal[0].ToString("0.00");
                    row["HTLJZJ"] = tempDecimal[1].ToString("0.00");
                    row["HTJZ"] = tempDecimal[2].ToString("0.00");
                    row["HTYZJ"] = tempDecimal[3].ToString("0.00");
                    for (int j = 0; j < tempSYJHYF.syjhyf; j++)
                        row[tempDatetime.AddMonths(j + 1).ToString("yyyyMM")] = tempDecimal[4 + j].ToString("0.00");
                    dataTable.Rows.Add(row);
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns["ZCFL"].HeaderText = "分类";
                dataGridView1.Columns["ZCYZ"].HeaderText = "原值";
                dataGridView1.Columns["HTLJZJ"].HeaderText = "累计折旧";
                dataGridView1.Columns["HTJZ"].HeaderText = "净值";
                dataGridView1.Columns["HTYZJ"].HeaderText = gyyzj;
            }
        }
    }
}