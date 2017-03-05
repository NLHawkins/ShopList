namespace ShopList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagMany2Mny : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        LocId = c.Int(nullable: false),
                        CatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CatId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.LocId)
                .Index(t => t.CatId);
            
            AddColumn("dbo.Posts", "Tag_Id", c => c.Int());
            CreateIndex("dbo.Posts", "Tag_Id");
            AddForeignKey("dbo.Posts", "Tag_Id", "dbo.Tags", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Tags", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Tags", "LocId", "dbo.Locations");
            DropForeignKey("dbo.Tags", "CatId", "dbo.Categories");
            DropIndex("dbo.Tags", new[] { "CatId" });
            DropIndex("dbo.Tags", new[] { "LocId" });
            DropIndex("dbo.Tags", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "Tag_Id" });
            DropColumn("dbo.Posts", "Tag_Id");
            DropTable("dbo.Tags");
        }
    }
}
