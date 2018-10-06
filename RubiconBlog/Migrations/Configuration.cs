
using System.Collections.Generic;
namespace RubiconBlog.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RubiconBlog.DAL.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "RubiconBlog.DAL.BlogContext";
        }
       
        protected override void Seed(RubiconBlog.DAL.BlogContext context)
        {
          
            var tags = new List<Tag>
            {
                new Tag { Name="Android"},
                new Tag {Name="iOS" },
                new Tag {Name="Microsoft" },
                new Tag { Name="Programming"},
                new Tag {Name="React" },
                new Tag {Name="React Native" },
                new Tag { Name="iPhone"},
                new Tag {Name="Test" }
            };
            tags.ForEach(tag => context.Tags.AddOrUpdate(tag));
            context.SaveChanges();

            var posts = new List<BlogPost>
            {
                new BlogPost {Slug="augmented-reality-ios-application", Body= "The app is simple to use, and will help you decide on your best furniture fit.", Title="Augmented Reality iOS Application", UpdatedAt=DateTime.Today, CreatedAt=DateTime.Today, Description="Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app."},
                new BlogPost {Slug="augmented-reality-android-application", Body= "The app is simple to use, and will help you decide on your best furniture fit.", Title="Augmented Reality Android Application", UpdatedAt=DateTime.Today, CreatedAt=DateTime.Today, Description="Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app."},
                new BlogPost {Slug="test-post", Body= "This is a test blog post.", Title="Test post", UpdatedAt=DateTime.Today, CreatedAt=DateTime.Today, Description="Rubicon Software Development approved this test post"},
                new BlogPost {Slug="react-native-programming", Body= "Why is React Native a big hit in programming today?", Title="React Native Programming", UpdatedAt=DateTime.Today, CreatedAt=DateTime.Today, Description="This is just a simple blog post about React Native."},
                new BlogPost {Slug="ios-rocks", Body= "iOS is so much better than Android! It's fool proof and it offers great stuff too.", Title="iOS Rocks", UpdatedAt=DateTime.Today, CreatedAt=DateTime.Today, Description="Post about iOS and why it rocks."},
                new BlogPost {Slug="programming-is-easy", Body= "This is a post about how programming is so easy when you love it.", Title="Programming is easy", UpdatedAt=DateTime.Today, CreatedAt=DateTime.Today, Description="Programming..."}

            };
             posts.ForEach(post => context.BlogPosts.AddOrUpdate(post));
            context.SaveChanges();

            AddOrUpdateTag(context, "augmented-reality-ios-application", "iOS");
            AddOrUpdateTag(context, "augmented-reality-android-application", "Android");
            AddOrUpdateTag(context, "test-post", "Test");
            AddOrUpdateTag(context, "ios-rocks", "iOS");
            AddOrUpdateTag(context, "ios-rocks", "iPhone");
            AddOrUpdateTag(context, "react-native-programming", "React");
            AddOrUpdateTag(context, "react-native-programming", "React Native");
            AddOrUpdateTag(context, "react-native-programming", "Programming");
            context.SaveChanges();
            
        }
        void AddOrUpdateTag(RubiconBlog.DAL.BlogContext context,string slug, string tagName)
        {
            var crs = context.BlogPosts.FirstOrDefault(c => c.Slug == slug);
            if (crs != null)
            {
                if(crs.TagList==null)
                crs.TagList = new List<Tag>();
                crs.TagList.Add(context.Tags.Single(i => i.Name == tagName));
            }
        }
    }
}
