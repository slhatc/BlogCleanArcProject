using AutoMapper;
using Blog.Application.Abstracts.Persistence;
using Blog.Application.Base;
using Blog.Application.Features.SubComments.Commands;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Handlers
{
    public class RemoveSubCommentCommandHandler(IGenericRepository<SubComment> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subComment = await _repository.GetByIdAsync(request.Id);
            if (subComment == null)
            {
                return BaseResult<object>.Fail("SubComment not found");
            }
            await _repository.DeleteAsync(subComment);
            var response = await _unitOfWork.SaveChangesAsync();
            return response > 0 ? BaseResult<object>.Success(true) : BaseResult<object>.Fail();
        }
    }
}
