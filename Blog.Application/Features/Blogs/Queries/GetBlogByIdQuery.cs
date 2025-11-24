using Blog.Application.Base;
using Blog.Application.Features.Blogs.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Blogs.Queries
{
    public class GetBlogByIdQuery : IRequest<BaseResult<GetBlogByIdQueryResult>>
    {
        public Guid Id { get; set; }
    }
}
