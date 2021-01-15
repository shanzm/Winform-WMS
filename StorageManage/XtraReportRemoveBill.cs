using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace StorageManage
{
    public partial class XtraReportRemoveBill : DevExpress.XtraReports.UI.XtraReport
    {
        public DataSet ds;
        public XtraReportRemoveBill(DataSet dataset)
        {
            InitializeComponent();

            IniControl_CN();

            ds = dataset;

            DataBind();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void DataBind()
        {
            this.DataSource = ds;
            lblBillAutoID.Text = ds.Tables[0].Rows[0]["BillAutoID"].ToString();
            lblBillDate.Text = ds.Tables[0].Rows[0]["BillDate"].ToString();
            txtDepotOut.Text = ds.Tables[0].Rows[0]["DepotOut"].ToString();
            txtDepotIN.Text = ds.Tables[0].Rows[0]["DepotIn"].ToString();
            xrTableCell7.Text = ds.Tables[0].Rows[0]["HandlePerson"].ToString();
      


            //明细表
            this.DataSource = ds.Tables[1];
            xrTableCell1.DataBindings.Add("Text", DataSource, "dtlBillDetail.MaterialName");
            xrTableCell2.DataBindings.Add("Text", DataSource, "dtlBillDetail.Spec");
            xrTableCell3.DataBindings.Add("Text", DataSource, "dtlBillDetail.Unit");
            xrTableCell5.DataBindings.Add("Text", DataSource, "dtlBillDetail.Price");
            xrTableCell9.DataBindings.Add("Text", DataSource, "dtlBillDetail.Qty");
            xrTableCell17.DataBindings.Add("Text", DataSource, "dtlBillDetail.Total");
            xrTableCell18.DataBindings.Add("Text", DataSource, "dtlBillDetail.Remark");

            decimal qty = 0;
            decimal total = 0;
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                qty = qty + decimal.Parse(ds.Tables[1].Rows[i]["Qty"].ToString());
                total = total + decimal.Parse(ds.Tables[1].Rows[i]["total"].ToString());
            }

            xrLabel10.Text = qty.ToString();
            xrLabel11.Text = total.ToString();


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
            ////DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraPivotGridLocalizationCHS();
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
