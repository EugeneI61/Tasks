using _5Task.Managers;
using _5Task.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _5Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.DataSource = Cars.GetValues(typeof(Cars));
        }
        DbManager manager = new DbManager();

        
        private void button4_Click(object sender, System.EventArgs e)
        {
            dataGridView1.Rows.Clear();
            manager.LoadData(dataGridView1);
        }

        private void button1_Click(object sender, System.EventArgs e)
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

        private void button2_Click(object sender, System.EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string delete = textBox4.Text;
            manager.Delete(delete);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string result = textBox3.Text;
            if(int.TryParse(result, out int find))
            {
                manager.Find(find, dataGridView1);
            }    
        }
    }
}
