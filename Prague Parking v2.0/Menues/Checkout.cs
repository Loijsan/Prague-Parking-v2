using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._0
{
    public class Checkout
    {
        /// <summary>
        /// This method is for the menu Check out vehicle.
        /// </summary>
        public static void CheckOut()
        {
            Console.Clear();
            Console.Write("Please enter the registration number of the vehicle you would like to check out: ");
            string regNr = Console.ReadLine().ToUpper();
            (Vehicle foundVehicle, ParkingSpot spot) = ParkingHouse.FindVehicle(regNr);

            if (spot is not null)
            {
                int vehicleCost = 0;
                if (foundVehicle.value == Initilizing.CarValue)
                {
                    vehicleCost = Initilizing.CarCost;
                }
                else
                {
                    vehicleCost = Initilizing.McCost;
                }
                spot.RemoveVehicle(foundVehicle);
                ParkingHouse.BackUp();
                foundVehicle.timeOut = DateTime.Now;
                TimeSpan parkedTime = foundVehicle.timeOut - foundVehicle.timeIn;
                if (parkedTime.Hours < 1)
                {
                    if (parkedTime.Minutes <= Initilizing.FreeMinutes)
                    {
                        Console.WriteLine($"\nThe parking for { foundVehicle.RegNr } is less than { Initilizing.FreeMinutes } minutes and is therefore without cost. " +
                            $"\nThis vehicle has been checked out. \n\nPress any key to return to the main menu");
                        Console.ReadKey();
                        Mainmenu.MainMenu();
                    }
                    else
                    {
                        Console.WriteLine($"\nThe vehicle with the regnr { foundVehicle.RegNr } has been parked for more than { Initilizing.FreeMinutes } minutes but less than an hour. " +
                            $"\nThe cost for this parking is { vehicleCost } CZK. This vehicle has been checked out. \n\nPress any key to return to the main menu");
                        Console.ReadKey();
                        Mainmenu.MainMenu();
                    }
                }
                else
                {
                    if (parkedTime.Days < 30)
                    {
                        int parkedHours = parkedTime.Hours;
                        parkedHours += 1;
                        int startedDays = parkedTime.Days;
                        int startedHours = parkedHours + (startedDays * 24);
                        vehicleCost = startedHours * vehicleCost;

                        if (parkedTime.Days >= 1)
                        {
                            Console.WriteLine($"\nThe vehicle with the regnr { foundVehicle.RegNr } has been parked for { parkedTime.Days } day(s) and { parkedHours } started hours. " +
                            $"\nThe cost for this parking is { vehicleCost } CZK. This vehicle has been checked out. \n\nPress any key to return to the main menu");
                            Console.ReadKey();
                            Mainmenu.MainMenu();
                        }
                        else
                        {
                            Console.WriteLine($"\nThe vehicle with the regnr { foundVehicle.RegNr } has been parked for { startedHours } started hours. " +
                            $"\nThe cost for this parking is { vehicleCost } CZK. This vehicle has been checked out. \n\nPress any key to return to the main menu");
                            Console.ReadKey();
                            Mainmenu.MainMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nThe vehicle with the regnr { foundVehicle.RegNr } has been parked for more than a month. " +
                        $"\nThe cost for this parking is on me :). This vehicle has been checked out. \n\nPress any key to return to the main menu");
                        Console.ReadKey();
                        Mainmenu.MainMenu();
                    }
                } 
            }
            else if (regNr == "EXIT")
            {
                Mainmenu.MainMenu();
            }
            else
            {
                Console.WriteLine("There is no vehicle with that registration number, try again");
                Console.ReadKey();
                CheckOut();
            }
        
        }
        
    }
}
