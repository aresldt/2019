namespace Right
{
    partial class RightFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RightFrm));
            this.tsp_user = new System.Windows.Forms.ToolStrip();
            this.tsb_refreshuser = new System.Windows.Forms.ToolStripButton();
            this.tss_1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_adduser = new System.Windows.Forms.ToolStripButton();
            this.tsb_copyuser = new System.Windows.Forms.ToolStripButton();
            this.tsb_saveuser = new System.Windows.Forms.ToolStripButton();
            this.tsb_deleteuser = new System.Windows.Forms.ToolStripButton();
            this.tss_2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_userright = new System.Windows.Forms.ToolStripButton();
            this.tsb_refreshmodule = new System.Windows.Forms.ToolStripButton();
            this.tss_3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_addmodule = new System.Windows.Forms.ToolStripButton();
            this.tsb_savemodule = new System.Windows.Forms.ToolStripButton();
            this.tsb_deletemodule = new System.Windows.Forms.ToolStripButton();
            this.tpg_module = new System.Windows.Forms.TabPage();
            this.scn_module = new System.Windows.Forms.SplitContainer();
            this.tlp_module = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_module = new System.Windows.Forms.Panel();
            this.lbl_modulename = new System.Windows.Forms.Label();
            this.tbx_modulename = new System.Windows.Forms.TextBox();
            this.lbl_namespace = new System.Windows.Forms.Label();
            this.tbx_namespace = new System.Windows.Forms.TextBox();
            this.lbl_classname = new System.Windows.Forms.Label();
            this.tbx_classname = new System.Windows.Forms.TextBox();
            this.lbl_moduletype = new System.Windows.Forms.Label();
            this.cbb_moduletype = new System.Windows.Forms.ComboBox();
            this.lbl_moduletext = new System.Windows.Forms.Label();
            this.tbx_moduletext = new System.Windows.Forms.TextBox();
            this.lbl_bubb = new System.Windows.Forms.Label();
            this.tbx_bubb = new System.Windows.Forms.TextBox();
            this.rbn_samelevel = new System.Windows.Forms.RadioButton();
            this.rbn_nextlevel = new System.Windows.Forms.RadioButton();
            this.lbl_id = new System.Windows.Forms.Label();
            this.tbx_id = new System.Windows.Forms.TextBox();
            this.tvw_module = new System.Windows.Forms.TreeView();
            this.tpg_user = new System.Windows.Forms.TabPage();
            this.scn_user = new System.Windows.Forms.SplitContainer();
            this.tlp_user = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_user = new System.Windows.Forms.Panel();
            this.lbl_user = new System.Windows.Forms.Label();
            this.tbx_user = new System.Windows.Forms.TextBox();
            this.lbl_department = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.lbl_usertext = new System.Windows.Forms.Label();
            this.tbx_usertext = new System.Windows.Forms.TextBox();
            this.lbl_type = new System.Windows.Forms.Label();
            this.cbb_usertype = new System.Windows.Forms.ComboBox();
            this.cbb_department = new System.Windows.Forms.ComboBox();
            this.cbx_used = new System.Windows.Forms.CheckBox();
            this.tvw_user = new System.Windows.Forms.TreeView();
            this.tcl_right = new System.Windows.Forms.TabControl();
            this.tsp_user.SuspendLayout();
            this.tpg_module.SuspendLayout();
            this.scn_module.Panel1.SuspendLayout();
            this.scn_module.Panel2.SuspendLayout();
            this.scn_module.SuspendLayout();
            this.tlp_module.SuspendLayout();
            this.pnl_module.SuspendLayout();
            this.tpg_user.SuspendLayout();
            this.scn_user.Panel1.SuspendLayout();
            this.scn_user.Panel2.SuspendLayout();
            this.scn_user.SuspendLayout();
            this.tlp_user.SuspendLayout();
            this.pnl_user.SuspendLayout();
            this.tcl_right.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsp_user
            // 
            this.tsp_user.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_refreshuser,
            this.tss_1,
            this.tsb_adduser,
            this.tsb_copyuser,
            this.tsb_saveuser,
            this.tsb_deleteuser,
            this.tss_2,
            this.tsb_userright,
            this.tsb_refreshmodule,
            this.tss_3,
            this.tsb_addmodule,
            this.tsb_savemodule,
            this.tsb_deletemodule});
            this.tsp_user.Location = new System.Drawing.Point(0, 0);
            this.tsp_user.Name = "tsp_user";
            this.tsp_user.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsp_user.Size = new System.Drawing.Size(892, 25);
            this.tsp_user.TabIndex = 0;
            this.tsp_user.Text = "toolStrip1";
            // 
            // tsb_refreshuser
            // 
            this.tsb_refreshuser.Image = ((System.Drawing.Image)(resources.GetObject("tsb_refreshuser.Image")));
            this.tsb_refreshuser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_refreshuser.Name = "tsb_refreshuser";
            this.tsb_refreshuser.Size = new System.Drawing.Size(76, 22);
            this.tsb_refreshuser.Text = "刷新用户";
            this.tsb_refreshuser.Click += new System.EventHandler(this.tsb_refreshuser_Click);
            // 
            // tss_1
            // 
            this.tss_1.Name = "tss_1";
            this.tss_1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_adduser
            // 
            this.tsb_adduser.Image = ((System.Drawing.Image)(resources.GetObject("tsb_adduser.Image")));
            this.tsb_adduser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_adduser.Name = "tsb_adduser";
            this.tsb_adduser.Size = new System.Drawing.Size(76, 22);
            this.tsb_adduser.Text = "添加用户";
            this.tsb_adduser.Click += new System.EventHandler(this.tsb_adduser_Click);
            // 
            // tsb_copyuser
            // 
            this.tsb_copyuser.Image = ((System.Drawing.Image)(resources.GetObject("tsb_copyuser.Image")));
            this.tsb_copyuser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_copyuser.Name = "tsb_copyuser";
            this.tsb_copyuser.Size = new System.Drawing.Size(76, 22);
            this.tsb_copyuser.Text = "复制用户";
            this.tsb_copyuser.Click += new System.EventHandler(this.tsb_copyuser_Click);
            // 
            // tsb_saveuser
            // 
            this.tsb_saveuser.Image = ((System.Drawing.Image)(resources.GetObject("tsb_saveuser.Image")));
            this.tsb_saveuser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_saveuser.Name = "tsb_saveuser";
            this.tsb_saveuser.Size = new System.Drawing.Size(76, 22);
            this.tsb_saveuser.Text = "保存用户";
            this.tsb_saveuser.Click += new System.EventHandler(this.tsb_saveuser_Click);
            // 
            // tsb_deleteuser
            // 
            this.tsb_deleteuser.Image = ((System.Drawing.Image)(resources.GetObject("tsb_deleteuser.Image")));
            this.tsb_deleteuser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_deleteuser.Name = "tsb_deleteuser";
            this.tsb_deleteuser.Size = new System.Drawing.Size(76, 22);
            this.tsb_deleteuser.Text = "删除用户";
            this.tsb_deleteuser.Click += new System.EventHandler(this.tsb_deleteuser_Click);
            // 
            // tss_2
            // 
            this.tss_2.Name = "tss_2";
            this.tss_2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_userright
            // 
            this.tsb_userright.Image = ((System.Drawing.Image)(resources.GetObject("tsb_userright.Image")));
            this.tsb_userright.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_userright.Name = "tsb_userright";
            this.tsb_userright.Size = new System.Drawing.Size(76, 22);
            this.tsb_userright.Text = "用户权限";
            // 
            // tsb_refreshmodule
            // 
            this.tsb_refreshmodule.Image = ((System.Drawing.Image)(resources.GetObject("tsb_refreshmodule.Image")));
            this.tsb_refreshmodule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_refreshmodule.Name = "tsb_refreshmodule";
            this.tsb_refreshmodule.Size = new System.Drawing.Size(76, 22);
            this.tsb_refreshmodule.Text = "刷新模块";
            this.tsb_refreshmodule.Visible = false;
            this.tsb_refreshmodule.Click += new System.EventHandler(this.tsb_refreshmodule_Click);
            // 
            // tss_3
            // 
            this.tss_3.Name = "tss_3";
            this.tss_3.Size = new System.Drawing.Size(6, 25);
            this.tss_3.Visible = false;
            // 
            // tsb_addmodule
            // 
            this.tsb_addmodule.Image = ((System.Drawing.Image)(resources.GetObject("tsb_addmodule.Image")));
            this.tsb_addmodule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_addmodule.Name = "tsb_addmodule";
            this.tsb_addmodule.Size = new System.Drawing.Size(76, 22);
            this.tsb_addmodule.Text = "添加模块";
            this.tsb_addmodule.Visible = false;
            this.tsb_addmodule.Click += new System.EventHandler(this.tsb_addmodule_Click);
            // 
            // tsb_savemodule
            // 
            this.tsb_savemodule.Image = ((System.Drawing.Image)(resources.GetObject("tsb_savemodule.Image")));
            this.tsb_savemodule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_savemodule.Name = "tsb_savemodule";
            this.tsb_savemodule.Size = new System.Drawing.Size(76, 22);
            this.tsb_savemodule.Text = "保存模块";
            this.tsb_savemodule.Visible = false;
            this.tsb_savemodule.Click += new System.EventHandler(this.tsb_savemodule_Click);
            // 
            // tsb_deletemodule
            // 
            this.tsb_deletemodule.Image = ((System.Drawing.Image)(resources.GetObject("tsb_deletemodule.Image")));
            this.tsb_deletemodule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_deletemodule.Name = "tsb_deletemodule";
            this.tsb_deletemodule.Size = new System.Drawing.Size(76, 22);
            this.tsb_deletemodule.Text = "删除模块";
            this.tsb_deletemodule.Visible = false;
            this.tsb_deletemodule.Click += new System.EventHandler(this.tsb_deletemodule_Click);
            // 
            // tpg_module
            // 
            this.tpg_module.Controls.Add(this.scn_module);
            this.tpg_module.Location = new System.Drawing.Point(4, 22);
            this.tpg_module.Name = "tpg_module";
            this.tpg_module.Padding = new System.Windows.Forms.Padding(3);
            this.tpg_module.Size = new System.Drawing.Size(884, 515);
            this.tpg_module.TabIndex = 1;
            this.tpg_module.Text = "模块";
            this.tpg_module.UseVisualStyleBackColor = true;
            // 
            // scn_module
            // 
            this.scn_module.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scn_module.Location = new System.Drawing.Point(3, 3);
            this.scn_module.Name = "scn_module";
            // 
            // scn_module.Panel1
            // 
            this.scn_module.Panel1.Controls.Add(this.tvw_module);
            // 
            // scn_module.Panel2
            // 
            this.scn_module.Panel2.Controls.Add(this.tlp_module);
            this.scn_module.Size = new System.Drawing.Size(878, 509);
            this.scn_module.SplitterDistance = 268;
            this.scn_module.TabIndex = 8;
            // 
            // tlp_module
            // 
            this.tlp_module.ColumnCount = 3;
            this.tlp_module.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_module.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 292F));
            this.tlp_module.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_module.Controls.Add(this.pnl_module, 1, 1);
            this.tlp_module.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_module.Location = new System.Drawing.Point(0, 0);
            this.tlp_module.Name = "tlp_module";
            this.tlp_module.RowCount = 3;
            this.tlp_module.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_module.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 243F));
            this.tlp_module.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_module.Size = new System.Drawing.Size(606, 509);
            this.tlp_module.TabIndex = 1;
            // 
            // pnl_module
            // 
            this.pnl_module.Controls.Add(this.tbx_id);
            this.pnl_module.Controls.Add(this.lbl_id);
            this.pnl_module.Controls.Add(this.rbn_nextlevel);
            this.pnl_module.Controls.Add(this.rbn_samelevel);
            this.pnl_module.Controls.Add(this.tbx_bubb);
            this.pnl_module.Controls.Add(this.lbl_bubb);
            this.pnl_module.Controls.Add(this.tbx_moduletext);
            this.pnl_module.Controls.Add(this.lbl_moduletext);
            this.pnl_module.Controls.Add(this.cbb_moduletype);
            this.pnl_module.Controls.Add(this.lbl_moduletype);
            this.pnl_module.Controls.Add(this.tbx_classname);
            this.pnl_module.Controls.Add(this.lbl_classname);
            this.pnl_module.Controls.Add(this.tbx_namespace);
            this.pnl_module.Controls.Add(this.lbl_namespace);
            this.pnl_module.Controls.Add(this.tbx_modulename);
            this.pnl_module.Controls.Add(this.lbl_modulename);
            this.pnl_module.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_module.Location = new System.Drawing.Point(160, 136);
            this.pnl_module.Name = "pnl_module";
            this.pnl_module.Size = new System.Drawing.Size(286, 237);
            this.pnl_module.TabIndex = 0;
            // 
            // lbl_modulename
            // 
            this.lbl_modulename.AutoSize = true;
            this.lbl_modulename.Location = new System.Drawing.Point(12, 68);
            this.lbl_modulename.Name = "lbl_modulename";
            this.lbl_modulename.Size = new System.Drawing.Size(41, 12);
            this.lbl_modulename.TabIndex = 16;
            this.lbl_modulename.Text = "模块：";
            // 
            // tbx_modulename
            // 
            this.tbx_modulename.Location = new System.Drawing.Point(59, 65);
            this.tbx_modulename.Name = "tbx_modulename";
            this.tbx_modulename.Size = new System.Drawing.Size(210, 21);
            this.tbx_modulename.TabIndex = 17;
            // 
            // lbl_namespace
            // 
            this.lbl_namespace.AutoSize = true;
            this.lbl_namespace.Location = new System.Drawing.Point(12, 95);
            this.lbl_namespace.Name = "lbl_namespace";
            this.lbl_namespace.Size = new System.Drawing.Size(41, 12);
            this.lbl_namespace.TabIndex = 18;
            this.lbl_namespace.Text = "空间：";
            // 
            // tbx_namespace
            // 
            this.tbx_namespace.Location = new System.Drawing.Point(59, 92);
            this.tbx_namespace.Name = "tbx_namespace";
            this.tbx_namespace.Size = new System.Drawing.Size(210, 21);
            this.tbx_namespace.TabIndex = 19;
            // 
            // lbl_classname
            // 
            this.lbl_classname.AutoSize = true;
            this.lbl_classname.Location = new System.Drawing.Point(12, 122);
            this.lbl_classname.Name = "lbl_classname";
            this.lbl_classname.Size = new System.Drawing.Size(41, 12);
            this.lbl_classname.TabIndex = 20;
            this.lbl_classname.Text = "类名：";
            // 
            // tbx_classname
            // 
            this.tbx_classname.Location = new System.Drawing.Point(59, 119);
            this.tbx_classname.Name = "tbx_classname";
            this.tbx_classname.Size = new System.Drawing.Size(210, 21);
            this.tbx_classname.TabIndex = 21;
            // 
            // lbl_moduletype
            // 
            this.lbl_moduletype.AutoSize = true;
            this.lbl_moduletype.Location = new System.Drawing.Point(12, 149);
            this.lbl_moduletype.Name = "lbl_moduletype";
            this.lbl_moduletype.Size = new System.Drawing.Size(41, 12);
            this.lbl_moduletype.TabIndex = 22;
            this.lbl_moduletype.Text = "类型：";
            // 
            // cbb_moduletype
            // 
            this.cbb_moduletype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_moduletype.FormattingEnabled = true;
            this.cbb_moduletype.Items.AddRange(new object[] {
            "目录",
            "目录（不可见）",
            "应用"});
            this.cbb_moduletype.Location = new System.Drawing.Point(59, 146);
            this.cbb_moduletype.Name = "cbb_moduletype";
            this.cbb_moduletype.Size = new System.Drawing.Size(210, 20);
            this.cbb_moduletype.TabIndex = 23;
            // 
            // lbl_moduletext
            // 
            this.lbl_moduletext.AutoSize = true;
            this.lbl_moduletext.Location = new System.Drawing.Point(12, 202);
            this.lbl_moduletext.Name = "lbl_moduletext";
            this.lbl_moduletext.Size = new System.Drawing.Size(41, 12);
            this.lbl_moduletext.TabIndex = 24;
            this.lbl_moduletext.Text = "备注：";
            // 
            // tbx_moduletext
            // 
            this.tbx_moduletext.Location = new System.Drawing.Point(59, 199);
            this.tbx_moduletext.Name = "tbx_moduletext";
            this.tbx_moduletext.Size = new System.Drawing.Size(210, 21);
            this.tbx_moduletext.TabIndex = 25;
            // 
            // lbl_bubb
            // 
            this.lbl_bubb.AutoSize = true;
            this.lbl_bubb.Location = new System.Drawing.Point(12, 175);
            this.lbl_bubb.Name = "lbl_bubb";
            this.lbl_bubb.Size = new System.Drawing.Size(41, 12);
            this.lbl_bubb.TabIndex = 28;
            this.lbl_bubb.Text = "位序：";
            // 
            // tbx_bubb
            // 
            this.tbx_bubb.Location = new System.Drawing.Point(59, 172);
            this.tbx_bubb.Name = "tbx_bubb";
            this.tbx_bubb.Size = new System.Drawing.Size(210, 21);
            this.tbx_bubb.TabIndex = 29;
            // 
            // rbn_samelevel
            // 
            this.rbn_samelevel.AutoSize = true;
            this.rbn_samelevel.Location = new System.Drawing.Point(14, 13);
            this.rbn_samelevel.Name = "rbn_samelevel";
            this.rbn_samelevel.Size = new System.Drawing.Size(71, 16);
            this.rbn_samelevel.TabIndex = 34;
            this.rbn_samelevel.Text = "同级节点";
            this.rbn_samelevel.UseVisualStyleBackColor = true;
            // 
            // rbn_nextlevel
            // 
            this.rbn_nextlevel.AutoSize = true;
            this.rbn_nextlevel.Checked = true;
            this.rbn_nextlevel.Location = new System.Drawing.Point(145, 13);
            this.rbn_nextlevel.Name = "rbn_nextlevel";
            this.rbn_nextlevel.Size = new System.Drawing.Size(83, 16);
            this.rbn_nextlevel.TabIndex = 35;
            this.rbn_nextlevel.TabStop = true;
            this.rbn_nextlevel.Text = "下一级节点";
            this.rbn_nextlevel.UseVisualStyleBackColor = true;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(12, 41);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(41, 12);
            this.lbl_id.TabIndex = 36;
            this.lbl_id.Text = "标识：";
            // 
            // tbx_id
            // 
            this.tbx_id.Location = new System.Drawing.Point(59, 38);
            this.tbx_id.Name = "tbx_id";
            this.tbx_id.Size = new System.Drawing.Size(210, 21);
            this.tbx_id.TabIndex = 37;
            // 
            // tvw_module
            // 
            this.tvw_module.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvw_module.FullRowSelect = true;
            this.tvw_module.HideSelection = false;
            this.tvw_module.ItemHeight = 16;
            this.tvw_module.Location = new System.Drawing.Point(0, 0);
            this.tvw_module.Name = "tvw_module";
            this.tvw_module.Size = new System.Drawing.Size(268, 509);
            this.tvw_module.TabIndex = 3;
            this.tvw_module.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvw_module_AfterSelect);
            // 
            // tpg_user
            // 
            this.tpg_user.Controls.Add(this.scn_user);
            this.tpg_user.Location = new System.Drawing.Point(4, 22);
            this.tpg_user.Name = "tpg_user";
            this.tpg_user.Padding = new System.Windows.Forms.Padding(3);
            this.tpg_user.Size = new System.Drawing.Size(884, 515);
            this.tpg_user.TabIndex = 0;
            this.tpg_user.Text = "用户";
            this.tpg_user.UseVisualStyleBackColor = true;
            // 
            // scn_user
            // 
            this.scn_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scn_user.Location = new System.Drawing.Point(3, 3);
            this.scn_user.Name = "scn_user";
            // 
            // scn_user.Panel1
            // 
            this.scn_user.Panel1.Controls.Add(this.tvw_user);
            // 
            // scn_user.Panel2
            // 
            this.scn_user.Panel2.Controls.Add(this.tlp_user);
            this.scn_user.Size = new System.Drawing.Size(878, 509);
            this.scn_user.SplitterDistance = 268;
            this.scn_user.TabIndex = 7;
            // 
            // tlp_user
            // 
            this.tlp_user.ColumnCount = 3;
            this.tlp_user.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_user.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 292F));
            this.tlp_user.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_user.Controls.Add(this.pnl_user, 1, 1);
            this.tlp_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_user.Location = new System.Drawing.Point(0, 0);
            this.tlp_user.Name = "tlp_user";
            this.tlp_user.RowCount = 3;
            this.tlp_user.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_user.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tlp_user.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_user.Size = new System.Drawing.Size(606, 509);
            this.tlp_user.TabIndex = 0;
            // 
            // pnl_user
            // 
            this.pnl_user.Controls.Add(this.cbx_used);
            this.pnl_user.Controls.Add(this.cbb_department);
            this.pnl_user.Controls.Add(this.cbb_usertype);
            this.pnl_user.Controls.Add(this.lbl_type);
            this.pnl_user.Controls.Add(this.tbx_usertext);
            this.pnl_user.Controls.Add(this.lbl_usertext);
            this.pnl_user.Controls.Add(this.tbx_name);
            this.pnl_user.Controls.Add(this.lbl_name);
            this.pnl_user.Controls.Add(this.lbl_department);
            this.pnl_user.Controls.Add(this.tbx_user);
            this.pnl_user.Controls.Add(this.lbl_user);
            this.pnl_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_user.Location = new System.Drawing.Point(160, 168);
            this.pnl_user.Name = "pnl_user";
            this.pnl_user.Size = new System.Drawing.Size(286, 172);
            this.pnl_user.TabIndex = 0;
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(12, 15);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(41, 12);
            this.lbl_user.TabIndex = 16;
            this.lbl_user.Text = "用户：";
            // 
            // tbx_user
            // 
            this.tbx_user.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbx_user.Location = new System.Drawing.Point(59, 12);
            this.tbx_user.Name = "tbx_user";
            this.tbx_user.Size = new System.Drawing.Size(209, 21);
            this.tbx_user.TabIndex = 17;
            // 
            // lbl_department
            // 
            this.lbl_department.AutoSize = true;
            this.lbl_department.Location = new System.Drawing.Point(12, 69);
            this.lbl_department.Name = "lbl_department";
            this.lbl_department.Size = new System.Drawing.Size(41, 12);
            this.lbl_department.TabIndex = 18;
            this.lbl_department.Text = "部门：";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(12, 42);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(41, 12);
            this.lbl_name.TabIndex = 19;
            this.lbl_name.Text = "名称：";
            // 
            // tbx_name
            // 
            this.tbx_name.Location = new System.Drawing.Point(59, 39);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(209, 21);
            this.tbx_name.TabIndex = 20;
            // 
            // lbl_usertext
            // 
            this.lbl_usertext.AutoSize = true;
            this.lbl_usertext.Location = new System.Drawing.Point(12, 122);
            this.lbl_usertext.Name = "lbl_usertext";
            this.lbl_usertext.Size = new System.Drawing.Size(41, 12);
            this.lbl_usertext.TabIndex = 21;
            this.lbl_usertext.Text = "备注：";
            // 
            // tbx_usertext
            // 
            this.tbx_usertext.Location = new System.Drawing.Point(59, 119);
            this.tbx_usertext.Name = "tbx_usertext";
            this.tbx_usertext.Size = new System.Drawing.Size(209, 21);
            this.tbx_usertext.TabIndex = 22;
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.Location = new System.Drawing.Point(12, 96);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(41, 12);
            this.lbl_type.TabIndex = 23;
            this.lbl_type.Text = "类型：";
            // 
            // cbb_usertype
            // 
            this.cbb_usertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_usertype.FormattingEnabled = true;
            this.cbb_usertype.Items.AddRange(new object[] {
            "普通用户",
            "管理员"});
            this.cbb_usertype.Location = new System.Drawing.Point(59, 93);
            this.cbb_usertype.Name = "cbb_usertype";
            this.cbb_usertype.Size = new System.Drawing.Size(209, 20);
            this.cbb_usertype.TabIndex = 24;
            // 
            // cbb_department
            // 
            this.cbb_department.FormattingEnabled = true;
            this.cbb_department.Items.AddRange(new object[] {
            "采购部",
            "开发部",
            "生产技术部",
            "生管部",
            "物流部",
            "销售部",
            "质管部"});
            this.cbb_department.Location = new System.Drawing.Point(59, 66);
            this.cbb_department.Name = "cbb_department";
            this.cbb_department.Size = new System.Drawing.Size(209, 20);
            this.cbb_department.Sorted = true;
            this.cbb_department.TabIndex = 25;
            // 
            // cbx_used
            // 
            this.cbx_used.AutoSize = true;
            this.cbx_used.Location = new System.Drawing.Point(14, 146);
            this.cbx_used.Name = "cbx_used";
            this.cbx_used.Size = new System.Drawing.Size(48, 16);
            this.cbx_used.TabIndex = 26;
            this.cbx_used.Text = "有效";
            this.cbx_used.UseVisualStyleBackColor = true;
            // 
            // tvw_user
            // 
            this.tvw_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvw_user.FullRowSelect = true;
            this.tvw_user.HideSelection = false;
            this.tvw_user.ItemHeight = 16;
            this.tvw_user.Location = new System.Drawing.Point(0, 0);
            this.tvw_user.Name = "tvw_user";
            this.tvw_user.Size = new System.Drawing.Size(268, 509);
            this.tvw_user.TabIndex = 3;
            this.tvw_user.DoubleClick += new System.EventHandler(this.tvw_user_DoubleClick);
            this.tvw_user.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvw_user_AfterSelect);
            // 
            // tcl_right
            // 
            this.tcl_right.Controls.Add(this.tpg_user);
            this.tcl_right.Controls.Add(this.tpg_module);
            this.tcl_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcl_right.Location = new System.Drawing.Point(0, 25);
            this.tcl_right.Name = "tcl_right";
            this.tcl_right.SelectedIndex = 0;
            this.tcl_right.Size = new System.Drawing.Size(892, 541);
            this.tcl_right.TabIndex = 2;
            this.tcl_right.SelectedIndexChanged += new System.EventHandler(this.tcl_right_SelectedIndexChanged);
            // 
            // RightFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 566);
            this.Controls.Add(this.tcl_right);
            this.Controls.Add(this.tsp_user);
            this.Name = "RightFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tsp_user.ResumeLayout(false);
            this.tsp_user.PerformLayout();
            this.tpg_module.ResumeLayout(false);
            this.scn_module.Panel1.ResumeLayout(false);
            this.scn_module.Panel2.ResumeLayout(false);
            this.scn_module.ResumeLayout(false);
            this.tlp_module.ResumeLayout(false);
            this.pnl_module.ResumeLayout(false);
            this.pnl_module.PerformLayout();
            this.tpg_user.ResumeLayout(false);
            this.scn_user.Panel1.ResumeLayout(false);
            this.scn_user.Panel2.ResumeLayout(false);
            this.scn_user.ResumeLayout(false);
            this.tlp_user.ResumeLayout(false);
            this.pnl_user.ResumeLayout(false);
            this.pnl_user.PerformLayout();
            this.tcl_right.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsp_user;
        private System.Windows.Forms.ToolStripButton tsb_adduser;
        private System.Windows.Forms.ToolStripButton tsb_addmodule;
        private System.Windows.Forms.ToolStripSeparator tss_2;
        private System.Windows.Forms.ToolStripButton tsb_deleteuser;
        private System.Windows.Forms.ToolStripButton tsb_deletemodule;
        private System.Windows.Forms.ToolStripButton tsb_copyuser;
        private System.Windows.Forms.ToolStripButton tsb_refreshuser;
        private System.Windows.Forms.ToolStripSeparator tss_1;
        private System.Windows.Forms.ToolStripButton tsb_refreshmodule;
        private System.Windows.Forms.ToolStripSeparator tss_3;
        private System.Windows.Forms.ToolStripButton tsb_userright;
        private System.Windows.Forms.ToolStripButton tsb_saveuser;
        private System.Windows.Forms.ToolStripButton tsb_savemodule;
        private System.Windows.Forms.TabPage tpg_module;
        private System.Windows.Forms.SplitContainer scn_module;
        private System.Windows.Forms.TreeView tvw_module;
        private System.Windows.Forms.TableLayoutPanel tlp_module;
        private System.Windows.Forms.Panel pnl_module;
        private System.Windows.Forms.TextBox tbx_id;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.RadioButton rbn_nextlevel;
        private System.Windows.Forms.RadioButton rbn_samelevel;
        private System.Windows.Forms.TextBox tbx_bubb;
        private System.Windows.Forms.Label lbl_bubb;
        private System.Windows.Forms.TextBox tbx_moduletext;
        private System.Windows.Forms.Label lbl_moduletext;
        private System.Windows.Forms.ComboBox cbb_moduletype;
        private System.Windows.Forms.Label lbl_moduletype;
        private System.Windows.Forms.TextBox tbx_classname;
        private System.Windows.Forms.Label lbl_classname;
        private System.Windows.Forms.TextBox tbx_namespace;
        private System.Windows.Forms.Label lbl_namespace;
        private System.Windows.Forms.TextBox tbx_modulename;
        private System.Windows.Forms.Label lbl_modulename;
        private System.Windows.Forms.TabPage tpg_user;
        private System.Windows.Forms.SplitContainer scn_user;
        private System.Windows.Forms.TreeView tvw_user;
        private System.Windows.Forms.TableLayoutPanel tlp_user;
        private System.Windows.Forms.Panel pnl_user;
        private System.Windows.Forms.CheckBox cbx_used;
        private System.Windows.Forms.ComboBox cbb_department;
        private System.Windows.Forms.ComboBox cbb_usertype;
        private System.Windows.Forms.Label lbl_type;
        private System.Windows.Forms.TextBox tbx_usertext;
        private System.Windows.Forms.Label lbl_usertext;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_department;
        private System.Windows.Forms.TextBox tbx_user;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.TabControl tcl_right;
    }
}

