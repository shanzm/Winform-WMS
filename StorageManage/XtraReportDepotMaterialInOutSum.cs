using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace StorageManage
{
    /// <summary>
    /// 收发存汇总表报表
    /// </summary>
    public partial class XtraReportDepotMaterialInOutSum : DevExpress.XtraReports.UI.XtraReport
    {

        public XtraReportDepotMaterialInOutSum(DataTable dtl ,string BillDate, string Depot, string StorageTypeGuid,string BarNo,string MaterialName,string Spec,string producttype)
        {
            InitializeComponent();
            IniControl_CN();

            DataBind(dtl, BillDate, Depot, StorageTypeGuid, BarNo, MaterialName, Spec, producttype);

        }

        private void DataBind(DataTable dtl, string BillDate, string Depot, string StorageTypeGuid, string BarNo, string MaterialName, string Spec, string producttype)
        {
            xrTableCell1.Text = Depot;//仓库
            xrTableCell3.Text = BillDate;//日期
            xrTableCell4.Text = BarNo;//助查码
            xrTableCell5.Text = MaterialName;//品名
            xrTableCell6.Text = Spec;//规格
            xrTableCell9.Text = producttype;//货品类型


            //明细表
            //明细表
            this.DataSource = dtl;
            xrTableCell11.DataBindings.Add("Text", DataSource, "MaterialName");
            xrTableCell7.DataBindings.Add("Text", DataSource, "Spec");
            xrTableCell13.DataBindings.Add("Text", DataSource, "StartQtySum");
            xrTableCell131.DataBindings.Add("Text", DataSource, "StartTotalSum");
            xrTableCell14.DataBindings.Add("Text", DataSource, "InQtySum");
            xrTableCell141.DataBindings.Add("Text", DataSource, "InTotalSum");
            xrTableCell15.DataBindings.Add("Text", DataSource, "OutQtySum");
            xrTableCell151.DataBindings.Add("Text", DataSource, "OutTotalSum");
            xrTableCell16.DataBindings.Add("Text", DataSource, "DepotQtySum");
            xrTableCell161.DataBindings.Add("Text", DataSource, "DepotTotalSum");


            xrTableCell19.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", DataSource, "StartQtySum") });
            XRSummary XrSummary1 = new XRSummary();
            XrSummary1.FormatString = "{0}";
            XrSummary1.Func = SummaryFunc.Sum;
            XrSummary1.Running = SummaryRunning.Report;
            xrTableCell19.Summary = XrSummary1;



            xrTableCell191.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", DataSource, "StartTotalSum" )});
            XRSummary XrSummary2 = new XRSummary();
           // XrSummary2.FormatString = "{0}";
            XrSummary2.Func = SummaryFunc.Sum;
            XrSummary2.Running = SummaryRunning.Report;
            xrTableCell191.Summary = XrSummary2;


            xrTableCell29.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", DataSource, "InQtySum" )});
            XRSummary XrSummary3 = new XRSummary();
            XrSummary3.FormatString = "{0}";
            XrSummary3.Func = SummaryFunc.Sum;
            XrSummary3.Running = SummaryRunning.Report;
            xrTableCell29.Summary = XrSummary3;


            xrTableCell291.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", DataSource, "InTotalSum") });
            XRSummary XrSummary4 = new XRSummary();
            //XrSummary4.FormatString = "{0}";
            XrSummary4.Func = SummaryFunc.Sum;
            XrSummary4.Running = SummaryRunning.Report;
            xrTableCell291.Summary = XrSummary4;


            xrTableCell39.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", DataSource, "OutQtySum") });
            XRSummary XrSummary5 = new XRSummary();
            XrSummary5.FormatString = "{0}";
            XrSummary5.Func = SummaryFunc.Sum;
            XrSummary5.Running = SummaryRunning.Report;
            xrTableCell39.Summary = XrSummary5;

            xrTableCell391.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", DataSource, "OutTotalSum") });
            XRSummary XrSummary6 = new XRSummary();
            //XrSummary6.FormatString = "{0}";
            XrSummary6.Func = SummaryFunc.Sum;
            XrSummary6.Running = SummaryRunning.Report;
            xrTableCell391.Summary = XrSummary6;

            xrTableCell49.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", DataSource, "DepotQtySum") });
            XRSummary XrSummary7 = new XRSummary();
            XrSummary7.FormatString = "{0}";
            XrSummary7.Func = SummaryFunc.Sum;
            XrSummary7.Running = SummaryRunning.Report;
            xrTableCell49.Summary = XrSummary7;

            xrTableCell491.DataBindings.AddRange(new XRBinding[] { new XRBinding("Text", DataSource, "DepotTotalSum") });
            XRSummary XrSummary8 = new XRSummary();
            //XrSummary8.FormatString = "{0}";
            XrSummary8.Func = SummaryFunc.Sum;
            XrSummary8.Running = SummaryRunning.Report;
            xrTableCell491.Summary = XrSummary8;



            ////计算汇总值
            //int Qty1=0;
            //decimal total1=0;
            //int Qty2=0;
            //decimal total2=0;
            //int Qty3=0;
            //decimal total3=0;
            //int Qty4=0;
            //decimal total4=0;
            //for (int i = 0; i < dtl.Rows.Count;i++ )
            //{
            //    Qty1 = Qty1 + int.Parse(dtl.Rows[i]["StartQtySum"].ToString());
            //    total1 = total1 + decimal.Parse(dtl.Rows[i]["StartTotalSum"].ToString());
            //    Qty2 = Qty2 + int.Parse(dtl.Rows[i]["InQtySum"].ToString());
            //    total2 = total2 + decimal.Parse(dtl.Rows[i]["InTotalSum"].ToString());
            //    Qty3 = Qty3 + int.Parse(dtl.Rows[i]["OutQtySum"].ToString());
            //    total3 = total3 + decimal.Parse(dtl.Rows[i]["OutTotalSum"].ToString());
            //    Qty4 = Qty4 + int.Parse(dtl.Rows[i]["DepotQtySum"].ToString());
            //    total4 = total4 + decimal.Parse(dtl.Rows[i]["DepotTotalSum"].ToString());
            //}
            //xrTableCell19.Text = Qty1.ToString() ;
            //xrTableCell191.Text = total1.ToString();
            //xrTableCell29.Text = Qty2.ToString();
            //xrTableCell291.Text = total2.ToString();
            //xrTableCell39.Text = Qty3.ToString();
            //xrTableCell391.Text = total3.ToString();
            //xrTableCell49.Text = Qty4.ToString();
            //xrTableCell491.Text = total4.ToString();
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
