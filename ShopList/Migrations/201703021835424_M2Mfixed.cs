namespace ShopList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2Mfixed : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tags", "PostId");
            CreateIndex("dbo.Tags", "LocId");
            CreateIndex("dbo.Tags", "CatId");
            AddForeignKey("dbo.Tags", "CatId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tags", "LocId", "dbo.Locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tags", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Tags", "LocId", "dbo.Locations");
            DropForeignKey("dbo.Tags", "CatId", "dbo.Categories");
            DropIndex("dbo.Tags", new[] { "CatId" });
            DropIndex("dbo.Tags", new[] { "LocId" });
            DropIndex("dbo.Tags", new[] { "PostId" });
        }
    }
}
