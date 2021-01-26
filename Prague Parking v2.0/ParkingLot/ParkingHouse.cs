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
        // This is the Parking House Array where all the parking spaces are, they are occupied by a ParkingSpot object that the vehicles end up in.
        public static ParkingSpot[] ParkingSpots { get; set; } = new ParkingSpot[Initilizing.ParkValue];
        
        // This method finds the first free spot that has the correct free space value for parking a vehicle on it.
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
        // This method searches for the correct spot where the vehicle is parked and returns both the object and the spot.
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
        // This method return the percentage of the occupied space of the parking house
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
        // This method is used to show the correct menu in parking
        public static int FreeSpaces()
        {
            int freeSpaces = 0;
            foreach (ParkingSpot spot in ParkingSpots)
            {
                freeSpaces += spot.FreeSpace;
            }
            return freeSpaces;

        }
        // This method is used to pick the correct information to the map in the main menu.
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

        // This method reads from the parkinglist on startup
        public static void ReadParkingFile()
        {
            // TODO Fill in the correct pathname when opening this on another computer
            string parkingPath = @"C:\Users\louis\OneDrive\BED\BED år 1\C# del 2\repos\Prague Parking v2\Prague Parking v2.0\Textfiles\Parkinglist.txt";
            List<string> lines = File.ReadAllLines(parkingPath).ToList(); // Thank you Tim Corey!

            if (lines.Count > 0)
            {
                foreach (string line in lines)
                {
                    string[] places = line.Split("|");
                    int spotNr = int.Parse(places[1]);
                    int spot = spotNr - 1;
                    ParkingSpots[spot] = new ParkingSpot();
                    ParkingSpots[spot].SpotNumber = spotNr;
                    ParkingSpots[spot].FreeSpace = int.Parse(places[2]);

                    if (places[0] == "#") // This line belongs to a car
                    {
                        string regNr = places[4];
                        DateTime parkedTime = DateTime.Parse(places[5]);
                        Car newCar = new(regNr);
                        newCar.timeIn = parkedTime;
                        ParkingSpots[spot].Vehicles.Add(newCar);   
                    }
                    else if (places[0] == "&") // This line contains one mc
                    {
                        string regNr = places[4];
                        DateTime parkedTime = DateTime.Parse(places[5]);
                        MC newMc = new(regNr);
                        newMc.timeIn = parkedTime;
                        ParkingSpots[spot].Vehicles.Add(newMc);
                    }
                    else if (places[0] == "§") // This line contains two mc's
                    {
                        // Adding the first mc
                        string regNr1 = places[4];
                        DateTime parkedTime1 = DateTime.Parse(places[5]);
                        MC newMc1 = new(regNr1);
                        newMc1.timeIn = parkedTime1;
                        ParkingSpots[spot].Vehicles.Add(newMc1);

                        // Adding the second mc
                        string regNr2 = places[7];
                        DateTime parkedTime2 = DateTime.Parse(places[8]);
                        MC newMc2 = new(regNr2);
                        newMc2.timeIn = parkedTime2;
                        ParkingSpots[spot].Vehicles.Add(newMc2);
                    }
                }
            }
            else
            { //This loop creates the ParkingSpots in the ParkingHouse if the parkinglist is empty.
                for (int i = 0; i < Initilizing.ParkValue; i++)
                {
                    ParkingSpots[i] = new ParkingSpot();
                    ParkingSpots[i].SpotNumber = i + 1;
                }
            }
        }
        // This method overwrites the parkinglist every time a change has been made
        public static void BackUp()
        {
            List<string> backUp = new List<string>();

            // TODO Fill in the correct pathname when opening this on another computer
            string parkingPath = @"C:\Users\louis\OneDrive\BED\BED år 1\C# del 2\repos\Prague Parking v2\Prague Parking v2.0\Textfiles\Parkinglist.txt";
            string oneLine = "";
            string separator = "|";
            
            foreach (var spot in ParkingSpots)
            {
                if (spot.FreeSpace == 0) // if the space is full
                {
                    if (spot.Vehicles.Count == 1) // ...but there is only one vehicle, in this case a car
                    {
                        oneLine = "#";
                        oneLine = oneLine + separator + spot.SpotNumber + separator + spot.FreeSpace;
                        foreach (Vehicle vehicle in spot.Vehicles)
                        {
                            oneLine += separator + vehicle.type + separator + vehicle.RegNr + separator + vehicle.timeIn; // example: #|1|0|Car|CAR1|2021-01-25 12:14
                            backUp.Add(oneLine);
                        }
                    }
                    else if (spot.Vehicles.Count == 2) // ..and there are two vehicles, in this case two mc's
                    {
                        oneLine = "§";
                        oneLine = oneLine + separator + spot.SpotNumber + separator + spot.FreeSpace; // Detta är för ParkingSpot
                        foreach (Vehicle vehicle in spot.Vehicles)
                        {
                            oneLine += separator + vehicle.type + separator + vehicle.RegNr + separator + vehicle.timeIn; // example: #|2|0|MC|MC1|2021-01-25 12:14|MC|MC2|2021-01-25
                        }
                        backUp.Add(oneLine);
                    }
                }
                else if (spot.Vehicles.Count == 1) // Det finns en motorcykel på platsen - Spot är aldrig null så den går in här oavsett!
                {
                    oneLine = "&";
                    oneLine = oneLine + separator + spot.SpotNumber + separator + spot.FreeSpace;
                    foreach (Vehicle vehicle in spot.Vehicles)
                    {
                        oneLine += separator + vehicle.type + separator + vehicle.RegNr + separator + vehicle.timeIn; // t ex #|3|0|MC|MC3|2021-01-25 12:14
                        backUp.Add(oneLine);
                    }
                }
                else // The spot is empty
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
