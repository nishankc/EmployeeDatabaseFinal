using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDatabase.Models
{
    public class Employee
    {

        public Employee() { }

        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public int PositionId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Position Department { get; set; }


        //public Employee() { }
        //public int Id { get; set; }        
        //public string FirstName { get; set; }        
        //public string Surname { get; set; }         
        //public System.DateTime DateOfBirth { get; set; }                     
        //public System.DateTime StartDate { get; set; }       
        //public string Username { get; set; }       
        //public string Password { get; set; }       
        //public string ConfirmPassword { get; set; }
        //public string PositionId { get; set; }
        //public virtual Address Address { get; set; }
        //public virtual Position Position { get; set; }
    }
}