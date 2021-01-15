using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StorageManage
{
    /// <summary>
    /// 父类窗口，提供公共的方法
    /// </summary>
    public partial class frmBase : Form
    {
       
        public frmBase()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 公共的数据选择窗口，边输边显示出最匹配的数据
        /// </summary>
        public void SelectDataGrid(DataGridView dgvobj,System.Windows.Forms.TextBox txtobj,int objtype,string sqlstr)
        {
            //dgvobj.Top = txtobj.Top + txtobj.Height + 5;
            //dgvobj.Left = txtobj.Left;

            //System.Data.DataTable dtl = new System.Data.DataTable();

            ////针对工作岗位的不同来选择不同中的数据库
            //switch (objtype)
            //{ 
            //    case 1://员工
            //        EmployeeManage empmanage = new EmployeeManage();
            //        dtl = empmanage.GetEmployeeInfo(sqlstr);
            //        dgvobj.DataSource = dtl;
            //        break;
            //    case 2://规格型号（品名）
            //        ProductModelManage productmanage = new ProductModelManage();
            //        dtl = productmanage.GetProductModelInfo(sqlstr);
            //        dgvobj.DataSource = dtl;
            //        break;
            //    case 3://工作组
            //        WorkGroupManage wgm = new WorkGroupManage();
            //        dtl = wgm.GetWorkGroupInfo(sqlstr);
            //        dgvobj.DataSource = dtl;
            //        break;
            
            //}
        }

        /// <summary>
        /// 显示警告信息
        /// </summary>
        /// <param name="strmessage"></param>
        public void ShowAlertMessage(string strmessage)
        {
            MessageBox.Show(strmessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="strmessage"></param>
        public void ShowMessage(string strmessage)
        {
            MessageBox.Show(strmessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示错误提示信息
        /// </summary>
        /// <param name="strmessage"></param>
        public void ShowErrorMessage(string strmessage)
        {
            MessageBox.Show(strmessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //得到当前工资计算月份
        public string GetCurrentSalaryMonth()
        {
           // BagWorkDataManage bagmanage = new BagWorkDataManage();
            //得到当前工资计算月份
          //  return bagmanage.GetCurrentSalaryMonth();
            return "";
        }


        /// <summary>
        /// 绑定下拉列表框，通用方法
        /// </summary>
        ///public void cboDataBind(ComboBox obj, int flag)
        ///{
            //CommonManage commonmanage = new CommonManage();

            //switch (flag)
            //{ 
            //    case 1:  //工作岗位
            //        System.Data.DataTable dtl = commonmanage.GetWorkStation();
            //        for (int i = 0; i < dtl.Rows.Count; i++)
            //        {
            //            obj.Items.Add(dtl.Rows[i]["WorkStation"].ToString());
            //        }
            //        break;

            
            //}
           
          
        ///}



        /// <summary>
        /// 禁用网格列排序功能
        /// </summary>
        public void DataGridViewColumnNoOrder(DataGridView datagridobj)
        {
            for (int i = 0; i < datagridobj.Columns.Count; i++)
            {
                datagridobj.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            
            }
        }
    }
}