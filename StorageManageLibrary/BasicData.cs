using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Daniel.Liu.DAO;

namespace StorageManageLibrary
{
    /// <summary>
    /// 常用选项维护
    /// </summary>
    public class BasicData
    {

        #region Model
        private string _unitname;
        private int _flag;
        /// <summary>
        /// 计量单位名称
        /// </summary>
        public string UnitName
        {
            set { _unitname = value; }
            get { return _unitname; }
        }
        /// <summary>
        /// 辅助数据类别：(1-单位 2-规格 3:封装 4:计价法)
        /// </summary>
        public int flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        #endregion Model

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [BasicData](");
            strSql.Append("UnitName,flag");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + UnitName + "',");
            strSql.Append("" + flag + "");
            strSql.Append(")");
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
    }
}
