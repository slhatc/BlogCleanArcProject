using AutoMapper;
using Blog.Application.Abstracts.Persistence;
using Blog.Application.Base;
using Blog.Application.Features.Users.Queries;
using Blog.Application.Features.Users.Results;
using Blog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Users.Handlers
{
    public class GetLoginQueryHandler(UserManager<AppUser> _userManager,IMapper _mapper, IJwtService _jwtService) : IRequestHandler<GetLoginQuery, BaseResult<GetLoginQueryResult>>
    {
        public async Task<BaseResult<GetLoginQueryResult>> Handle(GetLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return BaseResult<GetLoginQueryResult>.Fail("Invalid email or password");
            }
            var userResult = _mapper.Map<GetUsersQueryResult>(user);
            var response = await _jwtService.GenerateTokenAsync(userResult);
            if (response == null)
            {
                return BaseResult<GetLoginQueryResult>.Fail("Failed to generate token");
            }
            return BaseResult<GetLoginQueryResult>.Success(response);
        }
    }
}
