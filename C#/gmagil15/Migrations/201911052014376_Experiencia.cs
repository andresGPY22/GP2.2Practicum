namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Experiencia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Experiencias",
                c => new
                    {
                        experienciaId = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        agenciaPatrocinadora = c.String(),
                        Ciudad = c.String(),
                        Lugar = c.String(),
                        Dias = c.String(),
                        FechaIni = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        Duracion = c.Int(nullable: false),
                        PrecioMin = c.Int(nullable: false),
                        PrecioMed = c.Int(nullable: false),
                        PrecioMax = c.Int(nullable: false),
                        DescripcionPrecios = c.String(),
                        Excepciones = c.String(),
                    })
                .PrimaryKey(t => t.experienciaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Experiencias");
        }
    }
}
