namespace RubiconBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPost",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Slug = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Body = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BlogPost_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BlogPost", t => t.BlogPost_ID)
                .Index(t => t.BlogPost_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tag", "BlogPost_ID", "dbo.BlogPost");
            DropIndex("dbo.Tag", new[] { "BlogPost_ID" });
            DropTable("dbo.Tag");
            DropTable("dbo.BlogPost");
        }
    }
}
