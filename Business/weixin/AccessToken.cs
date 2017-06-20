using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using System.Security.Cryptography;
using Business.Extsion;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Business.weixin
{
    public class AccessToken
    {
        public static string AppID = ConfigurationManager.AppSettings["weixin_AppID"];
        public static string AppSecret = ConfigurationManager.AppSettings["weixin_AppSecret"];

        public static string mAccessToken;
        public static DateTime GettokenTime;
        public static int Expires_Period = 7200;//token有效时间，默认2小时

        /// <summary>
        /// 正经对接微信公众平台函数。获取echoStr，来返回。
        /// </summary>
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

        /// <summary>
        /// 校验函数，微信后台返回的signature和token+timestamp+nonce 对比
        /// </summary>
        /// <returns></returns>
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

        
        public static string Weixin_ACCESS_TOKEN
        {
            get{
                //如果为空或者过期。则重新获取
                if (string.IsNullOrEmpty(mAccessToken) || HasExpired())
                {
                    //获取accesstoken函数
                    mAccessToken = GetAccessToken(AppID, AppSecret);
                }
                return mAccessToken;
            }
        }
        /// <summary>
        /// 判断是不是token过期
        /// </summary>
        /// <returns></returns>
        public static bool HasExpired()
        {
            if (GettokenTime != null)
            {
                if (DateTime.Now > GettokenTime.AddSeconds(7200).AddSeconds(-60))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取accesstoken函数
        /// </summary>
        /// <param name="AppID"></param>
        /// <param name="AppSecret"></param>
        /// <returns></returns>
        public static string GetAccessToken(string AppID,string AppSecret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
            url = string.Format(url, AppID, AppSecret);
            string responsestring = HttpUtils.GetHttprequest(url);
            JObject result = JsonConvert.DeserializeObject(responsestring) as JObject;
            if (result["access_token"] != null)
            {
                GettokenTime = DateTime.Now;
                if (result["expires_in"] != null)
                {
                    Expires_Period = int.Parse(result["expires_in"].ToString());
                }
                return result["access_token"].ToString();
            }
            else
            {
                GettokenTime = DateTime.MinValue;
            }
            return null;
        }
    }
}
