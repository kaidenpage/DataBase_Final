using System;
using System.Collections;
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
        const string HOST = "localhost:5432";
        const string USER = "postgres";
        const string PASS = "11111";
        const string DB = "DB_Final";
        const string connectionString = $"Host={HOST};Username={USER};Password={PASS};Database={DB}";

        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
        public ClientLogin()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientRegister fm = new ClientRegister();
            fm.ShowDialog();
        }

        private void ClientLogin_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            var conn = GetConnection();
            try
            {
                conn.Open();
                string sql = @"select * from u_login(:_username,_password)";
                var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("_username",textBox1);
                cmd.Parameters.AddWithValue("_password", textBox2.Text);

                int result = (int)cmd.ExecuteScalar();

                
                conn.Close();

                if (result == 1)
                {
                    this.Hide();
                    new Client(textBox1.Text).Show();
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect. Please try again, or Register for an account.");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }

        }
    }
}
