using RubiconBlog.DAL;
using RubiconBlog.DAL.Model;
using RubiconBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
namespace RubiconBlog.Controller
{
    public class PostsController: ApiController
    {
        private BlogContext context = new BlogContext();
        private IBlogRepository blogRepository;
        public PostsController()
        {
            this.blogRepository = new BlogRepository(new BlogContext());

        }
        public PostsController(IBlogRepository blogRep)
        {
            this.blogRepository = blogRep;
        }

        public IHttpActionResult Get()
        {
            try
            {
                var blogPosts = blogRepository.GetPosts("");
                var posts = blogPosts.Select(p => new
                {
                    slug = p.Slug,
                    title = p.Title,
                    description = p.Description,
                    body = p.Body,
                    tagList = p.TagList.Select(o => o.Name),
                    createdAt = p.CreatedAt,
                    updatedAt = p.UpdatedAt
                }).OrderByDescending(post => post.updatedAt).ToList();

                return Ok(new { blogPosts = posts });
            }
            catch (Exception ex)
            {
                return BadRequest("An error happened");
            }
        }
        public IHttpActionResult Get(string tag)
        {
            try
            {
                var blogPosts = blogRepository.GetPosts(tag);
                var posts = blogPosts.Select(p => new
                {
                    slug = p.Slug,
                    title = p.Title,
                    description = p.Description,
                    body = p.Body,
                    tagList = p.TagList.Select(o => o.Name),
                    createdAt = p.CreatedAt,
                    updatedAt = p.UpdatedAt
                }).OrderByDescending(post => post.updatedAt).ToList();

                return Ok(new { blogPosts = posts });
            }
            catch (Exception ex)
            {
                return BadRequest("An error happened");
            }
        }
        
        [System.Web.Http.HttpPost]
        public IHttpActionResult Create(BlogPostCreateWrapper req)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(req.BlogPost.Body) || String.IsNullOrWhiteSpace(req.BlogPost.Description) || String.IsNullOrWhiteSpace(req.BlogPost.Title))
                    return BadRequest("Description, body and title are required.");
                var postDto = Mapper.Map<BlogPostCreateModel, BlogPost>(req.BlogPost);
                postDto.TagList = makeTagList(req.BlogPost.TagList);
                blogRepository.InsertPost(postDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error happened");
            }
        }

        [System.Web.Http.Route("api/posts/{slug}")]
        [System.Web.Http.HttpPut]
        public IHttpActionResult Update (string slug, BlogPostUpdateWrapper wrapper)
        {
            try
            {
                wrapper.BlogPost.Slug = slug;
                var postDto = Mapper.Map<BlogPostUpdateModel, BlogPost>(wrapper.BlogPost);  //  
                blogRepository.UpdatePost(postDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error happened");
            }
        }

        [System.Web.Http.Route("api/posts/{slug}")]
        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete (string slug)
        {
            try
            {
                blogRepository.DeletePost(slug);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest("An error happened");
            }
        }
        [System.Web.Http.Route("api/posts/{slug}")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetPostBySlug(string slug)
        {
            try
            {
                BlogPost post = blogRepository.GetPostBySlug(slug);
                if (post != null)
                {
                    BlogPostViewModel viewPost = new BlogPostViewModel();
                    Mapper.Map<BlogPost, BlogPostViewModel>(post, viewPost);
                    viewPost.TagList = post.TagList.Select(o => o.Name).ToList();

                    return Ok(new { blogPost = viewPost });
                }
                return Ok("None of the posts have the slug provided in the URL.");
            }
            catch (Exception ex)
            {
                return BadRequest("An error happened");
            }
        }

        [System.Web.Http.Route("api/tags")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetTags()
        {
            var tags = blogRepository.GetTags();
            var tagList = tags.Select(o => o.Name);
            return Ok(tagList);
        }
        private List<Tag> makeTagList(List<string> tags)
        {
            List<Tag> TagList = new List<Tag>();
            foreach (var tag in tags)
            {
                var existingTag = blogRepository.GetTagByName(tag);
                if (existingTag != null)
                {
                    TagList.Add(existingTag);
                }
                else
                {
                    Tag newTag = new Tag();
                    newTag.Name = tag;
                    //context.Tags.Add(newTag);
                    //context.SaveChanges();
                    TagList.Add(newTag);
                }
            }
            return TagList;
        }
    }
}