﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._0
{
    public class Movevehicle
    {
        /// <summary>
        /// This metod is for the menu choice "Search for and move vehicle"
        /// </summary>
        public static void MoveVehicle()
        {
            Console.Clear();
            Mainmenu.MenuPrinter();
            Console.Write("Please enter the registration number of the vehicle you would like to search for: ");
            string regNr = Console.ReadLine().ToUpper();
            if (regNr is not "EXIT")
            {
                (Vehicle foundVehicle, ParkingSpot oldSpot) = ParkingHouse.FindVehicle(regNr);
                if (foundVehicle is not null || oldSpot is not null)
                {
                    Console.Write($"\nThis vehicle is parked in spot { oldSpot.SpotNumber }, would you like to move it?: ");
                    string answer = Console.ReadLine().ToUpper();

                    if (answer == "Y" || answer == "YES")
                    {
                        Console.Write("Ok! Where would you like to park it instead?: ");
                        string spotAnswer = Console.ReadLine();
                        bool correct = int.TryParse(spotAnswer, out int spotSuggest);

                        if (correct)
                        {
                            ParkingSpot newSpot = ParkingHouse.FreeSpotFinder(foundVehicle.value, spotSuggest);
                            if (newSpot is not null)
                            {
                                oldSpot.RemoveVehicle(foundVehicle);
                                newSpot.Vehicles.Add(foundVehicle);
                                newSpot.FreeSpace -= foundVehicle.value;
                                Console.WriteLine($"\nThe { foundVehicle.type } with the registration number { foundVehicle.RegNr } " +
                                    $"\nthat was parked in { oldSpot.SpotNumber } has been moved to { newSpot.SpotNumber }.");
                                ParkingHouse.BackUp();
                            }
                            else
                            {
                                Console.WriteLine("This spot is not available." +
                                    "\nNo changes have been made, please start over");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input, please start from the beginning");
                            Console.ReadKey();
                            MoveVehicle();
                        }
                    }
                    else if (answer == "EXIT")
                    {
                        Mainmenu.MainMenu();
                    }
                    else
                    {
                        Mainmenu.MainMenu();
                    }
                }
                else
                {
                    Console.WriteLine("\nThere is no vehicle parked witht that number, press any key to try again");
                    Console.ReadKey();
                    MoveVehicle();
                }
            }
            else
            {
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
                Mainmenu.MainMenu();
            }
            Console.WriteLine("\nPress any key to return to the main menu");
            Console.ReadKey();
            Mainmenu.MainMenu();
        }
    }
}
