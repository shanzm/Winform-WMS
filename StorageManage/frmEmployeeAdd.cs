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
    public partial class frmEmployeeAdd : frmBase
    {
        EmployeeManage EmployeeManage = new EmployeeManage();
        public frmEmployeeAdd()
        {
            InitializeComponent();

            txtGuid.Text = Guid.NewGuid().ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //新增
        public void EmployeeAdd()
        {
            if (txtGuid.Text == "")
            {
                txtGuid.Text = Guid.NewGuid().ToString();
            }

            this.ShowDialog();
        
        }

        //新增
        public void EmployeeEdit(string EmployeeGuid)
        {
            FillData(EmployeeGuid);
        }


        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="MaterialGuid"></param>
        private void FillData(string EmployeeGuid)
        {
            EmployeeManage Employeemanage = new EmployeeManage();
            DataTable dtl = Employeemanage.GetEmployeeData(EmployeeGuid);

            if (dtl.Rows.Count > 0)
            {
                txtGuid.Text = dtl.Rows[0]["EmpGuid"].ToString();
                txtEmpId.Text = dtl.Rows[0]["EmpID"].ToString();
                txtEmpName.Text = dtl.Rows[0]["EmpName"].ToString();
                 txtTelephone.Text = dtl.Rows[0]["Telephone"].ToString();
                txtCardID.Text = dtl.Rows[0]["CardID"].ToString();
               txtAddress.Text = dtl.Rows[0]["Address"].ToString();
               txtDept.Text = dtl.Rows[0]["Dept"].ToString();
               txtSex.Text = dtl.Rows[0]["Sex"].ToString();
            }

            this.ShowDialog();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee Employee = new Employee();
            Employee.EmpGuid = txtGuid.Text;

            Employee.EmpID = txtEmpId.Text;
            Employee.EmpName = txtEmpName.Text;
            Employee.Telephone = txtTelephone.Text;
            Employee.CardID = txtCardID.Text;
            Employee.Address = txtAddress.Text;
            Employee.Dept = txtDept.Text;
            Employee.Sex = txtSex.Text;
            EmployeeManage.Save(Employee);

            frmEmployee.frmemployee.LoadEmployee();

            this.Close();

        }


    }
}