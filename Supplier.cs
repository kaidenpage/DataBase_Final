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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
            Console.WriteLine("Viewing vendors attempt");
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
                if (dr.HasRows)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Employee back = new Employee("User");
            back.Show();
        }

        public void BindGrid()
        {

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
                if (dr.HasRows)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete?", "Delete record",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Console.WriteLine("Deleting vendors attempt");
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
                    string name = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                    //string sql = @"select * from supplier";
                    NpgsqlCommand cmd = new NpgsqlCommand("Delete supplier where name = '" + name + "' ", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Deleted");






                    conn.Close();



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                BindGrid();
            }
           
        }
    }
}
