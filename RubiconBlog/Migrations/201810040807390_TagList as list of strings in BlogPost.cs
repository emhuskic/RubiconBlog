namespace RubiconBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagListaslistofstringsinBlogPost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tag", "BlogPost_ID", "dbo.BlogPost");
            DropIndex("dbo.Tag", new[] { "BlogPost_ID" });
            DropColumn("dbo.Tag", "BlogPost_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tag", "BlogPost_ID", c => c.Int());
            CreateIndex("dbo.Tag", "BlogPost_ID");
            AddForeignKey("dbo.Tag", "BlogPost_ID", "dbo.BlogPost", "ID");
        }
    }
}
