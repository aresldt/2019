namespace BasicFrame
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.msp_main = new System.Windows.Forms.MenuStrip();
            this.tmi_system = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_user = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_password = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_window = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_hideall = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsp_main = new System.Windows.Forms.ToolStrip();
            this.tsb_tree = new System.Windows.Forms.ToolStripButton();
            this.tsp_1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_password = new System.Windows.Forms.ToolStripButton();
            this.tsb_setup = new System.Windows.Forms.ToolStripButton();
            this.tsp_2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_exit = new System.Windows.Forms.ToolStripButton();
            this.tvw_main = new System.Windows.Forms.TreeView();
            this.ssp_main = new System.Windows.Forms.StatusStrip();
            this.msp_main.SuspendLayout();
            this.tsp_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // msp_main
            // 
            this.msp_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_system,
            this.tmi_user,
            this.tmi_window});
            this.msp_main.Location = new System.Drawing.Point(0, 0);
            this.msp_main.Name = "msp_main";
            this.msp_main.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.msp_main.Size = new System.Drawing.Size(292, 25);
            this.msp_main.TabIndex = 1;
            this.msp_main.Text = "menuStrip1";
            // 
            // tmi_system
            // 
            this.tmi_system.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_exit});
            this.tmi_system.Name = "tmi_system";
            this.tmi_system.Size = new System.Drawing.Size(44, 21);
            this.tmi_system.Text = "系统";
            // 
            // tmi_exit
            // 
            this.tmi_exit.Name = "tmi_exit";
            this.tmi_exit.Size = new System.Drawing.Size(100, 22);
            this.tmi_exit.Text = "退出";
            this.tmi_exit.Click += new System.EventHandler(this.tmi_exit_Click);
            // 
            // tmi_user
            // 
            this.tmi_user.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_password});
            this.tmi_user.Name = "tmi_user";
            this.tmi_user.Size = new System.Drawing.Size(44, 21);
            this.tmi_user.Text = "用户";
            // 
            // tmi_password
            // 
            this.tmi_password.Name = "tmi_password";
            this.tmi_password.Size = new System.Drawing.Size(124, 22);
            this.tmi_password.Text = "更改密码";
            this.tmi_password.Click += new System.EventHandler(this.tmi_password_Click);
            // 
            // tmi_window
            // 
            this.tmi_window.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_hideall,
            this.tmi_separator1});
            this.tmi_window.Name = "tmi_window";
            this.tmi_window.Size = new System.Drawing.Size(44, 21);
            this.tmi_window.Text = "窗口";
            // 
            // tmi_hideall
            // 
            this.tmi_hideall.Name = "tmi_hideall";
            this.tmi_hideall.Size = new System.Drawing.Size(124, 22);
            this.tmi_hideall.Text = "隐藏全部";
            this.tmi_hideall.Click += new System.EventHandler(this.tmi_hideall_Click);
            // 
            // tmi_separator1
            // 
            this.tmi_separator1.Name = "tmi_separator1";
            this.tmi_separator1.Size = new System.Drawing.Size(121, 6);
            // 
            // tsp_main
            // 
            this.tsp_main.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsp_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_tree,
            this.tsp_1,
            this.tsb_password,
            this.tsb_setup,
            this.tsp_2,
            this.tsb_exit});
            this.tsp_main.Location = new System.Drawing.Point(0, 25);
            this.tsp_main.Name = "tsp_main";
            this.tsp_main.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsp_main.Size = new System.Drawing.Size(292, 39);
            this.tsp_main.TabIndex = 2;
            this.tsp_main.Text = "toolStrip1";
            // 
            // tsb_tree
            // 
            this.tsb_tree.Image = ((System.Drawing.Image)(resources.GetObject("tsb_tree.Image")));
            this.tsb_tree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_tree.Name = "tsb_tree";
            this.tsb_tree.Size = new System.Drawing.Size(68, 36);
            this.tsb_tree.Text = "隐藏";
            this.tsb_tree.Click += new System.EventHandler(this.tsb_tree_Click);
            // 
            // tsp_1
            // 
            this.tsp_1.Name = "tsp_1";
            this.tsp_1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsb_password
            // 
            this.tsb_password.Image = ((System.Drawing.Image)(resources.GetObject("tsb_password.Image")));
            this.tsb_password.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_password.Name = "tsb_password";
            this.tsb_password.Size = new System.Drawing.Size(92, 36);
            this.tsb_password.Text = "更改密码";
            this.tsb_password.Click += new System.EventHandler(this.tsb_password_Click);
            // 
            // tsb_setup
            // 
            this.tsb_setup.Image = ((System.Drawing.Image)(resources.GetObject("tsb_setup.Image")));
            this.tsb_setup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_setup.Name = "tsb_setup";
            this.tsb_setup.Size = new System.Drawing.Size(92, 36);
            this.tsb_setup.Text = "系统设置";
            this.tsb_setup.Click += new System.EventHandler(this.tsb_setup_Click);
            // 
            // tsp_2
            // 
            this.tsp_2.Name = "tsp_2";
            this.tsp_2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsb_exit
            // 
            this.tsb_exit.Image = ((System.Drawing.Image)(resources.GetObject("tsb_exit.Image")));
            this.tsb_exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_exit.Name = "tsb_exit";
            this.tsb_exit.Size = new System.Drawing.Size(68, 36);
            this.tsb_exit.Text = "退出";
            this.tsb_exit.Click += new System.EventHandler(this.tsb_exit_Click);
            // 
            // tvw_main
            // 
            this.tvw_main.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvw_main.Location = new System.Drawing.Point(0, 64);
            this.tvw_main.Name = "tvw_main";
            this.tvw_main.Size = new System.Drawing.Size(201, 180);
            this.tvw_main.TabIndex = 3;
            this.tvw_main.DoubleClick += new System.EventHandler(this.tvw_main_DoubleClick);
            this.tvw_main.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvw_main_AfterSelect);
            // 
            // ssp_main
            // 
            this.ssp_main.Location = new System.Drawing.Point(0, 244);
            this.ssp_main.Name = "ssp_main";
            this.ssp_main.Size = new System.Drawing.Size(292, 22);
            this.ssp_main.TabIndex = 5;
            this.ssp_main.Text = "statusStrip1";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.tvw_main);
            this.Controls.Add(this.ssp_main);
            this.Controls.Add(this.tsp_main);
            this.Controls.Add(this.msp_main);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msp_main;
            this.Name = "MainFrm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrm_FormClosed);
            this.MdiChildActivate += new System.EventHandler(this.MainFrm_MdiChildActivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.msp_main.ResumeLayout(false);
            this.msp_main.PerformLayout();
            this.tsp_main.ResumeLayout(false);
            this.tsp_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msp_main;
        private System.Windows.Forms.ToolStripMenuItem tmi_system;
        private System.Windows.Forms.ToolStripMenuItem tmi_exit;
        private System.Windows.Forms.ToolStrip tsp_main;
        private System.Windows.Forms.TreeView tvw_main;
        private System.Windows.Forms.ToolStripButton tsb_tree;
        private System.Windows.Forms.ToolStripSeparator tsp_1;
        private System.Windows.Forms.ToolStripButton tsb_exit;
        private System.Windows.Forms.StatusStrip ssp_main;
        private System.Windows.Forms.ToolStripSeparator tsp_2;
        private System.Windows.Forms.ToolStripMenuItem tmi_window;
        private System.Windows.Forms.ToolStripMenuItem tmi_hideall;
        private System.Windows.Forms.ToolStripSeparator tmi_separator1;
        private System.Windows.Forms.ToolStripButton tsb_password;
        private System.Windows.Forms.ToolStripMenuItem tmi_user;
        private System.Windows.Forms.ToolStripMenuItem tmi_password;
        private System.Windows.Forms.ToolStripButton tsb_setup;
    }
}

