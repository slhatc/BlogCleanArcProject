using AutoMapper;
using Blog.Application.Features.Categories.Commands;
using Blog.Application.Features.Categories.Results;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Categories.Mappings
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, GetCategoryQueryResult>().ReverseMap();
            CreateMap<Category, CreateCategoryCommands>().ReverseMap();
            CreateMap<Category,GetCategoryByIdQueryResult>().ReverseMap();
            CreateMap<Category , UpdateCategoryCommand>().ReverseMap();
        }
    }
}
