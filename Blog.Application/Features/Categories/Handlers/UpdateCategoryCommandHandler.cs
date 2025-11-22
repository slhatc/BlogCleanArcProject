using AutoMapper;
using Blog.Application.Abstracts.Persistence;
using Blog.Application.Base;
using Blog.Application.Features.Categories.Commands;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Categories.Handlers
{
    public class UpdateCategoryCommandHandler(IGenericRepository<Category> _repository,IMapper _mapper,IUnitOfWork _unitOfWork) : IRequestHandler<UpdateCategoryCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            await _repository.UpdateAsync(category);
             var response = await _unitOfWork.SaveChangesAsync();
            return response > 0 ? BaseResult<bool>.Success(true) : BaseResult<bool>.Fail();
        }
    }
}
