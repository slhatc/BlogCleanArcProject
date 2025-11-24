using Blog.Application.Base;
using Blog.Application.Features.SubComments.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Queries
{
    public class GetSubCommentByIdQuery : IRequest<BaseResult<GetSubCommentByIdQueryResult>>
    {
        public Guid Id { get; set; }
    }
}
