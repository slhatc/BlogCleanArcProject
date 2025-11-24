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
    public class UpdateCommentCommandHandler(IGenericRepository<Comment> _repository,IMapper _mapper,IUnitOfWork _unitOfWork) : IRequestHandler<UpdateCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request);
            await _repository.UpdateAsync(comment);
            var response = await _unitOfWork.SaveChangesAsync();
            return response > 0 ? BaseResult<object>.Success(comment) : BaseResult<object>.Fail();
        }
    }
}
