namespace WebShopThoiTrang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Table_ReviewEdit_ForenKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.tb_Review", "ProductId");
            AddForeignKey("dbo.tb_Review", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Review", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_Review", new[] { "ProductId" });
        }
    }
}
