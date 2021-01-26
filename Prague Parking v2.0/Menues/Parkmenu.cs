using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._0
{
    public class Parkmenu
    {

        public static void ParkMenu()
        {
            //This method determines how the menu will look and tosses it to the corresponding method
            Console.Clear();
            int freeSpaces = ParkingHouse.FreeSpaces();

            if (freeSpaces >= Initilizing.SpotValue)
            {
                AllChoises();

            }
            else if (freeSpaces == Initilizing.McValue)
            {
                OneSpace();
            }
            else if (freeSpaces == 0)
            {
                NoSpaces();
            }
            
        }
        public static void AllChoises()
        {
            // This menu shows when there is one or more full spot available
            Console.Clear();
            Console.WriteLine("Park Vehicle. Please type the number of your menu choice" +
               "\n \n 1. Park a car" +
               "\n \n 2. Park a motorcycle" +
               "\n \n 3. Return to the main menu" +
               "\n");
            Console.Write("Number: ");
            string menuChoice = Console.ReadLine();
            int.TryParse(menuChoice, out int choice);

            if (choice >= 1 && choice <= 3)
            {
                switch (choice)
                {
                    case 1: ParkingSpot.ParkVehicle("car"); break;
                    case 2: ParkingSpot.ParkVehicle("mc"); break;
                    case 3: Mainmenu.MainMenu(); break;
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
        public static void OneSpace()
        {
            // This menu shows when there is one spot for a mc available
            Console.Clear();
            Console.WriteLine("Park Vehicle. Please type the number of your menu choice" +
                   "\n \n 1. Park a motorcycle" +
                   "\n \n 2. Return to the main menu" +
                   "\n");
            Console.Write("Number: ");
            string menuChoice = Console.ReadLine();
            int.TryParse(menuChoice, out int choice);

            if (choice >= 1 && choice <= 2)
            {
                switch (choice)
                {
                    case 1: ParkingSpot.ParkVehicle("mc"); break;
                    case 2: Mainmenu.MainMenu(); break;;
                    default:
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input, try again");
                OneSpace();
            }
        }

        public static void NoSpaces()
        {
            // This menu shows when there are no available spots
            Console.WriteLine("There are no empty spots left, please wait until a vehicle has been checked out before trying again. " +
                "\n Press any button to return to the main menu.");

            Console.ReadKey();
            Mainmenu.MainMenu();
        }
    }
}
