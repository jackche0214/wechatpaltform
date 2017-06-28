using Data;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.OrmLib.Entity;
using Business.Extsion;
using System.Web.Security;
using NHibernate.Linq;

namespace weixinmenu.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录函数
        /// </summary>
        /// <returns></returns>
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        public JsonResult ConfirmLogin()
        {
           
            try
            {
                NHibernateHelper nhlper = new NHibernateHelper();
                ISession session = nhlper.GetSession();
                string UserName = Request.Form["UserName"].ToString();
                string PassWord = Request.Form["PassWord"].ToString();
                IList<NT_sys_User> list = null;
                string selectHql = string.Format(@"select  * from NT_sys_User where UserName = '"+ UserName+"'");
                IQuery query = session.CreateSQLQuery(selectHql).AddEntity(typeof(NT_sys_User));
                list = query.List<NT_sys_User>();
                if (list.Count == 0)
                {
                    throw new Exception("登录名错误");
                }
                else
                {
                    string getpwd = list[0].UserPassword.ToString();
                    PassWord = extsions.Md5Encrypt(PassWord, 16);
                    if (PassWord != getpwd)
                    {
                        throw new Exception("密码错误");
                    }
                }
                FormsAuthentication.SetAuthCookie(UserName, false);//添加认证信息 
                Session["UserName"] = UserName;
                return Json(new { Success = true, Message = "登录成功" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
    }
}