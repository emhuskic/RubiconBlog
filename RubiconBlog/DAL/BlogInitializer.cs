using RubiconBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RubiconBlog.DAL
{
    public class BlogInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            //var tags = new List<Tag>
            //{
            //    new Tag { Name="Android"},
            //    new Tag {Name="iOS" },
            //    new Tag {Name="Microsoft" }
            //};
            //tags.ForEach(tag => context.Tags.Add(tag));
            //context.SaveChanges();
        }
    }
}