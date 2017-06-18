using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using System.Security.Cryptography;

namespace Business.weixin
{
    public class AccessToken
    {
        public static void Auth()
        {
            string echoStr = HttpContext.Current.Request.QueryString["echoStr"];
            if (CheckSignature())
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    HttpContext.Current.Response.Write("echoStr");
                    HttpContext.Current.Response.End();
                }
            }
        }
        public static bool CheckSignature()
        {
            string signature = HttpContext.Current.Request.QueryString["signature"];
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = HttpContext.Current.Request.QueryString["nonce"];
            string token = ConfigurationManager.AppSettings["weixintoken"];

            string[] tmpArr = { token, timestamp, nonce };
            Array.Sort(tmpArr);
            string tmpStr = string.Join("", tmpArr);
            tmpStr = Sha1_Hash(tmpStr);//通过hash算法得到一个字符串，跟signature对比
            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static string Sha1_Hash(string intputstr)
        {
            SHA1 sha1 =new SHA1CryptoServiceProvider();
            byte[] byte_in = UTF8Encoding.Default.GetBytes(intputstr);
            byte[] byte_out = sha1.ComputeHash(byte_in);
            string outputstr = BitConverter.ToString(byte_out);
            outputstr = outputstr.Replace("-","").ToLower();
            return outputstr;
        }


    }
}
