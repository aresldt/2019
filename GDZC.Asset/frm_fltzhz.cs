using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GDZC.Asset
{
    public partial class frm_fltzhz : MdiChild.DataChildFrm
    {
        public frm_fltzhz(List<object> objectArgs)
        {
            InitializeComponent();

            this.Init(tsp_file, null, (int)objectArgs[0]);

            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("GDZC.Asset");
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(assembly.GetManifestResourceStream("GDZC.Asset.xml_fltzhz.xml"));
            this.InitDataTable(pnl_file, dataGridView1, xmlDoc, "", new List<string>(), 0);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MdiChild.DataQuery dataQueryFrm = new MdiChild.DataQuery("GDZC.Asset", "GDZC.Asset.que_fltzhz.xml",
               Application.StartupPath + "\\XML\\" + this.formId.ToString());
            if (dataQueryFrm.ShowDialog() == DialogResult.OK)
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("GDZC.Asset");
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.Load(assembly.GetManifestResourceStream("GDZC.Asset.xml_fltzhz.xml"));
                this.InitDataTable(pnl_file, dataGridView1, xmlDoc, " WHERE " + dataQueryFrm.QueryText, new List<string>(), 0);
            }
        }

        private void tsb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.ExportExcel();
        }
    }
}