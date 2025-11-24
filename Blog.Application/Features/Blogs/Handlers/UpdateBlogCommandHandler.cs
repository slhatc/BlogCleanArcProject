using AutoMapper;
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
    public class UpdateBlogCommandHandler(IGenericRepository<Domain.Entities.Blog> repository,IMapper _mapper,IUnitOfWork _unitOfWork) : IRequestHandler<UpdateBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = _mapper.Map<Domain.Entities.Blog>(request);
            await repository.UpdateAsync(blog);
            var response = await _unitOfWork.SaveChangesAsync();
            return response > 0 ? BaseResult<object>.Success(blog) : BaseResult<object>.Fail();
        }
    }
}
