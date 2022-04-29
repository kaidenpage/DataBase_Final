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
    public partial class ClientRegister : Form
    {
        public ClientRegister()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Submitting Client info attempt");
            //var qmanager = new QueryManager();
            //qmanager.Clientlogin(textBox1.Text, textBox2.Text);

            const string HOST = "localhost:5432";
            const string USER = "postgres";
            const string PASS = "123411";
            const string DB = "postgres";
            const string connectionString = $"Host={HOST};Username={USER};Password={PASS};Database={DB}";
            var conn = new NpgsqlConnection(connectionString);

            try
            {
                conn.Open();

                var sql_address = "INSERT INTO Address(street, city, state, zip) VALUES(@street, @city, @state, @zip)";
                var sql_customer = "INSERT INTO customer(fname, lname,phone,email,address) VALUES(@fname,@lname,@phone,@email,@address)";
                var sql_custLogin = "INSERT INTO CustLogin(users, CID, pass) VALUES(@users, @CID, @pass)";

                using var cmd_address = new NpgsqlCommand(sql_address, conn);
                using var cmd_customer = new NpgsqlCommand(sql_customer, conn);
                using var cmd_custLogin = new NpgsqlCommand(sql_custLogin, conn);
                using var get_sequence = new NpgsqlCommand(@"SELECT MAX(cid) FROM Customer", conn);


                cmd_address.Parameters.AddWithValue("street", textBox6.Text);
                cmd_address.Parameters.AddWithValue("city", textBox8.Text);
                cmd_address.Parameters.AddWithValue("state", comboBox1.SelectedItem);
                cmd_address.Parameters.AddWithValue("zip", Int32.Parse(textBox9.Text));
                cmd_address.Prepare();

                cmd_address.ExecuteNonQuery();

                Console.WriteLine("Address row inserted");

                cmd_customer.Parameters.AddWithValue("fname", textBox1.Text);
                cmd_customer.Parameters.AddWithValue("lname", textBox2.Text);
                cmd_customer.Parameters.AddWithValue("phone", textBox4.Text);
                cmd_customer.Parameters.AddWithValue("email", textBox5.Text);
                cmd_customer.Parameters.AddWithValue("address", textBox6.Text);
                cmd_customer.Prepare();

                cmd_customer.ExecuteNonQuery();

                Console.WriteLine("Customer row inserted");

                int CID = (int)get_sequence.ExecuteScalar(); 

                cmd_custLogin.Parameters.AddWithValue("users", textBox3.Text);
                cmd_custLogin.Parameters.AddWithValue("CID", CID);
                cmd_custLogin.Parameters.AddWithValue("pass", textBox10.Text);
                cmd_custLogin.Prepare();

                cmd_custLogin.ExecuteNonQuery();

                Console.WriteLine("Customer Login Created");


                /*   string sql = @"select * from u_login(:_username,:_password)";
                   var cmd = new NpgsqlCommand(sql, conn);

                   cmd.Parameters.AddWithValue("_username", textBox1.Text);
                   cmd.Parameters.AddWithValue("_password", textBox2.Text);

                   int result = (int)cmd.ExecuteScalar();
   */

                //MessageBox.Show("" + CID);
                //MessageBox.Show(textBox2.Text);

                conn.Close();
                /*
                                if (result == 1)
                                {
                                    Hide();
                                    new Client(textBox1.Text).Show();
                                }
                                else
                                {
                                    MessageBox.Show("Username or Password is incorrect. Please try again, or Register for an account.");
                                    //MessageBox.Show(fm.textBox1.Text);
                                    //MessageBox.Show(fm.textBox2.Text);
                                    return;
                                }*/

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }


            //go back to login
                this.Close();
                ClientLogin back = new ClientLogin();
            back.Show();


        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            ClientLogin back = new ClientLogin();
            back.Show();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            ClientLogin back = new ClientLogin();
            back.Show();
        }
    }
}
