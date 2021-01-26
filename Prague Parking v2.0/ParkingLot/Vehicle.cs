using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._0
{
    public class Vehicle
    {

        public DateTime timeIn;
        public int value;
        public string type;

        public string RegNr { get; set; }
        public DateTime timeOut { get; set; }

    }
}
