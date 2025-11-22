using Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Persistence.Context
{
    public class AppDbContext(DbContextOptions options) :IdentityDbContext<AppUser,AppRole,string>(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Domain.Entities.Blog> Blogs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        
    }
}
