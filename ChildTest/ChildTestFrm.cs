using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChildTest
{
    public partial class ChildTestFrm : MdiChild.DataChildFrm
    {
        public ChildTestFrm(List<object> objectArgs)
        {
            InitializeComponent();

            List<Control> tempControl = new List<Control>();
            tempControl.Add(button1);
            tempControl.Add(button2);
            Init(this.tsp_child, tempControl, (int)objectArgs[0]);

            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("ChildTest");
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(assembly.GetManifestResourceStream("ChildTest.PjTest.xml"));
            this.InitDataTable(panel2, dataGridView1, xmlDoc, "", new List<string>(), 1);
        }

        private void tsb_button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Left.ToString() + " " + this.Top.ToString() + " " + this.Width.ToString() + " " + 
                this.Height.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MdiChild.DataQuery dataQueryFrm = new MdiChild.DataQuery("ChildTest", "ChildTest.TestQuery.xml",
                Application.StartupPath + "\\XML\\" + this.formId.ToString());
            if (dataQueryFrm.ShowDialog() == DialogResult.OK)
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("ChildTest");
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.Load(assembly.GetManifestResourceStream("ChildTest.PjTest.xml"));
                this.InitDataTable(panel2, dataGridView1, xmlDoc, " WHERE " + dataQueryFrm.QueryText, new List<string>(), 1);
            }
        }

        private void tsb_button2_Click(object sender, EventArgs e)
        {
            tbx_tdecimal.Focus();
            dataGridView1.Focus();
            this.SaveData();
        }

        private void tsb_button3_Click(object sender, EventArgs e)
        {
            MdiChild.DataQuery dataQueryFrm = new MdiChild.DataQuery("ChildTest", "ChildTest.TestQuery.xml",
                Application.StartupPath + "\\XML\\" + this.formId.ToString());
            if (dataQueryFrm.ShowDialog() == DialogResult.OK)
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("ChildTest");
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.Load(assembly.GetManifestResourceStream("ChildTest.PjTest.xml"));
                this.InitDataTable(panel2, dataGridView1, xmlDoc, " WHERE " + dataQueryFrm.QueryText, new List<string>(), 1);
            }
        }
    }
}