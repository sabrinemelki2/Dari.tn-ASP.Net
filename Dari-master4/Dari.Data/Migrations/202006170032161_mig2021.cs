namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2021 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Sexe", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Sexe");
        }
    }
}
