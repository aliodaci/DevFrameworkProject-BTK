using DevFramework.Northwind.Business.Abstarct;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.Core.DataAccess;
using DevFramework.Northwind.Core.DataAccess.EntityFramework;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DevFramework.Northwind.Core.DataAccess.NHibernate;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate;

namespace DevFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
