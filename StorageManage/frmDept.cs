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
    public partial class frmDept : frmBase
    {
        DeptManage DeptManage = new DeptManage();
        public static frmDept frmdept;
        public frmDept()
        {
            InitializeComponent();
            frmdept = this;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDeptAdd frmDeptAdd = new frmDeptAdd();
            frmDeptAdd.DeptAdd();

        }


        //载入货品数据
        public void LoadDept()
        {

            DataTable dtl = DeptManage.GetDeptData();
            gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;

        }

        private void frmDept_Load(object sender, EventArgs e)
        {
            LoadDept();
        }

        //编辑
        private void tsbedit_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmDeptAdd frmDeptAdd = new frmDeptAdd();
                frmDeptAdd.DeptEdit(guid);
            }

        }

        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除该数据！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                DataRowView dr = (DataRowView)(gridView1.GetFocusedRow());
                DeptManage.DeleteDept(dr[0].ToString());

                LoadDept();
                this.ShowMessage("删除成功!");
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmDeptAdd frmDeptAdd = new frmDeptAdd();
                frmDeptAdd.DeptEdit(guid);
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}