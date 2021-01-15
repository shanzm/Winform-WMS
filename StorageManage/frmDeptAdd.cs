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
    /// 部门新增
    /// </summary>
    public partial class frmDeptAdd : frmBase
    {
        DeptManage DeptManage = new DeptManage();
        public frmDeptAdd()
        {
            InitializeComponent();

            txtGuid.Text = Guid.NewGuid().ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //新增
        public void DeptAdd()
        {
            if (txtGuid.Text == "")
            {
                txtGuid.Text = Guid.NewGuid().ToString();
            }

            this.ShowDialog();
        
        }

        //新增
        public void DeptEdit(string DeptGuid)
        {
            FillData(DeptGuid);
        }


        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="MaterialGuid"></param>
        private void FillData(string DeptGuid)
        {
            DeptManage Deptmanage = new DeptManage();
            DataTable dtl = Deptmanage.GetDeptData(DeptGuid);

            if (dtl.Rows.Count > 0)
            {
                txtGuid.Text = dtl.Rows[0]["DeptGuid"].ToString();
                txtDeptName.Text = dtl.Rows[0]["DeptName"].ToString();
                txtDeptPerson.Text = dtl.Rows[0]["DeptPerson"].ToString();
                txtTelephone.Text = dtl.Rows[0]["Telephone"].ToString();
                txtFax.Text = dtl.Rows[0]["Fax"].ToString();
                txtAddress.Text = dtl.Rows[0]["Address"].ToString();
             
            }

            this.ShowDialog();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Dept Dept = new Dept();
            Dept.DeptGuid = txtGuid.Text;

            Dept.DeptName = txtDeptName.Text;
            Dept.DeptPerson = txtDeptPerson.Text;
            Dept.Telephone = txtTelephone.Text;
            Dept.Fax = txtFax.Text;
            Dept.Address = txtAddress.Text;
            DeptManage.Save(Dept);

            frmDept.frmdept.LoadDept();

            this.Close();

        }


    }
}