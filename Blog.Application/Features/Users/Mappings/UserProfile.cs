using AutoMapper;
using Blog.Application.Features.Users.Commands;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Users.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, CreateUserCommand>().ReverseMap();
        }
    }
}
