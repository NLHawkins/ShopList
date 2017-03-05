namespace ShopList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stillMakeingit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "SubCatId");
            DropColumn("dbo.Posts", "LocId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "LocId", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "SubCatId", c => c.Int(nullable: false));
        }
    }
}
