using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StorageManageLibrary;


namespace StorageManage
{
    public partial class frmChangePassword : Form
    {
        public string USERID;
        public string USERName;
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text.Trim()=="")
            {
                MessageBox.Show("请输入原密码!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPassword.Text.Trim() != txtNewPassword2.Text.Trim())
            {
                MessageBox.Show("请输入两次相同的新密码!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoginUserManage lum = new LoginUserManage();
            if (!lum.CheckUserPassword(USERID, txtOldPassword.Text))
            {
                MessageBox.Show("密码修改失败,请检查用户名或密码输入正确性!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (lum.ChangePassword(USERID, txtOldPassword.Text, txtNewPassword.Text))
            {
                MessageBox.Show("密码修改成功!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("密码修改失败,请检查原密码是否输入正确!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            txtUserName.Text = USERName;
           
        }
    }
}