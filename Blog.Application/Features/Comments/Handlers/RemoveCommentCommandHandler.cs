using AutoMapper;
using Blog.Application.Abstracts.Persistence;
using Blog.Application.Base;
using Blog.Application.Features.Comments.Commands;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Handlers
{
    public class RemoveCommentCommandHandler(IGenericRepository<Comment> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.Id);
            if (comment == null)
            {
                return BaseResult<object>.Fail("Comment not found");
            }
            await _repository.DeleteAsync(comment);
            var response = await _unitOfWork.SaveChangesAsync();
            return response > 0 ? BaseResult<object>.Success(true) : BaseResult<object>.Fail();
        }

    }
}
