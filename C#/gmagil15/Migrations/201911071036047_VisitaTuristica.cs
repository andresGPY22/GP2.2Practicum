namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VisitaTuristica : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VisitaTuristicas",
                c => new
                    {
                        VisitaTuristicaId = c.Int(nullable: false, identity: true),
                        Ciudad = c.String(),
                        Recorrido = c.Single(nullable: false),
                        Pago = c.Boolean(nullable: false),
                        Agencia = c.String(),
                        Tipo = c.String(),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        Duracion = c.Int(nullable: false),
                        Precio = c.Single(nullable: false),
                        DiasSemana = c.String(),
                        Excepciones = c.String(),
                    })
                .PrimaryKey(t => t.VisitaTuristicaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VisitaTuristicas");
        }
    }
}
