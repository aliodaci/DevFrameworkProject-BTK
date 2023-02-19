using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _dbContext;
        private DbSet<T> _entities;
        public EfQueryableRepository(DbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public IQueryable<T> Table => this.Entities;

        protected virtual IDbSet<T> Entities
        {
            get
            {
                return _entities ?? (_entities = _dbContext.Set<T>());
            }
        }

    }
}
