using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Task6.Models;

namespace Task6.Managers
{
    public class DbManager
    {
        public void Add(int id, string name, int age, Cars cars, string recordId)
        {
            EmployeeContext db = new EmployeeContext();

            Employee emp = new Employee { Id = id, Name = name, Age = age, Car = cars, RecordId = recordId };
            db.Employees.Add(emp);
            db.SaveChanges();
            db.Entry(emp).State = EntityState.Detached;

            MessageBox.Show("New Employee add!");
        }

        public void RegectAdd()
        {
            MessageBox.Show("New Employee is not add! Count is overflow!");
        }
        public void Delete(string delete)
        {
            EmployeeContext db = new EmployeeContext();
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
