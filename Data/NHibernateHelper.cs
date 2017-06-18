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
        public ISessionFactory _isessionfactory;

        public NHibernateHelper()
        {
            _isessionfactory = BulidISessionFactory();
        }
        public ISessionFactory BulidISessionFactory()
        {
            return (new Configuration()).Configure().BuildSessionFactory();
        }
        public ISession GetSession()
        {
            return _isessionfactory.OpenSession();
        }
    }
}
