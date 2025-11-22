using AutoMapper;
using Blog.Application.Features.Blogs.Results;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Blogs.Mappings
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<Domain.Entities.Blog,GetBlogsQueryResult>().ReverseMap();
        }
    }
}
