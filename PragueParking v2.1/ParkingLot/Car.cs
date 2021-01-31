using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._1
{
    class Car : Vehicle
    {
        public Car(string regNr)
        {
            type = "Car";
            value = Initilizing.CarValue;
            this.RegNr = regNr;
            cost = Initilizing.CarCost;
        }
    }
}
