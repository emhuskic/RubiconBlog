using RubiconBlog.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RubiconBlog.DAL
{

    public class BlogRepository : IBlogRepository, IDisposable
    {
        private BlogContext context;
        
        //Helper function to generate slug from title
        private string GenerateSlug(string phrase)
        {
            var s = phrase.ToLower();
            s = Regex.Replace(s, @"[^a-z0-9\s-]", "");                      // remove invalid characters
            s = Regex.Replace(s, @"\s+", " ").Trim();                       // single space
            s = s.Substring(0, s.Length <= 45 ? s.Length : 45).Trim();      // cut and trim
            s = Regex.Replace(s, @"\s", "-");                               // insert hyphens
            return s.ToLower();
        }

        public BlogRepository(BlogContext context)
        {
            this.context = context;
        }

        public IEnumerable<Tag> GetTags()
        {
            return context.Tags.ToList();
        }
        public Tag GetTagByName(string tagName)
        {
            return context.Tags.Where(t => t.Name == tagName).SingleOrDefault();
        }
        public IEnumerable<BlogPost> GetPosts(string tag)
        {
            if (!String.IsNullOrWhiteSpace(tag))
                return context.BlogPosts.Where(post => post.TagList.Where(tagg => tagg.Name == tag).Count() > 0).OrderByDescending(p => p.UpdatedAt).ToList();
            return context.BlogPosts.OrderByDescending(p => p.UpdatedAt).ToList();
        }

        public BlogPost GetPostBySlug(string slug)
        {
            return context.BlogPosts.Where(post => post.Slug == slug).SingleOrDefault();
        }

        public void InsertPost(BlogPost post)
        {
            post.CreatedAt = DateTime.Now;
            post.UpdatedAt = DateTime.Now;
            post.Slug = GenerateSlug(post.Title);
            context.BlogPosts.Add(post);
            Save();
        }

        public void DeletePost(string slug)
        { 
            BlogPost post = context.BlogPosts.Where(p => p.Slug == slug).SingleOrDefault();
            if (post != null)
            {
                context.BlogPosts.Remove(post);
                Save();
            }
        }

        public void UpdatePost(BlogPost post)
        {
            var existingPost = context.BlogPosts.Where(p => p.Slug == post.Slug).SingleOrDefault();
            if (existingPost != null)
            {
                if (!String.IsNullOrWhiteSpace(post.Title))
                {
                    existingPost.Title = post.Title;
                    existingPost.Slug = GenerateSlug(post.Title);
                }
                if (!String.IsNullOrWhiteSpace(post.Description))
                    existingPost.Description = post.Description;
                if (!String.IsNullOrWhiteSpace(post.Body))
                    existingPost.Body = post.Body;
                existingPost.UpdatedAt = DateTime.Now;
                context.Entry(existingPost).State = EntityState.Modified;
                Save();
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}