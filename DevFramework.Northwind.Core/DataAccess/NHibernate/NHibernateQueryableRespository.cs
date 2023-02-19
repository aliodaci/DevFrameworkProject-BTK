using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Core.DataAccess.NHibernate
{
    public class NHibernateQueryableRespository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;

        public NHibernateQueryableRespository(NHibernateHelper nHibernateHelper, IQueryable<T> entities)
        {
            _nHibernateHelper = nHibernateHelper;
            _entities = entities;
        }

        public IQueryable<T> Table => this.Entities;

        public virtual IQueryable<T> Entities
        {
            get
            {
                return _entities??(_entities=_nHibernateHelper.OpenSession().Query<T>());
            }
        }
    }
}
