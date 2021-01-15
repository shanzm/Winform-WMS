using System;
using System.Collections.Generic;
using System.Text;
using Daniel.Liu.DAO;
using System.Data;


namespace StorageManageLibrary
{
    /// <summary>
    /// 出入库单控制类
    /// </summary>
    public class BillManage
    {

        ///<summary>
        /// 保存数据
        /// </summary>
        /// <param name="pObj">信息集实体类</param>
        /// <returns>返回保存成功(true)或失败(false)</returns>
        public void SaveBill(Bill bill,List<BillDetail> billdetail)
        {
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                pComm.BeginTrans();

                //保存单据主表数据
                //先删除主表数据
                string strDeleteSql = "Delete from Bill where  BillGuid='"+bill.BillGuid+"'";
                pComm.Execute(strDeleteSql);

                //插入主表数据
                string strInsertSql = GetAddBillSQL(bill);
                pComm.Execute(strInsertSql);


                //删除明细表
                strDeleteSql = "Delete from BillDetail where  BillGuid='" + bill.BillGuid + "'";
                pComm.Execute(strDeleteSql);

                //插入明细表数据
                for (int i = 0; i < billdetail.Count; i++)
                {
                    strInsertSql = GetAddBillDetailSQL(billdetail[i]);
                    pComm.Execute(strInsertSql);
                }


                pComm.CommitTrans();
            
            }
            catch (Exception e)
            {
                pComm.RollbackTrans();
                pComm.Close();
                throw e;

            }
        }




