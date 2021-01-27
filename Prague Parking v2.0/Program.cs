using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Denna kod är skriven av Louise Olsson
namespace Prague_Parking_v2._0
{
    class Program
    {
        static void Main()
        {
            // Please note! When setting this program up on your computer you need to fill in the correct filepaths in four places! 
            // Search for TODO and you will find them.

            // Read the config file
            Initilizing.ReadConfigFile();

            // Read the pricelist file
            Initilizing.ReadPriceFile();

            // Read the parkinglist file
            ParkingHouse.ReadParkingFile();

            // Goes into the main menu
            Mainmenu.MainMenu();
            
        }
    }
}
