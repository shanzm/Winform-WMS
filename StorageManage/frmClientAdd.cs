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
    /// <summary>
    /// 客户新增
    /// </summary>
    public partial class frmClientAdd : frmBase
    {
        ClientManage ClientManage = new ClientManage();
        public frmClientAdd()
        {
            InitializeComponent();

            txtGuid.Text = Guid.NewGuid().ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //新增
        public void ClientAdd()
        {
            if (txtGuid.Text == "")
            {
                txtGuid.Text = Guid.NewGuid().ToString();
            }

            this.ShowDialog();
        
        }

        //新增
        public void ClientEdit(string ClientGuid)
        {
            FillData(ClientGuid);
        }


        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="MaterialGuid"></param>
        private void FillData(string ClientGuid)
        {
            ClientManage Clientmanage = new ClientManage();
            DataTable dtl = Clientmanage.GetClientData_CN(ClientGuid);

            if (dtl.Rows.Count > 0)
            {
                txtGuid.Text = dtl.Rows[0]["Guid"].ToString();
                txtName.Text = dtl.Rows[0]["Name"].ToString();
                txtSimpName.Text = dtl.Rows[0]["SimpName"].ToString();
                txtLinkMan.Text = dtl.Rows[0]["LinkMan"].ToString();
                txtTelephone.Text = dtl.Rows[0]["Telephone"].ToString();
                txtFax.Text = dtl.Rows[0]["Fax"].ToString();
                txtAddress.Text = dtl.Rows[0]["Address"].ToString();
                txtZip.Text = dtl.Rows[0]["Zip"].ToString();
                txtRemark.Text = dtl.Rows[0]["Remark"].ToString();
            }

            this.ShowDialog();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Client Client = new Client();
            Client.Guid = txtGuid.Text;

            Client.Name = txtName.Text;
            Client.SimpName = txtSimpName.Text;
            Client.LinkMan = txtLinkMan.Text;
            Client.Telephone = txtTelephone.Text;
            Client.Fax = txtFax.Text;
            Client.Address = txtAddress.Text;
            Client.Zip = txtZip.Text;
            Client.Remark = txtRemark.Text;


            ClientManage.Save(Client);

            frmClient.frmclient.LoadClient();

            this.Close();

        }


    }
}