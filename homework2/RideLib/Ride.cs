

using DriverLib;
using LocationLib;
using PassengerLib;

namespace RideLib
{
    public class Ride
    {
        public Location startLocation { get; set; }
        public Location endLocation { get; set; }

        public int price { get; set; }
        public Driver driver { get; set; }
        public Passenger passenger { get; set; }

        public Ride()
        {
            this.startLocation = new Location();
            this.endLocation = new Location();
            this.driver = new Driver();
            this.passenger = new Passenger();
        }

        // just assigning passenger to Ride
        public bool assignPassenger(Passenger passenger)
        {
            this.passenger = passenger;
            return true;
        }

        // to assign a driver to Ride Request (if we have driver available)
        public bool assignDriver(List<Driver> allDriversList)
        {
            Driver tempDriver = new Driver();
            float? minDistance = 0;

            if (allDriversList.Count == 0)  // means we have no drivers - zero drivers in the list
            {
                return false;
            }

            bool rideTypeMatced = true;
            string? rideType;
            int count = 3; // as we have only three type of Vehicles

            // we will loop until we find user requierment fulfilld of particaular Vehicle Type 
            do
            {
                // Entering Ride Type
                rideType = getRideType();
                count--;

                foreach (var driver in allDriversList)
                {
                    if (driver.availability == true) // checking driver is available
                    {
                        if (driver.vehicle!.type == rideType)
                        {
                            rideTypeMatced = false;
                            if (minDistance != 0)
                            {
                                float? tempMinDistance = getDistance(this.startLocation, driver.currentLocation!);
                                if (tempMinDistance < minDistance) // giving ride to nearest available driver then previous one
                                {
                                    tempDriver = driver;
                                    minDistance = tempMinDistance;
                                }
                            }
                            else // giving ride to first available driver
                            {
                                tempDriver = driver;
                                minDistance = getDistance(this.startLocation, driver.currentLocation!);
                            }
                        }
                    }
                }

                if (rideTypeMatced)
                {
                    System.Console.WriteLine("Sorry your required Ride Type NOT FOUND please select other option");
                }


            } while (count > 0 && rideTypeMatced);
            // means rider Want a Car But we don't have Car right now, so again prompting for input

            if (rideTypeMatced)  // means we have no drivers matched
            {
                return false;
            }


            driver = tempDriver; // setting driver of current ride
            driver.availability = false; // setting availability to false // means same driver cannot be booked until freed

            return true;
        }

        // this function simply takes input of start and end locations
        public bool getLocations()
        {

            Console.Write("Enter Start Location: ");
            // string? locationsInput = Console.ReadLine();
            string? locationsInput = readInput();
            string[] locationsArray = { "1", "2" };
            locationsArray = locationsInput!.Split(',');

            this.startLocation.setLocation(
                (float)System.Convert.ToDouble(locationsArray[0]),
                (float)System.Convert.ToDouble(locationsArray[1])
            );

            Console.Write("Enter End Location: ");
            // locationsInput = Console.ReadLine();
            locationsInput = readInput();
            locationsArray = locationsInput!.Split(',');

            this.endLocation.setLocation(
                (float)System.Convert.ToDouble(locationsArray[0]),
                (float)System.Convert.ToDouble(locationsArray[1])
            );

            return true;
        }

        // this function calculate price for the given distance and our setted parameters
        public float calculatePrice()
        {
            float distance = getDistance(startLocation, endLocation);
            float fuelPrice = 550;

            float fuelAverage = 0;
            float commission = 0;

            if (driver.vehicle!.type == "Bike")
            {
                fuelAverage = 50;
                commission = 0.05F;
            }
            else if (driver.vehicle.type == "Rickshaw")
            {
                fuelAverage = 35;
                commission = 0.10F;
            }
            else
            {
                fuelAverage = 15;
                commission = 0.20F;
            }

            float price = ((distance * fuelPrice) / fuelAverage) + commission;

            return price;
        }

        // passenger will give rating to particular driver
        // which will be added to drivers Rating list
        public bool giveRating()
        {
            int intRating = 5;
            while (true)
            {

                Console.Write("Give rating out of 5 (Between 1-5 Only) : ");
                // string? ratingInput = Console.ReadLine();
                string? ratingInput = readInput();
                intRating = System.Convert.ToInt16(ratingInput);
                if (intRating <= 5 && intRating >= 1)
                {
                    driver.addRating(intRating);  // adding rating to drivers rating list
                    break;
                }

            }

            return true;
        }


        // **** my helper functions ****

        // function to calculate distance b/w two points
        public static float getDistance(Location p1, Location p2)
        {

            double num6 = p1.longitude - p2.longitude;
            double num7 = p1.latitude - p2.latitude;

            double num9 = Math.Sqrt((num7 * num7) + (num6 * num6));
            return (float)(num9);
        }

        private string? getRideType()
        {
            string? rideType = "";
            while (true)
            {
                System.Console.Write("Enter Ride Type:");
                // rideType = System.Console.ReadLine();
                rideType = readInput();
                if (rideType == "Bike" || rideType == "Rickshaw" || rideType == "Car")
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("Please Enter Only (Bike - Rickshaw - Car)");
                }
            }

            return rideType;
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


/*

*/