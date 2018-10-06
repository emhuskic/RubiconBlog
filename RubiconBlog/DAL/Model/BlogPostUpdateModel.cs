using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RubiconBlog.DAL.Model
{
    public class BlogPostUpdateWrapper
    {
        public BlogPostUpdateModel BlogPost { get; set; }
    }
    public class BlogPostUpdateModel
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
    }
}