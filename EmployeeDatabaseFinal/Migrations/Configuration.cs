namespace EmployeeDatabaseFinal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeDatabaseFinal.Context.DBContextEmployee>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EmployeeDatabaseFinal.Context.DBContextEmployee";
        }

        protected override void Seed(EmployeeDatabaseFinal.Context.DBContextEmployee context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Address ad = new Address { Address1 = "a", Address2 = "a", Town = "a", County = "c", Postcode = "dsas", PhoneNumber = "sad" };


            context.Employee.AddOrUpdate(p => p.FirstName,
                new Employee { FirstName = "Vina", Surname = "Chikhalia", DateOfBirth = DateTime.Today, StartDate = DateTime.Today, Username = "vina", Password = "password", ConfirmPassword = "password", PositionId = 2, Address = {  Address1 = "a", Address2 = "a", Town = "a", County = "c", Postcode = "dsas", PhoneNumber = "sad" } });
        }
    }
}
