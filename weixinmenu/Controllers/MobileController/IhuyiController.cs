using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Extsion;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace weixinmenu.Controllers.MobileController
{
    public class IhuyiController : Controller
    {
        // GET: Ihuyi
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetItemInfo(string mobileNo, string rechargeAmount,string itemId, string userNum,string userName)
        {
            string BasicUrl = ConfigurationManager.AppSettings["Ihuyi_Charge_Api"].ToString() + "?action=getpackages&";
            string username = ConfigurationManager.AppSettings["Ihuyi_Apiid"].ToString().ToLower();
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");//时间戳(签名)
            string tmpstamp = timestamp;
            string apikey = ConfigurationManager.AppSettings["Ihuyi_Apikey"].ToString();
            try {
                string tempsign = string.Format("apikey={0}&timestamp={1}&username={2}", apikey, tmpstamp, username);
                string sign = extsions.Md5Encrypt(tempsign, 32); //签名
                string ApiUrl = string.Format("{0}username={1}&timestamp={2}&sign={3}", BasicUrl,username, tmpstamp, sign);
                string responsestring = HttpUtils.GetHttprequest(ApiUrl);
                JObject result = JsonConvert.DeserializeObject(responsestring) as JObject;
                int code = int.Parse(result["code"].ToString());
                if (code != 1)
                {
                    throw new Exception(Ihuyi_ErrorCode.GetErrorMessage(code));
                }
                string message =result["packages"].ToString();

                return Json(new { Success = true, Message = message });
            }
            catch (Exception ex)
            {
                string MethodName = "namespace weixinmenu.Controllers.MobileController--public class IhuyiController : Controller--GetItemInfo";
                extsions.IoLog(MethodName, ex.Message);
                return Json(new { Success = false, Message =ex.Message });
            }
        }

        public ActionResult CreateBill(string mobile, string package)
        {
            string BasicUrl = ConfigurationManager.AppSettings["Ihuyi_Charge_Api"].ToString() + "?action=recharge&";
            string username = ConfigurationManager.AppSettings["Ihuyi_Apiid"].ToString().ToLower();
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");//时间戳(签名)
            string tmpstamp = timestamp;
            string apikey = ConfigurationManager.AppSettings["Ihuyi_Apikey"].ToString();
            string orderid = timestamp+Guid.NewGuid().ToString().Replace("-","");
            try
            {
                string tempsign = string.Format("apikey={0}&mobile={1}&orderid={2}&package={3}&timestamp={4}&username={5}", apikey,mobile,orderid, package,tmpstamp,username);
                string sign = extsions.Md5Encrypt(tempsign, 32); //签名
                string ApiUrl = string.Format("{0}username={1}&mobile={2}&orderid={3}&package={4}&timestamp={5}&sign={6}",BasicUrl,username, mobile,orderid,package, tmpstamp,sign);
                string responsestring = HttpUtils.GetHttprequest(ApiUrl);
                JObject result = JsonConvert.DeserializeObject(responsestring) as JObject;
                int code = int.Parse(result["code"].ToString());
                if (code != 1)
                {
                    throw new Exception(Ihuyi_ErrorCode.GetErrorMessage(code));
                }

                return Json(new { Success = true, Message ="hahha" });
            }
            catch (Exception ex)
            {
                string MethodName = "namespace weixinmenu.Controllers.MobileController--public class IhuyiController : Controller--CreateBill";
                extsions.IoLog(MethodName,ex.Message);
                return Json(new { Success = false, Message = ex.Message });
            }
        }
    }
}