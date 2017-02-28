using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class BasicTable
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }
}