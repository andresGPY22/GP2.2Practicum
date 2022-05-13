namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearOpinion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Opinions",
                c => new
                    {
                        OpinionId = c.Int(nullable: false, identity: true),
                        Recurso = c.Int(nullable: false),
                        NombreRecurso = c.String(),
                        Descripcion = c.String(),
                        Voto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OpinionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Opinions");
        }
    }
}
