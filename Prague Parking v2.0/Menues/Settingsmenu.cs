﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._0
{
    public class Settingsmenu
    {
        public static void SettingsMenu()
        {
            Console.Clear();
            Console.WriteLine("Settings and help. Please type the number of your menu choice" +
              "\n \n 1. Re-read the pricelist file" +
              //"\n \n 2. Re-read the configuration file" + // TODO - Denna är egentligen en vg-del! Ta bort den efter G-delen är klar
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
                    //case 2: Configuration(); break; // TODO - Ta bort denna ifall att jag inte gör vg-delen, annars ska den bort först då!
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
        private static void PriceList()
        {
            Console.WriteLine($"The current prices for each new hour are {Initilizing.CarCost} CZK/car" +
                $"\nand { Initilizing.McCost } CZK/Motorcycles. Would you like to re-read the pricelist?");
            string confirm = Console.ReadLine();

            if (confirm == "yes" || confirm == "YES" || confirm == "y")
            {
                Initilizing.ReadPriceFile();

                Console.WriteLine($"Ok! The pricefile has been re-read! The new prices for each new hour are {Initilizing.CarCost} CZK/car" +
                $"\nand { Initilizing.McCost } CZK/Motorcycles" +
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
        //private static void Configuration()
        //{
            // TODO - ta bort om den inte behövs!
        //}
        private static void HowTo()
        {

            Console.WriteLine("This is Prague Parking v 2.0, the new and improved version!"+

                "\n\nThe application works so that any questions can be answered with these variations of yes: y or yes." +
                "\nIf you at any point wish to return to the main menu, please type “EXIT” and press enter." +
                "\nNote that any changes made prior will not be saved when exiting a menu this way." +

                "\n\nSince the system now has a parkinglist file that it reads to and from, it can be percieved as a bit" +
                "\nslower in its processes." +

                "\n\nPlease note that the configuration file should only be made changes to when the parkinglist is empty!" +
                "\nThe different values will produce a system collapse." +


                "\n\n\nPress any key to return to the main menu");

            Console.ReadKey();
            Mainmenu.MainMenu();


        }
    }
}