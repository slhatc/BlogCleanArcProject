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
    public class RemoveCategoryCommandHandler(IGenericRepository<Category> _repository,IUnitOfWork _unitOfWork): IRequestHandler<RemoveCategoryCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
            if (category == null)
            {
                return BaseResult<bool>.Fail("Category not found");
            }
            await _repository.DeleteAsync(category);
            var response = await _unitOfWork.SaveChangesAsync();
            return response > 0 ? BaseResult<bool>.Success(true) : BaseResult<bool>.Fail();
        }
    }
}
