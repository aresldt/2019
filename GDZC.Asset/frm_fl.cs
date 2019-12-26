using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GDZC.Asset
{
    public partial class frm_fl : MdiChild.DataChildFrm
    {
        public frm_fl(List<object> objectArgs)
        {
            InitializeComponent();

            this.Init(tsp_file, null, (int)objectArgs[0]);

            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("GDZC.Asset");
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(assembly.GetManifestResourceStream("GDZC.Asset.xml_fl.xml"));
            this.InitDataTable(pnl_file, dataGridView1, xmlDoc, " WHERE 1=1 ORDER BY GDFL", new List<string>(), 1);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MdiChild.DataQuery dataQueryFrm = new MdiChild.DataQuery("GDZC.Asset", "GDZC.Asset.que_fl.xml",
                Application.StartupPath + "\\XML\\" + this.formId.ToString());
            if (dataQueryFrm.ShowDialog() == DialogResult.OK)
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("GDZC.Asset");
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.Load(assembly.GetManifestResourceStream("GDZC.Asset.xml_fl.xml"));
                this.InitDataTable(pnl_file, dataGridView1, xmlDoc, " WHERE " + dataQueryFrm.QueryText + " ORDER BY GDFL", new List<string>(), 1);
            }
        }

        private void tsb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DataRow row = dataTable.NewRow();
            dataTable.Rows.Add(row);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }

        protected override bool WindowClosing()
        {
            return true;
        }
    }
}