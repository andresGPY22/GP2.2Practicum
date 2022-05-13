namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocalesOcioNocturno1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocalesDeOcioNocturnoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        ciudadPueblo = c.String(),
                        provincia = c.String(),
                        comunidadAutonoma = c.String(),
                        pais = c.String(),
                        tipo = c.String(),
                        precioEntrada = c.Single(nullable: false),
                        valoracionMedia = c.Single(nullable: false),
                        videoFoto = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LocalesDeOcioNocturnoes");
        }
    }
}
