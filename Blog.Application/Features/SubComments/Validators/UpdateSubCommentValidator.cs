using Blog.Application.Features.SubComments.Commands;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Validators
{
    public class UpdateSubCommentValidator : AbstractValidator<UpdateSubCommentCommand>
    {
        public UpdateSubCommentValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required.");
            RuleFor(x => x.CommentId).NotEmpty().WithMessage("CommentId is required.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
        }
    }
}
