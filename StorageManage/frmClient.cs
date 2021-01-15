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
    ///客户管理
    /// </summary>
    public partial class frmClient : frmBase
    {
        ClientManage ClientManage = new ClientManage();
        public static frmClient frmclient;
        public frmClient()
        {
            InitializeComponent();
            frmclient = this;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmClientAdd frmClientAdd = new frmClientAdd();
            frmClientAdd.ClientAdd();

        }


        //载入货品数据
        public void LoadClient()
        {

            DataTable dtl = ClientManage.GetClientData();
            gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;

        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            LoadClient();
        }

        //编辑
        private void tsbedit_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmClientAdd frmClientAdd = new frmClientAdd();
                frmClientAdd.ClientEdit(guid);
            }

        }

        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除该数据！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                DataRowView dr = (DataRowView)(gridView1.GetFocusedRow());
                ClientManage.DeleteClient(dr[0].ToString());

                LoadClient();
                this.ShowMessage("删除成功!");
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //int intRow = gridView1.GetSelectedRows()[0];
            string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

            frmClientAdd frmClientAdd = new frmClientAdd();
            frmClientAdd.ClientEdit(guid);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}