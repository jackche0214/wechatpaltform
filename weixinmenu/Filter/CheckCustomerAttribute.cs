using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace weixinmenu.Filter
{
    public class CheckCustomerAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (filterContext.HttpContext.Session["UserName"] == null)
            //{
            //    HttpContext.Current.Response.Write("<script>alert('请登录！');'</script>");
            //    filterContext.HttpContext.Response.Redirect("/Users/Login");
            //}
            if (HttpContext.Current.Session["UserName"] == null)
            {
                HttpContext.Current.Response.Write("<script>alert('请登录！');window.parent.location.href='/Users/Login'</script>");
                HttpContext.Current.Response.End();
                return;
            }

        }
    }
}