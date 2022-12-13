namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig303 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RDVs", "annonceID", "dbo.Annonces");
            AddForeignKey("dbo.RDVs", "annonceID", "dbo.Annonces", "AnnonceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RDVs", "annonceID", "dbo.Annonces");
            AddForeignKey("dbo.RDVs", "annonceID", "dbo.Annonces", "AnnonceId");
        }
    }
}
