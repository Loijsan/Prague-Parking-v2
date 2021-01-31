using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._1
{
    class MC : Vehicle
        {
        public MC(string regNr)
        {
            type = "MC";
            value = Initilizing.McValue;
            this.RegNr = regNr;
            cost = Initilizing.McCost;
        }
    }
}

