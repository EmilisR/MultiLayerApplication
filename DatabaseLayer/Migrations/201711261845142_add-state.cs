namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Baskets", "RegisterDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Baskets", "Paid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Baskets", "Paid");
            DropColumn("dbo.Baskets", "RegisterDate");
        }
    }
}
