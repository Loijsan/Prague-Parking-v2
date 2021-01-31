using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._1
{
    class Bike : Vehicle
    {
        public Bike(string regNr)
        {
            type = "Bike";
            value = Initilizing.BikeValue;
            this.RegNr = regNr;
            cost = Initilizing.BikeCost;
        }
    }
    
}
