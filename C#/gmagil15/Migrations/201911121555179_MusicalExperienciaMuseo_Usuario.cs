namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MusicalExperienciaMuseo_Usuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Experiencias", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Museos", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Musicals", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Experiencias", "UserId");
            CreateIndex("dbo.Museos", "UserId");
            CreateIndex("dbo.Musicals", "UserId");
            AddForeignKey("dbo.Experiencias", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Museos", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Musicals", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musicals", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Museos", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Experiencias", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Musicals", new[] { "UserId" });
            DropIndex("dbo.Museos", new[] { "UserId" });
            DropIndex("dbo.Experiencias", new[] { "UserId" });
            DropColumn("dbo.Musicals", "UserId");
            DropColumn("dbo.Museos", "UserId");
            DropColumn("dbo.Experiencias", "UserId");
        }
    }
}
