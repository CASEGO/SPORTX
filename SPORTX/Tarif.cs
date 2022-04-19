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

    public partial class Tarif : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= Sportx.mdb";
        private OleDbConnection myConnection;
        public Tarif()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tarif_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sportxDataSet.Тарифы_абонемента". При необходимости она может быть перемещена или удалена.
            this.тарифы_абонементаTableAdapter.Fill(this.sportxDataSet.Тарифы_абонемента);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string query = "SELECT [ID], [Название], [Цена], [Срок действия] FROM [Тарифы абонемента] WHERE Название LIKE '%" + Name + "%' ";
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
            dataGridView1.DataSource = тарифыАбонементаBindingSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox2.Text);
            string query = "DELETE FROM [Тарифы абонемента] WHERE [ID] = " + ID;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            dataGridView1.DataSource = тарифыАбонементаBindingSource;
            this.тарифы_абонементаTableAdapter.Fill(this.sportxDataSet.Тарифы_абонемента);
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTarif af = new AddTarif();
            af.Owner = this;
            af.Show();
        }

        private void Tarif_Activated(object sender, EventArgs e)
        {
            dataGridView1.DataSource = тарифыАбонементаBindingSource;
            this.тарифы_абонементаTableAdapter.Fill(this.sportxDataSet.Тарифы_абонемента);
        }
    }
}
