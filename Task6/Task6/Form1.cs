using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Task6.Managers;
using Task6.Models;

namespace Task6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(Cars));
            comboBox2.DataSource = Enum.GetValues(typeof(Cars));
        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
        private void SaveButton(object sender, System.EventArgs e)
        {
            DbManager manager = new DbManager();

            Config config = new Config();

            InputCheck checkin = new InputCheck();

            try
            {
                string name = textBox1.Text;

                if (checkin.IsNull(name) ? false : true)
                {
                    string age = textBox2.Text;

                    var cars = (Cars)comboBox1.SelectedItem;

                    var id = 1;

                    if (checkin.AgeAccept(age) ? true : false)
                    {
                        var recordId = string.Concat(name, age.ToString(), cars.ToString());

                        if (config.Check())
                        {
                            manager.Add(id, name, Convert.ToInt32(age), cars, GetHash(recordId));
                        }
                        else
                        {
                            manager.RegectAdd();
                        }
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
        public void DeleteClick(object sender, System.EventArgs e)
        {
            var delete = textBox4.Text;
            DbManager manager = new DbManager();

            manager.Delete(delete);
        }
        private void FindButton(object sender, System.EventArgs e)
        {
            EmployeeContext db = new EmployeeContext();
            var text = textBox3.Text;
            if (int.TryParse(text, out var idResult))
            {
                dataGridView1.DataSource = db.Employees.Where(x => x.Id == idResult).ToList();
            }
        }

        private void ViewClick(object sender, System.EventArgs e)
        {
            EmployeeContext db = new EmployeeContext();
            dataGridView1.DataSource = db.Employees.ToList();
        }

        private void SortClick(object sender, EventArgs e)
        {
            EmployeeContext db = new EmployeeContext();
            if (radioButton1.Checked)
            {
                var employee = db.Employees
                    .Select(p => new { p.Id, p.Name, p.Age, p.Car, p.RecordId })
                    .OrderByDescending(p => p.Name);

                dataGridView1.DataSource = employee.ToList();
            }
            else if (radioButton2.Checked)
            {
                var employee = db.Employees
                    .Select(p => new { p.Id, p.Name, p.Age, p.Car, p.RecordId })
                    .OrderBy(p => p.Name);
                dataGridView1.DataSource = employee.ToList();
            }
        }
        private void Filtre(object sender, EventArgs e)
        {
            EmployeeContext db = new EmployeeContext();
            dataGridView1.DataSource = db.Employees.Where(x => x.Name.Contains(textBox5.Text)).ToList();
        }
        private void CarSelected(object sender, EventArgs e)
        {
            EmployeeContext db = new EmployeeContext();
            Cars cars = (Cars)comboBox2.SelectedItem;
            dataGridView1.DataSource = db.Employees.Where(x => x.Car == cars).ToList();
        }
    }
}
