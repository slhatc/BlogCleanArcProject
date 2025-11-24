using AutoMapper;
using Blog.Application.Features.Comments.Commands;
using Blog.Application.Features.Comments.Results;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Mappings
{
    public class CommentProfile :Profile
    {
        public CommentProfile()
        {
            
            CreateMap<Comment,GetCommentsQueryResult>().ReverseMap();
            CreateMap<Comment,CreateCommentCommand>().ReverseMap();
            CreateMap<Comment,GetCommentByIdQueryResult>().ReverseMap();
            CreateMap<Comment,UpdateCommentCommand>().ReverseMap();
        }
    }
}
