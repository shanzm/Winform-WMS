using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using StorageManageLibrary;

namespace StorageManage
{
    /// <summary>
    /// 单据新增
    /// </summary>
    public partial class frmBillAdd : frmBase
    {
        MaterialManage MaterialManage = new MaterialManage();
        BillManage bm = new BillManage();
        BillAutoIDManage BillAutoIDManage = new BillAutoIDManage();
        DataSet ds = new DataSet();
        public int SendFlag = 0;//1：是从入库明细单处进入  0: 从出入库单处进入
        public frmBillAdd()
        {
            InitializeComponent();
        }

     
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            frmSelectMaterial frmSelectMaterial = new frmSelectMaterial();
            frmSelectMaterial.Tag = "";
            frmSelectMaterial.ShowDialog();

            //选择的料件填充
            if (frmSelectMaterial.Tag.ToString() != "")
            { 
                 //得到选择的料件guid，然后得到
                Material material= MaterialManage.GetMaterialByGuid(frmSelectMaterial.Tag.ToString());
               
                //填充数据
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue(gridMaterialGuid, material.MaterialGuid);
                gridView1.SetFocusedRowCellValue(gridMaterialID, material.MaterialId);
                gridView1.SetFocusedRowCellValue(gridMaterialName, material.MaterialName);
                gridView1.SetFocusedRowCellValue(gridClassName, material.ClassId);
                gridView1.SetFocusedRowCellValue(gridBarNo, material.BarNo);
                gridView1.SetFocusedRowCellValue(gridSpec , material.Spec);
                gridView1.SetFocusedRowCellValue(gridUnit, material.Unit);
                gridView1.SetFocusedRowCellValue(gridRemark , material.Remark);

                //出库单货品是否自动计算平均单价
                if (this.Text == "出库单新增" || this.Text == "出库单编辑")
                {
                    string AutoFillBillOutPrice = System.Configuration.ConfigurationSettings.AppSettings["IsAutoFillBillOutPrice"].ToString(); ;
                    if (AutoFillBillOutPrice == "true")
                    {
                        decimal priceAVG = 0;
                        string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();
                        //得到此料件在某个仓库中的平均价,写入单价列中
                        priceAVG = bm.sp_GetMaterialPrice(guid, cboDepot.Text);
                        gridView1.SetFocusedRowCellValue(gridPrice, priceAVG);
                    }
                }
            }
        }

        //新增
        public  void BillAdd(string flag,IWin32Window ifrm)
        {
            txtGuid.Text = Guid.NewGuid().ToString();
            txtAutoBillID.Text = GetAutoId(flag);
            txtCreateDate.Text = DateTime.Now.ToString();
            txtCreatePerson.Text = SysParams.UserName;

            this.Tag = flag;// flag 中I:入库单 E：出库单
            if (flag == "I")
            {
                //入库
                cboBearing.Items.Clear();
                cboBearing.Items.Add("");
                cboBearing.Items.Add("收货");
                cboBearing.Items.Add("退货");
                this.Text = "入库单新增";
                label5.Text = "供应商";
               

                CboBind("I");

                cboStorageType.Text = "原料采购入库";
            }
            else
            {
                //出库
                cboBearing.Items.Clear();
                cboBearing.Items.Add("");
                cboBearing.Items.Add("发货");
                cboBearing.Items.Add("退货");
                this.Text = "出库单新增";
                label5.Text = "客户";
               

                CboBind("E");

                cboStorageType.Text = "销售发货出库";
                cboDepot.Text = "仓库";

                

                
            }

            //反审不可用,审核可用
            tsbCheckNoPass.Enabled = false;
            tsbCheckPass.Enabled = false;
           
         
            
            this.gridControl1.DataSource = IniBindTable();
            gridMaterialGuid.Visible = false;


            this.Show(ifrm);
        }



