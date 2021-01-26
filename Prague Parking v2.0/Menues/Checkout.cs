using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._0
{
    public class Checkout
    {
        public static void CheckOut()
        {
            // Till denna klass skall det ju inte bara checkas ut fordon, den skall också svara hur länge den stod där och vad kostnaden då blev:

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
                    if (parkedTime.Minutes <= 10)
                    {
                        Console.WriteLine($"\nThe parking for { foundVehicle.RegNr } is less than 10 minutes and is therefore without cost. " +
                            $"\nThis vehicle has been checked out. \n\nPress any key to return to the main menu");
                        Console.ReadKey();
                        Mainmenu.MainMenu();
                    }
                    else
                    {
                        Console.WriteLine($"\nThe vehicle with the regnr { foundVehicle.RegNr } has been parked for more than 10 minutes but less than an hour. " +
                            $"\nThe cost for this parking is { vehicleCost } CZK. This vehicle has been checked out. \n\nPress any key to return to the main menu");
                        Console.ReadKey();
                        Mainmenu.MainMenu();
                    }
                }
                else
                {
                    for (int i = 1; i < 756; i++) // 756 h represents a month
                    {
                        if (parkedTime.Hours == i)
                        {
                            int staredHours = i + 1;
                            vehicleCost = staredHours * vehicleCost;

                            Console.WriteLine($"\nThe vehicle with the regnr { foundVehicle.RegNr } has been parked for { staredHours } started hours. " +
                            $"\nThe cost for this parking is { vehicleCost } CZK. This vehicle has been checked out. \n\nPress any key to return to the main menu");
                            Console.ReadKey();
                            Mainmenu.MainMenu();
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
