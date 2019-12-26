namespace ChildTest
{
    partial class ChildTestFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildTestFrm));
            this.tsp_child = new System.Windows.Forms.ToolStrip();
            this.tsb_button1 = new System.Windows.Forms.ToolStripButton();
            this.tsb_button2 = new System.Windows.Forms.ToolStripButton();
            this.tsb_button3 = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbx_tdecimal = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tbx_tvarchar = new System.Windows.Forms.TextBox();
            this.tsp_child.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsp_child
            // 
            this.tsp_child.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_button1,
            this.tsb_button2,
            this.tsb_button3});
            this.tsp_child.Location = new System.Drawing.Point(0, 0);
            this.tsp_child.Name = "tsp_child";
            this.tsp_child.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsp_child.Size = new System.Drawing.Size(292, 25);
            this.tsp_child.TabIndex = 0;
            this.tsp_child.Text = "toolStrip1";
            // 
            // tsb_button1
            // 
            this.tsb_button1.Image = ((System.Drawing.Image)(resources.GetObject("tsb_button1.Image")));
            this.tsb_button1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_button1.Name = "tsb_button1";
            this.tsb_button1.Size = new System.Drawing.Size(59, 22);
            this.tsb_button1.Text = "测试1";
            this.tsb_button1.Click += new System.EventHandler(this.tsb_button1_Click);
            // 
            // tsb_button2
            // 
            this.tsb_button2.Image = ((System.Drawing.Image)(resources.GetObject("tsb_button2.Image")));
            this.tsb_button2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_button2.Name = "tsb_button2";
            this.tsb_button2.Size = new System.Drawing.Size(59, 22);
            this.tsb_button2.Text = "测试2";
            this.tsb_button2.Click += new System.EventHandler(this.tsb_button2_Click);
            // 
            // tsb_button3
            // 
            this.tsb_button3.Image = ((System.Drawing.Image)(resources.GetObject("tsb_button3.Image")));
            this.tsb_button3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_button3.Name = "tsb_button3";
            this.tsb_button3.Size = new System.Drawing.Size(59, 22);
            this.tsb_button3.Text = "测试3";
            this.tsb_button3.Click += new System.EventHandler(this.tsb_button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(265, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 241);
            this.panel1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(292, 143);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbx_tdecimal);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.tbx_tvarchar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 98);
            this.panel2.TabIndex = 0;
            // 
            // tbx_tdecimal
            // 
            this.tbx_tdecimal.Location = new System.Drawing.Point(12, 41);
            this.tbx_tdecimal.Name = "tbx_tdecimal";
            this.tbx_tdecimal.Size = new System.Drawing.Size(126, 21);
            this.tbx_tdecimal.TabIndex = 20;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbx_tvarchar
            // 
            this.tbx_tvarchar.Location = new System.Drawing.Point(12, 68);
            this.tbx_tvarchar.Name = "tbx_tvarchar";
            this.tbx_tvarchar.Size = new System.Drawing.Size(126, 21);
            this.tbx_tvarchar.TabIndex = 14;
            // 
            // ChildTestFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tsp_child);
            this.Name = "ChildTestFrm";
            this.Text = "测试";
            this.tsp_child.ResumeLayout(false);
            this.tsp_child.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsp_child;
        private System.Windows.Forms.ToolStripButton tsb_button1;
        private System.Windows.Forms.ToolStripButton tsb_button2;
        private System.Windows.Forms.ToolStripButton tsb_button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbx_tvarchar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbx_tdecimal;
    }
}

