using System;

namespace Daniel.Liu.DAO
{
	/// <summary>
	/// 作者：刘志彬(Daniel Liu)
	/// 作用：数据类型枚举。
	/// 日期：2005-04-24
	/// </summary>
	public enum CommonData
	{
		/// <summary>
		/// 以SQL Server方式
		/// </summary>
		sql = 1,
		/// <summary>
		/// 以OLEDB方式
		/// </summary>
		oledb = 2,
		/// <summary>
		/// 以oracle方式
		/// </summary>
		Oracle = 3,
	} ;

	/// <summary>
	/// 作者：刘志彬(Daniel Liu)
	/// 作用： 数据库访问工厂类。
	/// 日期：2005-04-24
	/// </summary>
	public class CommonFactory
	{
		/// <summary>
		/// 创建一个数据访问接口
		/// </summary>
		/// <param name="CommonData_Parameter">数据访问类型</param>
		/// <returns>CommonInterface接口</returns>
		/// <example>示例：
		///	<code>
		///	using Daniel.Liu.DAO;
		///	创建使用默认数据连接的SQL数据访问接口
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql);
		///	</code>
		/// </example>
		public static CommonInterface CreateInstance(CommonData CommonData_Parameter)
		{
			switch ((int) CommonData_Parameter)
			{
				case 1:
					return new CommonSql();
				case 2:
					return new CommonOle();
				case 3:
					return new CommonOracle();
				default:
					return new CommonSql();
			}
		}

		/// <summary>
		/// 创建一个数据访问接口
		/// </summary>
		/// <param name="CommonData_Parameter">数据访问类型</param>
		/// <param name="connstr">数据库的连接串</param>
		/// <returns>CommonInterface接口</returns>
		/// <example>示例：
		///	<code>
		///	using Daniel.Liu.DAO;	
		///	string pConnectionString="";	
		///	ConnectionDefaultStr = "server=grd4-daniel-liu;database=readsystem;uid=sa;pwd=liuandliu";
		///	创建使用默认数据连接的SQL数据访问接口
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	</code>
		/// </example>
		public static CommonInterface CreateInstance(CommonData CommonData_Parameter, String connstr)
		{
			switch ((int) CommonData_Parameter)
			{
				case 1:
					return new CommonSql(connstr);
				case 2:
					return new CommonOle(connstr);
				case 3:
					return new CommonOracle(connstr);
				default:
					return new CommonSql(connstr);
			}
		}

	}
}