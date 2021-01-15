using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using Daniel.Liu.DAO;
using System.Data;

namespace StorageManageLibrary
{
    /// <summary>
    /// 登陆用户管理控制类
    /// </summary>
    public class LoginUserManage 
    {

        ///<summary>
        /// 保存数据
        /// </summary>
        /// <param name="pObj">信息集实体类</param>
        /// <returns>返回保存成功(true)或失败(false)</returns>
        public bool Save(LoginUser pObj)
        {
            try
            {
                if (SaveStatus(pObj) == false)
                {
                    return pObj.Add();
                }
                else
                {

                    return pObj.Update();
                }
            }
            catch (Exception e)
            {
                throw e;

            }
        }


        ///<summary>
        /// 得到当前是新增状态还是修改状态
        /// </summary>
        /// <param name="pObj">信息集实例</param>
        /// <returns>返回True或False</returns>
        public bool SaveStatus(LoginUser pObj)
        {
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string pSql = "";
                pSql = "SELECT USERID  FROM   LoginUser  " +
                    "where USERID ='" + pObj.USERID + "'";
                DataTable pDT = pComm.ExeForDtl(pSql);
                pComm.Close();
                if (pDT.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }


        ///<summary>
        /// 输入条件返回结果查询
        /// </summary>
        /// <param name="tableid">SQL查询条件</param>
        /// <returns>存放查询结果的DataTable</returns>
        public DataTable GetLoginUserInfo()
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataTable dtl = new DataTable();
                string StrSQL = " select  *   from LoginUser ";

                dtl = pComm.ExeForDtl(StrSQL);
                pComm.Close();
                return dtl;
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }


        ///<summary>
        /// 输入条件返回结果查询
        /// </summary>
        /// <param name="tableid">SQL查询条件</param>
        /// <returns>存放查询结果的DataTable</returns>
        public DataTable GetLoginUserInfo_CN()
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataTable dtl = new DataTable();
                string StrSQL = " select  USERID 用户账号,USERNAME 用户中文名称,Email   from LoginUser ";

                dtl = pComm.ExeForDtl(StrSQL);
                pComm.Close();
                return dtl;
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

        /// <summary>
        /// 检测用户名与密码正确性
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckUserPassword(string userid, string password)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                DataTable dtl = new DataTable();
                string StrSQL = " select userid,password   from LoginUser where userid='" + userid + "'";

                dtl = pComm.ExeForDtl(StrSQL);
                pComm.Close();

                //校验密码正确性
                if (dtl.Rows.Count > 0)
                {
                    string password2 = EncryptDES(password, "ABCD1234"); //用户输入的密码
                    if (password2 == dtl.Rows[0]["PASSWORD"].ToString())  //用户输入的密码与数据库中密码比较
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                pComm.Close();
                throw e;

            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LoginUser GetLoginUser(string USERID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append("USERID,USERNAME,EMAIL,PASSWORD ");
            strSql.Append(" from LOGINUSER ");
            strSql.Append(" where USERID='" + USERID + "'");
            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);

            try
            {
                LoginUser lu = new LoginUser();
                DataSet ds = new DataSet();
                ds = pComm.ExeForDst(strSql.ToString());//执行Sql语句返回DataSet
                pComm.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lu.USERID = ds.Tables[0].Rows[0]["USERID"].ToString();
                    lu.USERNAME = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                    lu.EMAIL = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                    lu.PASSWORD = ds.Tables[0].Rows[0]["PASSWORD"].ToString();
                }

                return lu;
            }
            catch (System.Exception e)
            {
                pComm.Close();
                throw e;
            }
        }

        ///<summary>
        /// 输入条件返回结果查询
        /// </summary>
        /// <param name="tableid">SQL查询条件</param>
        /// <returns>存放查询结果的DataTable</returns>
        public bool ChangePassword(string userid, string oldpassword, string newpassword)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {
                string StrSQL = " update LoginUser set PASSWORD='" + EncryptDES(newpassword, "ABCD1234")
                            + "' where USERID='" + userid + "' and PASSWORD='" + EncryptDES(oldpassword, "ABCD1234") + "'";

                pComm.Execute(StrSQL);
                pComm.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }


        ///<summary>
        /// 输入条件返回结果查询
        /// </summary>
        /// <param name="tableid">SQL查询条件</param>
        /// <returns>存放查询结果的DataTable</returns>
        public bool DeleteLoginUser(string userid)
        {

            CommonInterface pComm = CommonFactory.CreateInstance(CommonData.sql);
            try
            {

                string StrSQL = "delete from  LoginUser  where USERID='" + userid + "'";

                pComm.Execute(StrSQL);
                pComm.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }







        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

    }
}
