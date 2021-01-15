using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Daniel.Liu.DAO;
using StorageManageLibrary;
using System.Diagnostics;
namespace StorageManage
{
    public partial class frmStorageMain : frmBase
    {
        UserRightManage UserRightManage = new UserRightManage();
        /// <summary>
        /// 仓库管理系统主界面
        /// </summary>
        public frmStorageMain()
        {
            InitializeComponent();
        }

        private void frmStorageMain_Load(object sender, EventArgs e)
        {

            //初始化数据库连接字符串
            CommonDataConfig.ConnectionDefaultStr = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"].ToString();

            tsbUserID.Text = "  当前登陆人：" + SysParams.UserName;

            //企业名称
            tsbCompanyName.Text = "企业名称:" + System.Configuration.ConfigurationSettings.AppSettings["CompanyName"].ToString(); ;
        }


        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "kh") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return; 
            }
            frmDept frmDept = new frmDept();
            frmDept.Show(this);
        }

        //分类
        private void ItemStorageClass_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
            frmStorageClass fsc = new frmStorageClass();
            fsc.Show(this);
        }

        //货品
        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "hp") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmMaterial fm = new frmMaterial();
            fm.Show(this);
        }


        private void itemDepot_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ck") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmDepot frmDepot = new frmDepot();
            frmDepot.Show(this);

            
        }

        //供应商管理
        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "gys") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmSupplier frmSupplier = new frmSupplier();
            frmSupplier.Show(this);
        }

        //客户管理
        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "kh") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmClient frmClient = new frmClient();
             frmClient.Show(this);
        }

        //员工管理
        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "yg") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmEmployee frmEmployee = new frmEmployee();
            frmEmployee.Show(this);
        }

        private void BaseItem1_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "hp") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmMaterial fm = new frmMaterial();
            fm.Show(this);
        }

        private void BaseItem2_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ck") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmDepot frmDepot = new frmDepot();
            frmDepot.Show(this);
        }

        private void BaseItem3_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "kh") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmClient frmClient = new frmClient();
            frmClient.Show(this);
        }

        private void BaseItem4_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "gys") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmSupplier frmSupplier = new frmSupplier();
            frmSupplier.Show(this);
        }

        private void BaseItem5_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "yg") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmEmployee frmEmployee = new frmEmployee();
            frmEmployee.Show(this);
        }

        private void BaseItem6_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "bm") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmDept frmDept = new frmDept();
            frmDept.Show(this);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出本系统！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //入库单
        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdgl") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmBill frmBill = new frmBill();
            frmBill.Show(this);
        }

        //出库单
        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ckdgl") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmBillE frmBillE = new frmBillE();
            frmBillE.Show(this);
        }

        private void frmStorageMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //入库单
        private void tsbI_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdgl") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmBill frmBill = new frmBill();
            frmBill.Show(this);
        }

        //出库单
        private void tsbE_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ckdgl") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmBillE frmBillE = new frmBillE();
            frmBillE.Show(this);
        }

        //调拨单
        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "dbdgl") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmRemoveBill frmRemoveBill = new frmRemoveBill();
            frmRemoveBill.Show(this);
        }

        //调拨单
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "dbdgl") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmRemoveBill frmRemoveBill = new frmRemoveBill();
            frmRemoveBill.Show(this);
        }

        //入库单明细表查询
        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdmxb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmInDepotDetail frmInDepotDetail = new frmInDepotDetail();
            frmInDepotDetail.Show(this);
        }

        //出库单明细表查询
        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            if (UserRightManage.IsOperateRight(SysParams.UserID, "ckdmxb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmOutDepotDetail frmOutDepotDetail = new frmOutDepotDetail();
            frmOutDepotDetail.Show(this);
        }

        //入库汇总表
        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdhzb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmInDepotDetailSum frmInDepotDetailSum = new frmInDepotDetailSum();
            frmInDepotDetailSum.Show(this);
        }

        //出库汇总表
        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ckdhzb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmOutDepotDetailSum frmOutDepotDetailSum = new frmOutDepotDetailSum();
            frmOutDepotDetailSum.Show(this);
        }
        //入库汇总表
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdhzb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmInDepotDetailSum frmInDepotDetailSum = new frmInDepotDetailSum();
            frmInDepotDetailSum.Show(this);
        }
        //出库汇总表
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdhzb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmOutDepotDetailSum frmOutDepotDetailSum = new frmOutDepotDetailSum();
            frmOutDepotDetailSum.Show(this);
        }

        //库存查询
        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "cccx") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmDepotMaterialSum frmDepotMaterialSum = new frmDepotMaterialSum();
            frmDepotMaterialSum.Show(this);
        }

        //盘点单
        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "kcpd") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmCheckBill frmCheckBill = new frmCheckBill();
            frmCheckBill.Show(this);
        }

        //收发存汇总表
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "sfchzb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmDepotMaterialInOutSum frmDepotMaterialInOutSum = new frmDepotMaterialInOutSum();
            frmDepotMaterialInOutSum.Show(this);
        }

        //库存查询
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "cccx") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmDepotMaterialSum frmDepotMaterialSum = new frmDepotMaterialSum();
            frmDepotMaterialSum.Show(this);
        }

        //收发类型汇总表
        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "sflxhzb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmDepotMaterialTypeInOutSum frmDepotMaterialTypeInOutSum = new frmDepotMaterialTypeInOutSum();
            frmDepotMaterialTypeInOutSum.Show(this);
        }

        //仓库收发明细表
        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "cksfmxb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmInOutDepotDetail frmInOutDepotDetail = new frmInOutDepotDetail();
            frmInOutDepotDetail.Show(this);
        }

        //部门收发明细表
        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "bmsfmxb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmInOutDeptDetail frmInOutDeptDetail = new frmInOutDeptDetail();
            frmInOutDeptDetail.Show(this);
        }
        //存货明细账
        private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "chmxz") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmDepotMaterialDetailQry frmDepotMaterialDetailQry = new frmDepotMaterialDetailQry();
            frmDepotMaterialDetailQry.Show(this);
        }

        //用户管理
        private void tsbUserManage_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "yhgl") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmLoginUser frmLoginUser = new frmLoginUser();
            frmLoginUser.Show(this);
            
        }

        private void tsblkd_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdgl") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmBill frmBill = new frmBill();
            frmBill.Show(this);
        }
        private void tsblkdmx_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdmxb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmInDepotDetail frmInDepotDetail = new frmInDepotDetail();
            frmInDepotDetail.Show(this);
        }

        private void tsblkhzb_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "lkdhzb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmInDepotDetailSum frmInDepotDetailSum = new frmInDepotDetailSum();
            frmInDepotDetailSum.Show(this);
        }

        private void tsbckdgl_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ckdgl") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmBillE frmBillE = new frmBillE();
            frmBillE.Show(this);
        }

        private void tsbckdmx_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ckdmxb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmOutDepotDetail frmOutDepotDetail = new frmOutDepotDetail();
            frmOutDepotDetail.Show(this);
        }

        private void tsbckhzb_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "ckdhzb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmOutDepotDetailSum frmOutDepotDetailSum = new frmOutDepotDetailSum();
            frmOutDepotDetailSum.Show(this);
        }

        private void tsbdbd_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "dbdgl") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmRemoveBill frmRemoveBill = new frmRemoveBill();
            frmRemoveBill.Show(this);
        }

        private void tsbqxgl_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "qxgl") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmUserRight frmUserRight = new frmUserRight();
            frmUserRight.Show(this);
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要注销系统?", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                try
                {

                    Application.Exit();

                    Process p = new Process();
                    p.StartInfo.FileName = Application.StartupPath + @"\StorageManage.exe";
                    p.StartInfo.Arguments = "/StorageManage";
                    p.Start();
                }
                catch (Exception ee)
                {
                    throw ee;
                }

            }
        }

        private void tsbcccx_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "cccx") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmDepotMaterialSum frmDepotMaterialSum = new frmDepotMaterialSum();
            frmDepotMaterialSum.Show(this);
        }

        private void tsbcksfmxb_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "cksfmxb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmInOutDepotDetail frmInOutDepotDetail = new frmInOutDepotDetail();
            frmInOutDepotDetail.Show(this);
        }

        private void tsbbmsfmxb_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "bmsfmxb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmInOutDeptDetail frmInOutDeptDetail = new frmInOutDeptDetail();
            frmInOutDeptDetail.Show(this);
        }

        private void tsbsfchzb_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "sfchzb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmDepotMaterialInOutSum frmDepotMaterialInOutSum = new frmDepotMaterialInOutSum();
            frmDepotMaterialInOutSum.Show(this);
        }

        private void tsbsflxhzb_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "sflxhzb") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmDepotMaterialTypeInOutSum frmDepotMaterialTypeInOutSum = new frmDepotMaterialTypeInOutSum();
            frmDepotMaterialTypeInOutSum.Show(this);
        }

        private void tsbchmxz_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "chmxz") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmDepotMaterialDetailQry frmDepotMaterialDetailQry = new frmDepotMaterialDetailQry();
            frmDepotMaterialDetailQry.Show(this);
        }

        private void tsbkcpd_Click(object sender, EventArgs e)
        {
            if (UserRightManage.IsOperateRight(SysParams.UserID, "kcpd") == false)
            {
                this.ShowAlertMessage("对不起，你没有该功能的操作权限，请与管理员联系！");
                return;
            }
            frmCheckBill frmCheckBill = new frmCheckBill();
            frmCheckBill.Show(this);
        }

        //各仓库汇总表
        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            frmAllDepotSumQry frmAllDepotSumQry = new frmAllDepotSumQry();
            frmAllDepotSumQry.Show(this);
        }

     
    }
}