using System;
using System.Collections.Generic;
using System.Text;
using Daniel.Liu.DAO;
using System.Data;

namespace StorageManageLibrary
{
    /// <summary>
    /// 货品管理控制类
    /// </summary>
    public class MaterialManage
    {

        ///<summary>
        /// 保存数据
        /// </summary>
        /// <param name="pObj">信息集实体类</param>
        /// <returns>返回保存成功(true)或失败(false)</returns>
        public bool Save(Material pObj)
        {
            try
            {
                if (SaveStatus(pObj) == false)
                {
                    return pObj.Add();
                }
                else
                {

                    return pObj.Update();
                }
            }
            catch (Exception e)
            {
                throw e;

            }
        }


        ///<summary>
        /// 得到当前是新增状态还是修改状态
        /// </summary>
        /// <param name="pObj">信息集实例</param>
        /// <returns>返回True或False</returns>
        public bool SaveStatus(Material pObj)
        {
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string pSql = "";
                pSql = "SELECT MaterialGuid   FROM   Material  " +
                    "where MaterialGuid  ='" + pObj.MaterialGuid + "'";
                DataTable pDT = pComm.ExeForDtl(pSql);
                pComm.Close();
                if (pDT.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
        public DataTable GetMaterialData_CN()
        {
            string ps_Sql = "";
            DataTable pDTMain = new DataTable();
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                ps_Sql = "select  MaterialGuid,(select InterName from StorageClass where    InterId=ClassId)  as 货品分类,MaterialId as 货号,MaterialName as 品名,Spec as 规格,BarNo as  助查码,"
                          +"Unit as 单位,CalculateMethod as 成本核算法,remark as 备注  from Material order by MaterialId";
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


        /// <summary>
        /// 得到所有产品类另信息
        /// </summary>
        /// <returns>pDTMain 字段信息集</returns>
        public DataTable GetMaterialData_CN(string strsql)
        {
            string ps_Sql = "";
            DataTable pDTMain = new DataTable();
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                ps_Sql = "select  MaterialGuid,(select InterName from StorageClass where    InterId=ClassId)  as 货品分类,MaterialId as 货号,MaterialName as 品名,Spec as 规格,BarNo as  助查码,"
                          + "Unit as 单位,CalculateMethod as 成本核算法,remark as 备注  from Material " + strsql + "  order by MaterialId";
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


        /// <summary>
        /// 得到所有产品类另信息--供料件选择用
        /// </summary>
        /// <returns>pDTMain 字段信息集</returns>
        public DataTable GetSelectMaterialData_CN(string strsql)
        {
            string ps_Sql = "";
            DataTable pDTMain = new DataTable();
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                ps_Sql = "select  MaterialGuid,(select InterName from StorageClass where    InterId=ClassId)  as 货品分类,BarNo as  助查码,MaterialId as 货号,MaterialName as 品名,Spec as 规格,"
                          + "Unit as 单位,remark as 备注  from Material " + strsql + "  order by MaterialId";
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


        /// <summary>
        /// 得到所有产品类另信息
        /// </summary>
        /// <returns>pDTMain 字段信息集</returns>
        public DataTable GetMaterialDataByClassID(string classid)
        {
            string ps_Sql = "";
            DataTable pDTMain = new DataTable();
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                if (classid != "")
                {
                    ps_Sql = "select  MaterialGuid,(select InterName from StorageClass where    InterId=ClassId) as 货品分类,MaterialId as 货号,MaterialName as 品名,Spec as 规格,BarNo as  助查码,"
                           + "Unit as 单位,CalculateMethod as 成本核算法,remark as 备注  from Material where  ClassId='" + classid + "' order by MaterialId";


                }
                else
                {
                    ps_Sql = "select  MaterialGuid,(select InterName from StorageClass where    InterId=ClassId) as 货品分类,MaterialId as 货号,MaterialName as 品名,Spec as 规格,BarNo as  助查码,"
                              + "Unit as 单位,CalculateMethod as 成本核算法,remark as 备注  from Material   order by MaterialId";


                }
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

        public Material GetMaterialByGuid(string MaterialGuid)
		{
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
            strSql.Append("MaterialGuid,UpperLimit,LowerLimit,IConsultPrice,EConsultPrice,CalculateMethod,Remark,MaterialId,MaterialName,ClassId,(select InterName from StorageClass where    InterId=ClassId) as ClassName,Spec,Unit,BarNo,Place,Encapsulation ");
			strSql.Append(" from Material ");
			strSql.Append(" where MaterialGuid='"+MaterialGuid+"'" );
            try
            {
                Material Material = new Material();
                DataTable dt = pObj_Comm.ExeForDtl(strSql.ToString());
                pObj_Comm.Close();
                if (dt.Rows.Count > 0)
                {

                    Material.MaterialGuid = dt.Rows[0]["MaterialGuid"].ToString();
                    if (dt.Rows[0]["UpperLimit"].ToString() != "")
                    {
                        Material.UpperLimit = int.Parse(dt.Rows[0]["UpperLimit"].ToString());
                    }
                    if (dt.Rows[0]["LowerLimit"].ToString() != "")
                    {
                        Material.LowerLimit = int.Parse(dt.Rows[0]["LowerLimit"].ToString());
                    }
                    if (dt.Rows[0]["IConsultPrice"].ToString() != "")
                    {
                        Material.IConsultPrice = decimal.Parse(dt.Rows[0]["IConsultPrice"].ToString());
                    }
                    if (dt.Rows[0]["EConsultPrice"].ToString() != "")
                    {
                        Material.EConsultPrice = decimal.Parse(dt.Rows[0]["EConsultPrice"].ToString());
                    }
                    Material.CalculateMethod = dt.Rows[0]["CalculateMethod"].ToString();
                    Material.Remark = dt.Rows[0]["Remark"].ToString();
                    Material.MaterialId = dt.Rows[0]["MaterialId"].ToString();
                    Material.MaterialName = dt.Rows[0]["MaterialName"].ToString();
                    Material.ClassId = dt.Rows[0]["ClassName"].ToString();  //因为单据中没有用到，所以这个值赋为名称，供外面使用
                    Material.Spec = dt.Rows[0]["Spec"].ToString();
                    Material.Unit = dt.Rows[0]["Unit"].ToString();
                    Material.BarNo = dt.Rows[0]["BarNo"].ToString();
                    Material.Place = dt.Rows[0]["Place"].ToString();
                    Material.Encapsulation = dt.Rows[0]["Encapsulation"].ToString();
                }

                return Material;
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
		}


        public DataTable  GetMaterial(string MaterialGuid)
        {
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append("MaterialGuid,UpperLimit,LowerLimit,IConsultPrice,EConsultPrice,CalculateMethod,Remark,MaterialId,MaterialName,ClassId,(select InterName from StorageClass where    InterId=ClassId) as ClassName,Spec,Unit,BarNo,Place,Encapsulation ");
            strSql.Append(" from Material ");
            strSql.Append(" where MaterialGuid='" + MaterialGuid + "'");
            try
            {
                Material Material = new Material();
                DataTable dt = pObj_Comm.ExeForDtl(strSql.ToString());
                pObj_Comm.Close();
                return dt;
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
        public void DeleteMaterial(string MaterialGuid)
        {

            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string ps_Sql = "delete  from Material  where  MaterialGuid='" + MaterialGuid + "'";
                pObj_Comm.Execute(ps_Sql);

                pObj_Comm.Close();


            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }
        }

        /// <summary>
        /// 是否已经存在相同的货品
        /// </summary>
        /// <returns></returns>
        public bool IsExistMaterial(string Classid,string MaterialName, string MaterialID, string BarNo, string Spec, string Place, string Unit)
        {
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);

            string strSql = " select MaterialGuid  from Material where ClassId='" + Classid + "' and MaterialName='" + MaterialName + "' "
                    + " and MaterialID='" + MaterialID + "' and BarNo='" + BarNo + "' and Spec='" + Spec + "' and Place='" + Place + "' and Unit='" + Unit + "'";
            try
            {

                DataTable dt = pObj_Comm.ExeForDtl(strSql);
                pObj_Comm.Close();
                if (dt.Rows.Count > 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }
              
            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }

        }


        /// <summary>
        /// 判断此货品是否已被使用
        /// </summary>
        /// <returns></returns>
        public bool IsUseMaterial(string MaterialGuid)
        {
            CommonInterface pObj_Comm = CommonFactory.CreateInstance(CommonData.sql);

            string strSql = " select MaterialGuid from (  select MaterialGuid  from BillDetail "
                           + "    union  select MaterialGuid  from CheckBillDetail "
                           + "    union  "
                           + "      select MaterialGuid  from RemoveBillDetail) M where M.MaterialGuid='" + MaterialGuid + "'";
            try
            {

                DataTable dt = pObj_Comm.ExeForDtl(strSql);
                pObj_Comm.Close();
                if (dt.Rows.Count > 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                pObj_Comm.Close();
                throw e;
            }

        }
    }
}
