namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EncuentroDeportivo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EncuentroDeportivoes",
                c => new
                    {
                        IdEncuentroDeportivo = c.Int(nullable: false, identity: true),
                        Deporte = c.String(),
                        EquipoLocal = c.String(),
                        EquipoVisitante = c.String(),
                        Ciudad = c.String(),
                        Lugar = c.String(),
                        Dia = c.String(),
                        Hora = c.DateTime(nullable: false),
                        PrecioMin = c.Int(nullable: false),
                        PrecioMed = c.Int(nullable: false),
                        PrecioMax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdEncuentroDeportivo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EncuentroDeportivoes");
        }
    }
}
