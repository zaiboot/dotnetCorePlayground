using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class BasicWebApiContext : DbContext, IBasicWebApi
    {
        public BasicWebApiContext(DbContextOptions<BasicWebApiContext> options)
            : base(options)
        { }

        public DbSet<BasicTable> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
