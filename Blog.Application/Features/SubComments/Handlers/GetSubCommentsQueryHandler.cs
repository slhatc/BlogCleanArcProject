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
    public class GetSubCommentsQueryHandler(IGenericRepository<SubComment> _repository, IMapper _mapper) : IRequestHandler<GetSubCommentsQuery, BaseResult<List<GetSubCommentsQueryResult>>>
    {
        public async Task<BaseResult<List<GetSubCommentsQueryResult>>> Handle(GetSubCommentsQuery request, CancellationToken cancellationToken)
        {
            var subComments = await _repository.GetAllAsync();
            var response = _mapper.Map<List<GetSubCommentsQueryResult>>(subComments);
            return BaseResult<List<GetSubCommentsQueryResult>>.Success(response);
        }
    }
}
