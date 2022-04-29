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
    public partial class EmployeeLogin : Form
    {
        public EmployeeLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Login attempt");
            //var qmanager = new QueryManager();
            //qmanager.Clientlogin(textBox1.Text, textBox2.Text);

            const string HOST = "localhost:5432";
            const string USER = "postgres";
            const string PASS = "Youarestrong07!";
            const string DB = "DB_Final";
            const string connectionString = $"Host={HOST};Username={USER};Password={PASS};Database={DB}";
            var conn = new NpgsqlConnection(connectionString);

            try
            {
                conn.Open();
                string sql = @"select * from e_login(:_usernames,:_passwords)";
                var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("_usernames", textBox1.Text);
                cmd.Parameters.AddWithValue("_passwords", textBox2.Text);

                int result = (int)cmd.ExecuteScalar();


                //MessageBox.Show(textBox1.Text);
                //MessageBox.Show(textBox2.Text);

                conn.Close();

                if (result == 1)
                {
                    Hide();
                    new Employee(textBox1.Text).Show();
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect. Please try again, or Register for an account.");
                    //MessageBox.Show(fm.textBox1.Text);
                    //MessageBox.Show(fm.textBox2.Text);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Main back = new Main();
            back.Show();

        }
    }
}
