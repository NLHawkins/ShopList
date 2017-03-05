namespace ShopList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fkanotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "SubCategory_Id", "dbo.SubCategories");
            DropForeignKey("dbo.Posts", "Image_Id", "dbo.ImageUploads");
            DropForeignKey("dbo.Posts", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Posts", new[] { "Image_Id" });
            DropIndex("dbo.Posts", new[] { "Location_Id" });
            DropIndex("dbo.Posts", new[] { "SubCategory_Id" });
            DropColumn("dbo.Posts", "SubCat_Id");
            DropColumn("dbo.Posts", "Loc_Id");
            RenameColumn(table: "dbo.Posts", name: "SubCategory_Id", newName: "SubCat_Id");
            RenameColumn(table: "dbo.Posts", name: "Image_Id", newName: "Img_Id");
            RenameColumn(table: "dbo.Posts", name: "Location_Id", newName: "Loc_Id");
            AlterColumn("dbo.Posts", "Img_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "Loc_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "SubCat_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "SubCat_Id");
            CreateIndex("dbo.Posts", "Loc_Id");
            CreateIndex("dbo.Posts", "Img_Id");
            AddForeignKey("dbo.Posts", "SubCat_Id", "dbo.SubCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "Img_Id", "dbo.ImageUploads", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "Loc_Id", "dbo.Locations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Loc_Id", "dbo.Locations");
            DropForeignKey("dbo.Posts", "Img_Id", "dbo.ImageUploads");
            DropForeignKey("dbo.Posts", "SubCat_Id", "dbo.SubCategories");
            DropIndex("dbo.Posts", new[] { "Img_Id" });
            DropIndex("dbo.Posts", new[] { "Loc_Id" });
            DropIndex("dbo.Posts", new[] { "SubCat_Id" });
            AlterColumn("dbo.Posts", "SubCat_Id", c => c.Int());
            AlterColumn("dbo.Posts", "Loc_Id", c => c.Int());
            AlterColumn("dbo.Posts", "Img_Id", c => c.Int());
            RenameColumn(table: "dbo.Posts", name: "Loc_Id", newName: "Location_Id");
            RenameColumn(table: "dbo.Posts", name: "Img_Id", newName: "Image_Id");
            RenameColumn(table: "dbo.Posts", name: "SubCat_Id", newName: "SubCategory_Id");
            AddColumn("dbo.Posts", "Loc_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "SubCat_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "SubCategory_Id");
            CreateIndex("dbo.Posts", "Location_Id");
            CreateIndex("dbo.Posts", "Image_Id");
            AddForeignKey("dbo.Posts", "Location_Id", "dbo.Locations", "Id");
            AddForeignKey("dbo.Posts", "Image_Id", "dbo.ImageUploads", "Id");
            AddForeignKey("dbo.Posts", "SubCategory_Id", "dbo.SubCategories", "Id");
        }
    }
}
