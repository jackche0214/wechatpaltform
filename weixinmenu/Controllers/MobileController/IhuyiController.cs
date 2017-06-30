using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Extsion;
using System.Configuration;

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
            try {
                string BasicUrl = ConfigurationManager.AppSettings["Ihuyi_Charge_Api"].ToString()+ "?action=getpackages&";
                string username = ConfigurationManager.AppSettings["Ihuyi_Apiid"].ToString();
                string timestamp =DateTime.Now.ToString("yyyyMMddHHmmss");//时间戳(签名)
                string sign = "";//签名
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new { Success=true,Message = "哈哈"});
        }
    }
}