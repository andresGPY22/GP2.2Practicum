namespace Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sprint1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conciertoes",
                c => new
                    {
                        IdConcierto = c.Int(nullable: false, identity: true),
                        Grupo = c.String(),
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
                    })
                .PrimaryKey(t => t.IdConcierto);
            
            CreateTable(
                "dbo.ObraDeTeatroes",
                c => new
                    {
                        obraTeatroId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        ActoresPrincipales = c.String(),
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
                    })
                .PrimaryKey(t => t.obraTeatroId);
            
            CreateTable(
                "dbo.PortalComentarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Evento = c.String(),
                        Comentario = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PortalComentarios");
            DropTable("dbo.ObraDeTeatroes");
            DropTable("dbo.Conciertoes");
        }
    }
}
