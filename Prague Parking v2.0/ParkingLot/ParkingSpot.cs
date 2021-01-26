using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._0
{
    public class ParkingSpot
    {
        static int spotValue = Initilizing.SpotValue;
        public ParkingSpot()
        {

        }
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public int FreeSpace { get; set; } = Initilizing.SpotValue;
        public int SpotNumber { get; set; }

        // This method is for parking a vehicle
        public static void ParkVehicle(string type)
        {
            Console.Clear();
            Console.WriteLine("Please enter the registration number:");
            string regNr = Console.ReadLine().ToUpper();
            int vehicleValue = 0;
            if (regNr is not "EXIT")
            {
                if (type == "car")
                {
                    Car newCar = new(regNr);
                    vehicleValue = newCar.value;
                    ParkingSpot spot = ParkingHouse.SpotFinder(vehicleValue);
                    spot.FreeSpace -= vehicleValue;
                    newCar.timeIn = DateTime.Now;
                    spot.Vehicles.Add(newCar);
                    ParkingHouse.BackUp();
                    int slot = spot.SpotNumber;
                    Receipt(newCar, "car", slot);
                }
                else if (type == "mc")
                {
                    MC newMc = new(regNr);
                    vehicleValue = newMc.value;
                    ParkingSpot spot = ParkingHouse.SpotFinder(vehicleValue);
                    spot.FreeSpace -= vehicleValue;
                    newMc.timeIn = DateTime.Now;
                    spot.Vehicles.Add(newMc);
                    ParkingHouse.BackUp();
                    int slot = spot.SpotNumber;
                    Receipt(newMc, "mc", slot);
                }
            }
            //else if (regNr.Contains("|"))
            //{
            //    Console.WriteLine("The registration number contains invalid symbols, please try again");
            //    Console.ReadKey();
            //    Mainmenu.MainMenu();
            //}
            else
            {
                Mainmenu.MainMenu();
            }
        }
        // This method writes a receipt to the user
        public static void Receipt(Vehicle parkedVehicle, string vehicle, int spot)
        {
            Console.WriteLine($"\n\nThe { vehicle } " +
                $"\nwith the registration number { parkedVehicle.RegNr }" +
                $"\nhas been parked in spot { spot }" +
                $"\nat { parkedVehicle.timeIn }");

            Console.WriteLine("\n\nPress any key to return to the main menu");
            Console.ReadKey();
            Mainmenu.MainMenu();
        }
        // This method is called to remove a vehicle from a spot and to give back space
        public void RemoveVehicle(Vehicle remover)
        {
            this.Vehicles.Remove(remover);
            this.FreeSpace += remover.value;
        }
    }
}
