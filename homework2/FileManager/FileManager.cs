
using System.Text.Json;
using System.Xml;
using DriverLib;
using LocationLib;
using VehicleLib;

namespace FileManager
{
    public class FileManagerClass
    {
        public const string TextDriverFileName = "drivers.txt";
        public const string JsonDriverFileName = "drivers.json";
        public const string JsonRatingFileName = "ratings.json";

        public List<Driver> loadAllDriversFromFileText()
        {
            FileStream fileIn = new FileStream(TextDriverFileName, FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fileIn);

            List<Driver> allDriversList = new List<Driver>();

            string? data = streamReader.ReadLine();

            while (data != null)
            {
                string[] fileDriver = data.Split(",");
                // public Location? currentLocation { get; set; }
                // public Vehicle? vehicle { get; set; }
                // public bool availability { get; set; }
                // private List<int> ratings = new List<int>();

                // we are obtaining it in the order of ToString method of Driver Class
                Driver newDriver = new Driver
                {
                    driverId = int.Parse(fileDriver[0]),
                    name = fileDriver[1],
                    age = int.Parse(fileDriver[2]),
                    gender = fileDriver[3],
                    address = fileDriver[4],
                    phoneNo = fileDriver[5],
                    availability = false,
                    // follwing attribs are setting below
                    // currentLocation = fileDriver[6],
                    // vehicle = fileDriver[],
                    // Ratings = new List<int>()
                };

                // setting location
                newDriver.currentLocation!.longitude = float.Parse(fileDriver[6]);
                newDriver.currentLocation.latitude = float.Parse(fileDriver[7]);

                // setting vehicle
                newDriver.vehicle!.type = fileDriver[8];
                newDriver.vehicle.model = fileDriver[9];
                newDriver.vehicle.licensePlate = fileDriver[10];

                // setting ratings
                for (int i = 11; i < fileDriver.Length; i++)
                {
                    newDriver.addRating(int.Parse(fileDriver[i]));
                }


                allDriversList.Add(newDriver);
                data = streamReader.ReadLine();
            }

            streamReader.Close();
            fileIn.Close();

            return allDriversList;
        }


        public void saveAllDriversToFileText(List<Driver> allDriversList)
        {
            // loadAllDriversFromFileJson();
            FileStream fileOut = new FileStream(TextDriverFileName, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fileOut);

            foreach (var driver in allDriversList)
            {
                streamWriter.WriteLine(driver.ToString());
            }

            streamWriter.Close();
            fileOut.Close();
            // saveAllDriversToFileJson();
        }


        public List<Driver> loadAllDriversFromFileJson()
        {
            string json = File.ReadAllText(JsonDriverFileName);
            var allDriversList = JsonSerializer.Deserialize<List<Driver>>(json)!;

            List<DriverRating> driverRatings = loadAllDriversRatingsFromFileJson();
            foreach (var driver in allDriversList)
            {
                foreach (var ratings in driverRatings)
                {
                    if (driver.driverId == ratings.driverId)
                    {
                        driver.Ratings = ratings.ratings;
                    }
                }
            }

            return allDriversList;
        }

        public void saveAllDriversToFileJson(List<Driver> allDriversList)
        {
            string json = JsonSerializer.Serialize(allDriversList);
            File.WriteAllText(JsonDriverFileName, json);

            saveAllDriversRatingsToFileJson(allDriversList);
        }

        public List<DriverRating> loadAllDriversRatingsFromFileJson()
        {
            string json = File.ReadAllText(JsonRatingFileName);
            var allDriversRatingsList = JsonSerializer.Deserialize<List<DriverRating>>(json)!;
            return allDriversRatingsList;
        }

        public void saveAllDriversRatingsToFileJson(List<Driver> allDriversList)
        {
            List<DriverRating> driverRatings = new List<DriverRating>();
            foreach (var driver in allDriversList)
            {
                DriverRating driverRating = new DriverRating
                {
                    driverId = driver.driverId,
                    ratings = driver.Ratings
                };
                driverRatings.Add(driverRating);
            }

            string json = JsonSerializer.Serialize(driverRatings);
            File.WriteAllText(JsonRatingFileName, json);
        }


        public void addNewRatingToFileJson(Driver driver)
        {
            List<DriverRating> driverRatings = loadAllDriversRatingsFromFileJson();

            foreach (var driverRating in driverRatings)
            {
                if (driverRating.driverId == driver.driverId)
                {
                    driverRating.ratings = driver.Ratings;
                }
            }

            string json = JsonSerializer.Serialize(driverRatings);
            File.WriteAllText(JsonRatingFileName, json);
        }



    }



    public class DriverRating
    {
        public int driverId { get; set; }
        public List<int> ratings { get; set; } = new List<int>();
    }
}