using AutoMapper;
using Blog.Application.Abstracts.Persistence;
using Blog.Application.Base;
using Blog.Application.Features.Blogs.Commands;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Blogs.Handlers
{
    public class CreateBlogCommandHandler(IGenericRepository<Domain.Entities.Blog> repository,IMapper mapper,IUnitOfWork unitOfWork) : IRequestHandler<CreateBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = mapper.Map<Domain.Entities.Blog>(request);
            await repository.AddAsync(blog);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(blog);
        }
    }
}