        //修改
        public void BillEdit(string billguid,string flag,IWin32Window ifrm)
        {
            txtGuid.Text = billguid;

            if (flag == "I")
            {
                //入库
                cboBearing.Items.Clear();
                cboBearing.Items.Add("");
                cboBearing.Items.Add("收货");
                cboBearing.Items.Add("退货");
                this.Text = "入库单编辑";
                label5.Text = "供应商";

                //加载选择项
                CboBind("I");
            }
            else
            {
                //出库
                cboBearing.Items.Clear();
                cboBearing.Items.Add("");
                cboBearing.Items.Add("发货");
                cboBearing.Items.Add("退货");
                this.Text = "出库单编辑";
                label5.Text = "客户";

                //加载选择项
                CboBind("E");

                cboDepot.Text = "仓库";

            
            }


           
        

            //得到主表数据
            DataTable dtl = bm.GetBillData(txtGuid.Text);
            txtGuid.Text = dtl.Rows[0]["billGuid"].ToString();
            dateTimePicker1.Text = dtl.Rows[0]["BillDate"].ToString();
            txtBillID.Text = dtl.Rows[0]["BillDate"].ToString();
            txtBatchNo.Text = dtl.Rows[0]["BatchNo"].ToString();
            cboDepot.Text = dtl.Rows[0]["DepotGuid"].ToString();
            cboDept.Text = dtl.Rows[0]["DeptGuid"].ToString();
            txtRemark.Text = dtl.Rows[0]["Remark"].ToString();
            cboSupplier.Text = dtl.Rows[0]["SupplierGuid"].ToString();
            cboStorageType.Text = dtl.Rows[0]["StorageTypeGuid"].ToString();
            cboBearing.Text = dtl.Rows[0]["Bearing"].ToString();
            cboHandlePerson.Text = dtl.Rows[0]["HandlePerson"].ToString();
            txtAutoBillID.Text = dtl.Rows[0]["BillAutoID"].ToString();
            txtBillID.Text = dtl.Rows[0]["BillID"].ToString();
            this.Tag = flag;// flag 中I:入库单 E：出库单

            txtCreateDate.Text = dtl.Rows[0]["CreateDate"].ToString();
            txtCreatePerson.Text = dtl.Rows[0]["CreatePerson"].ToString();
            if (dtl.Rows[0]["CheckDate"].ToString().Contains("1900-01-01")==false)
            {
                txtCheckDate.Text = dtl.Rows[0]["CheckDate"].ToString();
            }
            else
            {
                txtCheckDate.Text = "";
            }
            txtCheckPerson.Text = dtl.Rows[0]["CheckPerson"].ToString();

            if (dtl.Rows[0]["CheckPerson"].ToString() != "")
            {
                //设置为：已审核
                SetControlEnable(1);
            }
            else
            {
                //设置为：没有审核
                SetControlEnable(0);
            }
           
            //得到明细表数据
            DataTable dtlDetail = bm.GetBillDetailData(txtGuid.Text);
            this.gridControl1.DataSource = dtlDetail;
            gridMaterialGuid.Visible = false;
            gridMaterialID.Visible = false;

            ds.Tables.Add(dtl.Copy());
            ds.Tables[0].TableName = "dtlBill";
            ds.Tables.Add(dtlDetail.Copy());
            ds.Tables[1].TableName = "dtlBillDetail";


            this.Show(ifrm);
        }

