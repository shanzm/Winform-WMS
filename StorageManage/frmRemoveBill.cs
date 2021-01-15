using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StorageManageLibrary;
using DevExpress.Utils;

namespace StorageManage
{
    /// <summary>
    /// 调拨单新增窗口
    /// </summary>
    public partial class frmRemoveBill : frmBase
    {
        RemoveBillManage RemoveBillManage = new RemoveBillManage();
        public static frmRemoveBill frmremovebill;
        public frmRemoveBill()
        {
            InitializeComponent();
            frmremovebill = this;
            IniControl_CN();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserRightManage urm = new UserRightManage();
            if (urm.IsOperateRight(SysParams.UserID, "dbdxz") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }


            frmRemoveBillAdd frmRemoveBillAdd = new frmRemoveBillAdd();
            frmRemoveBillAdd.BillAdd(this);
        }

        public void LoadBill()
        {
            string strsql = " where  BillDate>='" + BeginDate.Text + " 00:00:00'" + " and BillDate<='" + endDate.Text + " 23:59:59'";

            DataTable dtl = RemoveBillManage.GetRemoveBillData_CN(strsql);
            this.gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;
            gridView1.Columns[7].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns[7].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns[9].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns[9].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
           
        }

        private void frmRemoveBill_Load(object sender, EventArgs e)
        {
            BeginDate.Text = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
            endDate.Text = DateTime.Now.ToShortDateString();

            LoadBill();

            //绑定调出仓库
            DepotManage DepotManage = new DepotManage();
            DataTable dtl = DepotManage.GetDepotData();
            cboDepotOut.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboDepotOut.Items.Add(dtl.Rows[i]["仓库名称"].ToString());
            }


            //绑定调入仓库
            dtl = DepotManage.GetDepotData();
            cboDepotIn.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboDepotIn.Items.Add(dtl.Rows[i]["仓库名称"].ToString());
            }

            //绑定经手人
            EmployeeManage EmployeeManage = new EmployeeManage();
            dtl = EmployeeManage.GetEmployeeData();
            cboHandlePerson.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboHandlePerson.Items.Add(dtl.Rows[i]["员工姓名"].ToString());
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

                frmRemoveBillAdd frmRemoveBillAdd = new frmRemoveBillAdd();
                frmRemoveBillAdd.BillEdit(guid,this);
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                frmRemoveBillAdd frmRemoveBillAdd = new frmRemoveBillAdd();
                frmRemoveBillAdd.BillEdit(guid,this);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                DataRowView dr = (DataRowView)(gridView1.GetFocusedRow());
                if (dr[8].ToString() == "")
                {

                    if (MessageBox.Show("确定删除该数据！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        dr = (DataRowView)(gridView1.GetFocusedRow());
                        RemoveBillManage.DeleteRemoveBill(dr[0].ToString());

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
            string strSQL = " where 1=1 ";
            if (BeginDate.Text != "")
            {
                strSQL = strSQL + " and BillDate>='" + BeginDate.Text.Replace("'", "''") + " 00:00:00'"; 
            }

            if (endDate.Text  != "")
            {
                strSQL = strSQL + " and BillDate<='" + endDate.Text.Replace("'", "''") + " 23:59:59'";
            }

            if (cboDepotOut.Text != "")
            {
                strSQL = strSQL + " and DepotOut like '" + cboDepotOut.Text.Replace("'", "''") + "%'";
            }

            if (cboDepotIn.Text != "")
            {
                strSQL = strSQL + " and DepotIn like '" + cboDepotIn.Text.Replace("'", "''") + "%'";
            }

            if (txtBillID.Text != "")
            {
                strSQL = strSQL + " and BillID like '" + txtBillID.Text.Replace("'", "''") + "%'";
            }

            if (cboHandlePerson.Text != "")
            {
                strSQL = strSQL + " and HandlePerson like '" + cboHandlePerson.Text.Replace("'", "''") + "%'";
            }

            if (txtSpec.Text != "")
            {
                strSQL = strSQL + " and RemoveBillGuid  in (select RemoveBillGuid from RemoveBillDetail where Spec like '" + txtSpec.Text.Replace("'", "''") + "%')";
            }

            if (txtMaterialName.Text != "")
            {
                strSQL = strSQL + " and RemoveBillGuid  in (select RemoveBillGuid from RemoveBillDetail where MaterialName like '" + txtMaterialName.Text.Replace("'", "''") + "%')";
            } 

            DataTable dtl = RemoveBillManage.GetRemoveBillData_CN(strSQL);
            this.gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;
            gridView1.Columns[7].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns[7].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            gridView1.Columns[9].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns[9].DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
        }

        #region 控件汉化
        /// <summary>
        /// 将控件汉化
        /// </summary>
        private void IniControl_CN()
        {

            //DevExpress.XtraBars.Localization.BarLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraBarsLocalizationCHS();
            ////DevExpress.XtraCharts.Localization.ChartLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraChartsLocalizationCHS();
            //DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraEditorsLocalizationCHS();
            //DevExpress.XtraGrid.Localization.GridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraGridLocalizationCHS();
            //DevExpress.XtraLayout.Localization.LayoutLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraLayoutLocalizationCHS();
            //DevExpress.XtraNavBar.NavBarLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraNavBarLocalizationCHS();
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

        private void gridControl1_Click(object sender, EventArgs e)
        {
           

            //显示出明细数据
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();

                //得到明细表数据
                DataTable dtlDetail = RemoveBillManage.GetRemoveBillDetailData(guid);
                this.gridControl2.DataSource = dtlDetail;
                gridMaterialGuid.Visible = false;
                gridMaterialId.Visible = false;
            
            }
        }
    }
}