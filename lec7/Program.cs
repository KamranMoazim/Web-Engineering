using System;
using Microsoft.Data.SqlClient;

namespace lec7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*          
             string connnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

             SqlConnection conn = new SqlConnection(connnectionString);

             conn.Open();

             string query = "Select * from Person";

             SqlCommand cmd = new SqlCommand(query, conn);

             SqlDataReader reader = cmd.ExecuteReader();

             while (reader.Read())
             {
                 Console.WriteLine($"id:{reader.GetValue(0)} , Name:{reader[1]} , Age:{reader.GetValue(2)}");
             }
              conn.Close();
             */


            /*string connnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            SqlConnection conn = new SqlConnection(connnectionString);

            conn.Open();
            Console.Write("Enter UserName : ");
            string userName = Console.ReadLine();
            Console.Write("Enter Password : ");
            string password = Console.ReadLine();

            string selectQuery = "Select * from Users";*/
            // string insertQuery = $"Insert Into Users(UserName, Password) Values('{userName}', '{password}')";
            // string updateQuery = $"Update Users Set Password='{password}' Where username='{userName}'";
            // string deleteQuery = $"Delete From Users Where username='{userName}'";

            /*
            SqlCommand cmd = new SqlCommand(selectQuery, conn);
            int effectedRows = cmd.ExecuteNonQuery();
            if (effectedRows >= 1)
            {
                Console.WriteLine("Row Inserted/Updated/Deleted");
            }
            else
            {
                Console.WriteLine("failed");
            }
            */


            /*SqlCommand cmd = new SqlCommand(selectQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"id:{reader.GetValue(0)} , UserName:{reader[1]} , Password:{reader.GetValue(2)}");
            }

            conn.Close();*/





            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            SqlConnection conn = new SqlConnection(connectionString);

            string query1 = "Select * from Person";

            string name = "";
            string query = "insert into Person(Name,Age) values ('dim',26)";
            string queryUp = $"insert into Person(Name,Age) values ('{name}',26)";
            string query3 = "Update Person set Name='Kamran' where id=1";
            string query2 = "delete from Person where id=1002";

            string query5 = "Select Count(*) From Person";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlCommand cmd2 = new SqlCommand(query5, conn);

            conn.Open();

            object obj = cmd2.ExecuteScalar();

            Console.WriteLine(obj);

            /*cmd.ExecuteNonQuery();

            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read()) {
                Console.WriteLine($" Name: {dr[1]}");
                Console.WriteLine($" Age: {dr[2]}");
            }*/
            conn.Close();
        }
    }
}