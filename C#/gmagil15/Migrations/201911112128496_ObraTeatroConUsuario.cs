namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ObraTeatroConUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ObraDeTeatroes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ObraDeTeatroes", "UserId");
            AddForeignKey("dbo.ObraDeTeatroes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ObraDeTeatroes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ObraDeTeatroes", new[] { "UserId" });
            DropColumn("dbo.ObraDeTeatroes", "UserId");
        }
    }
}
