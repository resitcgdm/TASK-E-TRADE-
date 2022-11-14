using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class ProductValidation:AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.ProductName).NotNull().NotEmpty().WithMessage("Ürün adı Boş geçilemez!").WithMessage("Ürün adı Boş geçilemez!").
              MinimumLength(1).WithMessage("Ürün adı en az 1 karaktere sahip olmalı!").
              MaximumLength(35).WithMessage("Ürün adı en fazla 35 karaktere sahip olmalı");

        }
    }
}
