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
    /// 入库单明细窗口
    /// </summary>
    public partial class frmOutDepotDetailSum : frmBase
    {
        BillManage BillManage = new BillManage(); 
        public frmOutDepotDetailSum()
        {
            InitializeComponent();
            IniControl_CN();
        }

      
        //载入数据
        public void LoadBill()
        {
            string strsql = " where 1=1 ";
            DataTable dtl = BillManage.GetOutDepotSumData(strsql);
            this.gridControl1.DataSource = dtl;

        }

        private void frmBill_Load(object sender, EventArgs e)
        {
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

            //绑定客户
            ClientManage ClientManage = new ClientManage();
            dtl = ClientManage.GetClientData();
            cboSupplier.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboSupplier.Items.Add(dtl.Rows[i]["客户名称"].ToString());
            }


        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
           
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

            if (txtMaterialId.Text != "")
            {
                strSQL = strSQL + " and MaterialId like '" + txtMaterialId.Text.Replace("'", "''") + "%'";
            }


            if (txtBarNo.Text != "")
            {
                strSQL = strSQL + " and BarNo like '" + txtBarNo.Text.Replace("'", "''") + "%'";
            }


            if (txtMaterialName.Text != "")
            {
                strSQL = strSQL + " and MaterialName like '" + txtMaterialName.Text.Replace("'", "''") + "%'";
            }

            if (txtBillAutoID.Text != "")
            {
                strSQL = strSQL + " and BillAutoID like '" + txtBillAutoID.Text.Replace("'", "''") + "%'";
            }

            if (txtRemark.Text != "")
            {
                strSQL = strSQL + " and RemarkHead like '" + txtRemark.Text.Replace("'", "''") + "%'";
            }

            if (txtRemark2.Text != "")
            {
                strSQL = strSQL + " and Remark like '" + txtRemark2.Text.Replace("'", "''") + "%'";
            }



            DataTable dtl = BillManage.GetOutDepotSumData(strSQL);
            this.gridControl1.DataSource = dtl;

           
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel文件|*.XLS|所有文件|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string filename = saveFileDialog1.FileName;
                gridView1.ExportToXls(filename);

                this.ShowMessage("导出成功");
            }
        }

        //重置
        private void button1_Click(object sender, EventArgs e)
        {
            BeginDate.Text = "";
            endDate.Text = "";
            cboDepot.Text = "";
            txtBatchNo.Text = "";
            cboSupplier.Text = "";
            txtBillID.Text = "";
            cboDept.Text = "";
            cboHandlePerson.Text = "";
            cboStorageType.Text = "";
            txtMaterialId.Text = "";
            txtBarNo.Text = "";
            txtMaterialName.Text = "";
            txtBillAutoID.Text = "";
            txtRemark.Text = "";
            txtRemark2.Text = "";

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

        private void tsbExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel文件|*.XLS|所有文件|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string filename = saveFileDialog1.FileName;
                gridView1.ExportToXls(filename);

                this.ShowMessage("导出成功");
            }
        }

        private void exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}