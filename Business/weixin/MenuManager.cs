using Data;
using Domain.OrmLib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Business.Extsion;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Domain.OrmLib.Model;

namespace Business.weixin
{
    public class MenuManager
    {
        private static string url_menu_create = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=";

        /// <summary>
        /// 创建菜单函数。
        /// </summary>
        public static void CreateMenu()
        {
            NHibernateHelper nhlper = new NHibernateHelper();
            ISession session = nhlper.GetSession();
            IEnumerable<WeiXinMenu> kinds = session.Query<WeiXinMenu>();
            if (kinds.Count() <= 1)
            {
                throw new Exception("请先配置菜单");
            }
            string menu = "";
            menu += "{\"button\":[";
            kinds.Where(c => c.ParentId == "10000").Foreach(c => {
                menu += "{";
                menu += "\"name\":\"{0}\",".FormartWith(c.MenuName);
                menu += "\"sub_button\":[";
                kinds.Where(m=>m.ParentId==c.MenuId).Foreach(m=> {
                    menu += "{";
                    menu += "\"type\":\"{0}\",".FormartWith(m.MenuType);
                    menu += "\"name\":\"{0}\",".FormartWith(m.MenuName);
                    if (m.MenuType == "click")
                    {
                        menu += "\"key\":\"{0}\"".FormartWith(m.MenuKey);
                    }
                    else
                    {
                        menu += "\"url\":\"{0}\"".FormartWith(m.MenuUrl);
                    }
                    menu += "},";
                });
                menu = menu.Remove(menu.Length - 1, 1);
                menu += "]";
                menu += "},";
            });
            menu = menu.Remove(menu.Length - 1, 1);

            menu += "]";
            menu += "}";
            string url = url_menu_create + AccessToken.Weixin_ACCESS_TOKEN;
            string responsestring = HttpUtils.SendHttprequest(url,menu);
            JObject result = JsonConvert.DeserializeObject(responsestring) as JObject;
            string errcode = result["errcode"].ToString();
            string errmsg = result["errmsg"].ToString();
            if (errcode != "0")
            {
                throw new Exception(Weixin_Errorcode.GetErrormsg(int.Parse(errcode)));
            }
        }

     
    }
}
