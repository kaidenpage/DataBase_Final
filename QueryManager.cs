﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace DBFinal
{

    //This partial class handles the connection
    internal partial class QueryManager
    {
        const string HOST = "localhost:5432";
        const string USER = "postgres";
        const string PASS = "11111";
        const string DB = "DB_Final";
        const string connectionString = $"Host={HOST};Username={USER};Password={PASS};Database={DB}";

        public QueryManager()
        {
            TestConnection();
        }

        private static void TestConnection()
        {
            using (NpgsqlConnection conn = GetConnection())
            {
                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("Conected");
                }
                else
                {
                    Console.WriteLine("Not conected");
                }
            }
        }

        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

    }

    //This partial class handles the queries.
    internal partial class QueryManager
    {
        public void GetAllEmployees()
        {
            var conn = GetConnection();
            conn.Open();
            string sql = "SELECT * FROM Employee";
            using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
            {
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["fname"].ToString());
                }
                conn.Close();
            }
        }


        public void Clientlogin()
        {
            var conn = GetConnection();
            ClientLogin fm = new ClientLogin();
            string usertext = fm.textBox1.Text;
            string passwordtext = fm.textBox2.Text;
            try
            {
                conn.Open();
                string sql = @"select * from u_login(:_username,:_password)";
                var cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("_username", fm.textBox1.Text);
                cmd.Parameters.AddWithValue("_password", fm.textBox2.Text);

                int result = (int)cmd.ExecuteScalar();


                conn.Close();

                if (result == 1)
                {
                    fm.Hide();
                    new Client(fm.textBox1.Text).Show();
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect. Please try again, or Register for an account.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }

        }

        public void clientlogin2()
        {
            var conn = GetConnection();
           
            try
            {
                ClientLogin fm = new ClientLogin();
            string usertext = fm.textBox1.Text;
            string passwordtext = fm.textBox2.Text;
            conn.Open();
            string sql = @"select * from u_login(:_username,:_password)";

            using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("_username", fm.textBox1.Text);
                command.Parameters.AddWithValue("_password", fm.textBox2.Text);

                int result = (int)command.ExecuteScalar();
                if (result == 1)
                {
                    fm.Hide();
                    new Client(fm.textBox1.Text).Show();
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect. Please try again, or Register for an account.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                conn.Close();
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
