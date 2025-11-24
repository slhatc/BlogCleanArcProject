using AutoMapper;
using Blog.Application.Abstracts.Persistence;
using Blog.Application.Base;
using Blog.Application.Features.SubComments.Queries;
using Blog.Application.Features.SubComments.Results;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Handlers
{
    public class GetSubCommentByIdQueryHandler(IGenericRepository<SubComment> _repository, IMapper _mapper) : IRequestHandler<GetSubCommentByIdQuery, BaseResult<GetSubCommentByIdQueryResult>>
    {
        public async Task<BaseResult<GetSubCommentByIdQueryResult>> Handle(GetSubCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var subComment = await _repository.GetByIdAsync(request.Id);
            if (subComment == null)
            {
                return BaseResult<GetSubCommentByIdQueryResult>.Fail("SubComment not found");
            }
            var result = _mapper.Map<GetSubCommentByIdQueryResult>(subComment);
            return BaseResult<GetSubCommentByIdQueryResult>.Success(result);
        }
    }
}
