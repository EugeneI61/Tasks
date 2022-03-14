using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
