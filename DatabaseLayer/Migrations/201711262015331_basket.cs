namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasketItems", "Basket_Id", c => c.Int());
            CreateIndex("dbo.BasketItems", "Basket_Id");
            AddForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets");
            DropIndex("dbo.BasketItems", new[] { "Basket_Id" });
            DropColumn("dbo.BasketItems", "Basket_Id");
        }
    }
}
