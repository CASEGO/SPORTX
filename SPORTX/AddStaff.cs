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

    public partial class AddStaff : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= Sportx.mdb";
        private OleDbConnection myConnection;
        public AddStaff()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);//Подключение к БД
            myConnection.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox1.Text);
            string Name = textBox2.Text;
            string Phone = textBox3.Text;
            string Home = textBox4.Text;
            string Status = textBox5.Text;
            string query = "INSERT INTO Сотрудники ([ID],[ФИО],[Телефон],[Адрес],[Должность]) VALUES (" + ID + ", '" + Name + "', '" + Phone + "', '" + Home + "','" + Status + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.Close();
        }

        private void AddStaff_Load(object sender, EventArgs e)
        {

        }
    }
}
