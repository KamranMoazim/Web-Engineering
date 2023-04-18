

using AdminLib;
using DBLib;
using DriverLib;
using Microsoft.Data.SqlClient;
using PassengerLib;
using RideLib;
using VehicleLib;

namespace MyRide
{

    class Program
    {
        static void Main(string[] args)
        {

            Passenger passenger = new Passenger();
            Ride ride = new Ride();
            Admin admin = new Admin();

            DbManager dbManager = new DbManager();

            mainMenu();
            int mainMenuChoice;

            do
            {
                System.Console.Write("Press 1 to 4 to select an option:");
                // mainMenuChoice = Convert.ToInt32(readInput());
                mainMenuChoice = intInput();
                switch (mainMenuChoice)
                {
                    case 1:
                        {
                            // to take name and phone from user
                            System.Console.Write("Enter Name: ");
                            string? name = readInput();

                            System.Console.Write("Enter Phone no: ");
                            string? phoneNo = readInput();
                            if (phoneNo!.Contains("-") || phoneNo.Contains(" ") || !phoneNo.All(char.IsDigit))
                            {
                                System.Console.WriteLine("Please Enter in this format - 03001234567");
                                System.Console.Write("Enter Phone no: ");
                                phoneNo = readInput();
                            }
                            // setting passenger values
                            passenger.name = name!;
                            passenger.phoneNo = phoneNo!;

                            // ************ save passenger to DB

                            // to take start and end location for ride
                            ride.getLocations();




                            if (admin.assignDriver(ride))  // making sure we have a Driver to fulfill Rider Request
                            {
                                // making driver booked because it is booked by the ride
                                dbManager.updateDriver(ride.driver);

                                System.Console.WriteLine("-------------------- THANK YOU ------------------");
                                // printing price for Ride
                                System.Console.WriteLine($"Price for this ride is: {ride.calculatePrice()}");



                                System.Console.Write("Enter 'Y' if you want to Book the ride, enter 'N' if you want to cancel operation: ");
                                string? cancelChoice = readInput();
                                if (cancelChoice == "Y" || cancelChoice == "N")
                                {
                                    if (cancelChoice == "Y")
                                    {

                                        Console.WriteLine("Happy Travel...!");
                                        var rating = ride.giveRating();
                                        ride.driver.availability = true; // freeing the driver from Ride
                                            
                                        dbManager.updateDriver(ride.driver);
                                        // ************ save rating to DB
                                        dbManager.addRating(ride.driver.driverId, rating);

                                    }
                                    System.Console.WriteLine("--------------------- Exiting Rider Menu ---------------------");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Sorry No Driver is Available Right Now as per your Requirements :( ");
                            }




                        }
                        break;
                    case 2:
                        {

                            System.Console.Write("Enter ID:");
                            // int driverId = Convert.ToInt32(readInput());
                            int driverId = intInput();
                            System.Console.Write("Enter Name:");
                            string? name = readInput();

                            Driver? driver = admin.isDriverExists(driverId);
                            if (driver != null)
                            {
                                System.Console.WriteLine($"Hello {driver.name}");
                                // driver.updateLocation();

                                driverMenu();
                                int driverMenuChoice;

                                do
                                {
                                    System.Console.Write("Please Select Only from 1-3 ");

                                    driverMenuChoice = intInput();

                                    if (driverMenuChoice == 1)
                                    {
                                        driver.updateAvailability();
                                        
                                        dbManager.updateDriver(driver);
                                        System.Console.WriteLine("--------------------- Availability Updated Successully ---------------------");
                                    
                                    }
                                    else if (driverMenuChoice == 2)
                                    {
                                        driver.updateLocation();

                                        dbManager.updateDriver(driver);
                                        System.Console.WriteLine("--------------------- Location Updated Successully ---------------------");
                                    }
                                    else if (driverMenuChoice == 3)
                                    {
                                        // simply exit Driver Menu
                                        System.Console.WriteLine("--------------------- Exiting Driver Menu ---------------------");
                                        break;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                } while (true);
                            }
                            else
                            {
                                Console.WriteLine("Error Driver does not Exists!");
                            }
                        }
                        break;
                    case 3:
                        {
                            adminMenu();
                            int adminMenuChoice;

                            do
                            {
                                System.Console.Write("Press 1 to 5 to select an option:");

                                adminMenuChoice = intInput();

                                if (adminMenuChoice == 1)
                                {
                                    admin.addDriver();
                                    System.Console.WriteLine("--------------------- Driver Added Successully ---------------------");
                                }
                                else if (adminMenuChoice == 2)
                                {
                                    admin.removeDriver();
                                }
                                else if (adminMenuChoice == 3)
                                {
                                    admin.updateDriver();
                                }
                                else if (adminMenuChoice == 4)
                                {
                                    admin.searchDriver();
                                }
                                else if (adminMenuChoice == 5)
                                {
                                    // simply exit Admin Menu
                                    System.Console.WriteLine("--------------------- Exiting Admin Menu ---------------------");
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            } while (true);
                        }
                        break;
                    case 4:
                        {
                            System.Console.WriteLine("--------------------- Exiting Program ---------------------");
                            break;
                        }
                    default:
                        {
                            continue;
                        }
                        // break;

                }

            } while (mainMenuChoice != 4);


        }


        private static string? readInput()
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            string? input = System.Console.ReadLine();
            System.Console.ResetColor();
            return input;
        }


        private static void mainMenu()
        {
            System.Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            System.Console.WriteLine("                                                 WELCOME TO MYRIDE                                                   ");
            System.Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

            System.Console.WriteLine("1. Book a Ride");
            System.Console.WriteLine("2. Enter as Driver");
            System.Console.WriteLine("3. Enter as Admin");
            System.Console.WriteLine("4. Exit Program");
            System.Console.WriteLine("");
        }

        private static void rideMenu()
        {
            // nothing here for rider menu
        }
        private static void driverMenu()
        {
            System.Console.WriteLine("1. Change availability");
            System.Console.WriteLine("2. Change Location");
            System.Console.WriteLine("3. Exit as Driver");
            System.Console.WriteLine("");
        }
        private static void adminMenu()
        {
            System.Console.WriteLine("1. Add Driver");
            System.Console.WriteLine("2. Remove Driver");
            System.Console.WriteLine("3. Update Driver");
            System.Console.WriteLine("4. Search Driver");
            System.Console.WriteLine("5. Exit as Admin");
            System.Console.WriteLine("");
        }

        private static int intInput()
        {
            int val = 0;
            while (true)
            {
                try
                {
                    val = Convert.ToInt32(readInput());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please Enter Only Number");
                }
            }
            return val;
        }
    }

}