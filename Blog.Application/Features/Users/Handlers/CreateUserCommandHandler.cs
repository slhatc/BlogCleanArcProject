using AutoMapper;
using Blog.Application.Base;
using Blog.Application.Features.Users.Commands;
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
    public class CreateUserCommandHandler(UserManager<AppUser> _userManager,IMapper _mapper) : IRequestHandler<CreateUserCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AppUser>(request);
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return BaseResult<object>.Fail(result.Errors);
            }
            return BaseResult<object>.Success(user);

        }
    }
}
