using System;
using System.Collections.Generic;
using System.Text;
using Daniel.Liu.DAO;
using System.Data;

namespace StorageManageLibrary
{
    /// <summary>
    ///  仓库名
    /// </summary>
    public class Depot
    {
	#region Model
		private string _depotguid;
		private string _depotname;
		private string _depotperson;
		private string _telephone;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public string DepotGuid
		{
			set{ _depotguid=value;}
			get{return _depotguid;}
		}
		/// <summary>
		/// 仓库名称
		/// </summary>
		public string DepotName
		{
			set{ _depotname=value;}
			get{return _depotname;}
		}
		/// <summary>
		/// 负责人
		/// </summary>
		public string DepotPerson
		{
			set{ _depotperson=value;}
			get{return _depotperson;}
		}
		/// <summary>
		/// 负责人电话
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
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
			strSql.Append("insert into [Depot](");
			strSql.Append("DepotGuid,DepotName,DepotPerson,Telephone,Remark");
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append("'"+DepotGuid+"',");
			strSql.Append("'"+DepotName+"',");
			strSql.Append("'"+DepotPerson+"',");
			strSql.Append("'"+Telephone+"',");
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
			strSql.Append("update Depot set ");
			strSql.Append("DepotName='"+DepotName+"',");
			strSql.Append("DepotPerson='"+DepotPerson+"',");
			strSql.Append("Telephone='"+Telephone+"',");
			strSql.Append("Remark='"+Remark+"'");
			strSql.Append(" where DepotGuid='"+DepotGuid+"' ");
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
