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
    public partial class QueryDifficultFrm : Form
    {
        private List<Query_Struct> queryList;
        private DataTable dataTable;
        private string pathStr;

        public string QueryText;

        public QueryDifficultFrm(string aAssembly, string aXml, string aPath)
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
                            cbx_field.Items.Add(queryInstance.QueryDescription);
                            break;
                        case "TYPE":
                            queryInstance.QueryType = xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[i].Attributes[j].Value;
                            break;
                        case "VALUE":
                            queryInstance.QueryValue = xmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes[i].Attributes[j].Value;
                            break;
                    }
                }
                queryList.Add(queryInstance);
            }
            dataTable = new DataTable();
            dataTable.Columns.Add("Bracket1");
            dataTable.Columns.Add("Field");
            dataTable.Columns.Add("Compare");
            dataTable.Columns.Add("Value");
            dataTable.Columns.Add("Bracket2");
            dataTable.Columns.Add("Relation");
            dgv_query.DefaultCellStyle.BackColor = Color.Ivory;
            dgv_query.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgv_query.DataSource = dataTable;
            dgv_query.Columns["Bracket1"].HeaderText = "";
            dgv_query.Columns["Bracket1"].Width = 30;
            dgv_query.Columns["Bracket1"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_query.Columns["Field"].HeaderText = "项目";
            dgv_query.Columns["Field"].Width = 100;
            dgv_query.Columns["Field"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_query.Columns["Compare"].HeaderText = "条件";
            dgv_query.Columns["Compare"].Width = 60;
            dgv_query.Columns["Compare"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_query.Columns["Value"].HeaderText = "值";
            dgv_query.Columns["Value"].Width = 120;
            dgv_query.Columns["Value"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_query.Columns["Bracket2"].HeaderText = "";
            dgv_query.Columns["Bracket2"].Width = 30;
            dgv_query.Columns["Bracket2"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_query.Columns["Relation"].HeaderText = "";
            dgv_query.Columns["Relation"].Width = 40;
            dgv_query.Columns["Relation"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv_query.Controls.Add(cbx_bracket1);
            dgv_query.Controls.Add(cbx_field);
            dgv_query.Controls.Add(cbx_compare);
            dgv_query.Controls.Add(cbx_value);
            dgv_query.Controls.Add(cbx_bracket2);
            dgv_query.Controls.Add(cbx_relation);

            pathStr = aPath;
            if (System.IO.Directory.Exists(pathStr) == false)
                System.IO.Directory.CreateDirectory(pathStr);
            string[] aPaths = System.IO.Directory.GetFiles(aPath);
            for (int i = 0; i < aPaths.Length; i++)
                lvw_query.Items.Add(System.IO.Path.GetFileName(aPaths[i]));
        }

        private void dgv_query_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dgv_query.Rows.Count &&
                e.ColumnIndex > -1 && e.ColumnIndex < dgv_query.Columns.Count)
            {
                if (e.ColumnIndex == 0)
                {
                    cbx_field.Visible = false;
                    cbx_compare.Visible = false;
                    cbx_value.Visible = false;
                    cbx_bracket2.Visible = false;
                    cbx_relation.Visible = false;
                    System.Drawing.Rectangle tempRect =
                        dgv_query.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    cbx_bracket1.Size = tempRect.Size;
                    cbx_bracket1.Top = tempRect.Top;
                    cbx_bracket1.Left = tempRect.Left;
                    if (dgv_query.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                        cbx_bracket1.SelectedIndex = -1;
                    else
                        cbx_bracket1.SelectedIndex = cbx_bracket1.Items.IndexOf(
                            dgv_query.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cbx_bracket1.Visible = true;
                }
                else if (dgv_query.Columns[e.ColumnIndex].HeaderText == "项目")
                {
                    cbx_bracket1.Visible = false;
                    cbx_compare.Visible = false;
                    cbx_value.Visible = false;
                    cbx_bracket2.Visible = false;
                    cbx_relation.Visible = false;
                    System.Drawing.Rectangle tempRect =
                        dgv_query.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    cbx_field.Size = tempRect.Size;
                    cbx_field.Top = tempRect.Top;
                    cbx_field.Left = tempRect.Left;
                    if (dgv_query.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                        cbx_field.SelectedIndex = -1;
                    else
                        cbx_field.SelectedIndex = cbx_field.Items.IndexOf(
                            dgv_query.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cbx_field.Visible = true;
                }
                else if (dgv_query.Columns[e.ColumnIndex].HeaderText == "条件")
                {
                    cbx_bracket1.Visible = false;
                    cbx_field.Visible = false;
                    cbx_value.Visible = false;
                    cbx_bracket2.Visible = false;
                    cbx_relation.Visible = false;
                    System.Drawing.Rectangle tempRect =
                        dgv_query.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    cbx_compare.Size = tempRect.Size;
                    cbx_compare.Top = tempRect.Top;
                    cbx_compare.Left = tempRect.Left;
                    if (dgv_query.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                        cbx_compare.SelectedIndex = -1;
                    else
                        cbx_compare.SelectedIndex = cbx_compare.Items.IndexOf(
                            dgv_query.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cbx_compare.Visible = true;
                }
                else if (dgv_query.Columns[e.ColumnIndex].HeaderText == "值")
                {
                    cbx_bracket1.Visible = false;
                    cbx_field.Visible = false;
                    cbx_compare.Visible = false;
                    cbx_value.Visible = false;
                    cbx_bracket2.Visible = false;
                    cbx_relation.Visible = false;
                    bool tempBool = false;
                    for (int i = 0; i < queryList.Count; i++)
                    {
                        if (dgv_query.Rows[e.RowIndex].Cells[e.ColumnIndex - 2].Value.ToString() ==
                            queryList[i].QueryDescription && queryList[i].QueryValue != "")
                        {
                            cbx_value.Items.Clear();
                            cbx_value.Items.AddRange(queryList[i].QueryValue.Split(','));
                            tempBool = true;
                        }
                    }
                    if (tempBool == true)
                    {
                        System.Drawing.Rectangle tempRect =
                            dgv_query.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        cbx_value.Size = tempRect.Size;
                        cbx_value.Top = tempRect.Top;
                        cbx_value.Left = tempRect.Left;
                        if (dgv_query.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                            cbx_value.SelectedIndex = -1;
                        else
                            cbx_value.SelectedIndex = cbx_value.Items.IndexOf(
                                dgv_query.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        cbx_value.Visible = true;
                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    cbx_bracket1.Visible = false;
                    cbx_field.Visible = false;
                    cbx_compare.Visible = false;
                    cbx_value.Visible = false;
                    cbx_bracket2.Visible = false;
                    cbx_relation.Visible = false;
                    System.Drawing.Rectangle tempRect =
                        dgv_query.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    cbx_bracket2.Size = tempRect.Size;
                    cbx_bracket2.Top = tempRect.Top;
                    cbx_bracket2.Left = tempRect.Left;
                    if (dgv_query.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                        cbx_bracket2.SelectedIndex = -1;
                    else
                        cbx_bracket2.SelectedIndex = cbx_bracket2.Items.IndexOf(
                            dgv_query.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cbx_bracket2.Visible = true;
                }
                else if (e.ColumnIndex == 5)
                {
                    cbx_bracket1.Visible = false;
                    cbx_field.Visible = false;
                    cbx_compare.Visible = false;
                    cbx_value.Visible = false;
                    cbx_bracket2.Visible = false;
                    cbx_relation.Visible = false;
                    System.Drawing.Rectangle tempRect =
                        dgv_query.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    cbx_relation.Size = tempRect.Size;
                    cbx_relation.Top = tempRect.Top;
                    cbx_relation.Left = tempRect.Left;
                    if (dgv_query.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                        cbx_relation.SelectedIndex = -1;
                    else
                        cbx_relation.SelectedIndex = cbx_relation.Items.IndexOf(
                            dgv_query.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    cbx_relation.Visible = true;
                }
                else
                {
                    cbx_bracket1.Visible = false;
                    cbx_field.Visible = false;
                    cbx_compare.Visible = false;
                    cbx_value.Visible = false;
                    cbx_bracket2.Visible = false;
                    cbx_relation.Visible = false;
                }
            }
            else
            {
                cbx_bracket1.Visible = false;
                cbx_field.Visible = false;
                cbx_compare.Visible = false;
                cbx_value.Visible = false;
                cbx_bracket2.Visible = false;
                cbx_relation.Visible = false;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Add(dataTable.NewRow());
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            string tempQuery = "";
            for (int i = 0; i < dgv_query.Rows.Count; i++)
            {
                for (int j = 0; j < dgv_query.Columns.Count; j++)
                {
                    if (j == 0)
                        tempQuery = tempQuery + dgv_query.Rows[i].Cells[j].Value.ToString();
                    else
                        tempQuery = tempQuery + "," + dgv_query.Rows[i].Cells[j].Value.ToString();
                }
                if (i < dgv_query.Rows.Count - 1)
                    tempQuery += "\r";
            }
            try
            {
                System.IO.FileStream stream = new System.IO.FileStream(pathStr + "\\上次查询",
                    System.IO.FileMode.Create, System.IO.FileAccess.Write);
                byte[] tempByte = System.Text.Encoding.Default.GetBytes(tempQuery);
                stream.Write(tempByte, 0, tempByte.Length);
                stream.Close();
                bool tempBool = false;
                for (int i = 0; i < lvw_query.Items.Count; i++)
                {
                    if (lvw_query.Items[i].Text == "上次查询")
                    {
                        tempBool = true;
                        break;
                    }
                }
                if (tempBool == false)
                    lvw_query.Items.Add("上次查询");
            }
            catch
            {
            }
            for (int i = 0; i < dgv_query.Rows.Count; i++)
            {
                if (dgv_query.Rows[i].Cells["Field"].Value.ToString() != "" &&
                    dgv_query.Rows[i].Cells["Compare"].Value.ToString() != "")
                {
                    if (i + 1 < dgv_query.Rows.Count &&
                        dgv_query.Rows[i + 1].Cells["Field"].Value.ToString() != "" &&
                        dgv_query.Rows[i + 1].Cells["Compare"].Value.ToString() != "" &&
                        dgv_query.Rows[i].Cells["Relation"].Value.ToString() == "")
                    {
                        MessageBox.Show("请输入第" + (i + 1).ToString() + "行关系！");
                        return;
                    }
                }
            }
            string tempStr = "1=1";
            for (int i = 0; i < dgv_query.Rows.Count; i++)
            {
                if (dgv_query.Rows[i].Cells["Field"].Value.ToString() != "" &&
                    dgv_query.Rows[i].Cells["Compare"].Value.ToString() != "")
                {
                    int tempInt = -1;
                    for (int j = 0; j < queryList.Count; j++)
                    {
                        if (dgv_query.Rows[i].Cells["Field"].Value.ToString() ==
                            queryList[j].QueryDescription)
                        {
                            tempInt = j;
                        }
                    }
                    if (tempInt > -1)
                    {
                        if (tempStr == "1=1")
                            tempStr = tempStr + " AND " + dgv_query.Rows[i].Cells["Bracket1"].Value.ToString() +
                                queryList[tempInt].QueryName;
                        else
                            tempStr = tempStr + dgv_query.Rows[i].Cells["Bracket1"].Value.ToString() +
                                queryList[tempInt].QueryName;
                        switch (queryList[tempInt].QueryType)
                        {
                            case "VarChar":
                                switch (dgv_query.Rows[i].Cells["Compare"].Value.ToString())
                                {
                                    case "等于":
                                        tempStr += "='";
                                        break;
                                    case "大于":
                                        tempStr += ">'";
                                        break;
                                    case "小于":
                                        tempStr += "<'";
                                        break;
                                    case "大于等于":
                                        tempStr += ">='";
                                        break;
                                    case "小于等于":
                                        tempStr += "<='";
                                        break;
                                    case "不等于":
                                        tempStr += "<>'";
                                        break;
                                    case "左包含":
                                        tempStr += " LIKE '%";
                                        break;
                                    case "右包含":
                                        tempStr += " LIKE '";
                                        break;
                                    case "包含":
                                        tempStr += " LIKE '%";
                                        break;
                                }
                                break;
                            case "Decimal":
                                switch (dgv_query.Rows[i].Cells["Compare"].Value.ToString())
                                {
                                    case "等于":
                                        tempStr += "=";
                                        break;
                                    case "大于":
                                        tempStr += ">";
                                        break;
                                    case "小于":
                                        tempStr += "<";
                                        break;
                                    case "大于等于":
                                        tempStr += ">=";
                                        break;
                                    case "小于等于":
                                        tempStr += "<=";
                                        break;
                                    case "不等于":
                                        tempStr += "<>";
                                        break;
                                }
                                break;
                        }
                        tempStr += dgv_query.Rows[i].Cells["Value"].Value.ToString();
                        switch (queryList[tempInt].QueryType)
                        {
                            case "VarChar":
                                switch (dgv_query.Rows[i].Cells["Compare"].Value.ToString())
                                {
                                    case "等于":
                                        tempStr += "'";
                                        break;
                                    case "大于":
                                        tempStr += "'";
                                        break;
                                    case "小于":
                                        tempStr += "'";
                                        break;
                                    case "大于等于":
                                        tempStr += "'";
                                        break;
                                    case "小于等于":
                                        tempStr += "'";
                                        break;
                                    case "不等于":
                                        tempStr += "'";
                                        break;
                                    case "左包含":
                                        tempStr += "'";
                                        break;
                                    case "右包含":
                                        tempStr += "%'";
                                        break;
                                    case "包含":
                                        tempStr += "%'";
                                        break;
                                }
                                break;
                        }
                        tempStr += dgv_query.Rows[i].Cells["Bracket2"].Value.ToString();
                        if (i < dgv_query.Rows.Count - 1)
                        {
                            switch (dgv_query.Rows[i].Cells["Relation"].Value.ToString())
                            {
                                case "并且":
                                    tempStr += " AND ";
                                    break;
                                case "或者":
                                    tempStr += " OR ";
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

        private void cbx_bracket1_DropDownClosed(object sender, EventArgs e)
        {
            if (cbx_bracket1.SelectedIndex > -1 && dgv_query.SelectedCells.Count == 1)
                dgv_query.SelectedCells[0].Value = cbx_bracket1.Text;
            cbx_bracket1.Visible = false;
        }

        private void cbx_field_DropDownClosed(object sender, EventArgs e)
        {
            if (cbx_field.SelectedIndex > -1 && dgv_query.SelectedCells.Count == 1)
                dgv_query.SelectedCells[0].Value = cbx_field.SelectedItem.ToString();
            cbx_field.Visible = false;
            if (dgv_query.Rows[dgv_query.SelectedCells[0].RowIndex].Cells["Compare"].Value.ToString() == "")
                dgv_query.Rows[dgv_query.SelectedCells[0].RowIndex].Cells["Compare"].Value = "等于";
        }

        private void cbx_compare_DropDownClosed(object sender, EventArgs e)
        {
            if (cbx_compare.SelectedIndex > -1 && dgv_query.SelectedCells.Count == 1)
                dgv_query.SelectedCells[0].Value = cbx_compare.Text;
            cbx_compare.Visible = false;
        }

        private void cbx_value_DropDownClosed(object sender, EventArgs e)
        {
            if (cbx_value.SelectedIndex > -1 && dgv_query.SelectedCells.Count == 1)
                dgv_query.SelectedCells[0].Value = cbx_value.Text;
            cbx_value.Visible = false;
        }

        private void cbx_bracket2_DropDownClosed(object sender, EventArgs e)
        {
            if (cbx_bracket2.SelectedIndex > -1 && dgv_query.SelectedCells.Count == 1)
                dgv_query.SelectedCells[0].Value = cbx_bracket2.Text;
            cbx_bracket2.Visible = false;
        }

        private void cbx_relation_DropDownClosed(object sender, EventArgs e)
        {
            if (cbx_relation.SelectedIndex > -1 && dgv_query.SelectedCells.Count == 1)
                dgv_query.SelectedCells[0].Value = cbx_relation.Text;
            cbx_relation.Visible = false;
        }

        private void dgv_query_Click(object sender, EventArgs e)
        {
            cbx_bracket1.Visible = false;
            cbx_field.Visible = false;
            cbx_compare.Visible = false;
            cbx_value.Visible = false;
            cbx_bracket2.Visible = false;
            cbx_relation.Visible = false;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataTable != null && dgv_query.ReadOnly == false)
            {
                for (int i = dgv_query.Rows.Count - 1; i >= 0; i--)
                {
                    if (dgv_query.Rows[i].Selected == true)
                        dgv_query.Rows.Remove(dgv_query.Rows[i]);
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (dgv_query.Rows.Count > 0)
            {
                QueryFileFrm queryFileFrm = new QueryFileFrm();
                if (queryFileFrm.ShowDialog() == DialogResult.OK)
                {
                    string tempStr = "";
                    for (int i = 0; i < dgv_query.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgv_query.Columns.Count; j++)
                        {
                            if (j == 0)
                                tempStr = tempStr + dgv_query.Rows[i].Cells[j].Value.ToString();
                            else
                                tempStr = tempStr + "," + dgv_query.Rows[i].Cells[j].Value.ToString();
                        }
                        if (i < dgv_query.Rows.Count - 1)
                            tempStr += "\r";
                    }
                    System.IO.FileStream stream = new System.IO.FileStream(pathStr + "\\" + queryFileFrm.FileStr, 
                        System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    byte[] tempByte = System.Text.Encoding.Default.GetBytes(tempStr);
                    stream.Write(tempByte, 0, tempByte.Length);
                    stream.Close();
                    lvw_query.Items.Add(queryFileFrm.FileStr);
                }
            }
        }

        private void btn_deleteitem_Click(object sender, EventArgs e)
        {
            if (lvw_query.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("是否删除" + lvw_query.SelectedItems[0].Text, "提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (System.IO.File.Exists(pathStr + "\\" + lvw_query.SelectedItems[0].Text))
                        System.IO.File.Delete(pathStr + "\\" + lvw_query.SelectedItems[0].Text);
                    lvw_query.Items.Remove(lvw_query.SelectedItems[0]);
                }
            }
        }

        private void lvw_query_DoubleClick(object sender, EventArgs e)
        {
            if (lvw_query.SelectedItems.Count == 1)
            {
                dataTable.Rows.Clear();
                System.IO.FileStream stream = new System.IO.FileStream(pathStr + "\\" + lvw_query.SelectedItems[0].Text,
                    System.IO.FileMode.Open, System.IO.FileAccess.Read);
                byte[] tempByte = new byte[stream.Length];
                if (tempByte.Length > 0)
                {
                    stream.Position = 0;
                    stream.Read(tempByte, 0, tempByte.Length);
                    string[] tempRows = System.Text.Encoding.Default.GetString(tempByte).Split('\r');
                    stream.Close();
                    for (int i = 0; i < tempRows.Length; i++)
                    {
                        string[] tempCells = tempRows[i].Split(',');
                        DataRow dataRow = dataTable.NewRow();
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                            dataRow[j] = tempCells[j];
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
        }
    }
}