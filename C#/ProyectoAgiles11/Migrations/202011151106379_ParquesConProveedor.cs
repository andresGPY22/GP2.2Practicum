namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParquesConProveedor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.parqueTematicoes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.parqueTematicoes", "UserId");
            AddForeignKey("dbo.parqueTematicoes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.parqueTematicoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.parqueTematicoes", new[] { "UserId" });
            DropColumn("dbo.parqueTematicoes", "UserId");
        }
    }
}
