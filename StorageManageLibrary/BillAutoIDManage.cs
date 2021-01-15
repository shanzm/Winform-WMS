using System;
using System.Collections.Generic;
using System.Text;
using Daniel.Liu.DAO;
using System.Data;

namespace StorageManageLibrary
{
    /// <summary>
    /// 自动编号
    /// </summary>
    public class BillAutoIDManage
    {
        ///<summary>
        /// 输入条件返回结果查询
        /// </summary>
        /// <param name="tableid">SQL查询条件</param>
        /// <returns>存放查询结果的DataTable</returns>
        public int GetBillAutoId(string flag)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataTable dtl = new DataTable();
                string StrSQL = " select BillAutoID from BillAutoID  where  Flag='" + flag + "'";

                dtl = pComm.ExeForDtl(StrSQL);
                pComm.Close();
                return int.Parse(dtl.Rows[0]["BillAutoID"].ToString());
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }


        ///<summary>
        /// 输入条件返回结果查询
        /// </summary>
        /// <param name="tableid">SQL查询条件</param>
        /// <returns>存放查询结果的DataTable</returns>
        public int GetAutoIDAdd(string flag)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                //更新缺陷自增号
                string StrSQL = "update  BillAutoID  set BillAutoID=BillAutoID+1  where flag='" + flag + "'";
                pComm.Execute(StrSQL);

                //得到自增后的号
                DataTable dtl = new DataTable();
                StrSQL = " select BillAutoID from BillAutoID  where  flag='" + flag + "'";
                dtl = pComm.ExeForDtl(StrSQL);
                pComm.Close();

                return int.Parse(dtl.Rows[0]["BillAutoID"].ToString());

               

            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

    }
}
