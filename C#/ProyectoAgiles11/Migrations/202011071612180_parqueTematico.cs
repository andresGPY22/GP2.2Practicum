namespace TeleViajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parqueTematico : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.parqueTematicoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        ciudadPueblo = c.String(),
                        provincia = c.String(),
                        comunidadAutonoma = c.String(),
                        pais = c.String(),
                        tipo = c.String(),
                        precioMin = c.Single(nullable: false),
                        precioMax = c.Single(nullable: false),
                        videoFoto = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.parqueTematicoes");
        }
    }
}
