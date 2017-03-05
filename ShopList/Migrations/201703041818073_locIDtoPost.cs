namespace ShopList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locIDtoPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Loc_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Category_Id", c => c.Int());
            CreateIndex("dbo.Posts", "Category_Id");
            AddForeignKey("dbo.Posts", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "Category_Id" });
            DropColumn("dbo.Posts", "Category_Id");
            DropColumn("dbo.Posts", "Loc_Id");
        }
    }
}
