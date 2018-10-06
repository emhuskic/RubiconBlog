namespace RubiconBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagListaslistofTags : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BlogPost", newName: "BlogPosts");
            RenameTable(name: "dbo.Tag", newName: "Tags");
            CreateTable(
                "dbo.BlogPostTags",
                c => new
                    {
                        BlogPost_ID = c.Int(nullable: false),
                        Tag_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogPost_ID, t.Tag_ID })
                .ForeignKey("dbo.BlogPosts", t => t.BlogPost_ID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_ID, cascadeDelete: true)
                .Index(t => t.BlogPost_ID)
                .Index(t => t.Tag_ID);
            
            AddColumn("dbo.BlogPosts", "Tag_ID", c => c.Int());
            CreateIndex("dbo.BlogPosts", "Tag_ID");
            AddForeignKey("dbo.BlogPosts", "Tag_ID", "dbo.Tags", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPostTags", "Tag_ID", "dbo.Tags");
            DropForeignKey("dbo.BlogPostTags", "BlogPost_ID", "dbo.BlogPosts");
            DropForeignKey("dbo.BlogPosts", "Tag_ID", "dbo.Tags");
            DropIndex("dbo.BlogPostTags", new[] { "Tag_ID" });
            DropIndex("dbo.BlogPostTags", new[] { "BlogPost_ID" });
            DropIndex("dbo.BlogPosts", new[] { "Tag_ID" });
            DropColumn("dbo.BlogPosts", "Tag_ID");
            DropTable("dbo.BlogPostTags");
            RenameTable(name: "dbo.Tags", newName: "Tag");
            RenameTable(name: "dbo.BlogPosts", newName: "BlogPost");
        }
    }
}
