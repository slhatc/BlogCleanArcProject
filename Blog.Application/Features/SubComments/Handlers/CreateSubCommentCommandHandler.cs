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
    public class CreateSubCommentCommandHandler(IGenericRepository<SubComment> _repository,IMapper _mapper,IUnitOfWork _unitOfWork) : IRequestHandler<CreateSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subComment = _mapper.Map<SubComment>(request);
            await _repository.AddAsync(subComment);
            var response = await _unitOfWork.SaveChangesAsync();
            return response > 0 ? BaseResult<object>.Success(subComment) : BaseResult<object>.Fail();
        }
    }
}
