namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlojamientosConUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alojamientoes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Alojamientoes", "UserId");
            AddForeignKey("dbo.Alojamientoes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alojamientoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Alojamientoes", new[] { "UserId" });
            DropColumn("dbo.Alojamientoes", "UserId");
        }
    }
}
