﻿using System.Windows.Forms;
using Task5.Managers;
using Task5.Models;

namespace Task5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.DataSource = Cars.GetValues(typeof(Cars));


            //dataGridView1.DataSource =
        }

        DbManager manager = new DbManager();
        private void ViewClick(object sender, System.EventArgs e)
        {
            dataGridView1.Rows.Clear();
            manager.LoadData(dataGridView1);
        }

        private void SaveButton(object sender, System.EventArgs e)
        {
            string name = textBox1.Text;

            string resultAge = textBox2.Text;

            Cars cars = (Cars)comboBox1.SelectedItem;

            string car = cars.ToString();

            if (int.TryParse(resultAge, out int age))
            {
                manager.Add(name, age, car);
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

            if (find != null)
            {
                Employee resultFind = manager.Find(find);

                dataGridView1.Rows.Add(0, resultFind.EmployeeName, resultFind.Age, resultFind.Car);
            }
            else
            {
                MessageBox.Show("Input Name of Employee!");
            }
        }
    }
}
