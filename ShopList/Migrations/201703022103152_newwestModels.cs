namespace ShopList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newwestModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Tags", "CatId", "dbo.Categories");
            DropForeignKey("dbo.Tags", "LocId", "dbo.Locations");
            DropForeignKey("dbo.Tags", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.Categories", new[] { "Post_Id" });
            DropIndex("dbo.Posts", new[] { "Tag_Id" });
            DropIndex("dbo.Tags", new[] { "PostId" });
            DropIndex("dbo.Tags", new[] { "LocId" });
            DropIndex("dbo.Tags", new[] { "CatId" });
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            AddColumn("dbo.Locations", "Locale", c => c.String());
            AddColumn("dbo.Posts", "SubCatId", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "LocId", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "SubCategory_Id", c => c.Int());
            AddColumn("dbo.Posts", "Location_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "PrefLocId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "SubCategory_Id");
            CreateIndex("dbo.Posts", "Location_Id");
            AddForeignKey("dbo.Posts", "SubCategory_Id", "dbo.SubCategories", "Id");
            AddForeignKey("dbo.Posts", "Location_Id", "dbo.Locations", "Id");
            DropColumn("dbo.Categories", "Post_Id");
            DropColumn("dbo.Locations", "LocTag");
            DropColumn("dbo.Posts", "Tag_Id");
            DropTable("dbo.Tags");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "Tag_Id", c => c.Int());
            AddColumn("dbo.Locations", "LocTag", c => c.String());
            AddColumn("dbo.Categories", "Post_Id", c => c.Int());
            DropForeignKey("dbo.Posts", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Posts", "SubCategory_Id", "dbo.SubCategories");
            DropIndex("dbo.Posts", new[] { "Location_Id" });
            DropIndex("dbo.Posts", new[] { "SubCategory_Id" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropColumn("dbo.AspNetUsers", "PrefLocId");
            DropColumn("dbo.Posts", "Location_Id");
            DropColumn("dbo.Posts", "SubCategory_Id");
            DropColumn("dbo.Posts", "LocId");
            DropColumn("dbo.Posts", "SubCatId");
            DropColumn("dbo.Locations", "Locale");
            DropTable("dbo.SubCategories");
            CreateIndex("dbo.Tags", "CatId");
            CreateIndex("dbo.Tags", "LocId");
            CreateIndex("dbo.Tags", "PostId");
            CreateIndex("dbo.Posts", "Tag_Id");
            CreateIndex("dbo.Categories", "Post_Id");
            AddForeignKey("dbo.Posts", "Tag_Id", "dbo.Tags", "Id");
            AddForeignKey("dbo.Tags", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tags", "LocId", "dbo.Locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tags", "CatId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Categories", "Post_Id", "dbo.Posts", "Id");
        }
    }
}
