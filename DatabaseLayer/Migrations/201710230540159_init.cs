namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Description", c => c.String());
            AddColumn("dbo.Customers", "Name", c => c.String());
            AddColumn("dbo.Customers", "Surname", c => c.String());
            AlterColumn("dbo.BasketItems", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Baskets", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Products", "Desription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Desription", c => c.String());
            AlterColumn("dbo.Baskets", "TotalPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.BasketItems", "TotalPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Customers", "Surname");
            DropColumn("dbo.Customers", "Name");
            DropColumn("dbo.Products", "Description");
        }
    }
}
