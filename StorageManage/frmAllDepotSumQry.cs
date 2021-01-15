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
    /// 各仓库汇总表
    /// </summary>
    public partial class frmAllDepotSumQry : frmBase
    {
        BillManage BillManage = new BillManage();
        MaterialManage MaterialManage = new MaterialManage();
        public frmAllDepotSumQry()
        {
            InitializeComponent();
            IniControl_CN();
        }

      

        private void frmBill_Load(object sender, EventArgs e)
        {
            BeginDate.Text = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
            endDate.Text = DateTime.Now.ToShortDateString();


        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

      
        //库存查询
        private void btnQty_Click(object sender, EventArgs e)
        {

            if (txtMaterialGuid.Text.Trim() == "")
            {
                this.ShowAlertMessage("请选择货品!");
                return;
            }

            if (BeginDate.Text == "")
            {
                this.ShowAlertMessage("请选择开始日期!");
                return;
            }

            if (endDate.Text == "")
            {
                this.ShowAlertMessage("请选择截止日期!");
                return;
            }

            DataTable dtl = BillManage.sp_GetAllDepotSum(txtMaterialGuid.Text,BeginDate.Text,endDate.Text);
            this.gridControl1.DataSource = dtl;

            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;
        
            for (int i = 5; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Width = 90;
                gridView1.Columns[i].MinWidth = 80;
            }

            gridView1.Columns[2].Caption = "货品名称";
            gridView1.Columns[3].Caption = "助查码";
            gridView1.Columns[4].Caption = "规格";

            gridView1.Columns[2].MinWidth = 50;
            gridView1.Columns[3].MinWidth = 50;
            gridView1.Columns[4].MinWidth =50;

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

            txtMaterialGuid.Text = "";
            txtBarNo.Text = "";
            txtMaterialName.Text = "";
            txtMaterialId.Text = "";
            txtSpec.Text = "";
        
        }


        #region 控件汉化
        /// <summary>
        /// 将控件汉化
        /// </summary>
        private void IniControl_CN()
        {

            #region szm：报错，注释
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

        //选择料件
        private void btnSelectMaterial_Click(object sender, EventArgs e)
        {
            frmSelectMaterial frmSelectMaterial = new frmSelectMaterial();
            frmSelectMaterial.Tag = "";
            frmSelectMaterial.ShowDialog();

            //选择的料件填充
            if (frmSelectMaterial.Tag.ToString() != "")
            {
                //得到选择的料件guid，然后得到
                Material material = MaterialManage.GetMaterialByGuid(frmSelectMaterial.Tag.ToString());

                //填充数据
                txtMaterialGuid.Text= material.MaterialGuid;
                txtBarNo.Text = material.BarNo;
                txtMaterialName.Text = material.MaterialName;
                txtMaterialId.Text = material.MaterialId;
                txtSpec.Text = material.Spec;
               
            }
        }
    }
}