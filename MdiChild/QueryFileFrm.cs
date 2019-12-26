using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MdiChild
{
    public partial class QueryFileFrm : Form
    {
        public string FileStr;

        public QueryFileFrm()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (tbx_query.Text.Trim() == "")
            {
                MessageBox.Show("«Î ‰»Î≤È—Ø√˚≥∆£°");
                return;
            }

            FileStr = tbx_query.Text.Trim();

            DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}