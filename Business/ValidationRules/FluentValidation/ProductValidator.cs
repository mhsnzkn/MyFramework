using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(a => a.ProductName).NotEmpty().WithMessage("Urun ismi bos birakilamaz");
            RuleFor(a => a.ProductName).Length(2, 30);
            RuleFor(a => a.UnitPrice).NotEmpty();
            RuleFor(a => a.UnitPrice).GreaterThanOrEqualTo(1);
            RuleFor(a => a.UnitPrice).GreaterThanOrEqualTo(10).When(a => a.CategoryId == 10);
            RuleFor(a => a.ProductName).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
