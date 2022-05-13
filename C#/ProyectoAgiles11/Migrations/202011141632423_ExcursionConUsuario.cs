namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExcursionConUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Excursions", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Excursions", "UserId");
            AddForeignKey("dbo.Excursions", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Excursions", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Excursions", new[] { "UserId" });
            DropColumn("dbo.Excursions", "UserId");
        }
    }
}
