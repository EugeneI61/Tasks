using System.Data.Entity;
using Task5.Models;

namespace Task5
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() :
            base("EmployeesDB")
        { }
        public DbSet<Employee> Employees { get; set; }
    }
}
