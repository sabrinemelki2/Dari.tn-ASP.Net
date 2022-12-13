namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig101 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annonces",
                c => new
                    {
                        AnnonceId = c.Int(nullable: false, identity: true),
                        TypeAn = c.Int(nullable: false),
                        Description = c.String(),
                        address = c.String(),
                        surface = c.Single(nullable: false),
                        price = c.Single(nullable: false),
                        chambres = c.Int(nullable: false),
                        images = c.String(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.AnnonceId)
                .ForeignKey("dbo.AspNetUsers", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Tel = c.String(),
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
                        UserId = c.Int(nullable: false),
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
                        UserId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Meubles",
                c => new
                    {
                        IdMeuble = c.Int(nullable: false, identity: true),
                        Titre = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Prix = c.Double(nullable: false),
                        Livraison = c.Int(nullable: false),
                        Etat = c.Int(nullable: false),
                        Disponibilite = c.Int(nullable: false),
                        dateAnn = c.DateTime(nullable: false),
                        IdClient = c.Int(),
                        CategoryMeubId = c.Int(),
                    })
                .PrimaryKey(t => t.IdMeuble)
                .ForeignKey("dbo.AspNetUsers", t => t.IdClient)
                .ForeignKey("dbo.CategorieMeubs", t => t.CategoryMeubId)
                .Index(t => t.IdClient)
                .Index(t => t.CategoryMeubId);
            
            CreateTable(
                "dbo.CategorieMeubs",
                c => new
                    {
                        CategoryMeubId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryMeubId);
            
            CreateTable(
                "dbo.RDVs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        visiteurID = c.Int(nullable: false),
                        annonceID = c.Int(nullable: false),
                        state = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Annonces", t => t.annonceID)
                .ForeignKey("dbo.AspNetUsers", t => t.visiteurID)
                .Index(t => t.visiteurID)
                .Index(t => t.annonceID);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        RateId = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        AnnonceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RateId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RDVs", "visiteurID", "dbo.AspNetUsers");
            DropForeignKey("dbo.RDVs", "annonceID", "dbo.Annonces");
            DropForeignKey("dbo.Meubles", "CategoryMeubId", "dbo.CategorieMeubs");
            DropForeignKey("dbo.Meubles", "IdClient", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Annonces", "Client_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.RDVs", new[] { "annonceID" });
            DropIndex("dbo.RDVs", new[] { "visiteurID" });
            DropIndex("dbo.Meubles", new[] { "CategoryMeubId" });
            DropIndex("dbo.Meubles", new[] { "IdClient" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Annonces", new[] { "Client_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Rates");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.RDVs");
            DropTable("dbo.CategorieMeubs");
            DropTable("dbo.Meubles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Annonces");
        }
    }
}
