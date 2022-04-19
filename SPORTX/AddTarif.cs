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

    public partial class AddTarif : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= Sportx.mdb";
        private OleDbConnection myConnection;
        public AddTarif()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);//Подключение к БД
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox1.Text);
            string Name = textBox2.Text;
            string Price = textBox3.Text;
            string Time = textBox4.Text;
            string query = "INSERT INTO [Тарифы абонемента] ([ID],[Название],[Цена],[Срок действия]) VALUES (" + ID + ", '" + Name + "', '" + Price + "', '" + Time + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddTarif_Load(object sender, EventArgs e)
        {

        }
    }
}
