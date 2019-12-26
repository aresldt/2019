namespace BasicFrame
{
    partial class SetupFrm
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
            this.btn_ok = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpg_user = new System.Windows.Forms.TabPage();
            this.cbb_querywindow = new System.Windows.Forms.ComboBox();
            this.lbl_querywindow = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpg_user.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(117, 235);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpg_user);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(260, 217);
            this.tabControl1.TabIndex = 3;
            // 
            // tpg_user
            // 
            this.tpg_user.Controls.Add(this.cbb_querywindow);
            this.tpg_user.Controls.Add(this.lbl_querywindow);
            this.tpg_user.Location = new System.Drawing.Point(4, 22);
            this.tpg_user.Name = "tpg_user";
            this.tpg_user.Padding = new System.Windows.Forms.Padding(3);
            this.tpg_user.Size = new System.Drawing.Size(252, 191);
            this.tpg_user.TabIndex = 0;
            this.tpg_user.Text = "用户设置";
            this.tpg_user.UseVisualStyleBackColor = true;
            // 
            // cbb_querywindow
            // 
            this.cbb_querywindow.FormattingEnabled = true;
            this.cbb_querywindow.Items.AddRange(new object[] {
            "简单",
            "复杂"});
            this.cbb_querywindow.Location = new System.Drawing.Point(101, 17);
            this.cbb_querywindow.Name = "cbb_querywindow";
            this.cbb_querywindow.Size = new System.Drawing.Size(121, 20);
            this.cbb_querywindow.TabIndex = 3;
            // 
            // lbl_querywindow
            // 
            this.lbl_querywindow.AutoSize = true;
            this.lbl_querywindow.Location = new System.Drawing.Point(20, 20);
            this.lbl_querywindow.Name = "lbl_querywindow";
            this.lbl_querywindow.Size = new System.Drawing.Size(53, 12);
            this.lbl_querywindow.TabIndex = 2;
            this.lbl_querywindow.Text = "查询类型";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(197, 235);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // SetupFrm
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_ok);
            this.MaximizeBox = false;
            this.Name = "SetupFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.SetupFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpg_user.ResumeLayout(false);
            this.tpg_user.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpg_user;
        private System.Windows.Forms.ComboBox cbb_querywindow;
        private System.Windows.Forms.Label lbl_querywindow;
        private System.Windows.Forms.Button btn_cancel;
    }
}