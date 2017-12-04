namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guestbasket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Baskets", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Baskets", new[] { "Customer_Id" });
            AlterColumn("dbo.Baskets", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Baskets", "Customer_Id");
            AddForeignKey("dbo.Baskets", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Baskets", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Baskets", new[] { "Customer_Id" });
            AlterColumn("dbo.Baskets", "Customer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Baskets", "Customer_Id");
            AddForeignKey("dbo.Baskets", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
