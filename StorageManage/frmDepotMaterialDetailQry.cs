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
    /// 存货明细账
    /// </summary>
    public partial class frmDepotMaterialDetailQry : frmBase
    {
        BillManage BillManage = new BillManage();
        MaterialManage MaterialManage = new MaterialManage();
        public frmDepotMaterialDetailQry()
        {
            InitializeComponent();
            IniControl_CN();
        }

      

        private void frmBill_Load(object sender, EventArgs e)
        {
          

            //绑定仓库
            DepotManage DepotManage = new DepotManage();
            DataTable dtl = DepotManage.GetDepotData();
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboDepot.Items.Add(dtl.Rows[i]["仓库名称"].ToString());
            }

            cboDepot.SelectedIndex = 0;
            //cboDepot.Text = "仓库";
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (bandedGridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(bandedGridView1.GetFocusedRow())).Row[0].ToString().Trim();
                string flag = ((DataRowView)(bandedGridView1.GetFocusedRow())).Row[3].ToString().Trim();

                switch (flag)
                {
                    case "I":  //入库
                        frmBillAdd frmBillAdd = new frmBillAdd();
                        frmBillAdd.SendFlag = 1;
                        frmBillAdd.BillEdit(guid, "I",this);
                        break;
                    case "E": //出库
                        frmBillAdd frmBillAdd2 = new frmBillAdd();
                        frmBillAdd2.SendFlag = 1;
                        frmBillAdd2.BillEdit(guid, "E",this);
                        break;
                    case "RI"://调拨入
                        frmRemoveBillAdd frmRemoveBillAdd = new frmRemoveBillAdd();
                        frmRemoveBillAdd.SendFlag = 1;
                        frmRemoveBillAdd.BillEdit(guid,this);
                        break;
                    case "RE"://调拨出
                        frmRemoveBillAdd frmRemoveBillAdd2 = new frmRemoveBillAdd();
                        frmRemoveBillAdd2.SendFlag = 1;
                        frmRemoveBillAdd2.BillEdit(guid,this);
                        break;
                    case "SI"://盘盈
                        frmCheckBillAdd frmCheckBillAdd = new frmCheckBillAdd();
                        frmCheckBillAdd.SendFlag = 1;
                        frmCheckBillAdd.BillEdit(guid,this);
                        break;
                    case "SE"://盘亏
                        frmCheckBillAdd frmCheckBillAdd2 = new frmCheckBillAdd();
                        frmCheckBillAdd2.SendFlag = 1;
                        frmCheckBillAdd2.BillEdit(guid,this);
                        break;

                }
            }
          
        }

    
        //库存查询
        private void btnQty_Click(object sender, EventArgs e)
        {
            if (cboDepot.Text == "")
            {
                this.ShowAlertMessage("请选择仓库!");
                return;
            }
            if (txtMaterialGuid.Text.Trim() == "")
            {
                this.ShowAlertMessage("请选择货品!");
                return;
            }

            DataTable dtl = BillManage.sp_GetDepotMaterialDetailSum(cboDepot.Text,txtMaterialGuid.Text);
            this.gridControl1.DataSource = dtl;

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel文件|*.XLS|所有文件|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string filename = saveFileDialog1.FileName;
                bandedGridView1.ExportToXls(filename);

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

            #region szm:注释
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
                bandedGridView1.ExportToXls(filename);

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