using Blog.Application.Features.Comments.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Validators
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required.");
            RuleFor(x => x.BlogId).NotEmpty().WithMessage("BlogId is required.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");

        }
    }
}
