namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExperienciaConProveedor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Experiencias", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Experiencias", "UserId");
            AddForeignKey("dbo.Experiencias", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experiencias", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Experiencias", new[] { "UserId" });
            DropColumn("dbo.Experiencias", "UserId");
        }
    }
}
