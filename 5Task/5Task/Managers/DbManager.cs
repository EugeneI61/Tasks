using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Task5.Models;

namespace Task5.Managers
{
    public class DbManager
    {
        EmployeeContext db = new EmployeeContext();
        public void Add(int id, string name, int age, string car)
        {
            Employee emp = new Employee { Id = id, Name = name, Age = age, Car = car };
            db.Employees.Add(emp);
            db.SaveChanges();
            db.Entry(emp).State = EntityState.Detached;

            MessageBox.Show("New Employee add!");
        }
        public Employee Find(int find)
        {
            Employee emp = null;

            if (find != null)
            {
                emp = db.Employees.Find(find);
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
    }
}
