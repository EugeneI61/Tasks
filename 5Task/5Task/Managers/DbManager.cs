using System;
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
        public List<String> Find(string find)
        {
            var emp = db.Employees.Include(m => m.EmployeeName == find).ToList();

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
        public void LoadData(DataGridView dataGridView1)
        {
            string connectString = "data source=(localdb)\\MSSQLLocalDB;Initial Catalog=employeesdb;Integrated Security=True";

            SqlConnection myConnection = new SqlConnection(connectString);

            myConnection.Open();

            string query = "SELECT * FROM Employees ORDER BY EmployeeId";

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
            }

            reader.Close();

            myConnection.Close();

            foreach (string[] text in data)
                dataGridView1.Rows.Add(text);
        }
    }
}
