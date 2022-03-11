using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Task5.Models;

namespace Task5.Managers
{
    public class DbManager
    {
        EmployeeContext db = new EmployeeContext();
        public void Add(string name, int age, string car)
        {
            Employee emp = new Employee { EmployeeName = name, Age = age, Car = car };
            db.Employees.Add(emp);
            db.SaveChanges();
            db.Entry(emp).State = EntityState.Detached;

            MessageBox.Show("New Employee add!");
        }
        public Employee Find(string find)
        {
            Employee emp = null;
        
            if (find == null)
            {
                MessageBox.Show("Incorrect Input");

            }
            else
            {
                emp = db.Employees.Find(find);
            }
            return emp;
        }
        public void Delete(string delete)
        {
            try
            {
                var deleteEmployee = db.Employees.Where(emp => emp.EmployeeName == delete).FirstOrDefault();
                db.Employees.Remove(deleteEmployee);
                db.SaveChanges();

                MessageBox.Show("Employee was Remove!");
            }
            catch
            {
                MessageBox.Show("Incorrect Input");
            }
        }
    }
}
