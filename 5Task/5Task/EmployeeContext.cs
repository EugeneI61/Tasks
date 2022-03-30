using _5Task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace _5Task
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() :
            base("EmployeesDB")
        { }
        public DbSet<Employee> Employees { get; set; }
    }
}
