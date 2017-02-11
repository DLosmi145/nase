using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

namespace Kladionica.data.dao.mysql
{
    class ConnectionPool
    {
        private static ArrayList connections;
        private static int connectionNumber = 10;
        private static string connectionString = "Server=127.0.0.1;Database=kladionica;Uid=root;Pwd=root;";

        static ConnectionPool()
        {
            try
            {
                connections = new ArrayList();
                for (int i = 0; i < connectionNumber; i++)
                {
                    MySqlConnection conn = new MySqlConnection(connectionString);
                    conn.Open();
                    connections.Add(conn);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
        }

        public static MySqlConnection getSingleConnection()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static void closeSingleConnection(MySqlConnection conn)
        {
            conn.Close();
        }

        public static MySqlConnection checkOutConnection()
        {
            foreach (MySqlConnection conn in connections)
            {
                if (conn.State == ConnectionState.Open)
                {
                    connections.Remove(conn);
                    return conn;
                }
            }
            MySqlConnection fallback = getSingleConnection();
            return fallback;
        }

        public static void checkInConnection(MySqlConnection conn)
        {
            connections.Add(conn);
        }
    }
}
