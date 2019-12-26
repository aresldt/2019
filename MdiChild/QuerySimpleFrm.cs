using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseService;

namespace MdiChild
{
    public partial class QuerySimpleFrm : Form
    {
        private List<Query_Struct> queryList;

        public string QueryText;

        public QuerySimpleFrm(string aAssembly, string aXml, string aPath)
        {
            InitializeComponent();

            QueryText = "";

            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(aAssembly);
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(assembly.GetManifestResourceStream(aXml));
            queryList = new List<Query_Struct>();
            for (int i = 0; i < xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes.Count; i++)
            {
                Query_Struct queryInstance = new Query_Struct();
                for (int j = 0; j < xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[i].Attributes.Count; j++)
                {
                    switch (xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[i].Attributes[j].Name.ToUpper())
                    {
                        case "NAME":
                            queryInstance.QueryName = xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[i].Attributes[j].Value;
                            break;
                        case "DESCRIPTION":
                            queryInstance.QueryDescription = xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[i].Attributes[j].Value;
                            break;
                        case "TYPE":
                            queryInstance.QueryType = xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[i].Attributes[j].Value;
                            break;
                        case "VALUE":
                            queryInstance.QueryValue = xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[i].Attributes[j].Value;
                            break;
                        case "RANGE":
                            queryInstance.QueryRange = System.Convert.ToInt32(xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[i].Attributes[j].Value);
                            break;
                    }
                }
                queryList.Add(queryInstance);
            }

            this.Height = 103 + queryList.Count * 27;
            btn_ok.Top = 38 + queryList.Count * 27;
            btn_cancel.Top = 38 + queryList.Count * 27;
            for (int i = 0; i < queryList.Count; i++)
            {
                CheckBox tempCheckBox = new CheckBox();
                tempCheckBox.Name = "cbx_" + queryList[i].QueryName;
                tempCheckBox.Left = 12;
                tempCheckBox.Top = 14 + i * 27;
                tempCheckBox.Text = queryList[i].QueryDescription;
                tempCheckBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
                tempCheckBox.Parent = this;
                Panel tempPanel = new Panel();
                tempPanel.Name = "pnl_" + queryList[i].QueryName;
                tempPanel.Left = 124;
                tempPanel.Top = 12 + i * 27;
                tempPanel.Width = 230;
                tempPanel.Height = 27;
                tempPanel.Visible = false;
                tempPanel.Parent = this;
                tempCheckBox.Tag = tempPanel;
                if (queryList[i].QueryRange == 1)
                {
                    TextBox tempTextBox1 = new TextBox();
                    tempTextBox1.Name = "tbx_" + queryList[i].QueryName;
                    tempTextBox1.Left = 0;
                    tempTextBox1.Top = 0;
                    tempTextBox1.Width = 200;
                    tempTextBox1.Text = "";
                    tempTextBox1.Parent = tempPanel;
                }
                else
                {
                    TextBox tempTextBox1 = new TextBox();
                    tempTextBox1.Name = "tbx_" + queryList[i].QueryName + "_1";
                    tempTextBox1.Left = 0;
                    tempTextBox1.Top = 0;
                    tempTextBox1.Width = 100;
                    tempTextBox1.Text = "";
                    tempTextBox1.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
                    tempTextBox1.Parent = tempPanel;
                    Label tempLabel = new Label();
                    tempLabel.Name = "lbl_" + queryList[i].QueryName;
                    tempLabel.Left = 106;
                    tempLabel.Top = 3;
                    tempLabel.Text = "µ½";
                    tempLabel.Width = 16;
                    tempLabel.Parent = tempPanel;
                    TextBox tempTextBox2 = new TextBox();
                    tempTextBox2.Name = "tbx_" + queryList[i].QueryName + "_2";
                    tempTextBox2.Left = 129;
                    tempTextBox2.Top = 0;
                    tempTextBox2.Width = 100;
                    tempTextBox1.Tag = tempTextBox2;
                    tempTextBox2.Text = "";
                    tempTextBox2.Parent = tempPanel;
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ((sender as CheckBox).Tag as Panel).Visible = (sender as CheckBox).Checked;
        }

        private Control GetPanelControl(Control aControl, string aName)
        {
            for (int i = 0; i < aControl.Controls.Count; i++)
            {
                if (aControl.Controls[i].Name == aName)
                {
                    return aControl.Controls[i];
                }
                else if (aControl.Controls[i] is Panel)
                {
                    Control tempControl = GetPanelControl(aControl.Controls[i], aName);
                    if (tempControl != null)
                        return tempControl;
                }
            }
            return null;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string tempStr = "1=1";
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is CheckBox && (this.Controls[i] as CheckBox).Checked == true)
                {
                    for (int j = 0; j < queryList.Count; j++)
                    {
                        if ((this.Controls[i] as CheckBox).Name == "cbx_" + queryList[j].QueryName)
                        {
                            switch (queryList[j].QueryType)
                            {
                                case "VarChar":
                                    if (queryList[j].QueryRange == 1)
                                        tempStr = tempStr + " AND " + queryList[j].QueryName + "='" +
                                            (GetPanelControl(this, "tbx_" + queryList[j].QueryName) as TextBox).Text + "'";
                                    else
                                        tempStr = tempStr + " AND " + queryList[j].QueryName + ">='" +
                                            (GetPanelControl(this, "tbx_" + queryList[j].QueryName + "_1") as TextBox).Text +
                                            "' AND " + queryList[j].QueryName + "<='" +
                                            (GetPanelControl(this, "tbx_" + queryList[j].QueryName + "_2") as TextBox).Text + "'";
                                    break;
                                case "Decimal":
                                    if (queryList[j].QueryRange == 1)
                                        tempStr = tempStr + " AND " + queryList[j].QueryName + "=" +
                                            (GetPanelControl(this, "tbx_" + queryList[j].QueryName) as TextBox).Text;
                                    else
                                        tempStr = tempStr + " AND " + queryList[j].QueryName + ">=" +
                                            (GetPanelControl(this, "tbx_" + queryList[j].QueryName + "_1") as TextBox).Text +
                                            " AND " + queryList[j].QueryName + "<=" +
                                            (GetPanelControl(this, "tbx_" + queryList[j].QueryName + "_2") as TextBox).Text;
                                    break;
                            }
                        }
                    }
                }
            }
            QueryText = tempStr;
            DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            ((sender as TextBox).Tag as TextBox).Text = (sender as TextBox).Text;
        }
    }
}