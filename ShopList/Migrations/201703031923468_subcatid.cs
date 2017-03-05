namespace ShopList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subcatid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "SubCat_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "SubCat_Id");
        }
    }
}
