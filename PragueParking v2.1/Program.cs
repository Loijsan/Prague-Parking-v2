using System;
using System.Collections.Generic;

namespace Prague_Parking_v2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            

            // Read the config file // läs in configfilen som steg 2 och jämför den med databasen!!! Ifall inte platserna stämmer så måste den ge ett felmeddelande
            Initilizing.ReadConfigFile();

            // Read the pricelist file
            Initilizing.ReadPriceFile();

            // Read the parkinglist file
            // TODO - byt ut denna mot att läsa in databasen! Börja med detta!
            ParkingHouse.ReadParkingFile();

            // Detta är ett försök till att börja hämta data från databasen
            List<Vehicle> Vehicles = new List<Vehicle>();

            DataAccess db = new();

            Vehicles = db.GetVehicles();

            foreach (Vehicle vehicle in Vehicles)
            {
                Console.WriteLine(vehicle.type);
            }
            

            // Goes into the main menu
            //Mainmenu.MainMenu();

        }
    }
}
