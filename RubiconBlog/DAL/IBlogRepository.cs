using RubiconBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RubiconBlog.DAL
{
    public interface IBlogRepository:IDisposable
    {
        IEnumerable<BlogPost> GetPosts(string tag);
        BlogPost GetPostBySlug(string slug);
        void InsertPost(BlogPost post);
        void DeletePost(string slug);
        void UpdatePost(BlogPost post);
        IEnumerable<Tag> GetTags();
        Tag GetTagByName(string tagName);
       void Save();
    }
}