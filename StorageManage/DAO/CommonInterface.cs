//using System.Data.SqlClient;
//using System.Data.OleDb;
using System;
using System.Data;

namespace Daniel.Liu.DAO
{
	/// <summary>
	/// 作者：刘志彬(Daniel Liu)
	/// 作用：对数据库通用操作的接口。
	/// 日期：2005-04-24
	/// </summary>
	public interface CommonInterface
	{
		/// <summary>
		/// 开始一个事务
		/// </summary>
		/// <example>示例：
		///	<code>
		///	using Daniel.Liu.DAO;
		///	
		///	//创建使用默认数据连接的SQL数据访问接口
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	
		///	//开始一个事务
		///	pComm.BeginTrans();
		///	
		///	//
		///	//进行一些数据访问操作的代码
		///	//
		///	
		///	//提交本次的事务
		///	pComm.CommitTrans();
		///	
		///	//关闭数据库连结
		///	pComm.Close();
		///	</code>
		/// </example>
		void BeginTrans();

		/// <summary>
		/// 提交一个事务
		/// </summary>
		/// <example>示例：
		///	<code>
		///	using Daniel.Liu.DAO;
		///	
		///	//创建使用默认数据连接的SQL数据访问接口
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	
		///	//开始一个事务
		///	pComm.BeginTrans();
		///	
		///	//
		///	//进行一些数据访问操作的代码
		///	//
		///	
		///	//提交本次的事务
		///	pComm.CommitTrans();
		///	
		///	//关闭数据库连结
		///	pComm.Close();
		///	</code>
		/// </example>
		void CommitTrans();

		/// <summary>
		/// 回滚一个事务
		/// </summary>
		/// <example>示例：
		///	<code>
		///	using Daniel.Liu.DAO;
		///	
		///	//创建使用默认数据连接的SQL数据访问接口
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	
		///	//开始一个事务
		///	pComm.BeginTrans();
		///	
		///	try
		///	{
		///			//
		///			//进行一些数据访问操作的代码
		///			//
		///	
		///			//提交本次的事务
		///			pComm.CommitTrans();
		///			
		///			//关闭数据库连结
		///			pComm.Close();
		///	}
		///	catch(Exception ex)
		///	{
		///			//
		///			//自己的处理
		///			//
		///			
		///			//回滚此次数据操作
		///			pComm.RollbackTrans();
		///			
		///			//关闭数据库连结
		///			pComm.Close();
		///	}
		///		
		///	</code>
		/// </example>
		void RollbackTrans();

		/// <summary>
		/// 执行SQL语句
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <example>示例：
		///	<code>
		///	using Daniel.Liu.DAO;
		///	
		///	//创建使用默认数据连接的SQL数据访问接口
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	
		///	//开始一个事务
		///	pComm.BeginTrans();
		///	
		///	//进行一些数据访问操作的代码
		///	string pSql="";
		///	
		///	pSql="select * from YourTable";
		///	
		///	//执行此次数据操作
		///	pComm.Execute(pSql);
		///	
		///	//提交本次的事务
		///	pComm.CommitTrans();
		///	//关闭数据库连结
		///	pComm.Close();
		///	</code>
		/// </example>		
		void Execute(String sql);


		/// <summary>
		/// 执行SQL语句，填充到指定的DataTable中，返回DataSet
		/// </summary>
		/// <param name="QueryString">SQL语句</param>
		/// <param name="strTable">DataTable的名称</param>
		/// <returns>DataSet数据集和</returns>
		DataSet ExeForDst(String QueryString, String strTable);

		/// <summary>
		/// 执行一段SQL语句，返回DataSet结果集
		/// </summary>
		/// <param name="QueryString">SQL语句</param>
		/// <returns>DataSet结果集</returns>
		/// <example>示例：
		///	<code>
		///	using Daniel.Liu.DAO;
		///	
		///	//创建使用默认数据连接的SQL数据访问接口
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	
		///	//开始一个事务
		///	pComm.BeginTrans();
		///	
		///	string pSql="";
		///	DataSet pDst=new DataSet();
		///	
		///	//进行一些数据访问操作的代码
		///	pSql="select * from YourTable";
		///	
		///	//执行此次数据操作
		///	pDst=pComm.ExeForDst(pSql);
		///	
		///	//提交本次的事务
		///	pComm.CommitTrans();
		///	//关闭数据库连结
		///	pComm.Close();
		///	</code>
		/// </example>		
		DataSet ExeForDst(String QueryString);

		/// <summary>
		/// 执行SQL语句，返回DataTable
		/// </summary>
		/// <param name="QueryString">SQL语句</param>
		/// <param name="TableName">DataTable的名称</param>
		/// <returns>DataTable的结果集</returns>
		/// <example>示例：
		///	<code>
		///	using Daniel.Liu.DAO;
		///	
		///	//创建使用默认数据连接的SQL数据访问接口
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	
		///	//开始一个事务
		///	pComm.BeginTrans();
		///	
		///	string pSql="";
		///	DataTable pDst=new DataTable();
		///	
		///	//进行一些数据访问操作的代码
		///	pSql="select * from YourTable";
		///	
		///	//执行此次数据操作
		///	pDst=pComm.ExeForDtl(pSql,"UserInfo");
		///	
		///	//提交本次的事务
		///	pComm.CommitTrans();
		///	//关闭数据库连结
		///	pComm.Close();
		///	</code>
		/// </example>			
		DataTable ExeForDtl(String QueryString, String TableName);

