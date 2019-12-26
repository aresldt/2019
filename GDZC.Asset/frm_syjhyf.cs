using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GDZC.Asset
{
    public partial class frm_syjhyf : Form
    {
        public int syjhyf;

        public frm_syjhyf()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            syjhyf = System.Convert.ToInt32(textBox1.Text);

            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frm_syjhyf_Load(object sender, EventArgs e)
        {

        }
    }
}