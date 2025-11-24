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
    public class GetCommentsQuery : IRequest<BaseResult<List<GetCommentsQueryResult>>>
    {
    }
}
