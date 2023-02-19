using DevFramework.Northwind.Core.DataAccess.NHibernate;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.ComplexType;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NHProductDal : NHibernateRepositoryBase<Product>, IProductDal
    {
        private NHibernateHelper _nHibernateHelper;
        public NHProductDal(NHibernateHelper nhibernateHelper) : base(nhibernateHelper)
        {
            _nHibernateHelper = nhibernateHelper;
        }

        public List<ProductDetail> GetProductDetails()
        {
            using (var session=_nHibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>()
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetail()
                             {
                                 ProductId=p.ProductId,
                                 ProductName=p.ProductName,
                                 CategoryName=c.CategoryName
                             };
                return result.ToList();
            }
        }
    }
}
