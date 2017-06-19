using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.OrmLib.Entity;
using Data.datalinq;
using System.Linq.Expressions;

namespace Business
{
    public class WeixinMenuBusiness
    {
        private weixinmenu _weixinmenudata;

        public WeixinMenuBusiness()
        {
            _weixinmenudata = new weixinmenu();
        }
        public IList<WeiXinMenu> GetWeixinMenuList(Expression<Func<WeiXinMenu, bool>> where)
        {
            return _weixinmenudata.GetWeixinMenuList(where);
        }
    }
}
