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

                return Json(new { Success = true, Message = result["packages"].ToString() } );
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message =ex.Message });
            }
        }
    }
}