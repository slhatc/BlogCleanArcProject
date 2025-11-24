using AutoMapper;
using Blog.Application.Abstracts.Persistence;
using Blog.Application.Base;
using Blog.Application.Features.Comments.Queries;
using Blog.Application.Features.Comments.Results;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Handlers
{
    public class GetCommentByIdQueryHandler(IGenericRepository<Comment> _repository,IMapper _mapper) : IRequestHandler<GetCommentByIdQuery, BaseResult<GetCommentByIdQueryResult>>
    {
        public async Task<BaseResult<GetCommentByIdQueryResult>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.Id);
            if (comment == null)
            {
                return BaseResult<GetCommentByIdQueryResult>.Fail("Comment not found");
            }
            var response = _mapper.Map<GetCommentByIdQueryResult>(comment);
            return BaseResult<GetCommentByIdQueryResult>.Success(response);
        }
    }
}
