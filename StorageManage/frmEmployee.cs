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
    /// 员工管理
    /// </summary>
    public partial class frmEmployee : frmBase
    {
        EmployeeManage EmployeeManage = new EmployeeManage();
        public static frmEmployee frmemployee;
        public frmEmployee()
        {
            InitializeComponent();
            frmemployee = this;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEmployeeAdd frmEmployeeAdd = new frmEmployeeAdd();
            frmEmployeeAdd.EmployeeAdd();

        }


        //载入货品数据
        public void LoadEmployee()
        {

            DataTable dtl = EmployeeManage.GetEmployeeData();
            gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;

        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployee();
        }

        //编辑
        private void tsbedit_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmEmployeeAdd frmEmployeeAdd = new frmEmployeeAdd();
                frmEmployeeAdd.EmployeeEdit(guid);
            }

        }

        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除该数据！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                DataRowView dr = (DataRowView)(gridView1.GetFocusedRow());
                EmployeeManage.DeleteEmployee(dr[0].ToString());

                LoadEmployee();
                this.ShowMessage("删除成功!");
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmEmployeeAdd frmEmployeeAdd = new frmEmployeeAdd();
                frmEmployeeAdd.EmployeeEdit(guid);
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}