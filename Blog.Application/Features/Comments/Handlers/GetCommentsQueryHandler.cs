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
    public class GetCommentsQueryHandler(IGenericRepository<Comment> _repository,IMapper _mapper) : IRequestHandler<GetCommentsQuery, BaseResult<List<GetCommentsQueryResult>>>
    {
        public async Task<BaseResult<List<GetCommentsQueryResult>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _repository.GetAllAsync();
            var response = _mapper.Map<List<GetCommentsQueryResult>>(comments);
            return BaseResult<List<GetCommentsQueryResult>>.Success(response);
        }
    }
}
