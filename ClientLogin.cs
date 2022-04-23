using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace DBFinal
{
    public partial class ClientLogin : Form
    {
        public ClientLogin()
        {
            InitializeComponent();
        }
        
        private static void TestConnection()
        {
            using(NpgsqlConnection conn = GetConnection())
            {
                if(conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("Connected");
                }
                else
                {
                    MessageBox.Show("Not Connected");
                }
            }
        }

        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=11111;Database=DB_Final;");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientRegister fm = new ClientRegister();
            fm.ShowDialog();
        }
    }
}
