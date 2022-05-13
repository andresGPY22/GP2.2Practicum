namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DegustacionesConProveedor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Degustacions", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Degustacions", "UserId");
            AddForeignKey("dbo.Degustacions", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Degustacions", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Degustacions", new[] { "UserId" });
            DropColumn("dbo.Degustacions", "UserId");
        }
    }
}
