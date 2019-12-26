using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BasicFrame
{
    public partial class PasswordFrm : Form
    {
        public PasswordFrm()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (tbx_password.Text.Trim() == "")
            {
                MessageBox.Show("«Î ‰»Î√‹¬Î£°");
                return;
            }
            DataAccess.DataRight dataRight = new DataAccess.DataRight();
            BaseService.StructUser structUser = new BaseService.StructUser();
            structUser.SUSER = BaseService.BaseService.ApplicationUser.SUSER;
            structUser.SPWD = BaseService.BaseService.EncryptPassword(tbx_password.Text.Trim());
            if (dataRight.ModifyUserPassword(structUser) == true)
                this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}