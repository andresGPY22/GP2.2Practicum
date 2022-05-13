namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaresyRestaurantesConProveedor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.barRestaurantes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.barRestaurantes", "UserId");
            AddForeignKey("dbo.barRestaurantes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.barRestaurantes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.barRestaurantes", new[] { "UserId" });
            DropColumn("dbo.barRestaurantes", "UserId");
        }
    }
}
