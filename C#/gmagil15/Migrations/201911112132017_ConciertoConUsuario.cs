namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConciertoConUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conciertoes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Conciertoes", "UserId");
            AddForeignKey("dbo.Conciertoes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Conciertoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Conciertoes", new[] { "UserId" });
            DropColumn("dbo.Conciertoes", "UserId");
        }
    }
}
