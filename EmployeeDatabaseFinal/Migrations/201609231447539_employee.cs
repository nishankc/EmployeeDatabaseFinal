namespace EmployeeDatabaseFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "FirstName", c => c.String());
            AddColumn("dbo.Employees", "Surname", c => c.String());
            AddColumn("dbo.Employees", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "Username", c => c.String());
            AddColumn("dbo.Employees", "Password", c => c.String());
            AddColumn("dbo.Employees", "ConfirmPassword", c => c.String());
            DropColumn("dbo.Employees", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Name", c => c.String());
            DropColumn("dbo.Employees", "ConfirmPassword");
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.Employees", "Username");
            DropColumn("dbo.Employees", "StartDate");
            DropColumn("dbo.Employees", "DateOfBirth");
            DropColumn("dbo.Employees", "Surname");
            DropColumn("dbo.Employees", "FirstName");
        }
    }
}
