using System;
using System.Collections.Generic;
using System.Text;
using Daniel.Liu.DAO;
using System.Data;
namespace StorageManageLibrary
{
    /// <summary>
    /// 登陆管理实体类
    /// </summary>
    public class LoginUser
    {
        public LoginUser()
        { }
        #region Model
        private string _userid;
        private string _username;
        private string _email;
        private string _password;
        /// <summary>
        /// 
        /// </summary>
        public string USERID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string USERNAME
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EMAIL
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PASSWORD
        {
            set { _password = value; }
            get { return _password; }
        }
        #endregion Model


        #region  成员方法


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LOGINUSER(");
            strSql.Append("USERID,USERNAME,EMAIL,PASSWORD");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + USERID + "',");
            strSql.Append("'" + USERNAME + "',");
            strSql.Append("'" + EMAIL + "',");
            strSql.Append("'" + PASSWORD + "'");
            strSql.Append(")");
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);

            try
            {
                pComm.Execute(strSql.ToString());//执行Sql语句无返回值

                string strsql = "insert into UserRight(UserID,ckdmxb,ckdhzb,dbdgl,dbdxz,dbzsh,cccx,cksfmxb,bmsfmxb,sfchzb,sflxhzb,lkdgl,chmxz,kcpd,kcpdxz,kcpdsh,hp,ck,kh,gys,yg,bm,lkdxz,yhgl,qxgl,lkdsh,lkdmxb,lkdhzb,ckdgl,ckdxz,ckdsh) "
                                + " values('" + USERID + "','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0')";

                pComm.Execute(strsql);//执行Sql语句无返回值
                pComm.Close();
                return true;
            }
            catch (System.Exception e)
            {
                pComm.Close();
                throw e;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LOGINUSER set ");
            strSql.Append("USERNAME='" + USERNAME + "',");
            strSql.Append("EMAIL='" + EMAIL + "',");
            strSql.Append("PASSWORD='" + PASSWORD + "'");
            strSql.Append(" where USERID='" + USERID + "' ");
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);

            try
            {
                pComm.Execute(strSql.ToString());//执行Sql语句无返回值
                pComm.Close();
                return true;
            }
            catch (System.Exception e)
            {
                pComm.Close();
                throw e;
            }
        }
        #endregion  成员方法
    }
}
