using AuthProjectJWT.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProjectJWT.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(p => p.Name).Length(2, 30);
            RuleFor(p => p.Price).NotEmpty();          
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.Stock).NotEmpty();
        }
    }
}
