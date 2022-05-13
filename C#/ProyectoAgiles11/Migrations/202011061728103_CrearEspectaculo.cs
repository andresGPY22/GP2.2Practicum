namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearEspectaculo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Espectaculoes",
                c => new
                    {
                        EspectaculoID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Tipo = c.String(),
                        Lugar = c.String(),
                        CiudadPueblo = c.String(),
                        Provincia = c.String(),
                        ComunidadAutonoma = c.String(),
                        Pais = c.String(),
                        DuracionMinutos = c.Int(nullable: false),
                        Lunes = c.Boolean(nullable: false),
                        Martes = c.Boolean(nullable: false),
                        Miercoles = c.Boolean(nullable: false),
                        Jueves = c.Boolean(nullable: false),
                        Viernes = c.Boolean(nullable: false),
                        Sabado = c.Boolean(nullable: false),
                        Domingo = c.Boolean(nullable: false),
                        FechaInicial = c.String(),
                        FechaFinal = c.String(),
                        PrecioMinimo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioMaximo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VideoFoto = c.String(),
                    })
                .PrimaryKey(t => t.EspectaculoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Espectaculoes");
        }
    }
}
