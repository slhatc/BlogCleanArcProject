using Blog.Application.Abstracts.Persistence;
using Blog.Application.Base;
using Blog.Application.Features.Blogs.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Blogs.Handlers
{
    public class RemoveBlogCommandHandler(IGenericRepository<Domain.Entities.Blog> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveBlogCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            if (blog == null)
            {
                return BaseResult<bool>.Fail("Blog not found");
            }
            await _repository.DeleteAsync(blog);
            var response = await _unitOfWork.SaveChangesAsync();
            return response > 0 ? BaseResult<bool>.Success(true) : BaseResult<bool>.Fail();
        }
    }
}
