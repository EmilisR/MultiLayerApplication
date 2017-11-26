namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets");
            DropForeignKey("dbo.BasketItems", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Baskets", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.BasketItems", new[] { "Basket_Id" });
            DropIndex("dbo.BasketItems", new[] { "Product_Id" });
            DropIndex("dbo.Baskets", new[] { "Customer_Id" });
            DropIndex("dbo.Customers", new[] { "Email" });
            AlterColumn("dbo.BasketItems", "Basket_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.BasketItems", "Product_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Baskets", "Customer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.BasketItems", "Basket_Id");
            CreateIndex("dbo.BasketItems", "Product_Id");
            CreateIndex("dbo.Baskets", "Customer_Id");
            CreateIndex("dbo.Customers", "Email", unique: true);
            AddForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BasketItems", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Baskets", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Baskets", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.BasketItems", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets");
            DropIndex("dbo.Customers", new[] { "Email" });
            DropIndex("dbo.Baskets", new[] { "Customer_Id" });
            DropIndex("dbo.BasketItems", new[] { "Product_Id" });
            DropIndex("dbo.BasketItems", new[] { "Basket_Id" });
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Password", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Baskets", "Customer_Id", c => c.Int());
            AlterColumn("dbo.BasketItems", "Product_Id", c => c.Int());
            AlterColumn("dbo.BasketItems", "Basket_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Email", unique: true);
            CreateIndex("dbo.Baskets", "Customer_Id");
            CreateIndex("dbo.BasketItems", "Product_Id");
            CreateIndex("dbo.BasketItems", "Basket_Id");
            AddForeignKey("dbo.Baskets", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.BasketItems", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets", "Id");
        }
    }
}
