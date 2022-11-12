using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CategoryValidation:AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.CategoryName).NotNull().NotEmpty().WithMessage("Kategori adı Boş geçilemez!").WithMessage("Kategori adı Boş geçilemez!").
              MinimumLength(3).WithMessage("Kategori adı en az 3 karaktere sahip olmalı!").
              MaximumLength(15).WithMessage("Kategori adı en fazla 15 karaktere sahip olmalı");

        }
    }
}
