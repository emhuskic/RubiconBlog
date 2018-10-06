namespace RubiconBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagListserialized : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogPosts", "Tag_ID", "dbo.Tags");
            DropForeignKey("dbo.BlogPostTags", "BlogPost_ID", "dbo.BlogPosts");
            DropForeignKey("dbo.BlogPostTags", "Tag_ID", "dbo.Tags");
            DropIndex("dbo.BlogPosts", new[] { "Tag_ID" });
            DropIndex("dbo.BlogPostTags", new[] { "BlogPost_ID" });
            DropIndex("dbo.BlogPostTags", new[] { "Tag_ID" });
            AddColumn("dbo.BlogPosts", "TagList", c => c.String());
            DropColumn("dbo.BlogPosts", "Tag_ID");
            DropTable("dbo.BlogPostTags");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BlogPostTags",
                c => new
                    {
                        BlogPost_ID = c.Int(nullable: false),
                        Tag_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogPost_ID, t.Tag_ID });
            
            AddColumn("dbo.BlogPosts", "Tag_ID", c => c.Int());
            DropColumn("dbo.BlogPosts", "TagList");
            CreateIndex("dbo.BlogPostTags", "Tag_ID");
            CreateIndex("dbo.BlogPostTags", "BlogPost_ID");
            CreateIndex("dbo.BlogPosts", "Tag_ID");
            AddForeignKey("dbo.BlogPostTags", "Tag_ID", "dbo.Tags", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BlogPostTags", "BlogPost_ID", "dbo.BlogPosts", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BlogPosts", "Tag_ID", "dbo.Tags", "ID");
        }
    }
}
