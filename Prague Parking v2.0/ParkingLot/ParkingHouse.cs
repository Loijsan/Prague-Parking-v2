using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._0
{
    static class ParkingHouse
    {
        public static ParkingSpot[] ParkingSpots { get; set; } = new ParkingSpot[Initilizing.ParkValue];

        /// <summary>
        /// This method finds the first free spot that has the correct free space value for parking a vehicle on it.
        /// </summary>
        public static ParkingSpot SpotFinder(int vehicleValue)
        {
            foreach (ParkingSpot spot in ParkingSpots)
            {
                if (spot.FreeSpace >= vehicleValue)
                {
                    return spot;
                }
            }
            return null;
        }
        /// <summary>
        /// This method searches for the correct spot where the vehicle is parked and returns both the object and the spot.
        /// It is also used to find if a vehicle with that registrationnumber is in the parkingarray.
        /// </summary>
        public static (Vehicle, ParkingSpot) FindVehicle(string searchReg)
        {
            foreach (ParkingSpot spot in ParkingSpots)
            {
                foreach (Vehicle vehicle in spot.Vehicles)
                {
                    if (vehicle.RegNr == searchReg)
                    {
                        return (vehicle, spot);
                    }
                }
            }
            return (null, null);
        }
        /// <summary>
        /// This method checks if the spot the user wants to move a vehicle to has enough space for it.
        /// </summary>
        public static ParkingSpot FreeSpotFinder(int vehicleValue, int spotSuggest)
        {
            foreach (ParkingSpot spot in ParkingSpots)
            {
                if (spot.SpotNumber == spotSuggest)
                {
                    if (spot.FreeSpace >= vehicleValue)
                    {
                        return spot;
                    }
                    return null;
                }
            }
            return null;
        }
        /// <summary>
        /// This method return the percentage of the occupied space of the parking house.
        /// </summary>
        public static int FillDegree()
        {
            int occupiedSpaces = 0;
            int totalSpace = Initilizing.ParkValue * Initilizing.SpotValue;
            foreach (ParkingSpot spot in ParkingSpots)
            {
                    foreach (Vehicle vehicle in spot.Vehicles)
                    {
                        occupiedSpaces += vehicle.value;
                    }
            }
            double fill = occupiedSpaces;
            double up = totalSpace;
            double fillUp = fill / up * 100d;
            int fillDegree = (int)fillUp;
            return fillDegree;
        }
        /// <summary>
        /// This method is used to show the correct menu in parking.
        /// </summary>
        public static int FreeSpaces()
        {
            int freeSpaces = 0;
            foreach (ParkingSpot spot in ParkingSpots)
            {
                freeSpaces += spot.FreeSpace;
            }
            return freeSpaces;
        }
        /// <summary>
        /// This method is used to pick the correct information to the map in the main menu.
        /// </summary>
        public static ParkingSpot MainMenuFiller(int spotRequest)
        {
            foreach (ParkingSpot spot in ParkingSpots)
            {
                
                    if (spot.SpotNumber == spotRequest)
                    {
                        return spot;
                    }
            }
            return null;
        }
        /// <summary>
        /// This method reads from the parkinglist on startup - I know, this method is huge...
        /// </summary>
        public static void ReadParkingFile()
        {
            string parkingPath = @"../../../Textfiles/Parkinglist.txt";
            List<string> lines = File.ReadAllLines(parkingPath).ToList(); // Thank you Tim Corey!
            string[] places;
            if (lines.Count > 0)
            {
                foreach (string line in lines)
                {
                    places = line.Split("|");
                    int spotNr = int.Parse(places[1]);
                    int spot = spotNr - 1;
                    ParkingSpots[spot] = new ParkingSpot();
                    ParkingSpots[spot].SpotNumber = spotNr;
                    ParkingSpots[spot].FreeSpace = int.Parse(places[2]);

                    if (places[0] == "#") // One vehicle in the spot
                    {
                        if (places[3] == "Car") { AddFirstCar(places, spot); }
                        else { AddFirstMC(places, spot); }
                    }
                    else if (places[0] == "§") // Two vehicles in the spot
                    {
                        if (places[3] == "Car") { AddFirstCar(places, spot); }
                        else { AddFirstMC(places, spot); }
                        
                        if (places[6] == "Car") { AddSecondCar(places, spot); }
                        else { AddSecondMC(places, spot); }
                    }
                    else if (places[0] == "&") // Three vehicles in the spot
                    {
                        if (places[3] == "Car") { AddFirstCar(places, spot); }
                        else { AddFirstMC(places, spot); }

                        if (places[6] == "Car") { AddSecondCar(places, spot); }
                        else { AddSecondMC(places, spot); }

                        if (places[9] == "Car") { AddThirdCar(places, spot); }
                        else { AddThirdMC(places, spot); }
                    }
                    else if (places[0] == "£") // Four vehicles in the spot
                    {
                        if (places[3] == "Car") { AddFirstCar(places, spot); }
                        else { AddFirstMC(places, spot); }

                        if (places[6] == "Car") { AddSecondCar(places, spot); }
                        else { AddSecondMC(places, spot); }

                        if (places[9] == "Car") { AddThirdCar(places, spot); }
                        else { AddThirdMC(places, spot); }

                        if (places[12] == "Car") { AddFourthCar(places, spot); }
                        else { AddFourthMC(places, spot); }
                    }
                }
            }
            else
            { //This loop creates the ParkingSpots in the ParkingHouse if the parkinglistfile is empty.
                for (int i = 0; i < Initilizing.ParkValue; i++)
                {
                    ParkingSpots[i] = new ParkingSpot();
                    ParkingSpots[i].SpotNumber = i + 1;
                }
            }
        }
        /// These methods might not be the most line efficient, but they work! 
        public static void AddFirstCar(string[] places, int spot)
        {
            string regNr = places[4];
            DateTime parkedTime = DateTime.Parse(places[5]);
            Car newCar = new(regNr);
            newCar.timeIn = parkedTime;
            ParkingSpots[spot].Vehicles.Add(newCar);
        }
        public static void AddSecondCar(string[] places, int spot)
        {
            string regNr = places[7];
            DateTime parkedTime = DateTime.Parse(places[8]);
            Car newCar = new(regNr);
            newCar.timeIn = parkedTime;
            ParkingSpots[spot].Vehicles.Add(newCar);
        }
        public static void AddThirdCar(string[] places, int spot)
        {
            string regNr = places[10];
            DateTime parkedTime = DateTime.Parse(places[11]);
            Car newCar = new(regNr);
            newCar.timeIn = parkedTime;
            ParkingSpots[spot].Vehicles.Add(newCar);
        }
        public static void AddFourthCar(string[] places, int spot)
        {
            string regNr = places[13];
            DateTime parkedTime = DateTime.Parse(places[14]);
            Car newCar = new(regNr);
            newCar.timeIn = parkedTime;
            ParkingSpots[spot].Vehicles.Add(newCar);
        }
        public static void AddFirstMC(string[] places, int spot)
        {
            string regNr = places[4];
            DateTime parkedTime = DateTime.Parse(places[5]);
            MC newMc = new(regNr);
            newMc.timeIn = parkedTime;
            ParkingSpots[spot].Vehicles.Add(newMc);
        }
        public static void AddSecondMC(string[] places, int spot)
        {
            string regNr = places[7];
            DateTime parkedTime = DateTime.Parse(places[8]);
            MC newMc = new(regNr);
            newMc.timeIn = parkedTime;
            ParkingSpots[spot].Vehicles.Add(newMc);
        }
        public static void AddThirdMC(string[] places, int spot)
        {
            string regNr = places[10];
            DateTime parkedTime = DateTime.Parse(places[11]);
            MC newMc = new(regNr);
            newMc.timeIn = parkedTime;
            ParkingSpots[spot].Vehicles.Add(newMc);
        }
        public static void AddFourthMC(string[] places, int spot)
        {
            string regNr = places[13];
            DateTime parkedTime = DateTime.Parse(places[14]);
            MC newMc = new(regNr);
            newMc.timeIn = parkedTime;
            ParkingSpots[spot].Vehicles.Add(newMc);
        }
        /// <summary>
        /// This method overwrites the parkinglist every time a change has been made
        /// </summary>
        public static void BackUp()
        {
            List<string> backUp = new List<string>();

            string parkingPath = @"../../../Textfiles/Parkinglist.txt";
            string oneLine = "";
            string separator = "|";
            
            foreach (var spot in ParkingSpots)
            {
                if (spot.Vehicles.Count == 1)
                {
                    oneLine = "#";
                    oneLine = oneLine + separator + spot.SpotNumber + separator + spot.FreeSpace;
                    foreach (Vehicle vehicle in spot.Vehicles)
                    {
                        oneLine += separator + vehicle.type + separator + vehicle.RegNr + separator + vehicle.timeIn;
                        backUp.Add(oneLine);
                    }
                }
                else if (spot.Vehicles.Count == 2)
                {
                    oneLine = "§";
                    oneLine = oneLine + separator + spot.SpotNumber + separator + spot.FreeSpace;
                    foreach (Vehicle vehicle in spot.Vehicles)
                    {
                        oneLine += separator + vehicle.type + separator + vehicle.RegNr + separator + vehicle.timeIn;
                    }
                    backUp.Add(oneLine);
                }
                else if (spot.Vehicles.Count == 3)
                {
                    oneLine = "&";
                    oneLine = oneLine + separator + spot.SpotNumber + separator + spot.FreeSpace; 
                    foreach (Vehicle vehicle in spot.Vehicles)
                    {
                        oneLine += separator + vehicle.type + separator + vehicle.RegNr + separator + vehicle.timeIn;
                    }
                    backUp.Add(oneLine);
                }
                else if (spot.Vehicles.Count == 4)
                {
                    oneLine = "£";
                    oneLine = oneLine + separator + spot.SpotNumber + separator + spot.FreeSpace;
                    foreach (Vehicle vehicle in spot.Vehicles)
                    {
                        oneLine += separator + vehicle.type + separator + vehicle.RegNr + separator + vehicle.timeIn;
                    }
                    backUp.Add(oneLine);
                }
                else
                {
                    oneLine = "¤";
                    oneLine = oneLine + separator + spot.SpotNumber + separator + spot.FreeSpace;
                    backUp.Add(oneLine);
                }
                File.WriteAllLines(parkingPath, backUp);
            }
        }
    }
}
