namespace ShopList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageUploads", "PostId", "dbo.Posts");
            DropIndex("dbo.ImageUploads", new[] { "PostId" });
            AddColumn("dbo.Posts", "Image_Id", c => c.Int());
            CreateIndex("dbo.Posts", "Image_Id");
            AddForeignKey("dbo.Posts", "Image_Id", "dbo.ImageUploads", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Image_Id", "dbo.ImageUploads");
            DropIndex("dbo.Posts", new[] { "Image_Id" });
            DropColumn("dbo.Posts", "Image_Id");
            CreateIndex("dbo.ImageUploads", "PostId");
            AddForeignKey("dbo.ImageUploads", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
