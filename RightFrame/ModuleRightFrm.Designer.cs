namespace Right
{
    partial class ModuleRightFrm
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
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lvw_right = new System.Windows.Forms.ListView();
            this.chd_check = new System.Windows.Forms.ColumnHeader();
            this.chd_name = new System.Windows.Forms.ColumnHeader();
            this.chd_text = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(194, 265);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(275, 265);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lvw_right
            // 
            this.lvw_right.CheckBoxes = true;
            this.lvw_right.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chd_check,
            this.chd_name,
            this.chd_text});
            this.lvw_right.FullRowSelect = true;
            this.lvw_right.HideSelection = false;
            this.lvw_right.Location = new System.Drawing.Point(8, 8);
            this.lvw_right.Name = "lvw_right";
            this.lvw_right.Size = new System.Drawing.Size(342, 253);
            this.lvw_right.TabIndex = 8;
            this.lvw_right.UseCompatibleStateImageBehavior = false;
            this.lvw_right.View = System.Windows.Forms.View.Details;
            // 
            // chd_check
            // 
            this.chd_check.Text = "";
            this.chd_check.Width = 20;
            // 
            // chd_name
            // 
            this.chd_name.Text = "程序名称";
            this.chd_name.Width = 150;
            // 
            // chd_text
            // 
            this.chd_text.Text = "显示名称";
            this.chd_text.Width = 150;
            // 
            // ModuleRightFrm
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(358, 294);
            this.Controls.Add(this.lvw_right);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModuleRightFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块权限";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ListView lvw_right;
        private System.Windows.Forms.ColumnHeader chd_check;
        private System.Windows.Forms.ColumnHeader chd_name;
        private System.Windows.Forms.ColumnHeader chd_text;
    }
}