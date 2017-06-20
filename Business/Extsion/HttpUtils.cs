using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extsion
{
   public class HttpUtils
    {
        /// <summary>
        /// 发起一个post类型的http请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string SendHttprequest(string url,string data)
        {
            return SendPostHttprequest( url, "application/x-www-form-urlencoded",  data);
        }
        /// <summary>
        /// 发起一个get模式的http请求
        /// </summary>
        /// <returns></returns>
        public static string GetHttprequest(string url)
        {
            return SendGetHttprequest(url,"application/x-www-form-urlencoded");
        }
        public static string SendPostHttprequest(string url,string contentType, string requestData)
        {
            WebRequest request = (WebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = contentType;
            byte[] postbytes = Encoding.UTF8.GetBytes(requestData);
            request.ContentLength = postbytes.Length;
            using (Stream outstream = request.GetRequestStream())
            {
                outstream.Write(postbytes, 0, postbytes.Length);
            }
            string result = string.Empty;
            using (WebResponse response = request.GetResponse())
            {
                if (response !=null)
                {
                    using (Stream getstream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(getstream,Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            return result;

        }

        public static string SendGetHttprequest(string url ,string contenType)
        {
            WebRequest request = (WebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = contenType;
            string result = string.Empty;
            using (WebResponse response = request.GetResponse())
            {
                if (response != null)
                {
                    using (Stream resstream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(resstream,Encoding.UTF8) )
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            return result;
        }
    }
}
