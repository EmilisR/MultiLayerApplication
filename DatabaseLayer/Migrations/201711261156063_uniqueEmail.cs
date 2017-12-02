namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueEmail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityInStock = c.Int(nullable: false),
                        QuantityArriving = c.Int(nullable: false),
                        ProductCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentType = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 50),
                        MobileNumber = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Baskets", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.BasketItems", "Product_Id", "dbo.Products");
            DropIndex("dbo.Customers", new[] { "Email" });
            DropIndex("dbo.Baskets", new[] { "Customer_Id" });
            DropIndex("dbo.BasketItems", new[] { "Product_Id" });
            DropTable("dbo.Customers");
            DropTable("dbo.Baskets");
            DropTable("dbo.Products");
            DropTable("dbo.BasketItems");
        }
    }
}
