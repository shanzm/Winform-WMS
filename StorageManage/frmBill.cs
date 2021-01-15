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
    /// 出入库单新增窗口
    /// </summary>
    public partial class frmBill : frmBase
    {
        BillManage BillManage = new BillManage();
        public static frmBill frmbill;
        public frmBill()
        {
            InitializeComponent();
            frmbill = this;
            IniControl_CN();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserRightManage urm = new UserRightManage();
            if (urm.IsOperateRight(SysParams.UserID, "lkdxz") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }

            frmBillAdd frmBillAdd = new frmBillAdd();
            frmBillAdd.BillAdd("I",this);
        }

        public void LoadBill()
        {
            string strsql = " where flag='I' and BillDate>='" + BeginDate.Text + " 00:00:00'" + " and BillDate<='" + endDate.Text + " 23:59:59'";

            DataTable dtl = BillManage.GetBillDataImport_CN(strsql);
            this.gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Width = 95;
            gridView1.Columns[8].Width = 150; //供应商


           
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            BeginDate.Text = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
            endDate.Text = DateTime.Now.ToShortDateString();


            LoadBill();

            //绑定仓库
            DepotManage DepotManage = new DepotManage();
            DataTable dtl = DepotManage.GetDepotData();
            cboDepot.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboDepot.Items.Add(dtl.Rows[i]["仓库名称"].ToString());
            }


            //绑定类型
            dtl = DepotManage.GetStorageTypeData("I");
            cboStorageType.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboStorageType.Items.Add(dtl.Rows[i]["StorageTypeName"].ToString());
            }


            //绑定部门
            DeptManage DeptManage = new DeptManage();
            dtl = DeptManage.GetDeptData();
            cboDept.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboDept.Items.Add(dtl.Rows[i]["部门名称"].ToString());
            }


            //绑定经手人
            EmployeeManage EmployeeManage = new EmployeeManage();
            dtl = EmployeeManage.GetEmployeeData();
            cboHandlePerson.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboHandlePerson.Items.Add(dtl.Rows[i]["员工姓名"].ToString());
            }


            //绑定供应商
            SupplierManage SupplierManage = new SupplierManage();
            dtl = SupplierManage.GetSupplierData();
            cboSupplier.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboSupplier.Items.Add(dtl.Rows[i]["供应商名称"].ToString());
            }


        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbedit_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmBillAdd frmBillAdd = new frmBillAdd();
                frmBillAdd.BillEdit(guid, "I",this);
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmBillAdd frmBillAdd = new frmBillAdd();
                frmBillAdd.BillEdit(guid, "I",this);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                DataRowView dr = (DataRowView)(gridView1.GetFocusedRow());
                if (dr[13].ToString() == "")
                {

                    if (MessageBox.Show("确定删除该数据！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        dr = (DataRowView)(gridView1.GetFocusedRow());
                        BillManage.DeleteBill(dr[0].ToString());

                        gridView1.DeleteSelectedRows();
                        this.ShowMessage("删除成功!");
                    }
                }
                else
                {
                    this.ShowAlertMessage("此单据已审核，不可以删除!!");
                }
            }
        }

        private void btnQty_Click(object sender, EventArgs e)
        {
            //查询
            string strSQL = " where flag='I' ";
            if (BeginDate.Text != "")
            {
                strSQL = strSQL + " and BillDate>='" + BeginDate.Text.Replace("'", "''") + " 00:00:00'"; 
            }

            if (endDate.Text  != "")
            {
                strSQL = strSQL + " and BillDate<='" + endDate.Text.Replace("'", "''") + " 23:59:59'";
            }

            if (cboDepot.Text != "")
            {
                strSQL = strSQL + " and DepotGuid like '" + cboDepot.Text.Replace("'", "''") + "%'";
            }

            if (txtBatchNo.Text != "")
            {
                strSQL = strSQL + " and BatchNo like '" + txtBatchNo.Text.Replace("'", "''") + "%'";
            }

            if (cboSupplier.Text != "")
            {
                strSQL = strSQL + " and SupplierGuid like '" + cboSupplier.Text.Replace("'", "''") + "%'";
            }

            if (txtBillID.Text != "")
            {
                strSQL = strSQL + " and BillID like '" + txtBillID.Text.Replace("'", "''") + "%'";
            }

            if (cboDept.Text != "")
            {
                strSQL = strSQL + " and DeptGuid like '" + cboDept.Text.Replace("'", "''") + "%'";
            }

            if (cboHandlePerson.Text != "")
            {
                strSQL = strSQL + " and HandlePerson like '" + cboHandlePerson.Text.Replace("'", "''") + "%'";
            }

            if (cboStorageType.Text != "")
            {
                strSQL = strSQL + " and StorageTypeGuid like '" + cboStorageType.Text.Replace("'", "''") + "%'";
            }


            DataTable dtl = BillManage.GetBillDataImport_CN(strSQL);
            this.gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Width = 95;
            gridView1.Columns[8].Width = 150; //供应商
        }

        #region 控件汉化
        /// <summary>
        /// 将控件汉化
        /// </summary>
        private void IniControl_CN()
        {

            #region szm:报错注释
            //DevExpress.XtraBars.Localization.BarLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraBarsLocalizationCHS();
            ////DevExpress.XtraCharts.Localization.ChartLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraChartsLocalizationCHS();
            //DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraEditorsLocalizationCHS();
            //DevExpress.XtraGrid.Localization.GridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraGridLocalizationCHS();
            //DevExpress.XtraLayout.Localization.LayoutLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraLayoutLocalizationCHS();
            //DevExpress.XtraNavBar.NavBarLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraNavBarLocalizationCHS(); 
            #endregion
            //DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraPivotGridLocalizationCHS();
            //DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraPrintingLocalizationCHS();
            //DevExpress.XtraReports.Localization.ReportLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraReportsLocalizationCHS();
            //DevExpress.XtraRichTextEdit.Localization.XtraRichTextEditLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraRichTextEditLocalizationCHS();
            //DevExpress.XtraScheduler.Localization.SchedulerLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSchedulerLocalizationCHS();
            //DevExpress.XtraScheduler.Localization.SchedulerExtensionsLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSchedulerExtensionsLocalizationCHS();
            //DevExpress.XtraSpellChecker.Localization.SpellCheckerLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraSpellCheckerLocalizationCHS();
            //DevExpress.XtraTreeList.Localization.TreeListLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraTreeListLocalizationCHS();
            //DevExpress.XtraVerticalGrid.Localization.VGridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraVerticalGridLocalizationCHS();
            //DevExpress.XtraWizard.Localization.WizardLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraWizardLocalizationCHS();
        }
        #endregion
    }
}