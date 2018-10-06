using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RubiconBlog.Model
{
    public class Tag
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BlogPost> Posts { get; set; }
    }
}