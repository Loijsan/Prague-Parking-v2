using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._0
{
    public class Mainmenu
    {
        // This method is for the main menu
        public static void MainMenu()
        {
            Console.Clear();
            int fillPercent = ParkingHouse.FillDegree();
            Console.WriteLine($"The current fill degree is: { fillPercent } % ");
            MenuPrinter();
            Console.WriteLine("Welcome to Prague Parking. Please type the number of your menu choice" +
               "\n1. Park vehicle " +
               "  2. Check out vehicle" +
               "  3. Search for and move vehicle" +
               "  4. Settings and help" +
               "  5. Close the application" +
               "\n");
            Console.Write("Number: ");
            string menuChoice = Console.ReadLine();
            int.TryParse(menuChoice, out int choice);

            if (choice >= 1 && choice <= 5)
            {
                switch (choice)
                {
                    case 1: Parkmenu.ParkMenu(); break;
                    case 2: Checkout.CheckOut(); break;
                    case 3: Movevehicle.MoveVehicle(); break;
                    case 4: Settingsmenu.SettingsMenu(); break;
                    case 5: CloseApplication(); break;
                    default:
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input, try again");
                MainMenu();
            }   
        }
        // This method prints the layout of the parking house and fills the spots with vehicles
        public static void MenuPrinter()
        {
            int spaces = Initilizing.ParkValue;
            int first = spaces / 4;
            int second = first + first;
            int third = second + first;
            int fourth = third + (spaces - third);
            int moveCoursor1 = 0;
            int moveCoursor2 = 0;
            int moveCoursor3 = 0;
            int moveCoursor4 = 0;

            for (int i = 1; i <= first; i++)
            {
                string parkingString = "";
                ParkingSpot currentSpot = ParkingHouse.MainMenuFiller(i);
                foreach (Vehicle vehicle in currentSpot.Vehicles)
                {
                    parkingString += " " + vehicle.type + "-" + vehicle.RegNr;
                }
                moveCoursor1++;
                Console.SetCursorPosition(0, moveCoursor1);
                Console.Write(i + parkingString + "\n");
            }
            for (int j = first + 1; j <= second; j++)
            {
                string parkingString = "";
                ParkingSpot currentSpot = ParkingHouse.MainMenuFiller(j);
                foreach (Vehicle vehicle in currentSpot.Vehicles)
                {
                    parkingString += " " + vehicle.type + "-" + vehicle.RegNr;
                }
                moveCoursor2++;
                Console.SetCursorPosition(30, moveCoursor2);
                Console.Write(j + parkingString + "\n");
            }
            for (int k = second + 1; k <= third; k++)
            {
                string parkingString = "";
                ParkingSpot currentSpot = ParkingHouse.MainMenuFiller(k);
                foreach (Vehicle vehicle in currentSpot.Vehicles)
                {
                    parkingString += " " + vehicle.type + "-" + vehicle.RegNr;
                }
                moveCoursor3++;
                Console.SetCursorPosition(60, moveCoursor3);
                Console.Write(k + parkingString + "\n");
            }
            for (int l = third + 1; l <= fourth; l++)
            {
                string parkingString = "";
                ParkingSpot currentSpot = ParkingHouse.MainMenuFiller(l);
                foreach (Vehicle vehicle in currentSpot.Vehicles)
                {
                    parkingString += " " + vehicle.type + "-" + vehicle.RegNr;
                }
                moveCoursor4++;
                Console.SetCursorPosition(90, moveCoursor4);
                Console.Write(l + parkingString + "\n");
            }
        }
        // This method makes it possible to close the application with two presses of a button
        public static void CloseApplication()
        {
            System.Environment.Exit(0);
        }
    }
}
