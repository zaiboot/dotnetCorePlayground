using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public interface IBasicWebApi
    {
        DbSet<BasicTable> Blogs { get; set; }
        DbSet<Post> Posts { get; set; }
    }
}