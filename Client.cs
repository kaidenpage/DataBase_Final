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
    public partial class Client : Form
    {
        public Client(string username)
        {
            this.username = username;
            InitializeComponent();

            Console.WriteLine("Updating Client info attempt");

            const string HOST = "localhost:5432";
            const string USER = "postgres";
            const string PASS = "123411";
            const string DB = "postgres";
            const string connectionString = $"Host={HOST};Username={USER};Password={PASS};Database={DB}";
            var conn = new NpgsqlConnection(connectionString);

            try
            {
                conn.Open();
                //string sql = @"select * from inventory";
                NpgsqlCommand get_cid = new NpgsqlCommand("SELECT CID FROM CustLogin WHERE Users=@Users", conn);
                get_cid.Parameters.AddWithValue("Users", username);

                //MessageBox.Show("" + username);

                this.CID = (int)get_cid.ExecuteScalar();

                //MessageBox.Show("" + CID);

                NpgsqlCommand customer_info = new NpgsqlCommand("SELECT fname, lname, phone, email, address FROM Customer Where cid =@cid ", conn);
                customer_info.Parameters.AddWithValue("cid", (int)CID);
                //MessageBox.Show("" + CID);


                NpgsqlDataReader customer_data = customer_info.ExecuteReader();

                //MessageBox.Show("" + fname);
                if (customer_data.HasRows)
                {
                    customer_data.Read();

                    this.fname = (string)customer_data[0];
                    this.lname = (string)customer_data[1];
                    this.phone = (string)customer_data[2];
                    this.email = (string)customer_data[3];
                    this.address = (string)customer_data[4];

                }

                conn.Close();

                conn.Open();

                NpgsqlCommand address_data = new NpgsqlCommand("Select * FROM Address WHERE street = @address", conn);
                address_data.Parameters.AddWithValue("address", this.address);
                //MessageBox.Show("" + address);

                NpgsqlDataReader address_data2 = address_data.ExecuteReader();

                if (address_data2.HasRows)
                {
                    address_data2.Read();

                    this.city = (string)address_data2[1];
                    this.state = (string)address_data2[2];
                    this.zip = (int)address_data2[3];
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private string username;
        private int CID;
        private string fname;
        private string lname;
        private string phone;
        private string email;
        private string address;
        private string city;
        private string state;
        private int zip;
        private void Client_Load(object sender, EventArgs e)
        {
            lbluser.Text = lbluser.Text + " " + username;
            textBox1.Text = this.fname;
            textBox2.Text = this.lname;
            textBox3.Text = this.phone;
            textBox7.Text = this.email;
            textBox6.Text = this.address;
            textBox5.Text = this.city;
            comboBox1.Text = this.state;
            textBox8.Text = this.zip.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Main back = new Main();
            back.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Updating Client info attempt");

            const string HOST = "localhost:5432";
            const string USER = "postgres";
            const string PASS = "123411";
            const string DB = "postgres";
            const string connectionString = $"Host={HOST};Username={USER};Password={PASS};Database={DB}";
            var conn = new NpgsqlConnection(connectionString);

            try
            {
                conn.Open();
                //string sql = @"select * from inventory";
                NpgsqlCommand update_address = new NpgsqlCommand("Update Address Set street=@street, city=@city, state=@state, zip=@zip where street=@street2", conn);
                NpgsqlCommand update_client = new NpgsqlCommand("Update Customer Set fname=@fname, lname=@lname, phone=@phone, email=@email Where CID=@CID", conn);

                update_address.Parameters.AddWithValue("street", textBox6.Text);
                update_address.Parameters.AddWithValue("city", textBox5.Text);
                update_address.Parameters.AddWithValue("state", comboBox1.Text);
                update_address.Parameters.AddWithValue("zip", Int32.Parse(textBox8.Text));
                update_address.Parameters.AddWithValue("street2", this.address);

                update_client.Parameters.AddWithValue("fname", textBox1.Text);
                update_client.Parameters.AddWithValue("lname", textBox2.Text);
                update_client.Parameters.AddWithValue("phone", textBox3.Text);
                update_client.Parameters.AddWithValue("email", textBox7.Text);
                update_client.Parameters.AddWithValue("CID", this.CID);


                update_address.ExecuteNonQuery();
                update_client.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }

        }
    }
}
