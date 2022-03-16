using System.Data.Entity;

namespace Task6.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() :
            base("EmployeeDB")
        { }
        public DbSet<Employee> Employees { get; set; }
    }
}
