using System.Configuration;

namespace Daniel.Liu.DAO
{
	/// <summary>
	/// 作者：刘志彬(Daniel Liu)
	/// 作用：设置数据库默认连接字符串的配置类。
	/// 日期：2005-04-24
	/// </summary>
	public class CommonDataConfig
	{
		/// <summary>
		/// 数据库连接字符串
		/// </summary>
		//public static string ConnectionDefaultStr = "server=grd4-daniel-liu;database=readsystem;uid=sa;pwd=liuandliu";
        public static string ConnectionDefaultStr = ConfigurationSettings.AppSettings["ConnStr"];

		/// <summary>
		/// CommonDataConfig
		/// </summary>
		public CommonDataConfig()
		{
			try
			{
				ConnectionDefaultStr = ConfigurationSettings.AppSettings["ConnStr"];
//				if (ConnectionDefaultStr != null)
//				{
//					byte[] data = Convert.FromBase64String(ConnectionDefaultStr);
//					ConnectionDefaultStr = ASCIIEncoding.ASCII.GetString(data);
//				}
//				byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(this.textBox1.Text); 
//				string str = Convert.ToBase64String(data);
			}
			catch
			{
				ConnectionDefaultStr = null;
			}
		}
	}
}