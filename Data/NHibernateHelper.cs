using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;

namespace Data
{
    public class NHibernateHelper
    {
        private ISessionFactory _sessionFactory;
        public NHibernateHelper()
        {
            //创建ISessionFactory
            _sessionFactory = GetSessionFactory();
        }
        public ISessionFactory GetSessionFactory()
        {
            //配置ISessionFactory
            return (new Configuration()).Configure().BuildSessionFactory();
        }
        public ISession GetSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
