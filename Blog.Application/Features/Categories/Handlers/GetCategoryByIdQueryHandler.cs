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
    public class GetCategoryByIdQueryHandler(IGenericRepository<Category> _repository,IMapper _mapper) : IRequestHandler<GetCategoryByIdQuery, BaseResult<GetCategoryByIdQueryResult>>
    {
        public async Task<BaseResult<GetCategoryByIdQueryResult>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
            if (category == null)
            {
                return BaseResult<GetCategoryByIdQueryResult>.Fail("Category not found");
            }
            var response = _mapper.Map<GetCategoryByIdQueryResult>(category);
            return BaseResult<GetCategoryByIdQueryResult>.Success(response);
        }
    }
}
