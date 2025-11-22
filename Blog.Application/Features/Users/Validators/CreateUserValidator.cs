using Blog.Application.Features.Users.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Users.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı gereklidir.");
            RuleFor(x=>x.FirstName).NotEmpty().WithMessage("İsim gereklidir.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim gereklidir.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email gereklidir.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Parola gereklidir.");
        }

    }
}
