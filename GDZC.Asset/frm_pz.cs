using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GDZC.Asset
{
    public partial class frm_pz : MdiChild.DataChildFrm
    {
        public frm_pz(List<object> objectArgs)
        {
            InitializeComponent();

            this.Init(tsp_file, null, (int)objectArgs[0]);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("GDZC.Asset");
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(assembly.GetManifestResourceStream("GDZC.Asset.xml_pz1.xml"));
            this.InitDataTable(pnl_file, dataGridView1, xmlDoc, "", new List<string>(), 0);
        }

        private void tsb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application m_objExcel = null;
            object ObjMiss = System.Reflection.Missing.Value;
            m_objExcel = new Microsoft.Office.Interop.Excel.Application();
            if (m_objExcel == null)
            {
                MessageBox.Show("请安装Excel2002。");
                return;
            }
            m_objExcel.Workbooks.Add(ObjMiss);
            m_objExcel.Visible = true;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                (m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (j == 1)
                        (m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[i + 2, j + 1] =
                            "'" + dataGridView1.Rows[i].Cells[j].Value.ToString().Trim();
                    else
                        (m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[i + 2, j + 1] =
                            dataGridView1.Rows[i].Cells[j].Value.ToString().Trim();
                }
            }

            MessageBox.Show("导出成功。");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("GDZC.Asset");
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(assembly.GetManifestResourceStream("GDZC.Asset.xml_pz2.xml"));
            this.InitDataTable(pnl_file, dataGridView1, xmlDoc, "", new List<string>(), 0);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("GDZC.Asset");
            //System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            //xmlDoc.Load(assembly.GetManifestResourceStream("GDZC.Asset.xml_pz3.xml"));
            //this.InitDataTable(pnl_file, dataGridView1, xmlDoc, "", new List<string>(), 0);
            MessageBox.Show("暂无功能！！！");
        }
    }
}