        /// <summary>
        /// 得到新增sql
        /// </summary>
        public string GetAddBillSQL(Bill bill)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Bill](");
            strSql.Append("BillGuid,BatchNo,CreatePerson,CreateDate,CheckPerson,CheckDate,Flag,Remark,BillAutoID,BillDate,DepotGuid,StorageTypeGuid,SupplierGuid,DeptGuid,HandlePerson,Bearing,BillID");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + bill.BillGuid + "',");
            strSql.Append("'" + bill.BatchNo + "',");
            strSql.Append("'" + bill.CreatePerson + "',");
            strSql.Append("'" + bill.CreateDate + "',");
            strSql.Append("'" + bill.CheckPerson + "',");
            if (bill.CheckDate == DateTime.Parse("1900-01-01"))
            {
                strSql.Append("null,");
            }
            else
            {
                strSql.Append("'" + bill.CheckDate + "',");
            }
            strSql.Append("'" + bill.Flag + "',");
            strSql.Append("'" + bill.Remark + "',");
            strSql.Append("'" + bill.BillAutoID + "',");
            strSql.Append("'" + bill.BillDate + "',");
            strSql.Append("'" + bill.DepotGuid + "',");
            strSql.Append("'" + bill.StorageTypeGuid + "',");
            strSql.Append("'" + bill.SupplierGuid + "',");
            strSql.Append("'" + bill.DeptGuid + "',");
            strSql.Append("'" + bill.HandlePerson + "',");
            strSql.Append("'" + bill.Bearing + "',");
            strSql.Append("'" + bill.BillID + "'");
            strSql.Append(")");
            return strSql.ToString();
        }


        /// <summary>
        /// 得到增加一条明细的SQL
        /// </summary>
        public string GetAddBillDetailSQL(BillDetail billdetail )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [BillDetail](");
            strSql.Append("BillDetailGuid,Remark,BillGuid,MaterialGuid,MaterialID,MaterialName,BarNo,Spec,Unit,Price,Qty,Total");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + billdetail.BillDetailGuid + "',");
            strSql.Append("'" + billdetail.Remark + "',");
            strSql.Append("'" + billdetail.BillGuid + "',");
            strSql.Append("'" + billdetail.MaterialGuid + "',");
            strSql.Append("'" + billdetail.MaterialID + "',");
            strSql.Append("'" + billdetail.MaterialName + "',");
            strSql.Append("'" + billdetail.BarNo + "',");
            strSql.Append("'" + billdetail.Spec + "',");
            strSql.Append("'" + billdetail.Unit + "',");
            strSql.Append("" + billdetail.Price + ",");
            strSql.Append("" + billdetail.Qty + ",");
            strSql.Append("" + billdetail.Total + "");
            strSql.Append(")");
            return strSql.ToString();
        }


        /// <summary>
        /// 得到数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetBillData()
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  BillGuid,BatchNo ,HandlePerson,CreatePerson,CreateDate,CheckPerson,CheckDate,Flag,Remark,BillAutoID,BillDate,DepotGuid,StorageTypeGuid,SupplierGuid,DeptGuid,Bearing,BillID  from Bill  order by CreateDate desc";
                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }


        /// <summary>
        /// 得到数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetBillDetailData(string BillGuid)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  MaterialGuid,MaterialID,MaterialName,BarNo,Spec,Unit,Qty,Price,Total,Remark,(select ClassName from V_MaterialClass  where    MaterialGuid=BillDetail.MaterialGuid) as ClassName from BillDetail where BillGuid='" + BillGuid + "' order by SortID";
                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }




        /// <summary>
        /// 得到数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetBillData(string billguid)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  BillGuid,BatchNo ,HandlePerson,CreatePerson,CreateDate,CheckPerson,CheckDate,Flag,Remark,BillAutoID,BillDate,DepotGuid,"
                              + "StorageTypeGuid,SupplierGuid,DeptGuid,Bearing,BillID  from Bill where BillGuid='" + billguid + "'  order by CreateDate desc";
                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }




        /// <summary>
        /// 得到数据--入库单
        /// </summary>
        /// <returns></returns>
        public DataTable GetBillDataImport_CN()
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  BillGuid,BillAutoID as 编号,BillID as  单号,BillDate as 业务日期,DepotGuid as  库存名称,Bearing as  方向,"
                   +"StorageTypeGuid as 类型, DeptGuid as 部门,SupplierGuid as 供应商,HandlePerson as 经手人,BatchNo as 批号,CreatePerson as 制单人, "
                    + "CreateDate as 制单时间,CheckPerson as 审核人,CheckDate as  审核日期  from Bill  where flag='I' order by CreateDate desc";
              
                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }

        /// <summary>
        /// 得到数据--入库单
        /// </summary>
        /// <returns></returns>
        public DataTable GetBillDataImport_CN(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  BillGuid,BillAutoID as 编号,BillID as  单号,BillDate as 业务日期,DepotGuid as  库存名称,Bearing as  方向,"
                   + "StorageTypeGuid as 类型, DeptGuid as 部门,SupplierGuid as 供应商,HandlePerson as 经手人,BatchNo as 批号,CreatePerson as 制单人, "
                    + "CreateDate as 制单时间,CheckPerson as 审核人,CheckDate as  审核日期  from Bill   " + strsql + " order by CreateDate desc";

                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }


        /// <summary>
        /// 得到数据--出库单
        /// </summary>
        /// <returns></returns>
        public DataTable GetBillDataExport_CN()
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  BillGuid,BillAutoID as 编号,BillID as  单号,BillDate as 业务日期,DepotGuid as  库存名称,Bearing as  方向,"
                   + "StorageTypeGuid as 类型, DeptGuid as 部门,SupplierGuid as 客户,HandlePerson as 经手人,BatchNo as 批号,CreatePerson as 制单人, "
                    + "CreateDate as 制单时间,CheckPerson as 审核人,CheckDate as  审核日期  from Bill  where flag='E' order by CreateDate desc";

                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }

        /// <summary>
        /// 得到数据-出库单
        /// </summary>
        /// <returns></returns>
        public DataTable GetBillDataExport_CN(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  BillGuid,BillAutoID as 编号,BillID as  单号,BillDate as 业务日期,DepotGuid as  库存名称,Bearing as  方向,"
                   + "StorageTypeGuid as 类型, DeptGuid as 部门,SupplierGuid as 客户,HandlePerson as 经手人,BatchNo as 批号,CreatePerson as 制单人, "
                    + "CreateDate as 制单时间,CheckPerson as 审核人,CheckDate as  审核日期  from Bill   " + strsql + " order by CreateDate desc";

                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public void DeleteBill(string BillGuid)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                pObj_Comm.BeginTrans();
                //删除主表
                string ps_Sql = "delete  from Bill  where  BillGuid='" + BillGuid + "'";
                pObj_Comm.Execute(ps_Sql);

                //删除明细表
                ps_Sql = "delete  from BillDetail  where  BillGuid='" + BillGuid + "'";
                pObj_Comm.Execute(ps_Sql);

                pObj_Comm.CommitTrans();
                pObj_Comm.Close();


            }
            catch (Exception e)
            {
                pObj_Comm.RollbackTrans();
                pObj_Comm.Close();
                throw e;
            }
        }




        /// <summary>
        /// 更新审核状态度
        /// </summary>
        /// <returns></returns>
        public void ChcekBill(string BillGuid,int pass )
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                 string ps_Sql ="";
                //删除主表
                if (pass==1)
                {
                    //通过
                    ps_Sql = "update  Bill  set CheckPerson='" + SysParams.UserName + "',CheckDate='"+DateTime.Now.ToString()+"'  where  BillGuid='" + BillGuid + "'";
                
                }else
                {
                    //不通过
                    ps_Sql = "update  Bill  set CheckPerson='',CheckDate=null  where  BillGuid='" + BillGuid + "'";
                
                }
                
                pObj_Comm.Execute(ps_Sql);
                pObj_Comm.Close();
            }
            catch (Exception e)
            {
             
                pObj_Comm.Close();
                throw e;
            }
        }


        //----------------------------------------------出入库单明细查询----------------------------------
        /// <summary>
        /// 得到数据-入库单
        /// </summary>
        /// <returns></returns>
        public DataTable GetInDepotDetailData(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  *  from  V_InDepotDetail   " + strsql + " order by BillDate";

                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }


        /// <summary>
        /// 得到数据-出库单
        /// </summary>
        /// <returns></returns>
        public DataTable GetOutDepotDetailData(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  *  from  V_OutDepotDetail   " + strsql + " order by BillDate";

                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }

        //---------------------------------------------------------------------------------------


        //----------------------------------------------出入库汇总表--------------------------------
         /// <summary>
        /// 得到数据-入库汇总表
        /// </summary>
        /// <returns></returns>
        public DataTable GetInDepotSumData(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "   select  InterName,MaterialName,Spec,Unit,sum(Qty) as Qty,sum(Total) as Total,count(*) as billcount "
                               + "  from  dbo.V_InDepotDetail " + strsql + " group by InterName,MaterialName,Spec,Unit"
                               + "    order by InterName  ";

                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }


        /// <summary>
        /// 得到数据-出库汇总表
        /// </summary>
        /// <returns></returns>
        public DataTable GetOutDepotSumData(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "   select  InterName,MaterialName,Spec,Unit,sum(Qty) as Qty,sum(Total) as Total,count(*) as billcount "
                               + "  from  dbo.V_OutDepotDetail " + strsql + " group by InterName,MaterialName,Spec,Unit"
                               + "    order by InterName  ";

                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }
        //-------------------------------------------------------------------------------------------------

       /// <summary>
        /// 得到数据-库存查询(包括出入库，调拨)
       /// </summary>
       /// <param name="strsql">查询条件仓库</param>
       /// <param name="strsql2">查询条件调拨</param>
       /// <param name="depot">仓库名</param>
       /// <returns></returns>
        public DataTable sp_GetDepotMaterailSum(string strsql1, string strsql2, string strsql3, string depot, string strsql4, string strsql5)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataSet dset = new DataSet();
                string[,] par;
                par = new string[6, 2];
                par[0, 0] = "@WhereSql";
                par[0, 1] = strsql1;
                par[1, 0] = "@WhereSql2";
                par[1, 1] = strsql2;
                par[2, 0] = "@WhereSql3";
                par[2, 1] = strsql3;
                par[3, 0] = "@Depot";
                par[3, 1] = depot;
                par[4, 0] = "@WhereSql4";
                par[4, 1] = strsql4;
                par[5, 0] = "@WhereSql5";
                par[5, 1] = strsql5;

                dset = pComm.ExcuteSp("sp_GetDepotDetailSum", par);

                pComm.Close();
                return dset.Tables[0];
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }


        /// <summary>
        /// 得到数据-收发存汇总表(包括出入库，调拨)
        /// </summary>
        /// <param name="strsql">查询条件仓库</param>
        /// <param name="strsql2">查询条件调拨</param>
        /// <param name="depot">仓库名</param>
        /// <returns></returns>
        public DataTable sp_GetDepotClassDetailSum(string BeginDate, string EndDate, string Depot, string BarNo,
                                                   string MaterialID,string MaterialName,string Spec,string Classid)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataSet dset = new DataSet();
                string[,] par;
                par = new string[8, 2];
                par[0, 0] = "@BeginDate";
                par[0, 1] = BeginDate;
                par[1, 0] = "@EndDate";
                par[1, 1] = EndDate;
                par[2, 0] = "@Depot";
                par[2, 1] = Depot;
                par[3, 0] = "@BarNo";
                par[3, 1] = BarNo;
                par[4, 0] = "@MaterialID";
                par[4, 1] = MaterialID;
                par[5, 0] = "@MaterialName";
                par[5, 1] = MaterialName;
                par[6, 0] = "@Spec";
                par[6, 1] = Spec;
                par[7, 0] = "@ClassID";
                par[7, 1] = Classid;
                dset = pComm.ExcuteSp("sp_GetDepotClassDetailSum", par);

                pComm.Close();
                return dset.Tables[0];
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }



        /// <summary>
        /// 得到数据-收发类型汇总表(包括出入库，调拨)
        /// </summary>
        /// <param name="strsql">查询条件仓库</param>
        /// <param name="strsql2">查询条件调拨</param>
        /// <param name="depot">仓库名</param>
        /// <returns></returns>
        public DataTable sp_GetDepotClassTypeDetailSum(string BeginDate, string EndDate, string Depot, string BarNo,
                                                   string MaterialID, string MaterialName, string Spec, string Classid)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataSet dset = new DataSet();
                string[,] par;
                par = new string[8, 2];
                par[0, 0] = "@BeginDate";
                par[0, 1] = BeginDate;
                par[1, 0] = "@EndDate";
                par[1, 1] = EndDate;
                par[2, 0] = "@Depot";
                par[2, 1] = Depot;
                par[3, 0] = "@BarNo";
                par[3, 1] = BarNo;
                par[4, 0] = "@MaterialID";
                par[4, 1] = MaterialID;
                par[5, 0] = "@MaterialName";
                par[5, 1] = MaterialName;
                par[6, 0] = "@Spec";
                par[6, 1] = Spec;
                par[7, 0] = "@ClassID";
                par[7, 1] = Classid;
                dset = pComm.ExcuteSp("sp_GetDepotClassTypeDetailSum", par);

                pComm.Close();
                return dset.Tables[0];
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }


        //----------------------------仓库收发明细与部门收发明细--------------------------------
        /// <summary>
        /// 得到数据-仓库收发明细表
        /// </summary>
        /// <returns></returns>
        public DataTable GetInOutDepotDetailData(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  *  from  V_ALLDepotDetail   " + strsql + " order by BillDate";

                DataTable pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }


        /// <summary>
        /// 得到数据-存货明细账
        /// </summary>
        /// <returns></returns>
        public DataTable sp_GetDepotMaterialDetailSum(string Depot,string MaterialID)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataSet dset = new DataSet();
                string[,] par;
                par = new string[2, 2];
                par[0, 0] = "@Depot";
                par[0, 1] = Depot;
                par[1, 0] = "@MaterialID";
                par[1, 1] = MaterialID;
                dset = pComm.ExcuteSp("sp_GetDepotMaterialDetailSum", par);

                pComm.Close();
                return dset.Tables[0];
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

        /// <summary>
        /// 得到某个料件在所有仓库中的库存数据
        /// </summary>
        /// <returns></returns>
        public DataTable sp_GetMaterialSumByDepot(string MaterialGuID)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataSet dset = new DataSet();
                string[,] par;
                par = new string[1, 2];
                par[0, 0] = "@MaterialGuID";
                par[0, 1] = MaterialGuID;
                dset = pComm.ExcuteSp("sp_GetMaterialSumByDepot", par);

                pComm.Close();
                return dset.Tables[0];
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

        /// <summary>
        /// 得到某个料件的平均单价
        /// </summary>
        /// <returns></returns>
        public decimal sp_GetMaterialPrice(string MaterialGuID,string Depot)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                decimal price=0;
                DataSet dset = new DataSet();
                string[,] par;
                par = new string[1, 2];
                par[0, 0] = "@MaterialGuID";
                par[0, 1] = MaterialGuID;
                dset = pComm.ExcuteSp("sp_GetMaterialSumByDepot", par);

                pComm.Close();

                if (dset.Tables[0].Rows.Count>0)
                {
                    DataRow[] drArr=dset.Tables[0].Select("DepotName='"+Depot+"'");
                    if (drArr.Length > 0)
                    {
                        DataRow dr=drArr[0];
                        price = decimal.Parse(dr[2].ToString());
                    }
                   
                }

                return price;
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }


        /// <summary>
        /// 得到数据-各仓库汇总表
        /// </summary>
        /// <returns></returns>
        public DataTable sp_GetAllDepotSum(string MaterialGuid, string begindate, string enddate)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataSet dset = new DataSet();
                string[,] par;
                par = new string[3, 2];
                par[0, 0] = "@MaterialGuid";
                par[0, 1] = MaterialGuid;
                par[1, 0] = "@BeginDate";
                par[1, 1] = begindate;
                par[2, 0] = "@EndDate";
                par[2, 1] = enddate;
                dset = pComm.ExcuteSp("sp_GetAllDepotSum", par);

                pComm.Close();
                return dset.Tables[0];
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

     
    }
}
