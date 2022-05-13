namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearDegustaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Degustacions",
                c => new
                    {
                        DegustacionId = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(nullable: false),
                        Lugar = c.String(),
                        Localidad = c.String(),
                        Provincia = c.String(),
                        ComunidadAutonoma = c.String(),
                        Pais = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duracion = c.Int(nullable: false),
                        VideoFoto = c.String(),
                        Obsequio = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DegustacionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Degustacions");
        }
    }
}
