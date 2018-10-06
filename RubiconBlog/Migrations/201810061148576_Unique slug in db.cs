namespace RubiconBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Uniqueslugindb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogPosts", "Slug", c => c.String(maxLength: 450));
            CreateIndex("dbo.BlogPosts", "Slug", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.BlogPosts", new[] { "Slug" });
            AlterColumn("dbo.BlogPosts", "Slug", c => c.String());
        }
    }
}
