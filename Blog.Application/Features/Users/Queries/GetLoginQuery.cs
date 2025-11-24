using Blog.Application.Base;
using Blog.Application.Features.Users.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Users.Queries
{
    public class GetLoginQuery : IRequest<BaseResult<GetLoginQueryResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
