namespace StorageManage
{
    partial class frmDepotMaterialStatusQty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepotMaterialStatusQty));
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridDepotName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridQTYSum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridTotalSum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.exit = new System.Windows.Forms.ToolStripButton();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(12, 105);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(484, 296);
            this.gridControl2.TabIndex = 63;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupFooter.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridDepotName,
            this.gridQTYSum,
            this.gridTotalSum,
            this.gridPrice});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridDepotName
            // 
            this.gridDepotName.Caption = "仓库";
            this.gridDepotName.FieldName = "DepotName";
            this.gridDepotName.Name = "gridDepotName";
            this.gridDepotName.Visible = true;
            this.gridDepotName.VisibleIndex = 0;
            this.gridDepotName.Width = 110;
            // 
            // gridQTYSum
            // 
            this.gridQTYSum.Caption = "数量";
            this.gridQTYSum.DisplayFormat.FormatString = "0.##";
            this.gridQTYSum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridQTYSum.FieldName = "QTYSum";
            this.gridQTYSum.Name = "gridQTYSum";
            this.gridQTYSum.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridQTYSum.Visible = true;
            this.gridQTYSum.VisibleIndex = 1;
            this.gridQTYSum.Width = 77;
            // 
            // gridTotalSum
            // 
            this.gridTotalSum.Caption = "金额";
            this.gridTotalSum.FieldName = "TotalSum";
            this.gridTotalSum.Name = "gridTotalSum";
            this.gridTotalSum.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridTotalSum.Visible = true;
            this.gridTotalSum.VisibleIndex = 2;
            this.gridTotalSum.Width = 84;
            // 
            // gridPrice
            // 
            this.gridPrice.Caption = "平均价";
            this.gridPrice.DisplayFormat.FormatString = "0.######";
            this.gridPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridPrice.FieldName = "Price";
            this.gridPrice.Name = "gridPrice";
            this.gridPrice.Visible = true;
            this.gridPrice.VisibleIndex = 3;
            this.gridPrice.Width = 80;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(506, 25);
            this.toolStrip1.TabIndex = 153;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // exit
            // 
            this.exit.Image = ((System.Drawing.Image)(resources.GetObject("exit.Image")));
            this.exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(49, 22);
            this.exit.Text = "退出";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.BackColor = System.Drawing.Color.White;
            this.txtMaterialName.Location = new System.Drawing.Point(70, 40);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.ReadOnly = true;
            this.txtMaterialName.Size = new System.Drawing.Size(130, 21);
            this.txtMaterialName.TabIndex = 157;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 156;
            this.label12.Text = "品名";
            // 
            // txtSpec
            // 
            this.txtSpec.BackColor = System.Drawing.Color.White;
            this.txtSpec.Location = new System.Drawing.Point(284, 40);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.ReadOnly = true;
            this.txtSpec.Size = new System.Drawing.Size(130, 21);
            this.txtSpec.TabIndex = 155;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 154;
            this.label7.Text = "规格";
            // 
            // txtUnit
            // 
            this.txtUnit.BackColor = System.Drawing.Color.White;
            this.txtUnit.Location = new System.Drawing.Point(70, 70);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(130, 21);
            this.txtUnit.TabIndex = 161;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 160;
            this.label1.Text = "单位";
            // 
            // txtBarNo
            // 
            this.txtBarNo.BackColor = System.Drawing.Color.White;
            this.txtBarNo.Location = new System.Drawing.Point(284, 70);
            this.txtBarNo.Name = "txtBarNo";
            this.txtBarNo.ReadOnly = true;
            this.txtBarNo.Size = new System.Drawing.Size(130, 21);
            this.txtBarNo.TabIndex = 159;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 158;
            this.label2.Text = "助查码";
            // 
            // frmDepotMaterialStatusQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 401);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBarNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaterialName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSpec);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gridControl2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDepotMaterialStatusQty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "货品库存查看";
            this.Load += new System.EventHandler(this.frmSelectMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridDepotName;
        private DevExpress.XtraGrid.Columns.GridColumn gridQTYSum;
        private DevExpress.XtraGrid.Columns.GridColumn gridTotalSum;
        private DevExpress.XtraGrid.Columns.GridColumn gridPrice;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton exit;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarNo;
        private System.Windows.Forms.Label label2;
    }
}