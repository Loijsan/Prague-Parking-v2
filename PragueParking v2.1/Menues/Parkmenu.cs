using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._1
{
    public class Parkmenu
    {
        /// <summary>
        /// This method determines how the menu will look and tosses it to the corresponding method.
        /// </summary>
        public static void ParkMenu()
        {
            Console.Clear();
            int freeSpaces = ParkingHouse.FreeSpaces();

            if (freeSpaces >= Initilizing.SpotValue)
            {
                AllChoises();
            }
            else if (freeSpaces == 0)
            {
                NoSpaces();
            }
        }
        /// <summary>
        /// This menu shows when there is one or more full spot available.
        /// </summary>
        public static void AllChoises()
        {
            Console.Clear();
            Console.WriteLine("Park Vehicle. Please type the number of your menu choice" +
               "\n \n 1. Park a bike" +
               "\n \n 2. Park a motorcycle" +
               "\n \n 3. Park a car" +
               "\n \n 4. Park a bus" +
               "\n \n 5. Return to the main menu" +
               "\n");
            Console.Write("Number: ");
            string menuChoice = Console.ReadLine();
            int.TryParse(menuChoice, out int choice);

            if (choice >= 1 && choice <= 5)
            {
                switch (choice)
                {
                    case 1: ParkingSpot.ParkVehicle("bike"); break;
                    case 2: ParkingSpot.ParkVehicle("mc"); break;
                    case 3: ParkingSpot.ParkVehicle("car"); break;
                    case 4: ParkingSpot.ParkVehicle("bus"); break;
                    case 5: Mainmenu.MainMenu(); break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, try again");
                AllChoises();
            }
        }
        /// <summary>
        /// This menu shows when there are no available spots.
        /// </summary>
        public static void NoSpaces()
        {
            Console.WriteLine("There are no empty spots left, please wait until a vehicle has been checked out before trying again. " +
                "\n Press any button to return to the main menu.");

            Console.ReadKey();
            Mainmenu.MainMenu();
        }
    }
}
