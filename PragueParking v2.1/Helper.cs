using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._1
{
    public static class Helper
    {
        /// <summary>
        /// This is the helper for the Connection String, Thank you Tim Corey again!
        /// </summary>
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
