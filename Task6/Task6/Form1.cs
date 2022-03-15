using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Task6.Managers;
using Task6.Models;

namespace Task6
{
    public partial class Form1 : Form
    {
        EmployeeContext db = new EmployeeContext();

        Blank bl = new Blank();
        DbManager manager = new DbManager();

        public Form1()
        {
            InitializeComponent();

            comboBox1.DataSource = Enum.GetValues(typeof(Cars));
            comboBox2.DataSource = Enum.GetValues(typeof(Cars));
        }

        private void SaveButton(object sender, System.EventArgs e)
        {
            try
            {
                string name = textBox1.Text;

                if (name != "")
                {
                    string resultAge = textBox2.Text;

                    Cars cars = (Cars)comboBox1.SelectedItem;

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
            string text = textBox3.Text;
            if (Int32.TryParse(text, out int idResult))
            {
                dataGridView1.DataSource = db.Employees.Where(x => x.Id == idResult).ToList();
            }
        }

        private void ViewClick(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = db.Employees.ToList();
        }

        private void SortClick(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dataGridView1.Sort(new RowComparer(SortOrder.Ascending));
            }
            else if (radioButton2.Checked)
            {
                dataGridView1.Sort(new RowComparer(SortOrder.Descending));
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.Employees.Where(x => x.Name.Contains(textBox5.Text)).ToList();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cars cars = (Cars)comboBox2.SelectedItem;
            dataGridView1.DataSource = db.Employees.Where(x => x.Car == cars).ToList();
        }
    }
}
