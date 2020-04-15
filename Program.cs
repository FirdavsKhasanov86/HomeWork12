using System;
using System.Data.SqlClient;
using System.Data;

namespace HomeWork12
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString = @"Data source=192.168.103.131; Initial catalog=testdb; user id=sa; password=Sa123.";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                System.Console.WriteLine("Opened!");
            }
             else
            {
                System.Console.WriteLine("Ooops, troubles with connection!!!");
            }
        }
    }
}

