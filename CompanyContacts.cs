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
    public partial class CompanyVendors : Form
    {
        public CompanyVendors()
        {
            InitializeComponent();
            Console.WriteLine("Login attempt");
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
                string sql = @"select * from supplier";
               NpgsqlCommand cmd = new NpgsqlCommand();

                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }

               

                conn.Close();

            

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewVendor fm = new NewVendor();
            fm.ShowDialog();
        }
    }
}
