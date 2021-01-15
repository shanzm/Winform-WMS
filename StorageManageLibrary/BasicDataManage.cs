using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Daniel.Liu.DAO;

namespace StorageManageLibrary
{
    /// <summary>
    /// 基础数据维护
    /// </summary>
    public class BasicDataManage
    {

        /// <summary>
        /// 辅助数据类别：
        /// </summary>
        /// <param name="Flag">(1-单位 2-规格 3:封装 4:计价法)</param>
        /// <returns></returns>
        public DataTable GetBasicData(int Flag)
        {
          
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  UnitName  from BasicData where  flag=" + Flag.ToString() + " order by UnitID";
                DataTable  pDTMain = pObj_Comm.ExeForDtl(ps_Sql);

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
        /// 辅助数据类别：
        /// </summary>
        /// <param name="Flag">(1-单位 2-规格 3:封装 4:计价法)</param>
        /// <returns></returns>
        public DataTable GetBasicData2(int Flag)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "select  UnitID,UnitName  from BasicData where  flag=" + Flag.ToString() + " order by UnitID";
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

        ///<summary>
        /// 保存数据
        /// </summary>
        /// <param name="pObj">信息集实体类</param>
        /// <returns>返回保存成功(true)或失败(false)</returns>
        public bool Save(BasicData pObj)
        {
            try
            {
               return pObj.Add();
               
            }
            catch (Exception e)
            {
                throw e;

            }
        }


        ///<summary>
        /// 输入条件返回结果查询
        /// </summary>
        /// <param name="tableid">SQL查询条件</param>
        /// <returns>存放查询结果的DataTable</returns>
        public bool DeleteBasicData(string UnitID)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {

                string StrSQL = "delete from  BasicData  where UnitID=" + UnitID;

                pComm.Execute(StrSQL);
                pComm.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }

    }
}
