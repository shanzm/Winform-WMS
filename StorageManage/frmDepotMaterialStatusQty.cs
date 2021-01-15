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
    /// 库存当前料件数量相看
    /// </summary>
    public partial class frmDepotMaterialStatusQty : Form
    {
        public frmDepotMaterialStatusQty()
        {
            InitializeComponent();
        }

        private void frmSelectMaterial_Load(object sender, EventArgs e)
        {
          
        }

        //载入数据
        public  void ShowData(string MaterialGuid,IWin32Window ifrm)
        {
            MaterialManage MaterialManage = new MaterialManage();
            DataTable dtl = MaterialManage.GetMaterial(MaterialGuid);
            if (dtl.Rows.Count > 0)
            {
                txtMaterialName.Text = dtl.Rows[0]["MaterialName"].ToString();
                txtBarNo.Text = dtl.Rows[0]["BarNo"].ToString();
                txtSpec.Text = dtl.Rows[0]["Spec"].ToString();
                txtUnit.Text = dtl.Rows[0]["Unit"].ToString();
            }

            BillManage BillManage = new BillManage();
             dtl = BillManage.sp_GetMaterialSumByDepot(MaterialGuid);
            this.gridControl2.DataSource = dtl;

            this.Show(ifrm);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}