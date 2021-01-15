using System;
using System.Collections.Generic;
using System.Text;
using Daniel.Liu.DAO;
using System.Data;
namespace StorageManageLibrary
{
    /// <summary>
    /// 货号类别分类管理
    /// </summary>
    public class StorageClassManage
    {
        /// <summary>
        /// 查找所有分类信息
        /// </summary>
        /// <returns>pDTMain 产品信息集</returns>
        public string GetMaxNodeData(string fatherid)
        {
            string ps_Sql = "";
            DataTable pDTMain = new DataTable();
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                ps_Sql = "SELECT Max(InterID) as InterID FROM StorageClass where FatherID ='" + fatherid + "'";
                pDTMain = pObj_Comm.ExeForDtl(ps_Sql);
                pObj_Comm.Close();

                if (pDTMain.Rows[0]["InterID"].ToString() == "")
                {
                    return fatherid + "0001";
                }
                else
                {
                    return pDTMain.Rows[0]["InterID"].ToString();
                }
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }

        /// <summary>
        /// 插入分类数据
        /// </summary>
        public void InsertTypeNode(string strInterID, string InterName, string strFatherID)
        {
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);

            try
            {


                string StrSQL = "";
                StrSQL = "insert into  StorageClass(InterID,InterName,FatherID) values('" + strInterID + "','" + InterName + "','" + strFatherID + "')";

                pComm.Execute(StrSQL);

                pComm.Close();


            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }



        ///<summary>
        /// 删除分类数据
        /// </summary>
        public void DeleteNodeData(string interid)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {

                string StrSQL = " delete from StorageClass where InterID ='" + interid + "'";

                pComm.Execute(StrSQL);
                pComm.Close();


            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

        /// <summary>
        /// 得到所有产品类另信息
        /// </summary>
        /// <returns>pDTMain 字段信息集</returns>
        public DataTable GetStorageClassData()
        {
            string ps_Sql = "";
            DataTable pDTMain = new DataTable();
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                ps_Sql = "select * from StorageClass ";
                pDTMain = pObj_Comm.ExeForDtl(ps_Sql);


                pObj_Comm.Close();

                return pDTMain;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }
    }
}
