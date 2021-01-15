using System.Data;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace Daniel.Liu.DAO
{
	/// <summary>
	/// 吴炜
	/// 对ado.net中各个数据库操作类型的CommandBuilder加一适配
	/// 
	/// </summary>
	public interface ICommandBuilder
	{
		/// <summary>
		/// 设置数据适配器
		/// </summary>
		/// <param name="da"></param>
		void SetDataAdapter(IDataAdapter da);
	}

	/// <summary>
	/// oracle
	/// </summary>
	public class OracleCmdBuilder : ICommandBuilder
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="da"></param>
		public void SetDataAdapter(IDataAdapter da)
		{
			OracleCommandBuilder cb = new OracleCommandBuilder((OracleDataAdapter) da);
		}
	}


	/// <summary>
	/// sql的命令建造者适配对象
	/// </summary>
	public class SqlCmdBuilder : ICommandBuilder
	{
		/// <summary>
		/// 设置数据适配器
		/// </summary>
		/// <param name="da">sql数据适配器</param>
		public void SetDataAdapter(IDataAdapter da)
		{
			SqlCommandBuilder cb = new SqlCommandBuilder((SqlDataAdapter) da);
		}
	}

	/// <summary>
	/// oledb的命令建造者适配对象
	/// </summary>
	public class OleDbCmdBuilder : ICommandBuilder
	{
		/// <summary>
		/// 设置数据适配器
		/// </summary>
		/// <param name="da">oledb数据适配器</param>
		public void SetDataAdapter(IDataAdapter da)
		{
			OleDbCommandBuilder cb = new OleDbCommandBuilder((OleDbDataAdapter) da);
		}
	}


}