using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDatabaseFinal
{
    public class Employee
    {

        public Employee() { }

        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First Name is Required"), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Surname is Required")]
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please enter a username")]
        [Remote("doesUserNameExist", "Account", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Enter a Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Please Confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Position is Required")]
        public int PositionId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Position Position { get; set; }


        //public Employee() { }
        //public int Id { get; set; }        

        //public string PositionId { get; set; }
        //public virtual Address Address { get; set; }
        //public virtual Position Position { get; set; }
    }
}