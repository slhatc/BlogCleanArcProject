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
    public class GetBlogsQueryHandler(IGenericRepository<Domain.Entities.Blog> _repository,IMapper _mapper) : IRequestHandler<GetBlogsQuery, BaseResult<List<GetBlogsQueryResult>>>
    {
        public async Task<BaseResult<List<GetBlogsQueryResult>>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _repository.GetAllAsync();
            var response = _mapper.Map<List<GetBlogsQueryResult>>(blogs);
            return BaseResult<List<GetBlogsQueryResult>>.Success(response);
        }
    }
}
