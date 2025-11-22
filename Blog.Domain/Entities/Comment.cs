using Blog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public virtual IList<SubComment> SubComments { get; set; }
        public Guid BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
