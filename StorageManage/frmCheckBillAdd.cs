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
    /// 单据新增
    /// </summary>
    public partial class frmCheckBillAdd : frmBase
    {
        MaterialManage MaterialManage = new MaterialManage();
        CheckBillManage rbm = new CheckBillManage();
        BillAutoIDManage BillAutoIDManage = new BillAutoIDManage();
        DataSet ds = new DataSet();
        public int SendFlag = 0;//0：从盘点单管理中进入，1:其它地方进入（不刷新父窗口）
        public frmCheckBillAdd()
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
                gridView1.SetFocusedRowCellValue(gridMaterialId, material.MaterialId);
                gridView1.SetFocusedRowCellValue(gridMaterialName, material.MaterialName);
                gridView1.SetFocusedRowCellValue(gridClassName , material.ClassId);
                gridView1.SetFocusedRowCellValue(gridBarNo, material.BarNo);
                gridView1.SetFocusedRowCellValue(gridSpec , material.Spec);
                gridView1.SetFocusedRowCellValue(gridUnit, material.Unit);
                gridView1.SetFocusedRowCellValue(gridRemark , material.Remark);
            }
        }

        //新增
        public  void BillAdd(IWin32Window ifrm)
        {
            txtGuid.Text = Guid.NewGuid().ToString();
            txtAutoBillID.Text = GetAutoId("P");
            txtCreateDate.Text = DateTime.Now.ToString();
            txtCreatePerson.Text = SysParams.UserName;
            //加载选择项
            CboBind();

            //反审不可用,审核可用
            tsbCheckNoPass.Enabled = false;
            tsbCheckPass.Enabled = false;
                 
            this.gridControl1.DataSource = IniBindTable();
            gridMaterialGuid.Visible = false;
            gridMaterialId.Visible = false;

            this.Show(ifrm);
        }

        //修改
        public void BillEdit(string billguid,IWin32Window ifrm)
        {
            txtGuid.Text = billguid;

            //加载选择项
            CboBind();
  
            //得到主表数据
            DataTable dtl = rbm.GetCheckBillData(txtGuid.Text);
            txtGuid.Text = dtl.Rows[0]["checkbillGuid"].ToString();
            dateTimePicker1.Text = dtl.Rows[0]["BillDate"].ToString();
            txtBillID.Text = dtl.Rows[0]["BillDate"].ToString();
            cboDepot.Text = dtl.Rows[0]["Depot"].ToString();
            txtRemark.Text = dtl.Rows[0]["Remark"].ToString();
            cboHandlePerson.Text = dtl.Rows[0]["HandlePerson"].ToString();
            txtAutoBillID.Text = dtl.Rows[0]["BillAutoID"].ToString();
            txtBillID.Text = dtl.Rows[0]["BillID"].ToString();
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
            DataTable dtlDetail = rbm.GetCheckBillDetailData(txtGuid.Text);
            this.gridControl1.DataSource = dtlDetail;
            gridMaterialGuid.Visible = false;
            gridMaterialId.Visible = false;

            //存放dataset供打印用数据集
            ds.Tables.Add(dtl.Copy());
            ds.Tables[0].TableName = "dtlRemoveBill";
            ds.Tables.Add(dtlDetail.Copy());
            ds.Tables[1].TableName = "dtlRemoveBillDetail";


            this.Show(ifrm);
        }

        private void CboBind()
        { 
            //绑定仓库
            DepotManage DepotManage = new DepotManage();
            DataTable dtl = DepotManage.GetDepotData();
            cboDepot.Items.Add("");
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                cboDepot.Items.Add(dtl.Rows[i]["仓库名称"].ToString());
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



        //初始经表格
        private DataTable IniBindTable()
        {
            DataTable _dt = new DataTable();
            DataColumn _datacol1 = new DataColumn("MaterialGuid");
            DataColumn _datacol2 = new DataColumn("MaterialId");
            DataColumn _datacol3 = new DataColumn("MaterialName");
            DataColumn _datacol4 = new DataColumn("BarNo");
            DataColumn _datacol5 = new DataColumn("Spec");
            DataColumn _datacol6 = new DataColumn("Unit");
            DataColumn _datacol7 = new DataColumn("SurplusQty");
            DataColumn _datacol8 = new DataColumn("DeficientQty");
            DataColumn _datacol9 = new DataColumn("Price");
            DataColumn _datacol10 = new DataColumn("Total");
            DataColumn _datacol11 = new DataColumn("Remark");
            DataColumn _datacol12 = new DataColumn("ClassName");

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
            _dt.Columns.Add(_datacol12);



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
                decimal total = 0;
                if (gridView1.GetFocusedRowCellValue("Price").ToString() != "")
                {
                    price = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("Price").ToString());
                }
                if (gridView1.GetFocusedRowCellValue("SurplusQty").ToString() != "")
                {
                    number = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("SurplusQty").ToString());
                }

                if (gridView1.GetFocusedRowCellValue("DeficientQty").ToString() != "")
                {
                    number = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("DeficientQty").ToString());
                }

                total = price * number;
                total = decimal.Parse(total.ToString("0.00"));
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

            if (dateTimePicker1.Text == "")
            {
                this.ShowAlertMessage("请选择日期!");
                return;
            }

            if (cboDepot.Text == "")
            {
                this.ShowAlertMessage("必须选择仓库!");
                return;
            }

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

            bool boolvalue = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRowView dr = (DataRowView)(gridView1.GetRow(i));
                if (dr[6].ToString().Trim() != "" && dr[7].ToString().Trim() != "")
                {
                    if (decimal.Parse(dr[6].ToString()) > 0 && decimal.Parse(dr[7].ToString()) > 0)
                    {
                        boolvalue = true;
                        break;
                    }
                }
            }
            if (boolvalue == true)
            {
                this.ShowAlertMessage("同一行数据盘盈或盘亏只能填一项,另一项必须为空或0!");
                return;
            }


            CheckBill CheckBill = new CheckBill();
            CheckBill.CheckBillGuid = txtGuid.Text;
            CheckBill.BillDate = DateTime.Parse(dateTimePicker1.Text);
            CheckBill.BillID = txtBillID.Text;
            CheckBill.Depot = cboDepot.Text;
            if (txtCreateDate.Text.Trim() == "")
            {
                CheckBill.CreateDate = DateTime.Now;
            }
            else
            {
                CheckBill.CreateDate = DateTime.Parse(txtCreateDate.Text);
            }
            CheckBill.CreatePerson = SysParams.UserName;
            CheckBill.CheckDate = DateTime.Parse("1900-01-01");
            CheckBill.CheckPerson = "";
            CheckBill.Remark = txtRemark.Text;
            CheckBill.BillAutoID = txtAutoBillID.Text;
            CheckBill.HandlePerson = cboHandlePerson.Text;


            List<CheckBillDetail> list = new List<CheckBillDetail>();
            CheckBillDetail CheckBillDetail = new CheckBillDetail();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRowView dr = (DataRowView)(gridView1.GetRow(i));

                CheckBillDetail = new CheckBillDetail();
                CheckBillDetail.CheckBillDetailGuid = Guid.NewGuid().ToString();
                CheckBillDetail.CheckBillGuid = CheckBill.CheckBillGuid;

                CheckBillDetail.MaterialGuid = dr[0].ToString(); //gridView1.GetRowCellValue(i, gridMaterialGuid).ToString();
                CheckBillDetail.MaterialID = dr[1].ToString(); //gridView1.GetRowCellValue(i, gridMaterialGuid).ToString();
                CheckBillDetail.MaterialName = dr[2].ToString();  //gridView1.GetRowCellValue(i, gridMaterialName).ToString();
                CheckBillDetail.BarNo = dr[3].ToString();  //gridView1.GetRowCellValue(i, gridMaterialName).ToString();
                CheckBillDetail.Spec = dr[4].ToString();// gridView1.GetRowCellValue(i, gridSpec).ToString();
                CheckBillDetail.Unit = dr[5].ToString();//gridView1.GetRowCellValue(i, gridUnit).ToString();
                if (dr[6].ToString().Trim() != "")
                {
                    CheckBillDetail.SurplusQty = decimal.Parse(dr[6].ToString());//int.Parse(gridView1.GetRowCellValue(i, gridQty).ToString());
                }
                else
                {
                    CheckBillDetail.SurplusQty = 0;
                }
                if (dr[7].ToString().Trim() != "")
                {
                    CheckBillDetail.DeficientQty = decimal.Parse(dr[7].ToString());//int.Parse(gridView1.GetRowCellValue(i, gridQty).ToString());
                }
                else
                {
                    CheckBillDetail.DeficientQty = 0;
                }


                if (dr[8].ToString().Trim() != "")
                {
                    CheckBillDetail.Price = decimal.Parse(dr[8].ToString()); //decimal.Parse(gridView1.GetRowCellValue(i, gridPrice).ToString());

                }
                else
                {
                    CheckBillDetail.Price = 0;
                }

                if (dr[9].ToString().Trim() != "")
                {
                    CheckBillDetail.Total = decimal.Parse(dr[9].ToString()); //decimal.Parse(gridView1.GetRowCellValue(i, gridTotal ).ToString());
                }
                else
                {
                    CheckBillDetail.Total = 0;
                }

                CheckBillDetail.Remark = dr[10].ToString();//gridView1.GetRowCellValue(i, gridRemark).ToString();
                list.Add(CheckBillDetail);

            }

            //保存
            rbm.SaveCheckBill(CheckBill, list);

            //刷新
            if (SendFlag == 0)
            {
                frmCheckBill.frmcheckbill.LoadBill();
            }
           

            tsbCheckPass.Enabled = true;

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
            if (urm.IsOperateRight(SysParams.UserID, "kcpdxz") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }

            //清空主表数据
            txtGuid.Text = Guid.NewGuid().ToString();
            txtBillID.Text = "";
            cboDepot.Text = "";
            txtRemark.Text = "";
            cboHandlePerson.Text = "";
            txtAutoBillID.Text = GetAutoId("M");
            

            txtCreateDate.Text = DateTime.Now.ToString();
            txtCreatePerson.Text = SysParams.UserName;
            txtCheckDate.Text = "";
            txtCheckPerson.Text = "";

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
            if (urm.IsOperateRight(SysParams.UserID, "kcpdsh") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }

            //更新审核状态
            rbm.ChcekCheckBill(txtGuid.Text, 1);

            //设置为：已审核
            SetControlEnable(1);
            //刷新
            if (SendFlag == 0)
            {
                frmCheckBill.frmcheckbill.LoadBill();
            }

            txtCheckDate.Text = DateTime.Now.ToString();
            txtCheckPerson.Text = SysParams.UserName;

        }

        //反审
        private void tsbCheckNoPass_Click(object sender, EventArgs e)
        {
            UserRightManage urm = new UserRightManage();
            if (urm.IsOperateRight(SysParams.UserID, "kcpdsh") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }

            //更新审核状态
            rbm.ChcekCheckBill(txtGuid.Text,0);

            //设置为：没有审核
            SetControlEnable(0);

            //刷新
            if (SendFlag == 0)
            {
                frmCheckBill.frmcheckbill.LoadBill();
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
                rbm.DeleteCheckBill(txtGuid.Text);

                //清空
                btnAdd_Click(null, null);

                //刷新
                if (SendFlag == 0)
                {
                    frmCheckBill.frmcheckbill.LoadBill();
                }

            }
        }

        //打印
        private void tsbPrint_Click(object sender, EventArgs e)
        {
            //打印入库单
           // XtraReportBillI XtraReportBillI = new XtraReportBillI(ds);

           // XtraReportBillI.ShowPreview();
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}