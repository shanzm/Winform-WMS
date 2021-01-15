using System;
using System.Data;
using System.Data.OleDb;

namespace Daniel.Liu.DAO
{
	/// <summary>
	/// 作者：刘志彬(Daniel Liu)
	/// 作用：OLEDB的数据库连结方式的类。
	/// 日期：2005-04-24
	/// </summary>
	internal class CommonOle : CommonInterface
	{
		/// <summary>
		/// 默认的构造方法
		/// </summary>
		public CommonOle()
		{
			connstr = CommonDataConfig.ConnectionDefaultStr;
			Initial();
		}

		/// <summary>
		/// 带有参数的构造方法
		/// </summary>
		/// <param name="Connstr_Param">数据库连接字符串</param>
		public CommonOle(String Connstr_Param)
		{
			connstr = Connstr_Param;
			Initial();
		}

		/// <summary>
		/// 初始化
		/// </summary>
		private void Initial()
		{
			try
			{
				if (connstr == null)
				{
					throw(new Exception("连接字符串没有在web.config里设置"));
				}
				this.conn = new OleDbConnection(connstr);
				this.cmd = new OleDbCommand();
				cmd.Connection = this.conn;
				this.conn.Open();
			}
			catch (Exception e)
			{
				throw e;

			}
		}

		private OleDbConnection conn = null;
		private OleDbCommand cmd = null;
		private OleDbTransaction trans = null;
		private String connstr = null;

		/// <summary>
		/// 开始一个事务
		/// </summary>
		public void BeginTrans()
		{
			trans = conn.BeginTransaction();
			cmd.Transaction = trans;
		}

		/// <summary>
		/// 提交一个事务
		/// </summary>
		public void CommitTrans()
		{
			trans.Commit();
		}

		/// <summary>
		/// 回滚一个事务
		/// </summary>
		public void RollbackTrans()
		{
			trans.Rollback();
		}

