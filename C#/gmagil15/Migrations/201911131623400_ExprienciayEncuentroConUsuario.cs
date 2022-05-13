namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExprienciayEncuentroConUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EncuentroDeportivoes", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.VisitaTuristicas", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.EncuentroDeportivoes", "UserId");
            CreateIndex("dbo.VisitaTuristicas", "UserId");
            AddForeignKey("dbo.EncuentroDeportivoes", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.VisitaTuristicas", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisitaTuristicas", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EncuentroDeportivoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.VisitaTuristicas", new[] { "UserId" });
            DropIndex("dbo.EncuentroDeportivoes", new[] { "UserId" });
            DropColumn("dbo.VisitaTuristicas", "UserId");
            DropColumn("dbo.EncuentroDeportivoes", "UserId");
        }
    }
}
