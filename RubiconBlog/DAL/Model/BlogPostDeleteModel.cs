using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RubiconBlog.DAL.Model
{
    public class BlogPostDeleteModel
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
    }
}