using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using BaseService;

namespace MdiChild
{
    public partial class DataChildFrm : MdiChildFrm
    {
        private Panel pnl_control;
        private DataGridView dgv_data;

        private bool formLoad = true;
        private DataAccess.DataRight dataRight;
        protected DataTable dataTable = null;
        private int primaryCount = 0;
        private List<Field_Struct> fieldsList;
        private string selectSql = "";
        private string insertSql = "";
        private string updateSql = "";
        private string deleteSql = "";

        public DataChildFrm()
        {
            InitializeComponent();

            dataRight = new DataAccess.DataRight();
        }

        private Control GetFormControl(Control aControl, string aName)
        {
            if (aControl != null)
            {
                for (int i = 0; i < aControl.Controls.Count; i++)
                {
                    if (aControl.Controls[i].Name.ToUpper() == aName.ToUpper())
                    {
                        return aControl.Controls[i];
                    }
                    else
                    {
                        if (aControl.Controls[i].Controls.Count > 0)
                        {
                            Control control = GetFormControl(aControl.Controls[i], aName);
                            if (control != null)
                                return control;
                        }
                    }
                }
            }
            return null;
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            bool tempField = false;
            if ((sender as Control).Tag != null && (sender as Control).Tag is Field_Struct)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    if (dataTable.Columns[i].ColumnName == ((sender as Control).Tag as Field_Struct).FieldName)
                    {
                        tempField = true;
                        break;
                    }
                }
            }
            if (tempField == true)
            {
                switch (((sender as Control).Tag as Field_Struct).FieldType.ToUpper())
                {
                    case "INT":
                        int tempInt = 0;
                        if (int.TryParse((sender as Control).Text.Trim(), out tempInt) == true)
                        {
                            dataTable.Columns[((sender as Control).Tag as Field_Struct).FieldName].DefaultValue =
                                tempInt;
                            if (formLoad == false)
                            {
                                for (int i = 0; i < dataTable.Rows.Count; i++)
                                    if (dataTable.Rows[i].RowState != DataRowState.Deleted)
                                        dataTable.Rows[i][((sender as Control).Tag as Field_Struct).FieldName] =
                                            tempInt;
                            }
                        }
                        else
                        {
                            dataTable.Columns[((sender as Control).Tag as Field_Struct).FieldName].DefaultValue = 0;
                            if (formLoad == false)
                            {
                                for (int i = 0; i < dataTable.Rows.Count; i++)
                                    if (dataTable.Rows[i].RowState != DataRowState.Deleted)
                                        dataTable.Rows[i][((sender as Control).Tag as Field_Struct).FieldName] = 0;
                            }
                        }
                        break;
                    case "DECIMAL":
                        decimal tempDecimal = 0;
                        if (decimal.TryParse((sender as Control).Text.Trim(), out tempDecimal) == true)
                        {
                            dataTable.Columns[((sender as Control).Tag as Field_Struct).FieldName].DefaultValue =
                                tempDecimal;
                            if (formLoad == false)
                            {
                                for (int i = 0; i < dataTable.Rows.Count; i++)
                                    if (dataTable.Rows[i].RowState != DataRowState.Deleted)
                                        dataTable.Rows[i][((sender as Control).Tag as Field_Struct).FieldName] =
                                            tempDecimal;
                            }
                        }
                        else
                        {
                            dataTable.Columns[((sender as Control).Tag as Field_Struct).FieldName].DefaultValue = 0;
                            if (formLoad == false)
                            {
                                for (int i = 0; i < dataTable.Rows.Count; i++)
                                    if (dataTable.Rows[i].RowState != DataRowState.Deleted)
                                        dataTable.Rows[i][((sender as Control).Tag as Field_Struct).FieldName] = 0;
                            }
                        }
                        break;
                    default:
                        dataTable.Columns[((sender as Control).Tag as Field_Struct).FieldName].DefaultValue =
                            (sender as Control).Text;
                        if (formLoad == false)
                        {
                            for (int i = 0; i < dataTable.Rows.Count; i++)
                                if (dataTable.Rows[i].RowState != DataRowState.Deleted)
                                    dataTable.Rows[i][((sender as Control).Tag as Field_Struct).FieldName] =
                                      (sender as Control).Text;
                        }
                        break;
                }
            }
        }

        protected bool InitDataTable(Panel aPanel, DataGridView aDataGridView, XmlDocument aXmlDoc, 
            string aDataWhere, List<string> aReplaceString, int aPrimaryCount)
        {
            try
            {
                pnl_control = aPanel;
                dgv_data = aDataGridView;

                dataTable = new DataTable();
                primaryCount = aPrimaryCount;
                fieldsList = new List<Field_Struct>();

                XmlNodeList xmlNodeList = aXmlDoc.ChildNodes[1].ChildNodes[0].ChildNodes;
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    #region 实例化

                    Field_Struct fieldInstance = new Field_Struct();
                    for (int j = 0; j < xmlNodeList[i].Attributes.Count; j++)
                    {
                        switch (xmlNodeList[i].Attributes[j].Name.Trim().ToUpper())
                        {
                            case "NAME":
                                fieldInstance.FieldName = xmlNodeList[i].Attributes[j].Value.Trim();
                                break;
                            case "TYPE":
                                fieldInstance.FieldType = xmlNodeList[i].Attributes[j].Value.Trim();
                                break;
                            case "SIZE":
                                int tempSize = 0;
                                if (int.TryParse(xmlNodeList[i].Attributes[j].Value.Trim(), out tempSize) == true)
                                    fieldInstance.FieldSize = tempSize;
                                break;
                            case "PRECISION":
                                byte tempPrecision = 0;
                                if (byte.TryParse(xmlNodeList[i].Attributes[j].Value.Trim(), out tempPrecision) == true)
                                    fieldInstance.FieldPrecision = tempPrecision;
                                break;
                            case "SCALE":
                                byte tempScale = 0;
                                if (byte.TryParse(xmlNodeList[i].Attributes[j].Value.Trim(), out tempScale) == true)
                                    fieldInstance.FieldScale = tempScale;
                                break;
                            case "PRIMARYKEY":
                                int tempPrimaryKey = 0;
                                if (int.TryParse(xmlNodeList[i].Attributes[j].Value.Trim(), out tempPrimaryKey) == true)
                                    fieldInstance.FieldPrimaryKey = (tempPrimaryKey == 1);
                                break;
                            case "COLUMNTEXT":
                                fieldInstance.GridColumnText = xmlNodeList[i].Attributes[j].Value.Trim();
                                break;
                            case "COLUMNWIDTH":
                                int tempColumnWidth = 0;
                                if (int.TryParse(xmlNodeList[i].Attributes[j].Value.Trim(), out tempColumnWidth) == true)
                                    fieldInstance.GridColumnWidth = tempColumnWidth;
                                break;
                            case "COLUMNVISIBLE":
                                int tempGridVisible = 0;
                                if (int.TryParse(xmlNodeList[i].Attributes[j].Value.Trim(), out tempGridVisible) == true)
                                    fieldInstance.GridColumnVisible = (tempGridVisible == 1);
                                break;
                            case "COLUMNSORT":
                                int tempGridSort = 0;
                                if (int.TryParse(xmlNodeList[i].Attributes[j].Value.Trim(), out tempGridSort) == true)
                                    fieldInstance.GridColumnSort = (tempGridSort == 1);
                                break;
                            case "COLUMNDEFAULT":
                                fieldInstance.GridColumnDefault = xmlNodeList[i].Attributes[j].Value.Trim();
                                break;
                            case "READONLY":
                                int tempReadOnly = 0;
                                if (int.TryParse(xmlNodeList[i].Attributes[j].Value.Trim(), out tempReadOnly) == true)
                                    fieldInstance.GridReadOnly = (tempReadOnly == 1);
                                break;
                            case "AUTOINCREMENT":
                                int tempAutoIncrement = 0;
                                if (int.TryParse(xmlNodeList[i].Attributes[j].Value.Trim(), out tempAutoIncrement) == true)
                                    fieldInstance.GridAutoIncrement = (tempAutoIncrement == 1);
                                break;
                            case "INCREMENTSEED":
                                int tempIncrementSeed = 0;
                                if (int.TryParse(xmlNodeList[i].Attributes[j].Value.Trim(), out tempIncrementSeed) == true)
                                    fieldInstance.GridIncrementSeed = tempIncrementSeed;
                                break;
                            case "INCREMENTSTEP":
                                int tempIncrementStep = 0;
                                if (int.TryParse(xmlNodeList[i].Attributes[j].Value.Trim(), out tempIncrementStep) == true)
                                    fieldInstance.GridIncrementStep = tempIncrementStep;
                                break;
                            case "SQLINSERT":
                                int tempSqlInsert = 0;
                                if (int.TryParse(xmlNodeList[i].Attributes[j].Value.Trim(), out tempSqlInsert) == true)
                                    fieldInstance.SqlInsert = (tempSqlInsert == 1);
                                break;
                            case "SQLUPDATE":
                                int tempSqlUpdate = 0;
                                if (int.TryParse(xmlNodeList[i].Attributes[j].Value.Trim(), out tempSqlUpdate) == true)
                                    fieldInstance.SqlUpdate = (tempSqlUpdate == 1);
                                break;
                            case "CONTROLCHANGE":
                                int tempControlChnage = 0;
                                if (int.TryParse(xmlNodeList[i].Attributes[j].Value.Trim(), out tempControlChnage) == true)
                                    fieldInstance.ControlChange = (tempControlChnage == 1);
                                break;
                        }
                    }

                    #endregion

                    fieldsList.Add(fieldInstance);
                }

                xmlNodeList = aXmlDoc.ChildNodes[1].ChildNodes[1].ChildNodes;
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    #region SQL

                    switch (xmlNodeList[i].Name.ToUpper())
                    {
                        case "SELECT":
                            selectSql = xmlNodeList[i].InnerText.Replace("#TABLE", BaseService.BaseService.LibraryName).Replace(
                                "#SMG", BaseService.BaseService.SmgDatabase);
                            break;
                        case "INSERT":
                            insertSql = xmlNodeList[i].InnerText.Replace("#TABLE", BaseService.BaseService.LibraryName).Replace(
                                "#SMG", BaseService.BaseService.SmgDatabase);
                            break;
                        case "UPDATE":
                            updateSql = xmlNodeList[i].InnerText.Replace("#TABLE", BaseService.BaseService.LibraryName).Replace(
                                "#SMG", BaseService.BaseService.SmgDatabase);
                            break;
                        case "DELETE":
                            deleteSql = xmlNodeList[i].InnerText.Replace("#TABLE", BaseService.BaseService.LibraryName).Replace(
                                "#SMG", BaseService.BaseService.SmgDatabase);
                            break;
                    }

                    #endregion
                }

                #region 数据表

                for (int i = 0; i < aReplaceString.Count; i=i+2)
                    selectSql = selectSql.Replace(aReplaceString[i], aReplaceString[i + 1]);
                dataTable = dataRight.FillChildTable(selectSql + aDataWhere);
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    for (int j = 0; j < fieldsList.Count; j++)
                    {
                        if (dataTable.Columns[i].ColumnName.Trim().ToUpper() == fieldsList[j].FieldName.ToUpper())
                        {
                            if (fieldsList[j].GridColumnDefault != "")
                                dataTable.Columns[i].DefaultValue = fieldsList[j].GridColumnDefault;
                            if (fieldsList[j].GridAutoIncrement == true)
                            {
                                dataTable.Columns[i].AutoIncrement = true;
                                int maxValue = 0;
                                for (int k = 0; k < dataTable.Rows.Count; k++)
                                    if (System.Convert.ToInt32(dataTable.Rows[k][fieldsList[j].FieldName].ToString()) > maxValue)
                                        maxValue = System.Convert.ToInt32(dataTable.Rows[k][fieldsList[j].FieldName].ToString());
                                dataTable.Columns[i].AutoIncrementSeed = (maxValue + 1 > fieldsList[j].GridIncrementSeed ?
                                    maxValue + 1 : fieldsList[j].GridIncrementSeed);
                                dataTable.Columns[i].AutoIncrementStep = fieldsList[j].GridIncrementStep;
                            }
                            break;
                        }
                    }
                }
                Control control = null;
                for (int i = 0; i < fieldsList.Count; i++)
                {
                    control = GetFormControl(pnl_control, "tbx_" + fieldsList[i].FieldName);
                    if (control == null)
                        control = GetFormControl(pnl_control, "cbx_" + fieldsList[i].FieldName);
                    if (control != null)
                    {
                        control.Tag = fieldsList[i];
                        if (fieldsList[i].ControlChange == true)
                        {
                            switch (control.GetType().Name)
                            {
                                case "TextBox":
                                    ((TextBox)control).TextChanged += new System.EventHandler(this.TextBoxTextChanged);
                                    break;
                                case "ComboBox":
                                    ((ComboBox)control).SelectedIndexChanged += new System.EventHandler(this.TextBoxTextChanged);
                                    ((ComboBox)control).TextUpdate += new System.EventHandler(this.TextBoxTextChanged);
                                    break;
                            }
                        }
                        if (dataTable.Rows.Count <= 0)
                            control.Text = fieldsList[i].GridColumnDefault;
                        else
                            control.Text = dataTable.Rows[0][fieldsList[i].FieldName].ToString().Trim();
                    }
                }

                #endregion

                dgv_data.DataSource = dataTable;
                for (int i = 0; i < fieldsList.Count; i++)
                {
                    dgv_data.Columns[fieldsList[i].FieldName].HeaderText = fieldsList[i].GridColumnText;
                    dgv_data.Columns[fieldsList[i].FieldName].Width = fieldsList[i].GridColumnWidth;
                    dgv_data.Columns[fieldsList[i].FieldName].Visible = fieldsList[i].GridColumnVisible;
                    if (fieldsList[i].GridColumnSort == true)
                        dgv_data.Columns[fieldsList[i].FieldName].SortMode = DataGridViewColumnSortMode.Automatic;
                    else
                        dgv_data.Columns[fieldsList[i].FieldName].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgv_data.Columns[fieldsList[i].FieldName].ReadOnly = fieldsList[i].GridReadOnly;
                }

                formLoad = false;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误！" + ex.Message);
                return false;
            }
        }

        private bool VerifyFormControl(Control aControl)
        {
            if (aControl != null)
            {
                for (int i = 0; i < aControl.Controls.Count; i++)
                {
                    int tempInt = 0;
                    decimal tempDecimal = 0;
                    if (aControl.Controls[i].Tag != null && aControl.Controls[i].Tag is Field_Struct &&
                        (((aControl.Controls[i].Tag as Field_Struct).FieldType.ToUpper() == "INT" &&
                        int.TryParse(aControl.Controls[i].Text.Trim(), out tempInt) == false) ||
                        ((aControl.Controls[i].Tag as Field_Struct).FieldType.ToUpper() == "DECIMAL" &&
                        decimal.TryParse(aControl.Controls[i].Text.Trim(), out tempDecimal) == false)))
                    {
                        MessageBox.Show((aControl.Controls[i].Tag as Field_Struct).GridColumnText + "，数据格式错误！");
                        return false;
                    }
                    else if (aControl.Controls[i].Controls.Count > 0)
                    {
                        return VerifyFormControl(aControl.Controls[i]);
                    }
                }
            }
            return true;
        }

        protected bool SaveData()
        {
            try
            {
                if (VerifyFormControl(pnl_control) == true)
                {
                    if (dataRight.UpdateChildTable(insertSql, updateSql, deleteSql, fieldsList, dataTable, primaryCount) == true)
                    {
                        dataTable.AcceptChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误！" + ex.Message);
                return false;
            }
        }

        protected virtual bool WindowClosing()
        {
            return false;
        }
        
        private void DataChildFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataTable != null)
            {
                bool tempBool = false;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (dataTable.Rows[i].RowState != DataRowState.Unchanged)
                    {
                        tempBool = true;
                        break;
                    }
                }
                if (tempBool == true)
                {
                    DialogResult tempDialogResult = MessageBox.Show("是否保存已修改的数据？", "提示", MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                    switch (tempDialogResult)
                    {
                        case DialogResult.Yes:
                            if (WindowClosing() == true)
                                SaveData();
                            else
                                e.Cancel = true;
                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                    }
                }
            }
        }

        protected void FindText(string aText)
        {
            if (dgv_data != null && dgv_data.DataSource != null)
            {
                dgv_data.ClearSelection();
                int n = 0;
                int tempInt = -1;
                for (int i = 0; i < dgv_data.RowCount; i++)
                {
                    for (int j = 0; j < dgv_data.ColumnCount; j++)
                    {
                        if (dgv_data.Columns[j].Visible == true)
                        {
                            if (dgv_data.Rows[i].Cells[j].Value.ToString().Trim().IndexOf(aText) > -1)
                            {
                                dgv_data.Rows[i].Cells[j].Selected = true;
                                n++;
                                if (tempInt == -1)
                                {
                                    tempInt = i;
                                    dgv_data.CurrentCell = dgv_data.Rows[i].Cells[j];
                                }
                            }
                        }
                    }
                }
                if (n > 0 && tempInt != -1)
                {
                    MessageBox.Show("共找到" + n.ToString() + "条记录。");
                }
                else
                {
                    MessageBox.Show("没有找到记录！");
                }
            }
        }

        protected void CopyText()
        {
            if (dgv_data != null && dgv_data.DataSource != null)
                Clipboard.SetText(dgv_data.GetClipboardContent().GetData(DataFormats.UnicodeText).ToString());
        }

        protected void ExportExcel()
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

            for (int i = 0; i < dgv_data.Columns.Count; i++)
                (m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[1, i + 1] = dgv_data.Columns[i].HeaderText;
            for (int i = 0; i < dgv_data.Rows.Count; i++)
            {
                for (int j = 0; j < dgv_data.Columns.Count; j++)
                {
                    (m_objExcel.ActiveSheet as Microsoft.Office.Interop.Excel._Worksheet).Cells[i + 2, j + 1] =
                        dgv_data.Rows[i].Cells[j].Value.ToString().Trim();
                }
            }

            MessageBox.Show("导出成功。");
        }
    }
}