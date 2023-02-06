using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjectLayer
{
    public class EmployeeBusinessObject
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhone { get; set; }
        public string Role { get; set; }
        public string Designation { get; set; }
        public bool IsAdmin { get; set; }
    }


}
