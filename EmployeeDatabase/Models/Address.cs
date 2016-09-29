using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDatabase.Models
{
    public class Address
    {
        
        public int AddressId { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
