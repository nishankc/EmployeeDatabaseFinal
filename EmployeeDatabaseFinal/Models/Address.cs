using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeDatabaseFinal
{
    public class Address
    {
        
        public int AddressId { get; set; }
        [Required(ErrorMessage = "First Line of Address is Required"), Display(Name = "Address First Line")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required(ErrorMessage = "Town is Required"), Display(Name = "Town")]
        public string Town { get; set; }
        [Required(ErrorMessage = "County is Required"), Display(Name = "County")]
        public string County { get; set; }
        [Required(ErrorMessage = "Post Code is Required"), Display(Name = "Post Code")]
        public string Postcode { get; set; }
        [Required(ErrorMessage = "Phone Number is Required"), Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
