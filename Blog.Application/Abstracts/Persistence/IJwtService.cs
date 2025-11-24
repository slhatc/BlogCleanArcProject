using Blog.Application.Features.Users.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Abstracts.Persistence
{
    public interface IJwtService
    {
        Task<GetLoginQueryResult> GenerateTokenAsync(GetUsersQueryResult result);
    }
}
