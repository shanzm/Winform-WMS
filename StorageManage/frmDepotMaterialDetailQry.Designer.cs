namespace StorageManage
{
    partial class frmDepotMaterialDetailQry
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepotMaterialDetailQry));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBillDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridStorageTypeGuid = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridInQty = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridInPrice = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridInTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridOutQty = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridOutPrice = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridOutTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridDepotQty = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand13 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridDepotPrice = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand14 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridDepotTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.txtGuid = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMaterialGuid = new System.Windows.Forms.TextBox();
            this.btnSelectMaterial = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.exit = new System.Windows.Forms.ToolStripButton();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBarNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaterialId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnQty = new System.Windows.Forms.Button();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDepot = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 110);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1});
            this.gridControl1.Size = new System.Drawing.Size(908, 549);
            this.gridControl1.TabIndex = 55;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.DarkGray;
            this.bandedGridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.DarkGray;
            this.bandedGridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.DimGray;
            this.bandedGridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.bandedGridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.DarkGray;
            this.bandedGridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.DarkGray;
            this.bandedGridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Gainsboro;
            this.bandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.bandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.bandedGridView1.Appearance.Empty.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.Gray;
            this.bandedGridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.Gray;
            this.bandedGridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.bandedGridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.Gray;
            this.bandedGridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.bandedGridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Black;
            this.bandedGridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("宋体", 9F);
            this.bandedGridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bandedGridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.DarkGray;
            this.bandedGridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.bandedGridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.Silver;
            this.bandedGridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.Silver;
            this.bandedGridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.bandedGridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.Silver;
            this.bandedGridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.Silver;
            this.bandedGridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("宋体", 9F);
            this.bandedGridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.bandedGridView1.Appearance.GroupFooter.Options.UseFont = true;
            this.bandedGridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.DimGray;
            this.bandedGridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.Silver;
            this.bandedGridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.bandedGridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.GroupRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DarkGray;
            this.bandedGridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.DarkGray;
            this.bandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("宋体", 9F);
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.LightSlateGray;
            this.bandedGridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.bandedGridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.OddRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bandedGridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.Preview.BackColor = System.Drawing.Color.Gainsboro;
            this.bandedGridView1.Appearance.Preview.ForeColor = System.Drawing.Color.DimGray;
            this.bandedGridView1.Appearance.Preview.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.Preview.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.Row.Font = new System.Drawing.Font("宋体", 9F);
            this.bandedGridView1.Appearance.Row.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.Row.Options.UseFont = true;
            this.bandedGridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.DimGray;
            this.bandedGridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.DimGray;
            this.bandedGridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("宋体", 9F);
            this.bandedGridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.bandedGridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridBillDate,
            this.gridStorageTypeGuid,
            this.gridInQty,
            this.gridInPrice,
            this.gridInTotal,
            this.gridOutQty,
            this.gridOutPrice,
            this.gridOutTotal,
            this.gridDepotQty,
            this.gridDepotPrice,
            this.gridDepotTotal});
            this.bandedGridView1.CustomizationFormBounds = new System.Drawing.Rectangle(568, 413, 217, 209);
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.bandedGridView1.OptionsView.EnableAppearanceOddRow = true;
            this.bandedGridView1.OptionsView.ShowColumnHeaders = false;
            this.bandedGridView1.OptionsView.ShowFooter = true;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "日期";
            this.gridBand1.Columns.Add(this.gridBillDate);
            this.gridBand1.MinWidth = 20;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.RowCount = 2;
            this.gridBand1.Width = 82;
            // 
            // gridBillDate
            // 
            this.gridBillDate.Caption = "日期";
            this.gridBillDate.FieldName = "BillDate";
            this.gridBillDate.Name = "gridBillDate";
            this.gridBillDate.Visible = true;
            this.gridBillDate.Width = 82;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "摘要";
            this.gridBand2.Columns.Add(this.gridStorageTypeGuid);
            this.gridBand2.MinWidth = 20;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 120;
            // 
            // gridStorageTypeGuid
            // 
            this.gridStorageTypeGuid.Caption = "摘要";
            this.gridStorageTypeGuid.FieldName = "StorageTypeGuid";
            this.gridStorageTypeGuid.Name = "gridStorageTypeGuid";
            this.gridStorageTypeGuid.Visible = true;
            this.gridStorageTypeGuid.Width = 120;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "收入";
            this.gridBand3.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand6,
            this.gridBand7,
            this.gridBand8});
            this.gridBand3.MinWidth = 20;
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 225;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "数量";
            this.gridBand6.Columns.Add(this.gridInQty);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.Width = 75;
            // 
            // gridInQty
            // 
            this.gridInQty.AppearanceHeader.Options.UseTextOptions = true;
            this.gridInQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridInQty.Caption = "收入数量";
            this.gridInQty.DisplayFormat.FormatString = "0.##";
            this.gridInQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridInQty.FieldName = "InQty";
            this.gridInQty.Name = "gridInQty";
            this.gridInQty.SummaryItem.DisplayFormat = "{0:n6}";
            this.gridInQty.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridInQty.Visible = true;
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.Caption = "单价";
            this.gridBand7.Columns.Add(this.gridInPrice);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.Width = 75;
            // 
            // gridInPrice
            // 
            this.gridInPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.gridInPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridInPrice.Caption = "收入单价";
            this.gridInPrice.DisplayFormat.FormatString = "0.######";
            this.gridInPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridInPrice.FieldName = "InPrice";
            this.gridInPrice.Name = "gridInPrice";
            this.gridInPrice.Visible = true;
            // 
            // gridBand8
            // 
            this.gridBand8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand8.Caption = "金额";
            this.gridBand8.Columns.Add(this.gridInTotal);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.Width = 75;
            // 
            // gridInTotal
            // 
            this.gridInTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.gridInTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridInTotal.Caption = "收入金额";
            this.gridInTotal.DisplayFormat.FormatString = "0.######";
            this.gridInTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridInTotal.FieldName = "InTotal";
            this.gridInTotal.Name = "gridInTotal";
            this.gridInTotal.SummaryItem.DisplayFormat = "{0:n6}";
            this.gridInTotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridInTotal.Visible = true;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "发出";
            this.gridBand4.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand9,
            this.gridBand10,
            this.gridBand11});
            this.gridBand4.MinWidth = 20;
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 225;
            // 
            // gridBand9
            // 
            this.gridBand9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand9.Caption = "数量";
            this.gridBand9.Columns.Add(this.gridOutQty);
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.Width = 75;
            // 
            // gridOutQty
            // 
            this.gridOutQty.AppearanceHeader.Options.UseTextOptions = true;
            this.gridOutQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridOutQty.Caption = "发出数量";
            this.gridOutQty.DisplayFormat.FormatString = "0.##";
            this.gridOutQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridOutQty.FieldName = "OutQty";
            this.gridOutQty.Name = "gridOutQty";
            this.gridOutQty.SummaryItem.DisplayFormat = "{0:n6}";
            this.gridOutQty.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridOutQty.Visible = true;
            // 
            // gridBand10
            // 
            this.gridBand10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand10.Caption = "单价";
            this.gridBand10.Columns.Add(this.gridOutPrice);
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.Width = 75;
            // 
            // gridOutPrice
            // 
            this.gridOutPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.gridOutPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridOutPrice.Caption = "发出单价";
            this.gridOutPrice.DisplayFormat.FormatString = "0.######";
            this.gridOutPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridOutPrice.FieldName = "OutPrice";
            this.gridOutPrice.Name = "gridOutPrice";
            this.gridOutPrice.Visible = true;
            // 
            // gridBand11
            // 
            this.gridBand11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand11.Caption = "金额";
            this.gridBand11.Columns.Add(this.gridOutTotal);
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.Width = 75;
            // 
            // gridOutTotal
            // 
            this.gridOutTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.gridOutTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridOutTotal.Caption = "发出金额";
            this.gridOutTotal.DisplayFormat.FormatString = "0.######";
            this.gridOutTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridOutTotal.FieldName = "OutTotal";
            this.gridOutTotal.Name = "gridOutTotal";
            this.gridOutTotal.SummaryItem.DisplayFormat = "{0:n6}";
            this.gridOutTotal.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridOutTotal.Visible = true;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "结存";
            this.gridBand5.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand12,
            this.gridBand13,
            this.gridBand14});
            this.gridBand5.MinWidth = 20;
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.Width = 225;
            // 
            // gridBand12
            // 
            this.gridBand12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand12.Caption = "数量";
            this.gridBand12.Columns.Add(this.gridDepotQty);
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.Width = 75;
            // 
            // gridDepotQty
            // 
            this.gridDepotQty.AppearanceHeader.Options.UseTextOptions = true;
            this.gridDepotQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridDepotQty.Caption = "结存数量";
            this.gridDepotQty.DisplayFormat.FormatString = "0.##";
            this.gridDepotQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridDepotQty.FieldName = "DepotQty";
            this.gridDepotQty.Name = "gridDepotQty";
            this.gridDepotQty.Visible = true;
            // 
            // gridBand13
            // 
            this.gridBand13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand13.Caption = "单价";
            this.gridBand13.Columns.Add(this.gridDepotPrice);
            this.gridBand13.Name = "gridBand13";
            this.gridBand13.Width = 75;
            // 
            // gridDepotPrice
            // 
            this.gridDepotPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.gridDepotPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridDepotPrice.Caption = "结存单价";
            this.gridDepotPrice.DisplayFormat.FormatString = "0.######";
            this.gridDepotPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridDepotPrice.FieldName = "DepotPrice";
            this.gridDepotPrice.Name = "gridDepotPrice";
            this.gridDepotPrice.Visible = true;
            // 
            // gridBand14
            // 
            this.gridBand14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand14.Caption = "金额";
            this.gridBand14.Columns.Add(this.gridDepotTotal);
            this.gridBand14.Name = "gridBand14";
            this.gridBand14.Width = 75;
            // 
            // gridDepotTotal
            // 
            this.gridDepotTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.gridDepotTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridDepotTotal.Caption = "结存金额";
            this.gridDepotTotal.DisplayFormat.FormatString = "0.######";
            this.gridDepotTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridDepotTotal.FieldName = "DepotTotal";
            this.gridDepotTotal.Name = "gridDepotTotal";
            this.gridDepotTotal.Visible = true;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // txtGuid
            // 
            this.txtGuid.Location = new System.Drawing.Point(725, 28);
            this.txtGuid.Name = "txtGuid";
            this.txtGuid.Size = new System.Drawing.Size(36, 21);
            this.txtGuid.TabIndex = 56;
            this.txtGuid.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMaterialGuid);
            this.panel1.Controls.Add(this.btnSelectMaterial);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.txtMaterialName);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtBarNo);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtMaterialId);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnQty);
            this.panel1.Controls.Add(this.txtSpec);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cboDepot);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 110);
            this.panel1.TabIndex = 114;
            // 
            // txtMaterialGuid
            // 
            this.txtMaterialGuid.Location = new System.Drawing.Point(788, 28);
            this.txtMaterialGuid.Name = "txtMaterialGuid";
            this.txtMaterialGuid.Size = new System.Drawing.Size(30, 21);
            this.txtMaterialGuid.TabIndex = 154;
            this.txtMaterialGuid.Visible = false;
            // 
            // btnSelectMaterial
            // 
            this.btnSelectMaterial.Location = new System.Drawing.Point(419, 74);
            this.btnSelectMaterial.Name = "btnSelectMaterial";
            this.btnSelectMaterial.Size = new System.Drawing.Size(43, 22);
            this.btnSelectMaterial.TabIndex = 153;
            this.btnSelectMaterial.Text = "...";
            this.btnSelectMaterial.UseVisualStyleBackColor = true;
            this.btnSelectMaterial.Click += new System.EventHandler(this.btnSelectMaterial_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExport,
            this.exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(908, 25);
            this.toolStrip1.TabIndex = 152;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbExport
            // 
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(79, 22);
            this.tsbExport.Text = "导出EXCEL";
            this.tsbExport.Click += new System.EventHandler(this.tsbExport_Click);
            // 
            // exit
            // 
            this.exit.Image = ((System.Drawing.Image)(resources.GetObject("exit.Image")));
            this.exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(49, 22);
            this.exit.Text = "退出";
            this.exit.Click += new System.EventHandler(this.exit_Click_1);
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.BackColor = System.Drawing.Color.White;
            this.txtMaterialName.Location = new System.Drawing.Point(283, 41);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.ReadOnly = true;
            this.txtMaterialName.Size = new System.Drawing.Size(130, 21);
            this.txtMaterialName.TabIndex = 141;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(241, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 140;
            this.label12.Text = "品名";
            // 
            // txtBarNo
            // 
            this.txtBarNo.BackColor = System.Drawing.Color.White;
            this.txtBarNo.Location = new System.Drawing.Point(78, 74);
            this.txtBarNo.Name = "txtBarNo";
            this.txtBarNo.ReadOnly = true;
            this.txtBarNo.Size = new System.Drawing.Size(130, 21);
            this.txtBarNo.TabIndex = 139;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 138;
            this.label11.Text = "助查码";
            // 
            // txtMaterialId
            // 
            this.txtMaterialId.BackColor = System.Drawing.Color.White;
            this.txtMaterialId.Location = new System.Drawing.Point(283, 74);
            this.txtMaterialId.Name = "txtMaterialId";
            this.txtMaterialId.ReadOnly = true;
            this.txtMaterialId.Size = new System.Drawing.Size(130, 21);
            this.txtMaterialId.TabIndex = 137;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(241, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 136;
            this.label10.Text = "货号";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(625, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 26);
            this.button1.TabIndex = 135;
            this.button1.Text = "重置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnQty
            // 
            this.btnQty.Location = new System.Drawing.Point(625, 38);
            this.btnQty.Name = "btnQty";
            this.btnQty.Size = new System.Drawing.Size(79, 26);
            this.btnQty.TabIndex = 133;
            this.btnQty.Text = "查询";
            this.btnQty.UseVisualStyleBackColor = true;
            this.btnQty.Click += new System.EventHandler(this.btnQty_Click);
            // 
            // txtSpec
            // 
            this.txtSpec.BackColor = System.Drawing.Color.White;
            this.txtSpec.Location = new System.Drawing.Point(485, 41);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.ReadOnly = true;
            this.txtSpec.Size = new System.Drawing.Size(130, 21);
            this.txtSpec.TabIndex = 123;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(443, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 122;
            this.label7.Text = "规格";
            // 
            // cboDepot
            // 
            this.cboDepot.FormattingEnabled = true;
            this.cboDepot.Location = new System.Drawing.Point(78, 42);
            this.cboDepot.Name = "cboDepot";
            this.cboDepot.Size = new System.Drawing.Size(130, 20);
            this.cboDepot.TabIndex = 116;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 115;
            this.label2.Text = "仓库";
            // 
            // frmDepotMaterialDetailQry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 659);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtGuid);
            this.Name = "frmDepotMaterialDetailQry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "存货明细账";
            this.Load += new System.EventHandler(this.frmBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.TextBox txtGuid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQty;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboDepot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBarNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMaterialId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbExport;
        private System.Windows.Forms.ToolStripButton exit;
        private System.Windows.Forms.Button btnSelectMaterial;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridBillDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridStorageTypeGuid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridInQty;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridInPrice;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridInTotal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridOutQty;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridOutPrice;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridOutTotal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridDepotQty;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridDepotPrice;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridDepotTotal;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand11;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand12;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand13;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand14;
        private System.Windows.Forms.TextBox txtMaterialGuid;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
    }
}