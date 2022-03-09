using _5Task.Managers;
using _5Task.Models;
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
            string delete = textBox4.Text;

            if (int.TryParse(delete, out int result))
            {
                MessageBox.Show("Input name of Employee!");
            }
            else
            {
                dataGridView1.Rows.Clear();
                manager.Delete(delete);
            }

        }

        private void FindButton(object sender, System.EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string result = textBox3.Text;
            if (int.TryParse(result, out int find))
            {
                manager.Find(find, dataGridView1);
            }
            else
            {
                MessageBox.Show("Input Id of Employee!");
            }
        }
    }
}
