using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._1
{
    public class Settingsmenu
    {
        /// <summary>
        /// This method is for the "settings and help" menu choice.
        /// </summary>
        public static void SettingsMenu()
        {
            Console.Clear();
            Console.WriteLine("Settings and help. Please type the number of your menu choice" +
              "\n \n 1. Re-read the pricelist file" +
              "\n \n 2. How to use the program" +
              "\n \n 3. Return to the main menu" +
              "\n");
            Console.Write("Number: ");
            string menuChoice = Console.ReadLine();
            int.TryParse(menuChoice, out int choice);

            if (choice >= 1 && choice <= 4)
            {
                switch (choice)
                {
                    case 1: PriceList(); break;
                    case 2: HowTo(); break;
                    case 3: Mainmenu.MainMenu(); break;
                    default:
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input, try again");
                SettingsMenu();
            }
        }
        /// <summary>
        /// This method re-reads the pricelist if the user wants it.
        /// </summary>
        private static void PriceList()
        {
            Console.WriteLine($"The current prices for each new hour are {Initilizing.CarCost} CZK/car" +
                $"\nand { Initilizing.McCost } CZK/Motorcycles. The number of free minutes before the parking starts to cost is { Initilizing.FreeMinutes }." +
                $"\nWould you like to re-read the pricelist?");
            string confirm = Console.ReadLine();

            if (confirm == "yes" || confirm == "YES" || confirm == "y")
            {
                Initilizing.ReadPriceFile();

                Console.WriteLine($"Ok! The pricefile has been re-read! The prices for each new hour are {Initilizing.CarCost} CZK/car" +
                $"\nand { Initilizing.McCost } CZK/Motorcycles. The free minutes value is { Initilizing.FreeMinutes }" +
                    "\nPress any key to return to the main menu");
                Console.ReadKey();
                Mainmenu.MainMenu();
            }
            else
            {
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
                Mainmenu.MainMenu();
            }
        }
        /// <summary>
        /// This method gives the user a text about how the program can be used.
        /// </summary>
        private static void HowTo()
        {
            Console.WriteLine("This is Prague Parking v 2.0, the new and improved version!"+

                "\n\nThe application works so that any questions can be answered with these variations of yes: y or yes." +
                "\nIf you at any point wish to return to the main menu, please type “EXIT” and press enter." +
                "\nNote that any changes made prior will not be saved when exiting a menu this way." +

                "\n\nSince the system now has a parkinglist file that it reads to and from, " +
                "\ntherefore, the program can be percieved as running a bit slower than its predecessor." +

                "\n\nPlease note that the configuration file should only be made changes to when the parkinglist is empty!" +
                "\nThe different values will produce a system collapse." +

                "\n\nThe pricelist can be changed and re-read while the program is running, it is written in this fomat: " +

                "\n\nbike:1:space" +
                "\nmc: 2:spaces" +
                "\ncar: 4:spaces" +
                "\nbus: 16:spaces" +
                "\nspotvalue: 4: total number of spaces for one parkingspace" +
                "\nplaces:100" +
                
                "\n\nIf you wish to change these, change nothing but the numbers. After that, just choose menu" +
                "\nchoise 1 in the \"settings and help menu\" and then confirm the operation with y or yes." + 

                "\n\n\nPress any key to return to the main menu");

            Console.ReadKey();
            Mainmenu.MainMenu();
        }
    }
}
