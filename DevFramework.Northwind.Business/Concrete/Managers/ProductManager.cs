using DevFramework.Northwind.Business.Abstarct;
using DevFramework.Northwind.Business.DependencyResolvers.Ninject;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.Core.DataAccess;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Northwind.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Northwind.Core.CrossCuttingConcerns.Logging.Loggers;
using DevFramework.Northwind.Core.Aspects.Postsharp.AuthorizationAspects;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using DevFramework.Northwind.Core.Utilities.Mappings;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        //[SecuredOperation(Roles ="Editor")]
        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Add(Product product)
        {
            
            return _productDal.Add(product);
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p=>p.ProductId==id);
        }

        //[SecuredOperation(Roles ="Admin,Editor")]
        public List<Product> GetAll()
        {
            var products = _mapper.Map<List<Product>>(_productDal.GetAll());
            return products;
            //return _productDal.GetAll().Select(p=>new Product()
            //{
            //   CategoryId= p.CategoryId,
            //   ProductId= p.ProductId,
            //   ProductName= p.ProductName,
            //   QuantityPerUnit= p.QuantityPerUnit,
            //   UnitPrice= p.UnitPrice,
            //}).ToList();

        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
    }
}
