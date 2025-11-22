using AutoMapper;
using Blog.Application.Abstracts.Persistence;
using Blog.Application.Base;
using Blog.Application.Features.Categories.Queries;
using Blog.Application.Features.Categories.Results;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Categories.Handlers
{
    public class GetCategoryQueryHandler(IGenericRepository<Category> _repository,IMapper mapper) : IRequestHandler<GetCategoryQuery, BaseResult<List<GetCategoryQueryResult>>>
    {
        async Task<BaseResult<List<GetCategoryQueryResult>>> IRequestHandler<GetCategoryQuery, BaseResult<List<GetCategoryQueryResult>>>.Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();
            var response = mapper.Map<List<GetCategoryQueryResult>>(categories);
            return BaseResult<List<GetCategoryQueryResult>>.Success(response);
        }
    }
}
