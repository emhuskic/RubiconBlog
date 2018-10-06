using AutoMapper;
using RubiconBlog.DAL.Model;
using RubiconBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RubiconBlog.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BlogPostUpdateModel, BlogPost>();
            CreateMap<BlogPostDeleteModel, BlogPost>();
            CreateMap<BlogPostCreateModel, BlogPost>().ForMember(x => x.TagList, opt => opt.Ignore());
            CreateMap<BlogPost, BlogPostViewModel>().ForMember(x => x.TagList, opt => opt.Ignore());

        }
    }
}