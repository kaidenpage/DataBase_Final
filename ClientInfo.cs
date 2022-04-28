﻿using System;
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
    public partial class ClientInfo : Form
    {
        public ClientInfo()
        {
            InitializeComponent();
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


                var sql = "INSERT INTO customer(cid, fname, lname,phone,email,address) VALUES(@cid, @fname,@lname,@phone,@email,@address)";
                using var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("cid", textBox3);
                cmd.Parameters.AddWithValue("fname", textBox1.Text);
                cmd.Parameters.AddWithValue("lname", textBox2.Text);
                cmd.Parameters.AddWithValue("phone", textBox4.Text);
                cmd.Parameters.AddWithValue("email", textBox5.Text);
                cmd.Parameters.AddWithValue("address", textBox6);
                cmd.Prepare();

                cmd.ExecuteNonQuery();

                Console.WriteLine("row inserted");


             /*   string sql = @"select * from u_login(:_username,:_password)";
                var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("_username", textBox1.Text);
                cmd.Parameters.AddWithValue("_password", textBox2.Text);

                int result = (int)cmd.ExecuteScalar();
*/

                //MessageBox.Show(textBox1.Text);
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
        }
    }
}
