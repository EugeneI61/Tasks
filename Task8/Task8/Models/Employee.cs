using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task8.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public Cars Car { get; set; }
        public string RecordId { get; set; }
    }
}
