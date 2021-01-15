using System;
using System.Collections.Generic;
using System.Text;
using Daniel.Liu.DAO;

namespace StorageManageLibrary
{
    public class Dept
    {
   	#region Model
		private string _deptguid;
		private string _deptname;
		private string _deptperson;
		private string _telephone;
		private string _fax;
		private string _address;
		/// <summary>
		/// 
		/// </summary>
		public string DeptGuid
		{
			set{ _deptguid=value;}
			get{return _deptguid;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string DeptName
		{
			set{ _deptname=value;}
			get{return _deptname;}
		}
		/// <summary>
		/// 部门负责人
		/// </summary>
		public string DeptPerson
		{
			set{ _deptperson=value;}
			get{return _deptperson;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 传真
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		#endregion Model


		#region  成员方法

		

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Dept](");
			strSql.Append("DeptGuid,DeptName,DeptPerson,Telephone,Fax,Address");
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append("'"+DeptGuid+"',");
			strSql.Append("'"+DeptName+"',");
			strSql.Append("'"+DeptPerson+"',");
			strSql.Append("'"+Telephone+"',");
			strSql.Append("'"+Fax+"',");
			strSql.Append("'"+Address+"'");
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

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Dept set ");
			strSql.Append("DeptName='"+DeptName+"',");
			strSql.Append("DeptPerson='"+DeptPerson+"',");
			strSql.Append("Telephone='"+Telephone+"',");
			strSql.Append("Fax='"+Fax+"',");
			strSql.Append("Address='"+Address+"'");
			strSql.Append(" where DeptGuid='"+DeptGuid+"' ");
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

