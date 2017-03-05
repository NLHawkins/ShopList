namespace ShopList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagChk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "CatId", "dbo.Categories");
            DropForeignKey("dbo.Tags", "LocId", "dbo.Locations");
            DropForeignKey("dbo.Tags", "PostId", "dbo.Posts");
            DropIndex("dbo.Tags", new[] { "PostId" });
            DropIndex("dbo.Tags", new[] { "LocId" });
            DropIndex("dbo.Tags", new[] { "CatId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Tags", "CatId");
            CreateIndex("dbo.Tags", "LocId");
            CreateIndex("dbo.Tags", "PostId");
            AddForeignKey("dbo.Tags", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tags", "LocId", "dbo.Locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tags", "CatId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
