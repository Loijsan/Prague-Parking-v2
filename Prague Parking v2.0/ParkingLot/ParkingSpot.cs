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

        /// <summary>
        /// This method is for parking a vehicle.
        /// </summary>
        public static void ParkVehicle(string type)
        {
            Console.Clear();
            Console.WriteLine("Please enter the registration number:");
            string regNr = Console.ReadLine().ToUpper();
            int vehicleValue = 0;
            if (regNr is not "EXIT" && !regNr.Contains("|") && regNr.Length < 11 && regNr.Length > 4)
            {
                (Vehicle spotsTaken, ParkingSpot occupied) = ParkingHouse.FindVehicle(regNr);
                if (spotsTaken is null)
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
                else
                {
                    Console.WriteLine("There is already a vehicle with that registration number parked. Please try again");
                    Console.ReadKey();
                    Parkmenu.ParkMenu();
                }
            }
            else if (regNr is "EXIT")
            {
                Mainmenu.MainMenu();
            }
            else
            {
                Console.WriteLine("The registration number is incorrect, it must be between 5 and 10 characters and can not contain |. Please start over. ");
                Console.ReadKey();
                Mainmenu.MainMenu();
            }
        }
        /// <summary>
        /// This method writes a receipt to the user
        /// </summary>
        public static void Receipt(Vehicle parkedVehicle, string vehicle, int spot)
        {
            Console.WriteLine($"\n\nThe { vehicle } with the " +
                $"\nregistration number { parkedVehicle.RegNr }" +
                $"\nhas been parked in spot { spot }" +
                $"\nat { parkedVehicle.timeIn }");

            Console.WriteLine("\n\nPress any key to return to the main menu");
            Console.ReadKey();
            Mainmenu.MainMenu();
        }
        /// <summary>
        /// This method is called to remove a vehicle from a spot and to give back the space it previously occupied.
        /// </summary>
        public void RemoveVehicle(Vehicle remover)
        {
            this.Vehicles.Remove(remover);
            this.FreeSpace += remover.value;
        }
    }
}
