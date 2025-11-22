using Blog.Application.Base;
using Blog.Application.Features.Categories.Results;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Blogs.Results
{
    public class GetBlogsQueryResult : BaseDto
    {
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public string BlogImage { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public  GetCategoryQueryResult Category { get; set; }
        public string UserId { get; set; }
        //public  AppUser User { get; set; }
        //public  IList<Comment> Comments { get; set; }
    }
}
