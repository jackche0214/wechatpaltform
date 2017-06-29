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
using Business.Extsion;
using System.Web.Security;

namespace weixinmenu.Controllers
{
    [Filter.LoginFilter]
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
            System.Web.HttpContext curContext = System.Web.HttpContext.Current;
            if (curContext.Session["UserName"] != null)
            {
                ViewBag.UserName = curContext.Session["UserName"].ToString();
            }
            
            return View();
            
        }
        /// <summary>
        /// 返回查询到的菜单json
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="sort"></param>
        /// <param name="order"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 保存更新操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult MenuSaveOrUpdate(WeiXinMenu model)
        {
            try
            {
                NHibernateHelper nhlper = new NHibernateHelper();
                ISession session = nhlper.GetSession();
                session.SaveOrUpdate(model);
                session.Flush();
                return Json(new { Success = true,Message = "保存成功"});
            }
            catch (Exception ex)
            {
                return Json(new { Success=false,Message = ex.Message});
            }
        }
        /// <summary>
        /// 菜单删除函数
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult MenuDelete(string ids)
        {
            try
            {
                NHibernateHelper nhlper = new NHibernateHelper();
                ISession session = nhlper.GetSession();
                string[] idss= ids.Split('\'');
                string idsss = idss[1];
                int id = int.Parse(idsss);
                WeiXinMenu tmpentites = session.Get<WeiXinMenu>(id);
                session.Delete(tmpentites);
                session.Flush();
                return Json(new { Success = true,Message = "删除成功"});
            }
            catch (Exception ex)
            {
                return Json(new { Success=false,Message = ex.Message});
            }
        }

        /// <summary>
        /// 菜单编辑函数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult MenuEdit(int id)
        {
            NHibernateHelper nhlper = new NHibernateHelper();
            ISession session = nhlper.GetSession();
            WeiXinMenu model = session.Get<WeiXinMenu>(id);

            if (model == null)
            {
                model = new WeiXinMenu();
                model.IsEnable = "1";
                model.CreateTime = DateTime.Now;
            }

            return View(model);
        }

        public ActionResult MenuTree()
        {
            string ids = Request["ids"];
            List<string> data = new List<string>();
            if (ids.IsNotNull())
            {
                data = ids.ToStrList(',');
            }
             return Content(GetMenuComboTree(data));
          
        }
        public static string GetMenuComboTree(List<string> data)
        {
            NHibernateHelper nhlper = new NHibernateHelper();
            ISession session = nhlper.GetSession();
            List<ComboTree> result = new List<ComboTree>();
            List<ComboTree> children = new List<ComboTree>();
            IEnumerable<WeiXinMenu> kinds = session.Query<WeiXinMenu>();
            WeiXinMenu root = kinds.FirstOrDefault(c => c.ParentId == "-1");
            GetMenuComboTree(kinds, children, root.MenuId, data);
            result.Add(new ComboTree
            {
                id = root.MenuId.ToString(),
                text = root.MenuName,
                @checked = false,
                children = children
            });

            return JsonConvert.SerializeObject(result);
        }

        public static void GetMenuComboTree(IEnumerable<WeiXinMenu> kinds,
            List<ComboTree> children, string pId, List<string> data)
        {
            foreach (WeiXinMenu p in kinds.Where(c => c.ParentId == pId).OrderBy(c => c.OrderBy))
            {
                ComboTree gt = new ComboTree();
                gt.id = p.MenuId;
                gt.text = p.MenuName;

                List<ComboTree> childrenTmp = new List<ComboTree>();
                GetMenuComboTree(kinds, childrenTmp, p.MenuId, data);
                gt.children = childrenTmp;
                if (childrenTmp.Count == 0 && data.Contains(p.Id.ToString()))
                {
                    gt.@checked = true;
                }
                else
                {
                    gt.@checked = false;
                }
                children.Add(gt);
            }
        }

    }

}