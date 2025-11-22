using Blog.Application.Features.Categories.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Categories.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori ismi gereklidir.")
                .MinimumLength(3).WithMessage("Kategori ismi en az 3 karekter olmalıdır.");
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Kategori Id gereklidir.");
        }
    }
}