		/// <summary>
		/// 执行SQL语句，返回默认DataTable
		/// </summary>
		/// <param name="QueryString">SQL语句</param>
		/// <returns>DataTable结果集</returns>
		/// <example>示例：
		///	<code>
		///	using Daniel.Liu.DAO;
		///	
		///	//创建使用默认数据连接的SQL数据访问接口
		///	CommonInterface pComm=CommonFactory.CreateInstance(CommonData.sql,pConnectionString);
		///	
		///	//开始一个事务
		///	pComm.BeginTrans();
		///	
		///	string pSql="";
		///	DataTable pDst=new DataTable();
		///	
		///	//进行一些数据访问操作的代码
		///	pSql="select * from YourTable";
		///	
		///	//执行此次数据操作
		///	pDst=pComm.ExeForDtl(pSql);
		///	
		///	//提交本次的事务
		///	pComm.CommitTrans();
		///	
		///	//关闭数据库连结
		///	pComm.Close();
		///	</code>
		/// </example>	
		DataTable ExeForDtl(String QueryString);

		/// <summary>
		/// 执行SQL语句，返回IDataReader接口
		/// </summary>
		/// <param name="QueryString">SQL语句</param>
		/// <returns>IDataReader接口</returns>
		IDataReader ExeForDtr(String QueryString);

		/// <summary>
		/// 返回IDbCommand接口
		/// </summary>
		/// <returns>IDbCommand接口</returns>
		IDbCommand GetCommand();

		/// <summary>
		/// 打开数据库连接
		/// </summary>
		void Open();

		/// <summary>
		/// 关闭数据库连接
		/// </summary>
		void Close();

		/// <summary>
		/// 用来执行带有参数的SQL语句（不是存储过程）
		/// </summary>
		/// <param name="SQLText">带有参数的SQL语句</param>
		/// <param name="Parameters">传递的参数列表</param>
		/// <param name="ParametersValue">同参数列表对应的参数值列表</param>
		void ExecuteNonQuery(string SQLText, string[] Parameters, string[] ParametersValue);

		/// <summary>
		/// 执行多sql语句
		/// </summary>
		int ExecuteSqls(string[] strSQLs);

		/// <summary>
		/// 执行一段SQL语句，返回DataSet结果集
		/// </summary>
		/// <param name="QueryString">SQL语句</param>
		/// <param name="pDS">指定DataSet</param>
		/// <param name="pTableName">pTableName</param>
		/// <returns>DataSet结果集</returns>
		DataSet ExeForFillDst(String QueryString,DataSet pDS,String pTableName);

		/// <summary>
		/// 执行存储过程
		/// </summary>
		/// <param name="StoredProcedureName">存储过程的名称</param>
		/// <param name="Parameters">传递的参数列表</param>
		/// <param name="ParametersValue">同参数列表对应的参数值列表</param>
		/// <param name="ParametersType">同参数列表对应的参数类型列表</param>
		void ExecuteSP(string StoredProcedureName, string[] Parameters, string[] ParametersValue, string[] ParametersType);

		/// <summary>
		/// 执行存储过程返回bool
		/// </summary>
		/// <param name="StoredProcedureName">存储过程名</param>
		/// <param name="ParametersNames">数组参数名</param>
		/// <param name="ParametersValue">数组参数值</param>
		/// <returns>bool</returns>
		bool ExecuteSP(string StoredProcedureName, string[] ParametersNames, object[] ParametersValue);

		/// <summary>
		/// 执行存储过程返回DataTable
		/// </summary>
		/// <param name="StoredProcedureName">存储过程名</param>
		/// <param name="ParametersNames">数组参数名</param>
		/// <param name="ParametersValue">数组参数值</param>
		/// <returns>DataTable</returns>
		DataTable ExecuteSPForDtl(string StoredProcedureName, string[] ParametersNames, object[] ParametersValue);

        ///<summary>
        /// 执行存储过程,得到结果集DataSet
        /// </summary>
        /// <param name="sqname">存储过程名称</param>
        /// <param name="array">参数名称与值的数组</param>
        /// <returns>返回True或False</returns>
        DataSet ExcuteSp(string sqname, string[,] array);


		/// <summary>
		/// 执行sql语句返回第一行第一列的值
		/// </summary>
		object ExecuteScalar(String QueryString);

		/// <summary>
		/// getDataAdapter
		/// </summary>
		IDataAdapter getDataAdapter(string sql);

		/// <summary>
		/// getCommandBuilder
		/// </summary>
		ICommandBuilder getCommandBuilder();

	}
}