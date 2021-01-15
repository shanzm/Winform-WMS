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
    /// 供应商管理
    /// </summary>
    public partial class frmSupplier : frmBase
    {
        SupplierManage SupplierManage = new SupplierManage();
        public static frmSupplier frmsupplier;
        public frmSupplier()
        {
            InitializeComponent();
            frmsupplier = this;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSupplierAdd frmSupplierAdd = new frmSupplierAdd();
            frmSupplierAdd.SupplierAdd();

        }


        //载入货品数据
        public void LoadSupplier()
        {

            DataTable dtl = SupplierManage.GetSupplierData();
            gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;

        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            LoadSupplier();
        }

        //编辑
        private void tsbedit_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmSupplierAdd frmSupplierAdd = new frmSupplierAdd();
                frmSupplierAdd.SupplierEdit(guid);
            }

        }

        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除该数据！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                DataRowView dr = (DataRowView)(gridView1.GetFocusedRow());
                SupplierManage.DeleteSupplier(dr[0].ToString());

                LoadSupplier();
                this.ShowMessage("删除成功!");
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmSupplierAdd frmSupplierAdd = new frmSupplierAdd();
                frmSupplierAdd.SupplierEdit(guid);
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}