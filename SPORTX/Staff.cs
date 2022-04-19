using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SPORTX
{

    public partial class Staff : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= Sportx.mdb";
        private OleDbConnection myConnection;
        public Staff()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sotrudniki_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sportxDataSet.Сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter.Fill(this.sportxDataSet.Сотрудники);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string query = "SELECT [ID], [ФИО], [Телефон], [Адрес], [Должность] FROM Сотрудники WHERE ФИО LIKE '%" + Name + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
            textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView1.DataSource = сотрудникиBindingSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox2.Text);
            string query = "DELETE FROM Сотрудники WHERE [ID] = " + ID;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            dataGridView1.DataSource = сотрудникиBindingSource;
            this.сотрудникиTableAdapter.Fill(this.sportxDataSet.Сотрудники);
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddStaff af = new AddStaff();
            af.Owner = this;
            af.Show();
        }

        private void Staff_Activated(object sender, EventArgs e)
        {
            this.сотрудникиTableAdapter.Fill(this.sportxDataSet.Сотрудники);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
