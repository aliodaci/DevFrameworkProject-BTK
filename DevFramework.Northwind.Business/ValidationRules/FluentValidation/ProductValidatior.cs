using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidatior:AbstractValidator<Product>
    {
        public ProductValidatior()
        {
            RuleFor(p=>p.CategoryId).NotEmpty();
            RuleFor(p => p.ProductName).NotEmpty().MinimumLength(5).WithMessage("Ürün Adı En Az 10 Karakter olmalıdır.");
            RuleFor(p=>p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty().GreaterThan(20).When(p => p.CategoryId == 1);

        }
    }
}
