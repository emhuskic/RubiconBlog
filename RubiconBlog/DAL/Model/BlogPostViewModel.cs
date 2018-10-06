using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RubiconBlog.DAL.Model
{
    public class BlogPostViewModel
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public List<string> TagList { get; set; }
        public DateTime UpdatedAt { get;set;}
        public DateTime CreatedAt { get; set; }
        public int ID { get; set; }
    }
}