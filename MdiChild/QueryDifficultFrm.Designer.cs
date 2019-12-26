namespace MdiChild
{
    partial class QueryDifficultFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_query = new System.Windows.Forms.DataGridView();
            this.lvw_query = new System.Windows.Forms.ListView();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.cbx_field = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.cbx_compare = new System.Windows.Forms.ComboBox();
            this.cbx_value = new System.Windows.Forms.ComboBox();
            this.cbx_bracket1 = new System.Windows.Forms.ComboBox();
            this.cbx_bracket2 = new System.Windows.Forms.ComboBox();
            this.cbx_relation = new System.Windows.Forms.ComboBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_deleteitem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_query)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_query
            // 
            this.dgv_query.AllowUserToAddRows = false;
            this.dgv_query.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_query.Location = new System.Drawing.Point(104, 12);
            this.dgv_query.MultiSelect = false;
            this.dgv_query.Name = "dgv_query";
            this.dgv_query.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_query.RowTemplate.Height = 21;
            this.dgv_query.Size = new System.Drawing.Size(422, 305);
            this.dgv_query.TabIndex = 0;
            this.dgv_query.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_query_CellClick);
            this.dgv_query.Click += new System.EventHandler(this.dgv_query_Click);
            // 
            // lvw_query
            // 
            this.lvw_query.HideSelection = false;
            this.lvw_query.Location = new System.Drawing.Point(12, 12);
            this.lvw_query.MultiSelect = false;
            this.lvw_query.Name = "lvw_query";
            this.lvw_query.Size = new System.Drawing.Size(86, 305);
            this.lvw_query.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvw_query.TabIndex = 1;
            this.lvw_query.UseCompatibleStateImageBehavior = false;
            this.lvw_query.DoubleClick += new System.EventHandler(this.lvw_query_DoubleClick);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(371, 323);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(452, 323);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // cbx_field
            // 
            this.cbx_field.FormattingEnabled = true;
            this.cbx_field.Location = new System.Drawing.Point(12, 38);
            this.cbx_field.Name = "cbx_field";
            this.cbx_field.Size = new System.Drawing.Size(86, 20);
            this.cbx_field.TabIndex = 4;
            this.cbx_field.Visible = false;
            this.cbx_field.DropDownClosed += new System.EventHandler(this.cbx_field_DropDownClosed);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(178, 323);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(65, 23);
            this.btn_add.TabIndex = 5;
            this.btn_add.Text = "添加条件";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // cbx_compare
            // 
            this.cbx_compare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_compare.FormattingEnabled = true;
            this.cbx_compare.Items.AddRange(new object[] {
            "",
            "等于",
            "大于",
            "小于",
            "小于等于",
            "大于等于",
            "不等于",
            "左包含",
            "右包含",
            "包含"});
            this.cbx_compare.Location = new System.Drawing.Point(12, 64);
            this.cbx_compare.Name = "cbx_compare";
            this.cbx_compare.Size = new System.Drawing.Size(86, 20);
            this.cbx_compare.TabIndex = 6;
            this.cbx_compare.Visible = false;
            this.cbx_compare.DropDownClosed += new System.EventHandler(this.cbx_compare_DropDownClosed);
            // 
            // cbx_value
            // 
            this.cbx_value.FormattingEnabled = true;
            this.cbx_value.Location = new System.Drawing.Point(12, 90);
            this.cbx_value.Name = "cbx_value";
            this.cbx_value.Size = new System.Drawing.Size(86, 20);
            this.cbx_value.TabIndex = 7;
            this.cbx_value.Visible = false;
            this.cbx_value.DropDownClosed += new System.EventHandler(this.cbx_value_DropDownClosed);
            // 
            // cbx_bracket1
            // 
            this.cbx_bracket1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_bracket1.FormattingEnabled = true;
            this.cbx_bracket1.Items.AddRange(new object[] {
            "",
            "(",
            "((",
            "(((",
            "((((",
            "((((("});
            this.cbx_bracket1.Location = new System.Drawing.Point(12, 12);
            this.cbx_bracket1.Name = "cbx_bracket1";
            this.cbx_bracket1.Size = new System.Drawing.Size(86, 20);
            this.cbx_bracket1.TabIndex = 8;
            this.cbx_bracket1.Visible = false;
            this.cbx_bracket1.DropDownClosed += new System.EventHandler(this.cbx_bracket1_DropDownClosed);
            // 
            // cbx_bracket2
            // 
            this.cbx_bracket2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_bracket2.FormattingEnabled = true;
            this.cbx_bracket2.Items.AddRange(new object[] {
            "",
            ")",
            "))",
            ")))",
            "))))",
            ")))))"});
            this.cbx_bracket2.Location = new System.Drawing.Point(12, 116);
            this.cbx_bracket2.Name = "cbx_bracket2";
            this.cbx_bracket2.Size = new System.Drawing.Size(86, 20);
            this.cbx_bracket2.TabIndex = 9;
            this.cbx_bracket2.Visible = false;
            this.cbx_bracket2.DropDownClosed += new System.EventHandler(this.cbx_bracket2_DropDownClosed);
            // 
            // cbx_relation
            // 
            this.cbx_relation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_relation.FormattingEnabled = true;
            this.cbx_relation.Items.AddRange(new object[] {
            "",
            "并且",
            "或者"});
            this.cbx_relation.Location = new System.Drawing.Point(12, 142);
            this.cbx_relation.Name = "cbx_relation";
            this.cbx_relation.Size = new System.Drawing.Size(86, 20);
            this.cbx_relation.TabIndex = 10;
            this.cbx_relation.Visible = false;
            this.cbx_relation.DropDownClosed += new System.EventHandler(this.cbx_relation_DropDownClosed);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(249, 323);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(65, 23);
            this.btn_delete.TabIndex = 11;
            this.btn_delete.Text = "删除条件";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(107, 323);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(65, 23);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "保存查询";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_deleteitem
            // 
            this.btn_deleteitem.Location = new System.Drawing.Point(11, 323);
            this.btn_deleteitem.Name = "btn_deleteitem";
            this.btn_deleteitem.Size = new System.Drawing.Size(65, 23);
            this.btn_deleteitem.TabIndex = 13;
            this.btn_deleteitem.Text = "删除查询";
            this.btn_deleteitem.UseVisualStyleBackColor = true;
            this.btn_deleteitem.Click += new System.EventHandler(this.btn_deleteitem_Click);
            // 
            // DataQueryFrm
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(539, 358);
            this.Controls.Add(this.btn_deleteitem);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.cbx_relation);
            this.Controls.Add(this.cbx_bracket2);
            this.Controls.Add(this.cbx_bracket1);
            this.Controls.Add(this.cbx_value);
            this.Controls.Add(this.cbx_compare);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.cbx_field);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lvw_query);
            this.Controls.Add(this.dgv_query);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DataQueryFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_query)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_query;
        private System.Windows.Forms.ListView lvw_query;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ComboBox cbx_field;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ComboBox cbx_compare;
        private System.Windows.Forms.ComboBox cbx_value;
        private System.Windows.Forms.ComboBox cbx_bracket1;
        private System.Windows.Forms.ComboBox cbx_bracket2;
        private System.Windows.Forms.ComboBox cbx_relation;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_deleteitem;
    }
}