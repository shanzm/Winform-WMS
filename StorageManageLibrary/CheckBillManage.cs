using System;
using System.Collections.Generic;
using System.Text;
using Daniel.Liu.DAO;
using System.Data;
namespace StorageManageLibrary
{
    /// <summary>
    /// 盘点单
    /// </summary>
    public class CheckBillManage
    {
        ///<summary>
        /// 保存数据
        /// </summary>
        /// <param name="pObj">信息集实体类</param>
        /// <returns>返回保存成功(true)或失败(false)</returns>
        public void SaveCheckBill(CheckBill CheckBill, List<CheckBillDetail> CheckBillDetail)
        {
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                pComm.BeginTrans();

                //保存单据主表数据
                //先删除主表数据
                string strDeleteSql = "Delete from CheckBill where  CheckBillGuid='" + CheckBill.CheckBillGuid + "'";
                pComm.Execute(strDeleteSql);

                //插入主表数据
                string strInsertSql = GetAddCheckBillSQL(CheckBill);
                pComm.Execute(strInsertSql);


                //删除明细表
                strDeleteSql = "Delete from CheckBillDetail where  CheckBillGuid='" + CheckBill.CheckBillGuid + "'";
                pComm.Execute(strDeleteSql);

                //插入明细表数据
                for (int i = 0; i < CheckBillDetail.Count; i++)
                {
                    strInsertSql = GetAddCheckBillDetailSQL(CheckBillDetail[i]);
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
        public string GetAddCheckBillSQL(CheckBill CheckBill)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [CheckBill](");
            strSql.Append("CheckBillGuid,CreatePerson,CreateDate,CheckPerson,CheckDate,Remark,BillAutoID,BillDate,Depot,HandlePerson,BillID");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + CheckBill.CheckBillGuid + "',");
            strSql.Append("'" + CheckBill.CreatePerson + "',");
            strSql.Append("'" + CheckBill.CreateDate + "',");
            strSql.Append("'" + CheckBill.CheckPerson + "',");
            if (CheckBill.CheckDate == DateTime.Parse("1900-01-01"))
            {
                strSql.Append("null,");
            }
            else
            {
                strSql.Append("'" + CheckBill.CheckDate + "',");
            }

            strSql.Append("'" + CheckBill.Remark + "',");
            strSql.Append("'" + CheckBill.BillAutoID + "',");
            strSql.Append("'" + CheckBill.BillDate + "',");
            strSql.Append("'" + CheckBill.Depot + "',");
            strSql.Append("'" + CheckBill.HandlePerson + "',");
            strSql.Append("'" + CheckBill.BillID + "'");
            strSql.Append(")");
            return strSql.ToString();
        }


        /// <summary>
        /// 得到增加一条明细的SQL
        /// </summary>
        public string GetAddCheckBillDetailSQL(CheckBillDetail CheckBillDetail)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [CheckBillDetail](");
            strSql.Append("CheckBillDetailGuid,Remark,CheckBillGuid,MaterialGuid,MaterialID,MaterialName,BarNo,Spec,Unit,Price,SurplusQty,DeficientQty,Total");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + CheckBillDetail.CheckBillDetailGuid + "',");
            strSql.Append("'" + CheckBillDetail.Remark + "',");
            strSql.Append("'" + CheckBillDetail.CheckBillGuid + "',");
            strSql.Append("'" + CheckBillDetail.MaterialGuid + "',");
            strSql.Append("'" + CheckBillDetail.MaterialID + "',");
            strSql.Append("'" + CheckBillDetail.MaterialName + "',");
            strSql.Append("'" + CheckBillDetail.BarNo + "',");
            strSql.Append("'" + CheckBillDetail.Spec + "',");
            strSql.Append("'" + CheckBillDetail.Unit + "',");
            strSql.Append("" + CheckBillDetail.Price + ",");
            strSql.Append("" + CheckBillDetail.SurplusQty + ",");
            strSql.Append("" + CheckBillDetail.DeficientQty + ",");
            strSql.Append("" + CheckBillDetail.Total + "");
            strSql.Append(")");
            return strSql.ToString();
        }


        /// <summary>
        /// 得到数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetCheckBillData()
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  CheckBillGuid ,HandlePerson,CreatePerson,CreateDate,CheckPerson,CheckDate,Remark,BillAutoID,BillDate,Depot,BillID  from CheckBill  order by CreateDate desc";
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
        public DataTable GetCheckBillDetailData(string CheckBillGuid)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  MaterialGuid,MaterialID,MaterialName,BarNo,Spec,Unit,SurplusQty,DeficientQty,Price,Total,Remark,(select ClassName from V_MaterialClass  where    MaterialGuid=CheckBillDetail.MaterialGuid) as ClassName  from CheckBillDetail where CheckBillGuid='" + CheckBillGuid + "' order by SortID";
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
        public DataTable GetCheckBillData(string CheckBillGuid)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  CheckBillGuid ,HandlePerson,CreatePerson,CreateDate,CheckPerson,CheckDate,Remark,BillAutoID,BillDate,Depot,"
                              + "BillID  from CheckBill where CheckBillGuid='" + CheckBillGuid + "'  order by CreateDate desc";
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
        /// 得到数据-调拨单
        /// </summary>
        /// <returns></returns>
        public DataTable GetCheckBillData_CN(string strsql)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  CheckBillGuid,BillAutoID as 编号,BillID as  单号,BillDate as 业务日期,Depot as  仓库,"
                   + "HandlePerson as 经手人, CreateDate as 制单时间,CheckPerson as 审核人,CheckDate as  审核日期  from CheckBill   " + strsql + " order by CreateDate desc";

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
        /// 得到数据-调拨单
        /// </summary>
        /// <returns></returns>
        public DataTable GetCheckBillData_CN()
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  CheckBillGuid,BillAutoID as 编号,BillID as  单号,BillDate as 业务日期,Depot as  仓库,"
                   + "HandlePerson as 经手人, CreateDate as 制单时间,CheckPerson as 审核人,CheckDate as  审核日期  from CheckBill   order by CreateDate desc";

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
        public void DeleteCheckBill(string CheckBillGuid)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                pObj_Comm.BeginTrans();
                //删除主表
                string ps_Sql = "delete  from CheckBill  where  CheckBillGuid='" + CheckBillGuid + "'";
                pObj_Comm.Execute(ps_Sql);

                //删除明细表
                ps_Sql = "delete  from CheckBillDetail  where  CheckBillGuid='" + CheckBillGuid + "'";
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
        public void ChcekCheckBill(string CheckBillGuid, int pass)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "";
                //删除主表
                if (pass == 1)
                {
                    //通过
                    ps_Sql = "update  CheckBill  set CheckPerson='" + SysParams.UserName + "',CheckDate='" + DateTime.Now.ToString() + "'  where  CheckBillGuid='" + CheckBillGuid + "'";

                }
                else
                {
                    //不通过
                    ps_Sql = "update  CheckBill  set CheckPerson='',CheckDate=null  where  CheckBillGuid='" + CheckBillGuid + "'";

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


    }
}
