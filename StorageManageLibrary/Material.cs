using System;
using System.Collections.Generic;
using System.Text;
using Daniel.Liu.DAO;
using System.Data;
namespace StorageManageLibrary
{
    /// <summary>
    ///  货品实体类
    /// </summary>
    public class Material
    {
	   #region Model
		private string _materialguid;
		private int _upperlimit;
		private int _lowerlimit;
		private decimal _iconsultprice;
		private decimal _econsultprice;
		private string _calculatemethod;
		private string _remark;
		private string _materialid;
		private string _materialname;
		private string _classid;
		private string _spec;
		private string _unit;
		private string _barno;
		private string _place;
		private string _encapsulation;
		/// <summary>
		/// 
		/// </summary>
		public string MaterialGuid
		{
			set{ _materialguid=value;}
			get{return _materialguid;}
		}
		/// <summary>
		/// 库存上限
		/// </summary>
		public int UpperLimit
		{
			set{ _upperlimit=value;}
			get{return _upperlimit;}
		}
		/// <summary>
		/// 库存下限
		/// </summary>
		public int LowerLimit
		{
			set{ _lowerlimit=value;}
			get{return _lowerlimit;}
		}
		/// <summary>
		/// 入库参考价
		/// </summary>
		public decimal IConsultPrice
		{
			set{ _iconsultprice=value;}
			get{return _iconsultprice;}
		}
		/// <summary>
		/// 出库参考价
		/// </summary>
		public decimal EConsultPrice
		{
			set{ _econsultprice=value;}
			get{return _econsultprice;}
		}
		/// <summary>
		/// 计价方法
		/// </summary>
		public string CalculateMethod
		{
			set{ _calculatemethod=value;}
			get{return _calculatemethod;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 货号
		/// </summary>
		public string MaterialId
		{
			set{ _materialid=value;}
			get{return _materialid;}
		}
		/// <summary>
		/// 品名
		/// </summary>
		public string MaterialName
		{
			set{ _materialname=value;}
			get{return _materialname;}
		}
		/// <summary>
		/// 货物类别
		/// </summary>
		public string ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 规格型号
		/// </summary>
		public string Spec
		{
			set{ _spec=value;}
			get{return _spec;}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 助查码
		/// </summary>
		public string BarNo
		{
			set{ _barno=value;}
			get{return _barno;}
		}
		/// <summary>
		/// 货位
		/// </summary>
		public string Place
		{
			set{ _place=value;}
			get{return _place;}
		}
		/// <summary>
		/// 封装
		/// </summary>
		public string Encapsulation
		{
			set{ _encapsulation=value;}
			get{return _encapsulation;}
		}
		#endregion Model


		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [Material](");
			strSql.Append("MaterialGuid,UpperLimit,LowerLimit,IConsultPrice,EConsultPrice,CalculateMethod,Remark,MaterialId,MaterialName,ClassId,Spec,Unit,BarNo,Place,Encapsulation");
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append("'"+MaterialGuid+"',");
			strSql.Append(""+UpperLimit+",");
			strSql.Append(""+LowerLimit+",");
			strSql.Append(""+IConsultPrice+",");
			strSql.Append(""+EConsultPrice+",");
			strSql.Append("'"+CalculateMethod+"',");
			strSql.Append("'"+Remark+"',");
			strSql.Append("'"+MaterialId+"',");
			strSql.Append("'"+MaterialName+"',");
			strSql.Append("'"+ClassId+"',");
			strSql.Append("'"+Spec+"',");
			strSql.Append("'"+Unit+"',");
			strSql.Append("'"+BarNo+"',");
			strSql.Append("'"+Place+"',");
			strSql.Append("'"+Encapsulation+"'");
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
			strSql.Append("update Material set ");
			strSql.Append("UpperLimit="+UpperLimit+",");
			strSql.Append("LowerLimit="+LowerLimit+",");
			strSql.Append("IConsultPrice="+IConsultPrice+",");
			strSql.Append("EConsultPrice="+EConsultPrice+",");
			strSql.Append("CalculateMethod='"+CalculateMethod+"',");
			strSql.Append("Remark='"+Remark+"',");
			strSql.Append("MaterialId='"+MaterialId+"',");
			strSql.Append("MaterialName='"+MaterialName+"',");
			strSql.Append("ClassId='"+ClassId+"',");
			strSql.Append("Spec='"+Spec+"',");
			strSql.Append("Unit='"+Unit+"',");
			strSql.Append("BarNo='"+BarNo+"',");
			strSql.Append("Place='"+Place+"',");
			strSql.Append("Encapsulation='"+Encapsulation+"'");
			strSql.Append(" where MaterialGuid='"+MaterialGuid+"' ");
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

