using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StorageManageLibrary;
using System.Web.UI.WebControls;
using Daniel.Liu.DAO;
using System.Xml;

namespace StorageManage
{
    /// <summary>
    /// 系统登陆
    /// </summary>
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        private void login()
        {
            if (cboUserID.Text.Trim() == "")
            {
                MessageBox.Show("请选择用户名!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户密码!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            LoginUserManage lum = new LoginUserManage();
            if (lum.CheckUserPassword(((ListItem)cboUserID.SelectedItem).Value, txtPassword.Text))
            {
                SysParams.UserID = ((ListItem)cboUserID.SelectedItem).Value;
                SysParams.UserName = ((ListItem)cboUserID.SelectedItem).Text;
             
                //将本次登陆的用户名与项目名称存起来
                 WriteLoginUnitXML();
                //this.DialogResult = DialogResult.OK;
                this.Visible = false;

                frmStorageMain frmStorageMain = new frmStorageMain();
                frmStorageMain.ShowDialog();

            }
            else
            {
                MessageBox.Show("你输入的用户账号或用户密码有错误,请重输!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                login();
            }
        }


        /// <summary>
        /// 绑定下拉列表框，通用方法
        /// </summary>
        public void cboDataBind(ComboBox obj)
        {
            LoginUserManage lum = new LoginUserManage();
            DataTable dtl = lum.GetLoginUserInfo();
            ListItem item;
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                item = new ListItem();
                item.Text = dtl.Rows[i]["USERNAME"].ToString();
                item.Value = dtl.Rows[i]["USERID"].ToString();
                obj.Items.Add(item);
            }

        }

        [Obsolete]
        private void frmLogin_Load(object sender, EventArgs e)
        {
            //初始化数据库连接字符串
            CommonDataConfig.ConnectionDefaultStr = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"].ToString();
           
            //绑定所有项目名称数据
            cboDataBind(cboUserID);

            //将上次登陆的用户与项目名称加载出来
            GetLoginUnitXML();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
         
            login();
        }

        /// <summary>
        /// 取出登陆用户名与项目名称
        /// </summary>
        private void GetLoginUnitXML()
        {
            string fileName = Application.StartupPath + @"\HistoryLogin.xml";
            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(fileName);
            XmlNode rootNode = myXmlDocument.DocumentElement;
            //用户上次登陆账号
            string username = rootNode.ChildNodes[0].ChildNodes[0].Attributes["value"].Value;


            for (int i = 0; i < cboUserID.Items.Count; i++)
            {
                if (((ListItem)cboUserID.Items[i]).Text == username)
                {
                    cboUserID.SelectedIndex = i;
                    break;
                }
            }
        }

        /// <summary>
        /// 将登陆用户与项目名称存入xml中
        /// </summary>
        private void WriteLoginUnitXML()
        {

            string fileName = Application.StartupPath + @"\HistoryLogin.xml";

            XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(fileName);
            XmlNode rootNode = myXmlDocument.DocumentElement;
            //用户上次登陆用户名
            rootNode.ChildNodes[0].ChildNodes[0].Attributes["value"].Value = cboUserID.Text;
        
            myXmlDocument.Save(Application.StartupPath + @"\HistoryLogin.xml");
        }

        private void lnkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePassword frmcp = new frmChangePassword();
            frmcp.USERID = ((ListItem)cboUserID.SelectedItem).Value;
            frmcp.USERName = ((ListItem)cboUserID.SelectedItem).Text;
            frmcp.ShowDialog();
        }


    }
}