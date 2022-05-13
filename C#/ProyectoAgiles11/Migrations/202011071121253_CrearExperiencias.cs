namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearExperiencias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Experiencias",
                c => new
                    {
                        ExperienciaId = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(nullable: false),
                        Lugar = c.String(),
                        Localidad = c.String(),
                        Provincia = c.String(),
                        ComunidadAutonoma = c.String(),
                        Pais = c.String(),
                        Agencia = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiasDisponible = c.Int(nullable: false),
                        VideoFoto = c.String(),
                    })
                .PrimaryKey(t => t.ExperienciaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Experiencias");
        }
    }
}
