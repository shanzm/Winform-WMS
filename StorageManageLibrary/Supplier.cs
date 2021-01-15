using System;
using System.Collections.Generic;
using System.Text;
using Daniel.Liu.DAO;
using System.Data;


namespace StorageManageLibrary
{
    /// <summary>
    /// 供应商
    /// </summary>
    public class Supplier
    {
   	#region Model
		private string _guid;
		private string _name;
		private string _simpname;
		private string _linkman;
		private string _telephone;
		private string _fax;
		private string _address;
		private string _zip;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public string Guid
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 供应商名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 简称
		/// </summary>
		public string SimpName
		{
			set{ _simpname=value;}
			get{return _simpname;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string LinkMan
		{
			set{ _linkman=value;}
			get{return _linkman;}
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
		/// 传真
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
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
		/// 邮编
		/// </summary>
		public string Zip
		{
			set{ _zip=value;}
			get{return _zip;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model


		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Supplier](");
			strSql.Append("Guid,Name,SimpName,LinkMan,Telephone,Fax,Address,Zip,Remark");
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append("'"+Guid+"',");
			strSql.Append("'"+Name+"',");
			strSql.Append("'"+SimpName+"',");
			strSql.Append("'"+LinkMan+"',");
			strSql.Append("'"+Telephone+"',");
			strSql.Append("'"+Fax+"',");
			strSql.Append("'"+Address+"',");
			strSql.Append("'"+Zip+"',");
			strSql.Append("'"+Remark+"'");
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
			strSql.Append("update Supplier set ");
			strSql.Append("Name='"+Name+"',");
			strSql.Append("SimpName='"+SimpName+"',");
			strSql.Append("LinkMan='"+LinkMan+"',");
			strSql.Append("Telephone='"+Telephone+"',");
			strSql.Append("Fax='"+Fax+"',");
			strSql.Append("Address='"+Address+"',");
			strSql.Append("Zip='"+Zip+"',");
			strSql.Append("Remark='"+Remark+"'");
			strSql.Append(" where Guid='"+Guid+"' ");
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

