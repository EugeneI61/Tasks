using _5Task;
using System.Windows.Forms;
using Task5.Managers;
using Task5.Models;

namespace Task5
{
    public partial class Form1 : Form
    {
        DbManager manager = new DbManager();

        Blank bl = new Blank();

        public Form1()
        {
            InitializeComponent();

            comboBox1.DataSource = Cars.GetValues(typeof(Cars));
        }
        private void SaveButton(object sender, System.EventArgs e)
        {
            try
            {
                string name = textBox1.Text;

                if (bl.IsNumber(name) == false && name != "")
                {
                    string resultAge = textBox2.Text;

                    Cars cars = (Cars)comboBox1.SelectedItem;

                    string car = cars.ToString();

                    int id = 1;

                    if (int.TryParse(resultAge, out int age) && bl.AgeAccept(age))
                    {
                        manager.Add(id, name, age, cars);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Age (18 - 99)!");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Name!");
                }
            }
            catch
            {
                MessageBox.Show("Fill the form!");
            }

        }

        private void DeleteClick(object sender, System.EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string delete = textBox4.Text;

            if (int.TryParse(delete, out int result))
            {
                MessageBox.Show("Input Name of Employee!");
            }
            else
            {
                manager.Delete(delete);
            }
        }

        private void FindButton(object sender, System.EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string find = textBox3.Text;

            try
            {
                if (int.TryParse(find, out int findResult))
                {
                    Employee resultFind = manager.Find(findResult);
                    if (bl.IsNull(resultFind) == false)
                    {
                        dataGridView1.Rows.Add(resultFind.Id, resultFind.Name, resultFind.Age, resultFind.Car);
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Input! Input Id of Employee!");
                }
            }
            catch
            {
                MessageBox.Show("Incorrect Input!");
            }

        }

        private void ViewClick(object sender, System.EventArgs e)
        {
            dataGridView1.Rows.Clear();
            EmployeeContext db = new EmployeeContext();

            Employee employee = new Employee();

            foreach (Employee emp in db.Employees)
            {
<<<<<<< HEAD
                dataGridView1.Rows.Add( emp.EmployeeName, emp.Age, emp.Car);
=======
                dataGridView1.Rows.Add(emp.Id, emp.Name, emp.Age, emp.Car);
>>>>>>> 762965302be95750bd2517b56e138ea4019cfbe2
            }
        }
    }
}
