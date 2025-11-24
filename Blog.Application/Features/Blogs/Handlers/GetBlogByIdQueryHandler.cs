using AutoMapper;
using Blog.Application.Abstracts.Persistence;
using Blog.Application.Base;
using Blog.Application.Features.Blogs.Queries;
using Blog.Application.Features.Blogs.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Blogs.Handlers
{
    public class GetBlogByIdQueryHandler(IGenericRepository<Domain.Entities.Blog> _repository, IMapper _mapper) : IRequestHandler<GetBlogByIdQuery, BaseResult<GetBlogByIdQueryResult>>
    {
        public async Task<BaseResult<GetBlogByIdQueryResult>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            if (blog == null)
            {
                return BaseResult<GetBlogByIdQueryResult>.Fail("Blog not found");
            }
            var result = _mapper.Map<GetBlogByIdQueryResult>(blog);
            return BaseResult<GetBlogByIdQueryResult>.Success(result);
        }
    }
}
