using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.OrmLib.Entity;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace Data.datalinq
{
    public class weixinmenu
    {
        public IList<WeiXinMenu> GetWeixinMenuList(Expression<Func<WeiXinMenu,bool>> where)
        {
            try
            {
                NHibernateHelper nhibernatehelper = new NHibernateHelper();
                ISession session = nhibernatehelper.GetSession();
                return session.Query<WeiXinMenu>().Select(x => new WeiXinMenu { UserName = x.UserName, UserNum = x.UserNum}).Where(where).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
