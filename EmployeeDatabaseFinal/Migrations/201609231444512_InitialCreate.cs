namespace EmployeeDatabaseFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Town = c.String(),
                        County = c.String(),
                        Postcode = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Employees", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        PositionName = c.String(),
                    })
                .PrimaryKey(t => t.PositionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Addresses", "AddressId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "PositionId" });
            DropIndex("dbo.Addresses", new[] { "AddressId" });
            DropTable("dbo.Positions");
            DropTable("dbo.Employees");
            DropTable("dbo.Addresses");
        }
    }
}
