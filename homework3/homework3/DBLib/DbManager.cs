using Microsoft.Data.SqlClient;
using DriverLib;
using PassengerLib;

namespace DBLib
{
    public class DbManager
    {
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private SqlConnection connection;

        DbManager()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public bool addPassenger(Passenger passenger)
        {
            return true;
        }

        public List<Driver> getDriverdList()
        {
            return null;
        }

        public bool addDriver(Driver driver)
        {
            return true;
        }

        public bool updateDriver(Driver driver, int id)
        {
            return true;
        }

        public bool removeDriver(int id)
        {
            return true;
        }

        ~DbManager()
        {
            connection.Close();
        }
    }
}