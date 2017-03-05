namespace ShopList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CatAndLocAddedWMany2Many : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Labels", "PostId", "dbo.Posts");
            DropIndex("dbo.Labels", new[] { "PostId" });
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatTag = c.String(),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.Post_Id);
            
            DropTable("dbo.Labels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Labels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LabelTag = c.String(),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Categories", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Categories", new[] { "Post_Id" });
            DropTable("dbo.Categories");
            CreateIndex("dbo.Labels", "PostId");
            AddForeignKey("dbo.Labels", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
