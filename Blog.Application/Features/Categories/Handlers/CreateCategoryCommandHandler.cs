using AutoMapper;
using Blog.Application.Abstracts.Persistence;
using Blog.Application.Base;
using Blog.Application.Features.Categories.Commands;
using Blog.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Categories.Handlers
{
    public class CreateCategoryCommandHandler(IGenericRepository<Category> _repository,IUnitOfWork _unitOfWork,IMapper _mapper) : IRequestHandler<CreateCategoryCommands, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(CreateCategoryCommands request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            await _repository.AddAsync(category);
            var response = await _unitOfWork.SaveChangesAsync();
            return response > 0 ? BaseResult<bool>.Success(true) : BaseResult<bool>.Fail();
        }
    }
}
