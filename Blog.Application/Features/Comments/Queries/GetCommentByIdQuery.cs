using Blog.Application.Base;
using Blog.Application.Features.Comments.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Queries
{
    public class GetCommentByIdQuery : IRequest<BaseResult<GetCommentByIdQueryResult>>
    {
        public Guid Id { get; set; }
    }
}
