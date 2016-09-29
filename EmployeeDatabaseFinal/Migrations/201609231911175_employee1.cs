namespace EmployeeDatabaseFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Password", c => c.String());
            AlterColumn("dbo.Employees", "Username", c => c.String());
            AlterColumn("dbo.Employees", "Surname", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
        }
    }
}
