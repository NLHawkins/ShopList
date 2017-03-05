namespace ShopList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class catIdtoPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Cat_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Cat_Id");
        }
    }
}
