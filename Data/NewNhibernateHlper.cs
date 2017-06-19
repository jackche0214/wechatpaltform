using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;

namespace Data
{
    public class NewNhibernateHlper
    {
        //先申明一个会话工厂
        private ISessionFactory _isessionfactory;
        public NewNhibernateHlper()
        {
            //创建会话工厂
            _isessionfactory = Get_isessionfactory();
        }
        public ISessionFactory Get_isessionfactory()
        {
            //配置会话工厂
            return (new Configuration()).Configure().BuildSessionFactory();
        }
        /// <summary>
        /// 打开session
        /// </summary>
        /// <returns></returns>
        public ISession openSession()
        {
            return _isessionfactory.OpenSession();
        }
    }
}
