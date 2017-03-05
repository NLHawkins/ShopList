namespace ShopList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class owneriD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Owner_Id", c => c.String());
            DropColumn("dbo.Posts", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "OwnerId", c => c.String());
            DropColumn("dbo.Posts", "Owner_Id");
        }
    }
}
