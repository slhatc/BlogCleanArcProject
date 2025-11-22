using Blog.Application.Base;
using Blog.Application.Features.Categories.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Categories.Queries
{
    public class GetCategoryQuery : IRequest<BaseResult<List<GetCategoryQueryResult>>>
    {
    }
}
