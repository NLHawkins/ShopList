namespace ShopList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostImagesAndLabelsAddedInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageUploads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        File = c.String(),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Labels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LabelTag = c.String(),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        OwnerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Labels", "PostId", "dbo.Posts");
            DropForeignKey("dbo.ImageUploads", "PostId", "dbo.Posts");
            DropIndex("dbo.Labels", new[] { "PostId" });
            DropIndex("dbo.ImageUploads", new[] { "PostId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Labels");
            DropTable("dbo.ImageUploads");
        }
    }
}
