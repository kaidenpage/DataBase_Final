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
    public partial class UpdateInventory : Form
    {
        public UpdateInventory()
        {
            InitializeComponent();
            Console.WriteLine("Viewing inventory attempt");
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
                string sql = @"select * from inventory";
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

        DataTable table = new DataTable();
        int indexRow;

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = textBoxName.Text;
            newDataRow.Cells[1].Value = Int32.Parse(textBoxQuantity.Text);
            newDataRow.Cells[2].Value = textBoxUnits.Text;

            Console.WriteLine("Updating inventory attempt");
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
                //string sql = @"select * from inventory";
                NpgsqlCommand cmd = new NpgsqlCommand("Update inventory Set name=@namee, quantity=@quan, units = @unit where name=@namee", conn);

                cmd.Parameters.AddWithValue("namee", textBoxName.Text);
                cmd.Parameters.AddWithValue("quan", Int32.Parse(textBoxQuantity.Text));
                cmd.Parameters.AddWithValue("unit", textBoxUnits.Text);

                cmd.ExecuteNonQuery();
                //cmd.Connection = conn;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
               


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
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            textBoxName.Text = row.Cells[0].Value.ToString();
            textBoxQuantity.Text = row.Cells[1].Value.ToString();
            textBoxUnits.Text = row.Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory fm = new Inventory();
            fm.ShowDialog();
        }
    }
}
