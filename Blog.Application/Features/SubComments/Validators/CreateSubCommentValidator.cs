using Blog.Application.Features.SubComments.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Validators
{
    public class CreateSubCommentValidator : AbstractValidator<CreateSubCommentCommand>
    {
        public CreateSubCommentValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required.");
            RuleFor(x => x.CommentId).NotEmpty().WithMessage("CommentId is required.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
        }
    }
}
