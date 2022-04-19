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

    public partial class Client : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= Sportx.mdb";
        private OleDbConnection myConnection;
        public Client()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sportxDataSet.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter.Fill(this.sportxDataSet.Клиенты);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string query = "SELECT [ID], [ФИО], [Телефон], [Абонимент], [Срок действия], [Тренер] FROM Клиенты WHERE ФИО LIKE '%" + Name + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView1.DataSource = клиентыBindingSource;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddClient af = new AddClient();
            af.Owner = this;
            af.Show();
        }

        private void Client_Activated(object sender, EventArgs e)
        {
            this.клиентыTableAdapter.Fill(this.sportxDataSet.Клиенты);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox2.Text);
            string query = "DELETE FROM Клиенты WHERE [ID] = " + ID;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            dataGridView1.DataSource = клиентыBindingSource;
            this.клиентыTableAdapter.Fill(this.sportxDataSet.Клиенты);
            textBox2.Clear();
        }
    }
}
