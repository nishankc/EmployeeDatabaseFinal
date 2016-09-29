namespace EmployeeDatabaseFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Address1", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "Town", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "County", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "Postcode", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Addresses", "Postcode", c => c.String());
            AlterColumn("dbo.Addresses", "County", c => c.String());
            AlterColumn("dbo.Addresses", "Town", c => c.String());
            AlterColumn("dbo.Addresses", "Address1", c => c.String());
        }
    }
}
