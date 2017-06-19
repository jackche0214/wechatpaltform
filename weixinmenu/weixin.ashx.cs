using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.weixin;
using System.IO;
using System.Text;

namespace weixinmenu
{
    /// <summary>
    /// weixin 的摘要说明
    /// </summary>
    public class weixin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                
                context.Response.ContentType = "text/plain";
                if (context.Request.HttpMethod.ToLower() == "post")
                {
                    using (Stream stream = HttpContext.Current.Request.InputStream)
                    {
                        Byte[] postBytes = new Byte[stream.Length];
                        stream.Read(postBytes,0,(Int32)stream.Length);
                        MessageHelp help = new MessageHelp();
                        string responseContent = help.ReturnMessage(postBytes);
                        HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
                        HttpContext.Current.Response.Write(responseContent);
                    }
                }
                else////否则就是get方式，进行校验认证
                {
                    AccessToken.Auth();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}