using Task5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

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
