using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace RubiconBlog.Model
{
    
    public class BlogPost
    {
        [Key]
        public int ID { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public virtual ICollection <Tag> TagList { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public class PostMapping : EntityTypeConfiguration<BlogPost>
        {
            public PostMapping()
            {
                HasMany(m => m.TagList).WithMany();
            }
        }
      
    }
}