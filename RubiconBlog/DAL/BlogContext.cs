using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RubiconBlog.Model;
using System.Xml.Linq;

namespace RubiconBlog.DAL
{
    public class BlogContext: DbContext
    {
        public BlogContext() : base("BlogContext")
        {
           
        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BlogPost.PostMapping());
            
        }
    }
}