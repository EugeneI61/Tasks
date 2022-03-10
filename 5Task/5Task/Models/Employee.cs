using System.ComponentModel.DataAnnotations;

namespace Task5.Models
{
    public class Employee
    {
        [Key]
        public string EmployeeName { get; set; }
        public int Age { get; set; }
        public string Car { get; set; }
    }
}