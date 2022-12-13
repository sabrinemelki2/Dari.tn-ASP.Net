namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig202 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            DropColumn("dbo.AspNetUsers", "Password");
        }
    }
}
