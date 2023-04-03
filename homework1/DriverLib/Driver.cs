

using System.Collections;
using LocationLib;
using VehicleLib;

namespace DriverLib
{
    public class Driver
    {
        public int driverId { get; set; }
        public string? name { get; set; }
        public int age { get; set; }
        public string? gender { get; set; }
        public string? address { get; set; }
        public string? phoneNo { get; set; }
        public Location? currentLocation { get; set; }
        public Vehicle? vehicle { get; set; }
        public bool availability { get; set; }

        private List<int> ratings = new List<int>();
        public List<int> Ratings
        {
            get { return ratings; }
            set { ratings = value; }
        }

        public Driver()
        {
            this.currentLocation = new Location();
            this.vehicle = new Vehicle();
        }



        // update availability (by user input)
        public bool updateAvailability()
        {
            Console.WriteLine("Set Your Availability Status (1/2) : ");
            Console.WriteLine("1. Available : ");
            Console.WriteLine("2. Not-Available : ");
            // string? available = Console.ReadLine();
            string? available = readInput();
            int intAvailable = System.Convert.ToInt16(available);
            if (intAvailable == 1)
            {
                this.availability = true;
            }
            else
            {
                this.availability = false;
            }
            return true;
        }

        // returns avg of all ratings
        public double getRating()
        {
            return this.ratings.Average();
        }

        // simply takes input from Driver and update its current location
        public bool updateLocation()
        {
            Console.WriteLine("Enter your current Location: ");
            // string? locationsInput = Console.ReadLine();
            string? locationsInput = readInput();
            string[] locationsArray = locationsInput!.Split(',');

            this.currentLocation!.setLocation(
                (float)System.Convert.ToDouble(locationsArray[0]),
                (float)System.Convert.ToDouble(locationsArray[1])
            );
            return true;
        }


        // ******** Helper Functions added By ME ******** 
        // to add rating to drivers rating list
        // rated by Rider after having a ride 
        public bool addRating(int rating)
        {
            this.ratings.Add(rating);
            return true;
        }

        private static string? readInput()
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            string? input = System.Console.ReadLine();
            System.Console.ResetColor();
            return input;
        }
    }
}