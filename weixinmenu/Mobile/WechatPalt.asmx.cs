using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Business.Extsion;

namespace weixinmenu.Mobile
{
    /// <summary>
    /// WechatPalt 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WechatPalt : System.Web.Services.WebService
    {

        public void Response(string JsonData,string MethodName,string Exception="") {
            try
            {
                if (!string.IsNullOrEmpty(Exception))
                {
                    //去存储日志
                    extsions.IoLog(MethodName,  Exception);
                }
            }
            catch { }
            //最后都要给httpcontext返回内容
            Context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            Context.Response.ContentType = "text/plain";
            Context.Response.Write(JsonData);
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        [WebMethod(Description ="输入真实姓名获取昵称")]
        public void GetNickName(string RealName)
        {
            string NickName = RealName + "是猪啊";
            string jsons = JsonConvert.SerializeObject(new { Success = true, Message = NickName });
           
            try
            {
                Response(jsons, "GetNickName");
            }
            catch (Exception ex)
            {
                string MethodName = "namespace weixinmenu.Mobile----public class WechatPalt :----GetNickName";
                extsions.IoLog(MethodName, ex.Message);
            }
          
        }
    
    }
}
