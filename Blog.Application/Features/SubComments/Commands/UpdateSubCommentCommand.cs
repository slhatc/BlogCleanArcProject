using Blog.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Commands
{
    public class UpdateSubCommentCommand : IRequest<BaseResult<object>>
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid CommentId { get; set; }
        public string UserId { get; set; }
    }
}
