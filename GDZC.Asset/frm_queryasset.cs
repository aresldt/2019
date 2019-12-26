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
    public partial class frm_queryasset : MdiChild.DataChildFrm
    {
        public frm_queryasset(List<object> objectArgs)
        {
            InitializeComponent();

            this.Init(tsp_file, null, (int)objectArgs[0]);

            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("GDZC.Asset");
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(assembly.GetManifestResourceStream("GDZC.Asset.xml_queryasset.xml"));
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
            MdiChild.DataQuery dataQueryFrm = new MdiChild.DataQuery("GDZC.Asset", "GDZC.Asset.que_asset.xml",
                Application.StartupPath + "\\XML\\" + this.formId.ToString());
            if (dataQueryFrm.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = null;

                System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("GDZC.Asset");
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.Load(assembly.GetManifestResourceStream("GDZC.Asset.xml_queryasset.xml"));
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

        private void tsb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream tempStream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);
                StringBuilder tempString = new StringBuilder();
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].Visible == true || i == dataGridView1.Columns.Count - 1)
                    {
                        if (i == dataGridView1.Columns.Count - 1)
                            tempString.Append("\"" + dataGridView1.Columns[i].HeaderText + "\"\r\n");
                        else
                            tempString.Append("\"" + dataGridView1.Columns[i].HeaderText + "\",");
                    }
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Columns[j].Visible == true || j == dataGridView1.Columns.Count - 1)
                        {
                            if (j == dataGridView1.Columns.Count - 1)
                                tempString.Append("\r\n");
                            else
                                tempString.Append("\"" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\",");
                        }
                    }
                }
                byte[] tempBytes = System.Text.Encoding.Default.GetBytes(tempString.ToString());
                tempStream.Write(tempBytes, 0, tempBytes.Length);
                tempStream.Close();
                MessageBox.Show("±£´æ³É¹¦¡£");
            }
        }
    }
}