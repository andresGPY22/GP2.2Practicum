namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crearExcursion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Excursions",
                c => new
                    {
                        ExcursionId = c.Int(nullable: false, identity: true),
                        CiudadPueblo = c.String(),
                        Pago = c.Boolean(nullable: false),
                        Recorrido = c.String(),
                        Pais = c.String(),
                        Agencia = c.String(),
                        Tipo = c.Int(nullable: false),
                        Duracion = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiasDisponible = c.Int(nullable: false),
                        VideoFoto = c.String(),
                    })
                .PrimaryKey(t => t.ExcursionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Excursions");
        }
    }
}
