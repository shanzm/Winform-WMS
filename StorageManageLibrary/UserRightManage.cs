using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using Daniel.Liu.DAO;
using System.Data;


namespace StorageManageLibrary
{
    /// <summary>
    /// 权限管理
    /// </summary>
    public class UserRightManage
    {


        ///<summary>
        /// 输入条件返回结果查询
        /// </summary>
        /// <param name="tableid">SQL查询条件</param>
        /// <returns>存放查询结果的DataTable</returns>
        public DataTable GetModule()
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataTable dtl = new DataTable();
                string StrSQL = " select ModuleID,ModuleName   from Module order by sortid";

                dtl = pComm.ExeForDtl(StrSQL);
                pComm.Close();
                return dtl;
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="lst"></param>
        public void SaveUserRight(List<UserRight> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                Update(lst[i]);
            
            }

        
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(UserRight UserRight)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserRight set ");
            strSql.Append("ckdmxb='" + UserRight.ckdmxb + "',");
            strSql.Append("ckdhzb='" + UserRight.ckdhzb + "',");
            strSql.Append("dbdgl='" + UserRight.dbdgl + "',");
            strSql.Append("dbdxz='" + UserRight.dbdxz + "',");
            strSql.Append("dbzsh='" + UserRight.dbzsh + "',");
            strSql.Append("cccx='" + UserRight.cccx + "',");
            strSql.Append("cksfmxb='" + UserRight.cksfmxb + "',");
            strSql.Append("bmsfmxb='" + UserRight.bmsfmxb + "',");
            strSql.Append("sfchzb='" + UserRight.sfchzb + "',");
            strSql.Append("sflxhzb='" + UserRight.sflxhzb + "',");
            strSql.Append("lkdgl='" + UserRight.lkdgl + "',");
            strSql.Append("chmxz='" + UserRight.chmxz + "',");
            strSql.Append("kcpd='" + UserRight.kcpd + "',");
            strSql.Append("kcpdxz='" + UserRight.kcpdxz + "',");
            strSql.Append("kcpdsh='" + UserRight.kcpdsh + "',");
            strSql.Append("hp='" + UserRight.hp + "',");
            strSql.Append("ck='" + UserRight.ck + "',");
            strSql.Append("kh='" + UserRight.kh + "',");
            strSql.Append("gys='" + UserRight.gys + "',");
            strSql.Append("yg='" + UserRight.yg + "',");
            strSql.Append("bm='" + UserRight.bm + "',");
            strSql.Append("lkdxz='" + UserRight.lkdxz + "',");
            strSql.Append("yhgl='" + UserRight.yhgl + "',");
            strSql.Append("qxgl='" + UserRight.qxgl + "',");
            strSql.Append("lkdsh='" + UserRight.lkdsh + "',");
            strSql.Append("lkdmxb='" + UserRight.lkdmxb + "',");
            strSql.Append("lkdhzb='" + UserRight.lkdhzb + "',");
            strSql.Append("ckdgl='" + UserRight.ckdgl + "',");
            strSql.Append("ckdxz='" + UserRight.ckdxz + "',");
            strSql.Append("ckdsh='" + UserRight.ckdsh + "'");
            strSql.Append(" where UserID='" + UserRight.UserID + "' ");
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                pComm.Execute(strSql.ToString());
                pComm.Close();
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

        
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public UserRight GetUserRight(string UserID)
        {
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  ");
                strSql.Append("UserID,ckdmxb,ckdhzb,dbdgl,dbdxz,dbzsh,cccx,cksfmxb,bmsfmxb,sfchzb,sflxhzb,lkdgl,chmxz,kcpd,kcpdxz,kcpdsh,hp,ck,kh,gys,yg,bm,lkdxz,yhgl,qxgl,lkdsh,lkdmxb,lkdhzb,ckdgl,ckdxz,ckdsh ");
                strSql.Append(" from UserRight ");
                strSql.Append(" where UserID='" + UserID + "'");
                UserRight UserRight = new UserRight();
                DataSet ds = new DataSet();
                ds = pComm.ExeForDst(strSql.ToString());
                pComm.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    UserRight.UserID = ds.Tables[0].Rows[0]["UserID"].ToString();
                    UserRight.ckdmxb = ds.Tables[0].Rows[0]["ckdmxb"].ToString();
                    UserRight.ckdhzb = ds.Tables[0].Rows[0]["ckdhzb"].ToString();
                    UserRight.dbdgl = ds.Tables[0].Rows[0]["dbdgl"].ToString();
                    UserRight.dbdxz = ds.Tables[0].Rows[0]["dbdxz"].ToString();
                    UserRight.dbzsh = ds.Tables[0].Rows[0]["dbzsh"].ToString();
                    UserRight.cccx = ds.Tables[0].Rows[0]["cccx"].ToString();
                    UserRight.cksfmxb = ds.Tables[0].Rows[0]["cksfmxb"].ToString();
                    UserRight.bmsfmxb = ds.Tables[0].Rows[0]["bmsfmxb"].ToString();
                    UserRight.sfchzb = ds.Tables[0].Rows[0]["sfchzb"].ToString();
                    UserRight.sflxhzb = ds.Tables[0].Rows[0]["sflxhzb"].ToString();
                    UserRight.lkdgl = ds.Tables[0].Rows[0]["lkdgl"].ToString();
                    UserRight.chmxz = ds.Tables[0].Rows[0]["chmxz"].ToString();
                    UserRight.kcpd = ds.Tables[0].Rows[0]["kcpd"].ToString();
                    UserRight.kcpdxz = ds.Tables[0].Rows[0]["kcpdxz"].ToString();
                    UserRight.kcpdsh = ds.Tables[0].Rows[0]["kcpdsh"].ToString();
                    UserRight.hp = ds.Tables[0].Rows[0]["hp"].ToString();
                    UserRight.ck = ds.Tables[0].Rows[0]["ck"].ToString();
                    UserRight.kh = ds.Tables[0].Rows[0]["kh"].ToString();
                    UserRight.gys = ds.Tables[0].Rows[0]["gys"].ToString();
                    UserRight.yg = ds.Tables[0].Rows[0]["yg"].ToString();
                    UserRight.bm = ds.Tables[0].Rows[0]["bm"].ToString();
                    UserRight.lkdxz = ds.Tables[0].Rows[0]["lkdxz"].ToString();
                    UserRight.yhgl = ds.Tables[0].Rows[0]["yhgl"].ToString();
                    UserRight.qxgl = ds.Tables[0].Rows[0]["qxgl"].ToString();
                    UserRight.lkdsh = ds.Tables[0].Rows[0]["lkdsh"].ToString();
                    UserRight.lkdmxb = ds.Tables[0].Rows[0]["lkdmxb"].ToString();
                    UserRight.lkdhzb = ds.Tables[0].Rows[0]["lkdhzb"].ToString();
                    UserRight.ckdgl = ds.Tables[0].Rows[0]["ckdgl"].ToString();
                    UserRight.ckdxz = ds.Tables[0].Rows[0]["ckdxz"].ToString();
                    UserRight.ckdsh = ds.Tables[0].Rows[0]["ckdsh"].ToString();
                }

                return UserRight;
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }


         
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public bool IsOperateRight(string UserID, string ModuleID)
        {
            string strsql = " select " + ModuleID + " from UserRight where userid='" + UserID + "'";
             CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
             try
             {
                 DataTable dtl = new DataTable();
                 dtl = pComm.ExeForDtl(strsql.ToString());
                 pComm.Close();

                 if (dtl.Rows[0][ModuleID].ToString() == "1")
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

    }
}
