namespace EmployeeDatabase.Migrations
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
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Surname = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PositionID = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        Position_PositionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Positions", t => t.Position_PositionID, cascadeDelete: true)
                .Index(t => t.Position_PositionID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.PositionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Position_PositionID", "dbo.Positions");
            DropForeignKey("dbo.Addresses", "AddressId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "Position_PositionID" });
            DropIndex("dbo.Addresses", new[] { "AddressId" });
            DropTable("dbo.Positions");
            DropTable("dbo.Employees");
            DropTable("dbo.Addresses");
        }
    }
}
