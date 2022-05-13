namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocalesOcioNocturnoConUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocalesDeOcioNocturnoes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.LocalesDeOcioNocturnoes", "UserId");
            AddForeignKey("dbo.LocalesDeOcioNocturnoes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LocalesDeOcioNocturnoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.LocalesDeOcioNocturnoes", new[] { "UserId" });
            DropColumn("dbo.LocalesDeOcioNocturnoes", "UserId");
        }
    }
}
