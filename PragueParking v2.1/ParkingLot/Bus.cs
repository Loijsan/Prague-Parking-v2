using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._1
{
    class Bus : Vehicle
    {
        public Bus(string regNr)
        {
            type = "Bus";
            value = Initilizing.BusValue;
            this.RegNr = regNr;
            cost = Initilizing.BusCost;
        }
    }
}