        private void CboBind(string flag)
        { 
            //绑定仓库
            DepotManage DepotManage = new DepotManage();
            DataTable dtl = DepotManage.GetDepotData();
            cboDepot.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboDepot.Items.Add(dtl.Rows[i]["仓库名称"].ToString());
            }
           
            
            //绑定类型
            dtl = DepotManage.GetStorageTypeData(flag);
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
            if (flag == "I")
            {
                SupplierManage SupplierManage = new SupplierManage();
                dtl = SupplierManage.GetSupplierData();
                cboSupplier.Items.Add("");
                for (int i = 0; i < dtl.Rows.Count; i++)
                {
                    cboSupplier.Items.Add(dtl.Rows[i]["供应商名称"].ToString());
                }
            }
            else
            {
                ClientManage ClientManage = new ClientManage();
                dtl = ClientManage.GetClientData();
                cboSupplier.Items.Add("");
                for (int i = 0; i < dtl.Rows.Count; i++)
                {
                    cboSupplier.Items.Add(dtl.Rows[i]["客户名称"].ToString());
                }
            }


        
        }



        //初始经表格
        private DataTable IniBindTable()
        {
            DataTable _dt = new DataTable();
            DataColumn _datacol1 = new DataColumn("MaterialGuid");
            DataColumn _datacol2 = new DataColumn("MaterialID");
            DataColumn _datacol3 = new DataColumn("MaterialName");
            DataColumn _datacol4 = new DataColumn("BarNo");
            DataColumn _datacol5 = new DataColumn("Spec");
            DataColumn _datacol6 = new DataColumn("Unit");
            DataColumn _datacol7 = new DataColumn("Qty");
            DataColumn _datacol8 = new DataColumn("Price");
            DataColumn _datacol9 = new DataColumn("Total");
            DataColumn _datacol10 = new DataColumn("Remark");
            DataColumn _datacol11 = new DataColumn("ClassName");

            _dt.Columns.Add(_datacol1);
            _dt.Columns.Add(_datacol2);
            _dt.Columns.Add(_datacol3);
            _dt.Columns.Add(_datacol4);
            _dt.Columns.Add(_datacol5);
            _dt.Columns.Add(_datacol6);
            _dt.Columns.Add(_datacol7);
            _dt.Columns.Add(_datacol8);
            _dt.Columns.Add(_datacol9);
            _dt.Columns.Add(_datacol10);
            _dt.Columns.Add(_datacol11);

            return _dt;

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelDetail_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "gridTotal" && e.Column.Name != "gridMaterialGuid" && e.Column.Name != "gridMaterialName"
                && e.Column.Name != "gridSpec" && e.Column.Name != "gridUnit" && e.Column.Name != "gridRemark" && e.Column.Name != "gridClassName"
                )
            {

                decimal number = 0;
                decimal price = 0;
                if (gridView1.GetFocusedRowCellValue("Price").ToString() != "")
                {
                    price = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("Price").ToString());
                }
                if (gridView1.GetFocusedRowCellValue("Qty").ToString() != "")
                {
                    number = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("Qty").ToString());
                }

                decimal total = price * number;
                total = decimal.Parse(total.ToString("0.000000"));
                gridView1.SetFocusedRowCellValue(gridTotal, total);
                //gridView1.SetRowCellValue(e.RowHandle, gridTotal, total);

            }

        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //int intRow = gridView1.GetSelectedRows()[0];
                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();
                frmDepotMaterialStatusQty fdms = new frmDepotMaterialStatusQty();
                fdms.ShowData(guid,this);
               
            }
           
        }

        //保存
        private void tsbSave_Click(object sender, EventArgs e)
        {
            gridView1.UpdateCurrentRow();

            if (cboDepot.Text == "")
            {
                this.ShowAlertMessage("必须选择仓库!");
                return;
            }

            if (cboStorageType.Text== "")
            {
                this.ShowAlertMessage("必须选择类型!");
                return;
            }

            if (this.Tag.ToString() == "I")
            {
                //if (cboSupplier.Text == "")
                //{
                //    this.ShowAlertMessage("必须选择供应商!");
                //    return;
                //}
            }
            else
            {
                if (cboSupplier.Text == "")
                {
                    this.ShowAlertMessage("必须选择客户!");
                    return;
                }
            }

            //if (cboDept.Text == "")
            //{
            //    this.ShowAlertMessage("必须选择部门!");
            //    return;
            //}

            //if (cboBearing.Text == "")
            //{
            //    this.ShowAlertMessage("必须选择方向!");
            //    return;
            //}

            if (cboHandlePerson.Text == "")
            {
                this.ShowAlertMessage("必须选择经手人!");
                return;
            }

            if (gridView1.RowCount <= 0)
            {
                this.ShowAlertMessage("必须增加货品明细数据!");
                return;
            }



            Bill Bill = new Bill();
            Bill.BillGuid = txtGuid.Text;
            Bill.BillDate =DateTime.Parse(dateTimePicker1.Text);
            Bill.BillID = txtBillID.Text;
            Bill.BatchNo = txtBatchNo.Text;
            Bill.DepotGuid = cboDepot.Text;
            Bill.DeptGuid = cboDept.Text;
            Bill.SupplierGuid =cboSupplier.Text;
            Bill.StorageTypeGuid = cboStorageType.Text;
            Bill.Flag = this.Tag.ToString();
            Bill.Bearing = cboBearing.Text;
            if (txtCreateDate.Text.Trim() == "")
            {
                Bill.CreateDate = DateTime.Now;
            }
            else
            {
                Bill.CreateDate = DateTime.Parse(txtCreateDate.Text);
            }
            Bill.CreatePerson = SysParams.UserName;
            Bill.CheckDate = DateTime.Parse("1900-01-01");
            Bill.CheckPerson = "";
            Bill.Remark = txtRemark.Text;
            Bill.BillAutoID = txtAutoBillID.Text;
            Bill.HandlePerson = cboHandlePerson.Text;
         

            List<BillDetail> list = new List<BillDetail>();
            BillDetail BillDetail = new BillDetail();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRowView dr = (DataRowView)(gridView1.GetRow(i));

                BillDetail = new BillDetail();
                BillDetail.BillDetailGuid = Guid.NewGuid().ToString();
                BillDetail.BillGuid = Bill.BillGuid;

                BillDetail.MaterialGuid =dr[0].ToString(); //gridView1.GetRowCellValue(i, gridMaterialGuid).ToString();
                BillDetail.MaterialID = dr[1].ToString(); //gridView1.GetRowCellValue(i, gridMaterialGuid).ToString();
                BillDetail.MaterialName = dr[2].ToString();  //gridView1.GetRowCellValue(i, gridMaterialName).ToString();
                BillDetail.BarNo = dr[3].ToString();  //gridView1.GetRowCellValue(i, gridMaterialName).ToString();
                BillDetail.Spec = dr[4].ToString();// gridView1.GetRowCellValue(i, gridSpec).ToString();
                BillDetail.Unit = dr[5].ToString();//gridView1.GetRowCellValue(i, gridUnit).ToString();
                if (dr[6].ToString().Trim() != "")
                {
                    BillDetail.Qty = decimal.Parse(dr[6].ToString());//int.Parse(gridView1.GetRowCellValue(i, gridQty).ToString());
                }
                else
                {
                    BillDetail.Qty = 0;
                }

                if (dr[7].ToString().Trim() != "")
                {
                    BillDetail.Price = decimal.Parse(dr[7].ToString()); //decimal.Parse(gridView1.GetRowCellValue(i, gridPrice).ToString());

                }
                else
                {
                    BillDetail.Price = 0;
                }

                if (dr[8].ToString().Trim() != "")
                {
                    BillDetail.Total = decimal.Parse(dr[8].ToString()); //decimal.Parse(gridView1.GetRowCellValue(i, gridTotal ).ToString());
                }
                else
                {
                    BillDetail.Total = 0;
                }

                BillDetail.Remark = dr[9].ToString();//gridView1.GetRowCellValue(i, gridRemark).ToString();
                list.Add(BillDetail);

            }

            //保存
            bm.SaveBill(Bill, list);

            // 如果sendflag等于1则是从入库明细查询中进入本窗口，不用刷新父窗口
            if (SendFlag == 0)
            {
                if (this.Tag.ToString() == "I")
                {
                    frmBill.frmbill.LoadBill();
                }
                else if (this.Tag.ToString() == "E")
                {
                    frmBillE.frmbille.LoadBill();
                }
            }

            tsbCheckPass.Enabled = true;

            //得到明细表数据
            DataTable dtl = bm.GetBillData(txtGuid.Text);
            DataTable dtlDetail = bm.GetBillDetailData(txtGuid.Text);
            this.gridControl1.DataSource = dtlDetail;

            ds.Tables.Clear();
            ds.Tables.Add(dtl.Copy());
            ds.Tables[0].TableName = "dtlBill";
            ds.Tables.Add(dtlDetail.Copy());
            ds.Tables[1].TableName = "dtlBillDetail";


            this.ShowMessage("保存成功");
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public string GetAutoId(string flag)
        {

            //得到自动编号
            string strautoid = "";
            int autoid = BillAutoIDManage.GetAutoIDAdd(flag);//得到入库单的单据自增号
            if (autoid < 10)
            {
                strautoid = "000" + autoid.ToString();
            }
            else if (autoid >= 10 && autoid < 100)
            {
                strautoid = "00" + autoid.ToString();
            }
            else if (autoid >= 100 && autoid < 1000)
            {
                strautoid = "0" + autoid.ToString();
            }
            else if (autoid >= 1000 && autoid < 10000)
            {
                strautoid = autoid.ToString();
            }

            strautoid=DateTime.Now.ToString("yyyyMMdd")+strautoid;
            return strautoid;
        }

        //新增
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserRightManage urm = new UserRightManage();
            if (urm.IsOperateRight(SysParams.UserID, "lkdxz") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }


            //清空主表数据
            txtGuid.Text = Guid.NewGuid().ToString();
            txtBillID.Text = "";
            txtBatchNo.Text ="";
            cboDepot.Text = "";
            cboDept.Text = "";
            txtRemark.Text = "";
            cboSupplier.Text = "";
            cboStorageType.Text = "";
            cboBearing.Text = "";
            cboHandlePerson.Text = "";
            
            txtAutoBillID.Text = GetAutoId(this.Tag.ToString());
            

            txtCreateDate.Text = DateTime.Now.ToString();
            txtCreatePerson.Text = SysParams.UserName;
            txtCheckDate.Text = "";
            txtCheckPerson.Text = "";

            if (this.Tag.ToString() == "I")
            {
                this.Text = "入库单新增";
                cboStorageType.Text = "原料采购入库";
            }
            else
            {
                this.Text = "出库单新增";
                cboStorageType.Text = "销售发货出库";
            }

         

            //清空明细表
            this.gridControl1.DataSource = IniBindTable();
            gridMaterialGuid.Visible = false;

            //初始化成没有审核
            SetControlEnable(0);

            tsbCheckPass.Enabled = false;
        }



        //审核
        private void tsbCheckPass_Click(object sender, EventArgs e)
        {
            UserRightManage urm = new UserRightManage();
            if (urm.IsOperateRight(SysParams.UserID, "lkdsh") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }

            //更新审核状态
            bm.ChcekBill(txtGuid.Text, 1);

            //设置为：已审核
            SetControlEnable(1);

            // 如果sendflag等于1则是从入库明细查询中进入本窗口，不用刷新父窗口
            if (SendFlag == 0)
            {
                if (this.Tag.ToString() == "I")
                {
                    frmBill.frmbill.LoadBill();
                }
                else if (this.Tag.ToString() == "E")
                {
                    frmBillE.frmbille.LoadBill();
                }
            }

            txtCheckDate.Text = DateTime.Now.ToString();
            txtCheckPerson.Text = SysParams.UserName;

        }

        //反审
        private void tsbCheckNoPass_Click(object sender, EventArgs e)
        {
            UserRightManage urm = new UserRightManage();
            if (urm.IsOperateRight(SysParams.UserID, "lkdsh") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }

            //更新审核状态
            bm.ChcekBill(txtGuid.Text,0);

            //设置为：没有审核
            SetControlEnable(0);

            // 如果sendflag等于1则是从入库明细查询中进入本窗口，不用刷新父窗口
            if (SendFlag == 0)
            {
                if (this.Tag.ToString() == "I")
                {
                    frmBill.frmbill.LoadBill();
                }
                else if (this.Tag.ToString() == "E")
                {
                    frmBillE.frmbille.LoadBill();
                }
            }

            txtCheckDate.Text = "";
            txtCheckPerson.Text = "";

        }

        private void SetControlEnable(int pass)
        {
            if (pass == 1)
            {
                //已审核
                tsbCheckNoPass.Enabled = true;
                tsbCheckPass.Enabled = false;

                tsbSave.Enabled = false;
                btnDelete.Enabled = false;

                btnAddDetail.Enabled = false;
                btnDelDetail.Enabled = false;
            }
            else
            { 
                //没有审核
                tsbCheckNoPass.Enabled = false;
                tsbCheckPass.Enabled = true;

                tsbSave.Enabled = true;
                btnDelete.Enabled = true;

                btnAddDetail.Enabled = true;
                btnDelDetail.Enabled = true;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除该单据！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //删除
                bm.DeleteBill(txtGuid.Text);

                //清空
                btnAdd_Click(null, null);

                 // 如果sendflag等于1则是从入库明细查询中进入本窗口，不用刷新父窗口
                if (SendFlag == 0)
                {
                    if (this.Tag.ToString() == "I")
                    {
                        frmBill.frmbill.LoadBill();
                    }
                    else if (this.Tag.ToString() == "E")
                    {
                        frmBillE.frmbille.LoadBill();
                    }
                }

               
               
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {

            if (this.Tag.ToString() == "I")
            {
                //打印入库单
                XtraReportBillI XtraReportBillI = new XtraReportBillI(ds);
                XtraReportBillI.ShowPreview();

            }
            else
            {

                //打印入库单
                XtraReportBillE XtraReportBillE = new XtraReportBillE(ds);
                XtraReportBillE.ShowPreview();
            }
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            frmMaterialAdd frmMaterialAdd = new frmMaterialAdd();
            frmMaterialAdd.Invalue = 1;
            frmMaterialAdd.MaterialAdd("", "");
        }

        private void repositoryItemSpinEdit2_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            e.Handled = true;
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void repositoryItemSpinEdit3_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void repositoryItemSpinEdit3_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (this.Text == "出库单新增" || this.Text == "出库单编辑")
                {
                    //调拨单货品是否自动计算平均单价
                    if (e.KeyValue == 8 || e.KeyValue == 46)
                    {
                        string AutoFillRemovePrice = System.Configuration.ConfigurationSettings.AppSettings["IsAutoFillRemovePrice"].ToString(); ;
                        if (AutoFillRemovePrice == "true")
                        {
                            if (gridView1.GetFocusedRow() != null)
                            {
                                decimal priceAVG = 0;
                                string guid = ((DataRowView)(gridView1.GetFocusedRow())).Row[0].ToString();
                                //得到此料件在某个仓库中的平均价,写入单价列中
                                priceAVG = bm.sp_GetMaterialPrice(guid, cboDepot.Text);
                                gridView1.SetFocusedRowCellValue(gridPrice, priceAVG);
                            }
                        }
                    }
                }
            }
            catch
            { }
        }
    }
}