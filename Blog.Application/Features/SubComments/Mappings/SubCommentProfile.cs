using AutoMapper;
using Blog.Application.Features.SubComments.Commands;
using Blog.Application.Features.SubComments.Results;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Mappings
{
    public class SubCommentProfile : Profile
    {
        public SubCommentProfile()
        {
            CreateMap<SubComment,CreateSubCommentCommand>().ReverseMap();
            CreateMap<SubComment,UpdateSubCommentCommand>().ReverseMap();
            CreateMap<SubComment,GetSubCommentsQueryResult>().ReverseMap();
            CreateMap<SubComment,GetSubCommentByIdQueryResult>().ReverseMap();
        }
    }
}
