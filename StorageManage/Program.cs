using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace StorageManage
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        [Obsolete]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //自动更新是否开启
            string strIsStartAutoUpdate = System.Configuration.ConfigurationSettings.AppSettings["IsStartAutoUpdate"].ToString();
            if (strIsStartAutoUpdate == "true")
            {
                try
                {
                    //本机程序版本
                    string strClientVer = System.Configuration.ConfigurationSettings.AppSettings["Ver"].ToString();

                    //读取服务器上程序版本
                    string strServerPath = System.Configuration.ConfigurationSettings.AppSettings["ServerPath"].ToString();
                    string fileName = strServerPath + "StorageManage.exe.config";
                    XmlDocument myXmlDocument = new XmlDocument();
                    myXmlDocument.Load(fileName);
                    XmlNode rootNode = myXmlDocument.DocumentElement;
                    string strServerVer = rootNode.ChildNodes[0].ChildNodes[5].Attributes["value"].Value;
                    if (strClientVer.Trim() != strServerVer.Trim())
                    {
                        Application.Exit();
                        string arguments = strServerPath;
                        Process.Start(Application.StartupPath + @"\Update.exe", arguments);
                    }
                    else
                    {
                        Application.Run(new frmLogin());
                    }
                }
                catch 
                {
                    Application.Run(new frmLogin());
                }

            }
            else
            {
                Application.Run(new frmLogin());
            }
        }
    }
}