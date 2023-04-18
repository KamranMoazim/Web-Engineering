
using DBLib;
using DriverLib;
using LocationLib;
using RideLib;
using System.Xml.Linq;
using VehicleLib;

namespace AdminLib
{
    public class Admin
    {
        private DbManager dbManager = new DbManager();
        private List<Driver> allDriversList = new List<Driver>();
        public List<Driver> AllDriversList
        {
            get { return dbManager.getDriverdList(); }
            // set { allDriversList = value; }
        }

        // to assign a driver to Ride Request (if we have driver available)
        public bool assignDriver(Ride ride)
        {
            var allDriversList = dbManager.getDriverdList();

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
                    if (driver.availability) // checking driver is available
                    {
                        if (driver.vehicle!.type == rideType)
                        {
                            rideTypeMatced = false;
                            if (minDistance != 0)
                            {
                                float? tempMinDistance = getDistance(ride.startLocation, driver.currentLocation!);
                                if (tempMinDistance < minDistance) // giving ride to nearest available driver then previous one
                                {
                                    tempDriver = driver;
                                    minDistance = tempMinDistance;
                                }
                            }
                            else // giving ride to first available driver
                            {
                                tempDriver = driver;
                                minDistance = getDistance(ride.startLocation, driver.currentLocation!);
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


            if (rideTypeMatced || count == 0)
            {
                return false;
            }


            ride.driver = tempDriver; // setting driver of current ride
            ride.driver.availability = false; // setting availability to false // means same driver cannot be booked until freed

            return true;
        }


        // add new driver to list
        public bool addDriver()
        {

            string? name = "";
            int age = 0;
            string? gender = "";
            string? address = "";
            string? type = "";
            string? model = "";
            string? licensePlate = "";

            System.Console.Write("Enter Name:");
            // name = System.Console.ReadLine();
            name = readInput();

            while (true)
            {
                System.Console.Write("Enter Age:");
                // age = Convert.ToInt32(System.Console.ReadLine());
                age = Convert.ToInt32(readInput());
                if (age < 18 || age > 65)
                {
                    System.Console.WriteLine("Please Enter Age B/W 18 - 65 ");
                }
                else
                {
                    break;
                }
            }

            System.Console.Write("Enter Gender:");
            // gender = System.Console.ReadLine();
            gender = readInput();

            System.Console.Write("Enter Address:");
            // address = System.Console.ReadLine();
            address = readInput();

            while (true)
            {
                System.Console.Write("Enter Vehicle Type:");
                // type = System.Console.ReadLine();
                type = readInput();
                if (type == "Bike" || type == "Rickshaw" || type == "Car")
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("Please Enter Only (Bike - Rickshaw - Car)");
                }
            }

            System.Console.Write("Enter Vehicle Model:");
            // model = System.Console.ReadLine();
            model = readInput();

            System.Console.Write("Enter Vehicle License Plate:");
            // licensePlate = System.Console.ReadLine();
            licensePlate = readInput();

            // ************* ************* ************* ************* 
            // till now we were taking simpl inputs in local variables according to our checks 
            // *************  ************* ************* ************* 


            // creating new vehicle 
            Vehicle newDriverVehicle = new Vehicle
            {
                licensePlate = licensePlate,
                model = model,
                type = type
            };

            // creating new driver
            Driver newDriver = new Driver
            {
                driverId = allDriversList.Count + 1,
                address = address,
                age = age,
                gender = gender,
                name = name,
                vehicle = newDriverVehicle
            };


            // adding driver to list
            // allDriversList.Add(newDriver);
            dbManager.addDriver(newDriver);

            System.Console.WriteLine($"*************************** New Driver Added Successfully ***************************");

            return true;
        }

        // update driver in list
        public bool updateDriver()
        {

            System.Console.Write("Enter Driver ID: ");
            // int driverId = Convert.ToInt32(System.Console.ReadLine());
            int driverId = Convert.ToInt32(readInput());


            Driver? existingDriver = dbManager.getDriverById(driverId); // chcking if Driver Exits or Not

            if (existingDriver == null)
            {
                System.Console.WriteLine(" ERROR - Driver with given ID not FOUND! ");
                return false;
            }

            System.Console.WriteLine($"-------------Driver with ID {driverId} exists-------------");

            string? name = "";
            int age = 0;
            string? gender = "";
            string? address = "";
            string? type = "";
            string? model = "";
            string? licensePlate = "";

            System.Console.Write("Enter Name:");
            // name = System.Console.ReadLine();
            name = readInput();

            while (true)
            {
                System.Console.Write("Enter Age:");
                // string? stringAge = System.Console.ReadLine();
                string? stringAge = readInput();
                if (stringAge != "")
                {
                    age = Convert.ToInt32(stringAge);
                    if (age < 18 || age > 65)
                    {
                        System.Console.WriteLine("Please Enter Age B/W 18 - 65 ");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            System.Console.Write("Enter Gender:");
            // gender = System.Console.ReadLine();
            gender = readInput();

            System.Console.Write("Enter Address:");
            // address = System.Console.ReadLine();
            address = readInput();

            while (true)
            {
                System.Console.Write("Enter Vehicle Type:");
                // type = System.Console.ReadLine();
                type = readInput();
                if (type == "Bike" || type == "Rickshaw" || type == "Car" || type == "")
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("Please Enter Only (Bike - Rickshaw - Car)");
                }
            }

            System.Console.Write("Enter Vehicle Model:");
            // model = System.Console.ReadLine();
            model = readInput();

            System.Console.Write("Enter Vehicle License Plate:");
            // licensePlate = System.Console.ReadLine();
            licensePlate = readInput();

            // ************* ************* ************* ************* 
            // till now we were taking simpl inputs in local variables according to our checks 
            // *************  ************* ************* ************* 




            // ************* ************* ************* ************* ************* ************* 
            // following below, we are only updating those values which were INPUT by the user 
            // *************  ************* ************* ************* ************* ************* 

            if (name != "")
            {
                existingDriver.name = name;
            }

            if (age != 0)
            {
                existingDriver.age = age;
            }

            if (gender != "")
            {
                existingDriver.gender = gender;
            }

            if (address != "")
            {
                existingDriver.address = address;
            }

            if (type != "")
            {
                existingDriver.vehicle!.type = type;
            }

            if (model != "")
            {
                existingDriver.vehicle!.model = model;
            }

            if (licensePlate != "")
            {
                existingDriver.vehicle!.licensePlate = licensePlate;
            }

            if(dbManager.isDriverExists(existingDriver.driverId))
            {
                dbManager.updateDriver(existingDriver);
                System.Console.WriteLine("--------------------- Driver Updated Successully ---------------------");
                return true;
            }
            else
            {
                System.Console.WriteLine("--------------------- Driver Do Not Exists ---------------------");
                return false;
            }

        }

        public bool removeDriver()
        {
            System.Console.Write("Enter Driver ID: ");
            // int driverId = Convert.ToInt32(System.Console.ReadLine());
            int driverId = Convert.ToInt32(readInput());


            /* Driver? existingDriver = allDriversList.Find(dri => dri.driverId == driverId); // chcking if Driver Exits or Not

             if (existingDriver == null)
             {
                 System.Console.WriteLine(" ERROR - Driver with given ID not FOUND! ");
                 return false;
             }

             allDriversList.Remove(existingDriver);*/ // removing Driver from the List

            if (dbManager.isDriverExists(driverId))
            {
                dbManager.removeDriver(driverId);
                System.Console.WriteLine("--------------------- Driver Removed Successully ---------------------");
                return true;
            }
            else
            {
                System.Console.WriteLine("--------------------- Driver Do Not Exists ---------------------");
                return false;
            }
        }

        public bool searchDriver()
        {

            List<Driver> foundedDriversList = new List<Driver>();

            string? name = "";
            int age = 0;
            string? gender = "";
            string? address = "";
            string? type = "";
            string? model = "";
            string? licensePlate = "";

            System.Console.Write("Enter Name:");
            // name = System.Console.ReadLine();
            name = readInput();

            // while (true)
            // {
            //     System.Console.Write("Enter Age:");
            //     age = Convert.ToInt32(System.Console.ReadLine());
            //     if (age < 18 || age > 65)
            //     {
            //         System.Console.WriteLine("Please Enter Age B/W 18 - 65 ");
            //     }
            //     else
            //     {
            //         break;
            //     }
            // }
            System.Console.Write("Enter Age:");
            // age = Convert.ToInt32(System.Console.ReadLine());
            string? stringAge = readInput();
            if (stringAge != "")
            {
                age = Convert.ToInt32(stringAge);
            }

            System.Console.Write("Enter Gender:");
            // gender = System.Console.ReadLine();
            gender = readInput();

            System.Console.Write("Enter Address:");
            // address = System.Console.ReadLine();
            address = readInput();

            // while (true)
            // {
            //     System.Console.Write("Enter Vehicle Type:");
            //     type = System.Console.ReadLine();
            //     if (type == "Bike" || type == "Rickshaw" || type == "Car")
            //     {
            //         break;
            //     }
            //     else
            //     {
            //         System.Console.WriteLine("Please Enter Only (Bike - Rickshaw - Car)");
            //     }
            // }

            System.Console.Write("Enter Vehicle Type:");
            // type = System.Console.ReadLine();
            type = readInput();

            System.Console.Write("Enter Vehicle Model:");
            // model = System.Console.ReadLine();
            model = readInput();

            System.Console.Write("Enter Vehicle License Plate:");
            // licensePlate = System.Console.ReadLine();
            licensePlate = readInput();

            // ************* ************* ************* ************* 
            // till now we were taking simpl inputs in local variables according to our checks 
            // for that driver which we are looking for
            // *************  ************* ************* ************* 




            // ************* ************* ************* ************* ************* ************* 
            // following below, we are filtering for each user input check
            // *************  ************* ************* ************* ************* ************* 

            Vehicle searchingDriverVehicle = new Vehicle 
            {
                licensePlate = licensePlate,
                model = model,
                type = type
            };

            Driver searchingDriverData = new Driver
            {
                name = name,
                age = age,
                gender = gender,
                address = address,
                vehicle = searchingDriverVehicle
            };
            /*
            if (name != "")
            {
                foundedDriversList = foundedDriversList.FindAll(dri => dri.name == name);
            }

            if (age != 0)
            {
                foundedDriversList = foundedDriversList.FindAll(dri => dri.age == age);
            }

            if (gender != "")
            {
                foundedDriversList = foundedDriversList.FindAll(dri => dri.gender == gender);
            }

            if (address != "")
            {
                foundedDriversList = foundedDriversList.FindAll(dri => dri.address == address);
            }

            if (type != "")
            {
                foundedDriversList = foundedDriversList.FindAll(dri => dri.vehicle!.type == type);
            }

            if (model != "")
            {
                foundedDriversList = foundedDriversList.FindAll(dri => dri.vehicle!.model == model);
            }

            if (licensePlate != "")
            {
                foundedDriversList = foundedDriversList.FindAll(dri => dri.vehicle!.licensePlate == licensePlate);
            }*/

            foundedDriversList = dbManager.searchDriver(searchingDriverData);


            // ************* ************* ************* ************* ************* ************* 
            // finally we are printing results on console
            // *************  ************* ************* ************* ************* ************* 

            System.Console.WriteLine("--------------------------------------------------------------------------------------------------------");

            System.Console.WriteLine($"Name \t Age \t Gender \t V.Type \t V.Model \t V.License");

            System.Console.WriteLine("--------------------------------------------------------------------------------------------------------");

            if (foundedDriversList.Count > 0)
            {
                foreach (var driver in foundedDriversList)
                {
                    System.Console.WriteLine($"{driver.name} \t {driver.age} \t {driver.gender} \t\t {driver.vehicle!.type} \t {driver.vehicle.model} \t {driver.vehicle.licensePlate}");
                }
            }
            else
            {
                System.Console.WriteLine($"NO DRIVER FOUND WITH YOUR ENTERED QUERY");
            }


            return true;
        }


        // **** my helper function to know whether driver exists or not
        public Driver? isDriverExists(int driverId)
        {

            Driver? existingDriver = dbManager.getDriverById(driverId);

            return existingDriver;
        }

        private static string? readInput()
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            string? input = System.Console.ReadLine();
            System.Console.ResetColor();
            return input;
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

        // function to calculate distance b/w two points
        public static float getDistance(Location p1, Location p2)
        {

            double num6 = p1.longitude - p2.longitude;
            double num7 = p1.latitude - p2.latitude;

            double num9 = Math.Sqrt((num7 * num7) + (num6 * num6));
            return (float)(num9);
        }
    }
}