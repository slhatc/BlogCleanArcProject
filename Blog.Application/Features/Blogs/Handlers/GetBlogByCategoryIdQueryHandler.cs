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
    public class GetBlogByCategoryIdQueryHandler(IGenericRepository<Domain.Entities.Blog> _repository, IMapper _mapper) : IRequestHandler<GetBlogsByCategoryIdQuery, BaseResult<List<GetBlogsByCategoryIdQueryResult>>>
    {
        public async Task<BaseResult<List<GetBlogsByCategoryIdQueryResult>>> Handle(GetBlogsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Find(x=>x.CategoryId == request.CategoryId).ToList();
            var blogs = _mapper.Map<List<GetBlogsByCategoryIdQueryResult>>(query);
            return BaseResult<List<GetBlogsByCategoryIdQueryResult>>.Success(blogs);
        }
    }
}
