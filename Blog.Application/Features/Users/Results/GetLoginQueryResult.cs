using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Users.Results
{
    public class GetLoginQueryResult
    {
        public string GenerateToken { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
