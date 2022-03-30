using System;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Windows.Forms;
using Task5.Models;

namespace Task5.Managers
{
    public class DbManager
    {
        EmployeeContext db = new EmployeeContext();
<<<<<<< HEAD
        public void Add( string name, int age, string car)
        {
            Employee emp = new Employee { EmployeeName = name, Age = age, Car = car};
=======
        public void Add(int id, string name, int age, Cars cars)
        {
            Employee emp = new Employee { Id = id, Name = name, Age = age, Car = cars};
>>>>>>> 762965302be95750bd2517b56e138ea4019cfbe2
            db.Employees.Add(emp);
            db.SaveChanges();
            db.Entry(emp).State = EntityState.Detached;

            MessageBox.Show("New Employee add!");
        }
        public Employee Find(int find)
        {
            Employee emp = null;
<<<<<<< HEAD
        
            if (find == null)
            {
                MessageBox.Show("Incorrect Input");
=======

            if (find != null)
            {
                emp = db.Employees.Find(find);
>>>>>>> 762965302be95750bd2517b56e138ea4019cfbe2
            }
            else
            {
                MessageBox.Show("Incorrect Input");
            }
            return emp;
        }
        public void Delete(string delete)
        {
            try
            {
                var deleteEmployee = db.Employees.Where(emp => emp.Name == delete).FirstOrDefault();
                db.Employees.Remove(deleteEmployee);
                db.SaveChanges();

                MessageBox.Show("Employee was Remove!");
            }
            catch
            {
                MessageBox.Show("Incorrect Input");
            }
        }
        public void View(Employee employee)
        {

        }
    }
}
