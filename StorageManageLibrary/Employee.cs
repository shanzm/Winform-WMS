using System;
using System.Collections.Generic;
using System.Text;
using Daniel.Liu.DAO;

namespace StorageManageLibrary
{
    public class Employee
    {
    	#region Model
		private string _empguid;
		private string _empid;
		private string _empname;
		private string _sex;
		private string _telephone;
		private string _address;
		private string _cardid;
		private string _dept;
		/// <summary>
		/// 唯一号
		/// </summary>
		public string EmpGuid
		{
			set{ _empguid=value;}
			get{return _empguid;}
		}
		/// <summary>
		/// 员工编号
		/// </summary>
		public string EmpID
		{
			set{ _empid=value;}
			get{return _empid;}
		}
		/// <summary>
		/// 员工姓名
		/// </summary>
		public string EmpName
		{
			set{ _empname=value;}
			get{return _empname;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 联系地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 身份证号
		/// </summary>
		public string CardID
		{
			set{ _cardid=value;}
			get{return _cardid;}
		}
		/// <summary>
		/// 所在部门
		/// </summary>
		public string Dept
		{
			set{ _dept=value;}
			get{return _dept;}
		}
		#endregion Model


		#region  成员方法

		


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Employee](");
			strSql.Append("EmpGuid,EmpID,EmpName,Sex,Telephone,Address,CardID,Dept");
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append("'"+EmpGuid+"',");
			strSql.Append("'"+EmpID+"',");
			strSql.Append("'"+EmpName+"',");
			strSql.Append("'"+Sex+"',");
			strSql.Append("'"+Telephone+"',");
			strSql.Append("'"+Address+"',");
			strSql.Append("'"+CardID+"',");
			strSql.Append("'"+Dept+"'");
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
			strSql.Append("update Employee set ");
			strSql.Append("EmpID='"+EmpID+"',");
			strSql.Append("EmpName='"+EmpName+"',");
			strSql.Append("Sex='"+Sex+"',");
			strSql.Append("Telephone='"+Telephone+"',");
			strSql.Append("Address='"+Address+"',");
			strSql.Append("CardID='"+CardID+"',");
			strSql.Append("Dept='"+Dept+"'");
			strSql.Append(" where EmpGuid='"+EmpGuid+"' ");
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

