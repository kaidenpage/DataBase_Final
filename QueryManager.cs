using System;
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
        const string PASS = "Youarestrong07!";
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
    
    }

}
