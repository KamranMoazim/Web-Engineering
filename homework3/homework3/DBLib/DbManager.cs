using Microsoft.Data.SqlClient;
using DriverLib;
using PassengerLib;
using System.Reflection;
using VehicleLib;
using Azure;
using System.Net;
using LocationLib;

namespace DBLib
{
    public class DbManager
    {

        // private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public DbManager()
        {
        }

        public bool addRating(int driverId, int rating)
        {

            string query = $"Insert into MyDB.dbo.AppDriverRatings(driver_id, rating) Values({driverId}, {rating})";

            var connection = new SqlConnection(connectionString);
            connection.Open();

            return MyExecuteNonQueryMethod(query, connection);
        }

        public List<int> getRatings(int driverId)
        {
            string query = $"Select rating From MyDB.dbo.AppDriverRatings Where driver_id={driverId}";

            List<int> ratings = new List<int>();

            var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlDataReader dataReader = MyExecuteReader(query, connection);
            while (dataReader.Read())
            {
                ratings.Add(Convert.ToInt32(dataReader.GetValue(0)));
            }
            
            connection.Close();

            return ratings; 
        }

        public List<Driver> getDriverdList()
        {
            string query = "Select * From MyDB.dbo.AppDriver";

            var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlDataReader dataReader = MyExecuteReader(query, connection);

            List<Driver> drivers = formateQueryToDrivers(dataReader);

            connection.Close();

            return drivers;
        }

        public List<Driver> searchDriver(Driver driver)
        {
            int gender = -1;
            if (driver.gender == "Male")
            {
                gender = 1;
            } else if (driver.gender == "Female")
            {
                gender = 0;
            }

            string query = $"""
                            Select * From MyDB.dbo.AppDriver 
                            Where name='{driver.name}' OR age = {driver.age} OR gender = {gender} OR address = '{driver.address}' OR type = '{driver.vehicle!.type}' OR model = '{driver.vehicle!.model}' OR license_plate = '{driver.vehicle!.licensePlate}'
                            """;

            var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlDataReader dataReader = MyExecuteReader(query, connection);


            List<Driver> drivers =  formateQueryToDrivers(dataReader);

            connection.Close();

            return drivers;

        }

        private List<Driver> formateQueryToDrivers(SqlDataReader dataReader)
        {
            List<Driver> allDriversList = new List<Driver>();

            while (dataReader.Read())
            {


                // creating new vehicle 
                Vehicle newDriverVehicle = new Vehicle
                {
                    type = (string)dataReader[8],
                    model = (string)dataReader[9],
                    licensePlate = (string)dataReader[10]
                };

                // creating new location 
                Location newDriverLocation = new Location
                {
                    latitude = Convert.ToSingle(dataReader[6]),
                    longitude = Convert.ToSingle(dataReader[7]),
                };


                bool availability = true;
                if (!(bool)dataReader[11])
                {
                    availability = false;
                }

                string gender = "Male";
                if ((bool)dataReader[3] == true)
                {
                    gender = "Female";
                }

                // creating new driver
                Driver newDriver = new Driver
                {
                    driverId = (int)dataReader[0],
                    name = (string)dataReader[1],
                    age = (int)dataReader[2],
                    gender = gender,
                    address = (string)dataReader[4],
                    phoneNo = (string)dataReader[5],

                    currentLocation = newDriverLocation,

                    availability = availability,

                    vehicle = newDriverVehicle,

                };


                allDriversList.Add(newDriver);
            }

            foreach (var driver in allDriversList)
            {
                driver.Ratings = getRatings(driver.driverId);
            }

            return allDriversList;
        }

        public bool addDriver(Driver driver)
        {
            int gender = 0;
            if (driver.gender == "Male")
            {
                gender = 1;
            }

            int availability = 0;
            if (driver.availability)
            {
                availability = 1;
            }

            string query = $"""
                Insert into 
                MyDB.dbo.AppDriver(name, age, gender, address, phone_no, latitude, longtitude, type, model, license_plate, availability) 
                Values(
                '{driver.name}', {driver.age}, {gender}, '{driver.address}', '{driver.phoneNo}', 
                {driver.currentLocation!.latitude}, {driver.currentLocation.longitude}, 
                '{driver.vehicle!.type}', '{driver.vehicle.model}', '{driver.vehicle.licensePlate}', 
                {availability});
                """;

            var connection = new SqlConnection(connectionString);
            connection.Open();

            return MyExecuteNonQueryMethod(query, connection);
        }

        public bool updateDriver(Driver driver)
        {
            int gender = 0;
            if (driver.gender == "Male")
            {
                gender = 1;
            }

            int availability = 0;
            if (driver.availability)
            {
                availability = 1;
            }

            string query = $"""
                Update MyDB.dbo.AppDriver
                Set 
                    name = '{driver.name}',
                    age = {driver.age},
                    gender = {gender},
                    address = '{driver.address}',
                    phone_no = '{driver.phoneNo}',
                    latitude = {driver.currentLocation!.latitude},
                    longtitude = {driver.currentLocation.longitude},
                    type = '{driver.vehicle!.type}',
                    model = '{driver.vehicle.model}',
                    license_plate = '{driver.vehicle.licensePlate}',
                    availability = {availability}
                Where id={driver.driverId};

                """;

            var connection = new SqlConnection(connectionString);
            connection.Open();

            return MyExecuteNonQueryMethod(query, connection);
        }

        public bool isDriverExists(int id)
        {
            string query = $"Select * From MyDB.dbo.AppDriver Where id={id}";

            var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlDataReader dataReader = MyExecuteReader(query, connection);

            if (dataReader.Cast<object>().Count() > 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public Driver getDriverById(int id)
        {
            string query = $"Select * From MyDB.dbo.AppDriver Where id={id}";

            var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlDataReader dataReader = MyExecuteReader(query, connection);

            var li = formateQueryToDrivers(dataReader);

            connection.Close();

            if(li.Count > 0)
            {
                return li[0];
            }

            return null;
        }

        public bool removeDriver(int id)
        {
            string query = $"""Delete From MyDB.dbo.AppDriver Where AppDriver.id={id}""";

            var connection = new SqlConnection(connectionString);
            connection.Open();

            return MyExecuteNonQueryMethod(query, connection);
        }

        private bool MyExecuteNonQueryMethod(string query, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand(query, connection);
            int effectedRows = cmd.ExecuteNonQuery();
            if (effectedRows >= 1)
            {
                // Console.WriteLine("Row Inserted/Updated/Deleted");

                connection.Close();
                return true;
            }
            else
            {
                // Console.WriteLine("failed");
                connection.Close();
                return false;
            }
        }

        private SqlDataReader MyExecuteReader(string query, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

    }
}