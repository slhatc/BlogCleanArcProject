using AutoMapper;
using Blog.Application.Features.Blogs.Commands;
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
            CreateMap<Domain.Entities.Blog,CreateBlogCommand>().ReverseMap();
            CreateMap<Domain.Entities.Blog,GetBlogByIdQueryResult>().ReverseMap();
            CreateMap<Domain.Entities.Blog,UpdateBlogCommand>().ReverseMap();
            CreateMap<Domain.Entities.Blog,GetBlogsByCategoryIdQueryResult>().ReverseMap();

        }
    }
}
