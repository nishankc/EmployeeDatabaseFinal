using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDatabaseFinal
{ 
    public class Position
    {      
            public Position()
            {
                StudentList = new List<Employee>();
            }

            public int PositionID { get; set; }
            public string PositionName { get; set; }           
            public virtual ICollection<Employee> StudentList { get; set; }
        }
    
}
