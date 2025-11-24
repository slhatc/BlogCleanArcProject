using Blog.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Commands
{
    public class RemoveCommentCommand : IRequest<BaseResult<object>>
    {
        public Guid Id { get; set; }
    }
}