		/// <summary>
		/// 执行一条SQL语句
		/// </summary>
		/// <param name="sql"></param>
		public void Execute(String sql)
		{
			try
			{
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		/// <summary>
		/// 执行SQL语句，填充到指定的DataTable中，返回DataSet
		/// </summary>
		/// <param name="QueryString">SQL语句</param>
		/// <param name="strTable">DataTable的名称</param>
		/// <returns>DataSet数据集和</returns>
		public DataSet ExeForDst(String QueryString, String strTable)
		{
			DataSet ds = new DataSet();
			OleDbDataAdapter ad = new OleDbDataAdapter();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = QueryString;
			try
			{
				ad.SelectCommand = cmd;
				ad.Fill(ds, strTable);
			}
			catch (Exception e)
			{
				throw e;
			}
			return ds;
		}

		/// <summary>
		/// 执行一段SQL语句，返回DataSet结果集
		/// </summary>
		/// <param name="QueryString">SQL语句</param>
		/// <returns>DataSet结果集</returns>
		public DataSet ExeForDst(String QueryString)
		{
			DataSet ds = new DataSet();
			OleDbDataAdapter ad = new OleDbDataAdapter();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = QueryString;
			try
			{
				ad.SelectCommand = cmd;
				ad.Fill(ds);
			}
			catch (Exception e)
			{
				throw e;
			}
			return ds;
		}

		/// <summary>
		/// 执行SQL语句，返回DataTable
		/// </summary>
		/// <param name="QueryString">SQL语句</param>
		/// <param name="TableName">DataTable的名称</param>
		/// <returns>DataTable的结果集</returns>
		public DataTable ExeForDtl(String QueryString, String TableName)
		{
			try
			{
				DataSet ds;
				DataTable dt;
				ds = ExeForDst(QueryString, TableName);
				dt = ds.Tables[TableName];
				ds = null;
				return dt;
			}
			catch
			{
				throw;
			}
			finally
			{
			}
		}

		/// <summary>
		/// 执行SQL语句，返回默认DataTable
		/// </summary>
		/// <param name="QueryString">SQL语句</param>
		/// <returns>DataTable结果集</returns>
		public DataTable ExeForDtl(String QueryString)
		{
			try
			{
				DataSet ds;
				DataTable dt;
				ds = ExeForDst(QueryString);
				dt = ds.Tables[0];
				ds = null;
				return dt;
			}
			catch
			{
				throw;
			}
			finally
			{
			}
		}

		/// <summary>
		/// 执行SQL语句，返回IDataReader接口
		/// </summary>
		/// <param name="QueryString">SQL语句</param>
		/// <returns>IDataReader接口</returns>
		public IDataReader ExeForDtr(String QueryString)
		{
			try
			{
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = QueryString;
				return cmd.ExecuteReader();
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 返回IDbCommand接口
		/// </summary>
		/// <returns>IDbCommand接口</returns>
		public IDbCommand GetCommand()
		{
			try
			{
				return this.cmd;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		/// <summary>
		/// 返回IDbConnection接口
		/// </summary>
		/// <returns>IDbConnection接口</returns>
		public IDbConnection GetConn()
		{
			return this.conn;
		}

		/// <summary>
		/// 打开一个数据连接
		/// </summary>
		public void Open()
		{
			if (conn.State.ToString().ToUpper() != "OPEN")
			{
				this.conn.Open();
			}
		}

		/// <summary>
		/// 关闭一个数据连接
		/// </summary>
		public void Close()
		{
			if (conn.State.ToString().ToUpper() == "OPEN")
			{
				this.conn.Close();
			}
		}

		/// <summary>
		/// 用来执行带有参数的SQL语句（不是存储过程）
		/// </summary>
		/// <param name="SQLText">带有参数的SQL语句</param>
		/// <param name="Parameters">传递的参数列表</param>
		/// <param name="ParametersValue">同参数列表对应的参数值列表</param>
		public void ExecuteNonQuery(string SQLText, string[] Parameters, string[] ParametersValue)
		{
			cmd.CommandType = CommandType.Text;
			this.cmd.CommandText = SQLText;
			for (int i = 0; i < Parameters.Length; i++)
			{
				this.cmd.Parameters.Add("@" + Parameters[i].ToString(), ParametersValue[i].ToString());
			}
			this.cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// 执行多sql语句
		/// </summary>
		/// <param name="strSQLs">sql语句数组</param>
		/// <returns></returns>
		public int ExecuteSqls(string[] strSQLs)
		{
			trans = conn.BeginTransaction();
			try
			{
				cmd.Transaction = trans;
				cmd.CommandType = CommandType.Text;
				foreach (string str in strSQLs)
				{
					cmd.CommandText = str;
					cmd.ExecuteNonQuery();
				}
				trans.Commit();
				return 0;
			}
			catch (OleDbException e)
			{
				trans.Rollback();
				throw e;
			}
		}

		#region 执行SQL填充到DataSet,指定TableName,返回DataSet ExeForFillDst
		/// <summary>
		/// 执行一段SQL语句，返回DataSet结果集
		/// </summary>
		/// <param name="QueryString">SQL语句</param>
		/// <param name="pDS">指定DataSet</param>
		/// <param name="pTableName">pTableName</param>
		/// <returns>DataSet结果集</returns>
		public DataSet ExeForFillDst(String QueryString,DataSet pDS,String pTableName)
		{
			try
			{
				OleDbDataAdapter ad = new OleDbDataAdapter();
				cmd.CommandText=QueryString;
				ad.SelectCommand =cmd;
				ad.Fill(pDS,pTableName);
			}
			catch (Exception e)
			{ 
				throw e;
			}
			return pDS;
		}

		#endregion

		#region 执行存储过程 ExecuteSP(string StoredProcedureName, string[] Parameters, string[] ParametersValue, string[] ParametersType)

		/// <summary>
		/// 执行存储过程
		/// </summary>
		/// <param name="StoredProcedureName">存储过程的名称</param>
		/// <param name="Parameters">传递的参数列表</param>
		/// <param name="ParametersValue">同参数列表对应的参数值列表</param>
		/// <param name="ParametersType">同参数列表对应的参数类型列表</param>
		public void ExecuteSP(string StoredProcedureName, string[] Parameters, string[] ParametersValue, string[] ParametersType)
		{
			try
			{
				this.cmd.Parameters.Clear();
				this.cmd.CommandText = StoredProcedureName;
				this.cmd.CommandType = CommandType.StoredProcedure;
				for (int i = 0; i < Parameters.Length; i++)
				{
					OleDbParameter myParm = this.cmd.Parameters.Add("@" + Parameters[i], Type.GetType(ParametersType[i].ToString()));
					myParm.Value = ParametersValue[i];
				}
				this.cmd.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		#endregion

		#region 执行存储过程返回DataTable ExecuteSPForDtl

		/// <summary>
		/// 执行存储过程返回DataTable
		/// </summary>
		/// <param name="StoredProcedureName">存储过程名</param>
		/// <param name="ParametersNames">数组参数名</param>
		/// <param name="ParametersValue">数组参数值</param>
		/// <returns>DataTable</returns>
		public DataTable ExecuteSPForDtl(string StoredProcedureName, string[] ParametersNames, object[] ParametersValue)
		{
			cmd.Parameters.Clear();
			DataTable pDT = new DataTable();
			cmd.CommandText = StoredProcedureName;
			cmd.CommandType = CommandType.StoredProcedure;
			for (int i = 0; i < ParametersNames.Length; i++)
			{
				cmd.Parameters.Add(ParametersNames[i], ParametersValue[i]);
			}
			OleDbDataReader SDR = cmd.ExecuteReader();
			for (int i = 0; i < SDR.FieldCount; i++)
			{
				pDT.Columns.Add(SDR.GetName(i), SDR.GetFieldType(i));
			}
			while (SDR.Read())
			{
				DataRow pDr1 = pDT.NewRow();
				for (int i = 0; i < pDT.Columns.Count; i++)
				{
					pDr1[i] = SDR.GetValue(i);

				}
				pDT.Rows.Add(pDr1);
			}
			SDR.Close();
			return pDT;
		}

		#endregion

		#region 执行存储过程返回bool  ExecuteSP(string StoredProcedureName, string[] ParametersNames, object[] ParametersValue)

		/// <summary>
		/// 执行存储过程返回bool
		/// </summary>
		/// <param name="StoredProcedureName">存储过程名</param>
		/// <param name="ParametersNames">数组参数名</param>
		/// <param name="ParametersValue">数组参数值</param>
		/// <returns>bool</returns>
		public bool ExecuteSP(string StoredProcedureName, string[] ParametersNames, object[] ParametersValue)
		{
			try
			{
				cmd.Parameters.Clear();
				cmd.CommandText = StoredProcedureName;
				cmd.CommandType = CommandType.StoredProcedure;
				for (int i = 0; i < ParametersNames.Length; i++)
				{
					cmd.Parameters.Add(ParametersNames[i], ParametersValue[i]);
				}
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		#endregion

        ///<summary>
        /// 执行存储过程,得到结果集DataSet
        /// </summary>
        /// <param name="sqname">存储过程名称</param>
        /// <param name="array">参数名称与值的数组</param>
        /// <returns>返回True或False</returns>
        public DataSet ExcuteSp(string sqname, string[,] array)
        {
            try
            {
                DataSet dset = new DataSet();

                //OleDbDataAdapter dp=new SqlDataAdapter();
                //SqlCommand cmmd = new  SqlCommand();

                OleDbDataAdapter odp = new OleDbDataAdapter();
                OleDbCommand ocmd = new OleDbCommand();
                odp.SelectCommand = ocmd;

                odp.SelectCommand.Connection = this.conn;
                odp.SelectCommand.CommandType = CommandType.StoredProcedure;
                odp.SelectCommand.CommandText = sqname;
                for (int i = 0; i <= array.GetUpperBound(0); i++)
                {
                    if (array[i, 0] != null)
                    {
                        //SqlParameter Parm = dp.SelectCommand.Parameters.Add( array[i,0].ToString(), SqlDbType.NVarChar);
                        OleDbParameter Parm = odp.SelectCommand.Parameters.Add(array[i, 0].ToString(), SqlDbType.NVarChar);
                        Parm.Value = array[i, 1].ToString();
                    }
                }
                odp.Fill(dset, "Default");
                return dset;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


		public object ExecuteScalar(string QueryString)
		{
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = QueryString;
			try
			{
				return cmd.ExecuteScalar();
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public IDataAdapter getDataAdapter(string sql)
		{
			return new OleDbDataAdapter(sql, this.conn);
		}

		public ICommandBuilder getCommandBuilder()
		{
			return new OleDbCmdBuilder();
		}

		#region 读取Excel到DS
		/// <summary>
		/// 读取Excel到DS
		/// </summary>
		/// <param name="Path">路径</param>
		/// <returns>DataSet</returns>
		public DataSet ReadExcelToDS(string Path)
		{
			string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
			OleDbConnection conn = new OleDbConnection(strConn);
			conn.Open();
			DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
			string tableName = schemaTable.Rows[0][2].ToString().Trim();
			string strExcel = "";
			OleDbDataAdapter myCommand = null;
			DataSet ds = null;
			strExcel = "select * from  [" + tableName + "]";
			myCommand = new OleDbDataAdapter(strExcel, strConn);
			ds = new DataSet();
			myCommand.Fill(ds, "table1");
			conn.Close();
			return ds;
		}

		#endregion
	}
}