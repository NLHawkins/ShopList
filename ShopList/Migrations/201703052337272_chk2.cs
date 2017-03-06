namespace ShopList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chk2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "PrefLocId", "dbo.Locations");
            DropIndex("dbo.AspNetUsers", new[] { "PrefLocId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.AspNetUsers", "PrefLocId");
            AddForeignKey("dbo.AspNetUsers", "PrefLocId", "dbo.Locations", "Id", cascadeDelete: true);
        }
    }
}
