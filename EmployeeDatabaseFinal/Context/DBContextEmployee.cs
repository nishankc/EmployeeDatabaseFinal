
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace EmployeeDatabaseFinal.Context
{
    public class DBContextEmployee : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Address> Address { get; set; }

        public DbSet<Position> Position { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Configure Student & StudentAddress entity
            modelBuilder.Entity<Employee>()
                        .HasOptional(s => s.Address) // Mark Address property optional in Student entity
                        .WithRequired(ad => ad.Employee); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student

            modelBuilder.Entity<Employee>()
                    .HasRequired<Position>(s => s.Position) // Student entity requires Standard 
                    .WithMany(s => s.StudentList); // Standard entity includes many Students entities

        }

    }
}