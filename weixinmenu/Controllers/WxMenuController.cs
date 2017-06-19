using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.OrmLib;
using Business;
using Domain.OrmLib.Entity;
using Domain.OrmLib.Model;
using Data.datalinq;
using Data;
using NHibernate;
using NHibernate.Linq;
using System.Collections;
using Newtonsoft.Json;
using Business.weixin;

namespace weixinmenu.Controllers
{
    public class WxMenuController : Controller
    {
        // GET: WxMenu

        WeixinMenuBusiness weixinMenuBusiness = new WeixinMenuBusiness();
        public ActionResult Index()
        {
            NHibernateHelper nhlper = new NHibernateHelper();
            ISession session = nhlper.GetSession();
            IEnumerable<WeiXinMenu> kinds = session.Query<WeiXinMenu>();
             WeiXinMenu root = kinds.FirstOrDefault(c => c.ParentId == "-1");
            ViewBag.root = kinds;
            return View(root);
        }
        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult MenuGridView(int? page, int? rows, string sort = "", string order = "asc")
        {
            return Content(GetMenuGridTree());
        }
        public string GetMenuGridTree()
        {
            NHibernateHelper nhlper = new NHibernateHelper();
            ISession session = nhlper.GetSession();
            List<TreeModel> result = new List<TreeModel>();
            List<TreeModel> children = new List<TreeModel>();
            IEnumerable<WeiXinMenu> kinds = session.Query<WeiXinMenu>();
            WeiXinMenu root = kinds.FirstOrDefault(c => c.ParentId == "-1");
            GetMenuGridTree(kinds, children, "10000");
            result.Add(new TreeModel
            {
                Id = root.Id.ToString(),
                MenuId = root.MenuId,
                Text = root.MenuName,
                Url = root.MenuUrl,
                ParentMenuId = root.ParentId.ToString(),
                IsEnable = root.IsEnable,
                OrderBy = root.OrderBy.ToString(),
                Target = root.MenuType,
                Ico = root.MenuKey,
                children = children
            });
            return JsonConvert.SerializeObject(result);
        }

        private void GetMenuGridTree(IEnumerable<WeiXinMenu> kinds, List<TreeModel> children, string pId)
        {
            foreach (WeiXinMenu p in kinds.Where(c => c.ParentId == pId).OrderBy(c => c.OrderBy))
            {
                TreeModel gt = new TreeModel();
                gt.Id = p.Id.ToString();
                gt.MenuId = p.MenuId;
                gt.Text = p.MenuName;
                gt.Url = p.MenuUrl;
                gt.ParentMenuId = p.ParentId;
                gt.IsEnable = p.IsEnable;
                gt.OrderBy = p.OrderBy.ToString();
                gt.Target = p.MenuType;
                gt.Ico = p.MenuKey;

                List<TreeModel> childrenTmp = new List<TreeModel>();

                GetMenuGridTree(kinds, childrenTmp, p.MenuId);

                /*
                if (childrenTmp.Count > 0)
                {
                    gt.state = "closed";
                }
                */

                gt.children = childrenTmp;

                children.Add(gt);
            }
        }

        public JsonResult MenuToWeiXin()
        {
            try
            {
                MenuManager.CreateMenu();
                return Json(new { Success = true, Message = "请求成功" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false,Message = ex.Message });
            }
        }

    }

}