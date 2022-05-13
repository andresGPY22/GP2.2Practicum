namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EspectaculoConProveedor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Espectaculoes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Espectaculoes", "UserId");
            AddForeignKey("dbo.Espectaculoes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Espectaculoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Espectaculoes", new[] { "UserId" });
            DropColumn("dbo.Espectaculoes", "UserId");
        }
    }
}
