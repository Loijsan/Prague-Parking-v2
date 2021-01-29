using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_v2._0
{
    public static class Initilizing
    {
        public static int CarValue { get; set; }
        public static int McValue { get; set; }
        public static int SpotValue { get; set; }
        public static int ParkValue { get; set; }
        public static int CarCost { get; set; }
        public static int McCost { get; set; }
        public static int FreeMinutes { get; set; }

        /// <summary>
        /// This method reads from the configuration file
        /// </summary>
        public static void ReadConfigFile()
        {
        // TODO Fill in the correct pathname when opening this on another computer
        string configPath = @"../../../Textfiles/Configuration.txt";

            List<string> initialize = File.ReadAllLines(configPath).ToList();

            foreach (var initial in initialize)
            {
                if (initial.Contains("car"))
                {
                    string[] carValues = initial.Split(':');
                    CarValue = int.Parse(carValues[1]);

                }
                else if (initial.Contains("mc"))
                {
                    string[] mcValues = initial.Split(':');
                    McValue = int.Parse(mcValues[1]);
                }
                else if (initial.Contains("spot"))
                {
                    string[] spotValues = initial.Split(':');
                    SpotValue = int.Parse(spotValues[1]);
                }
                else
                {
                    string[] parkValues = initial.Split(':');
                    ParkValue = int.Parse(parkValues[1]);
                }
            }
        }
        /// <summary>
        /// This method reads from the price file.
        /// </summary>
        public static void ReadPriceFile()
        {
            // TODO Fill in the correct pathname when opening this on another computer
            string pricePath = @"../../../Textfiles/Pricelist.txt";

            List<string> prices = File.ReadAllLines(pricePath).ToList();

            foreach (var price in prices)
            {
                if (price.Contains("car"))
                {
                    string[] carPrices = price.Split(':');
                    CarCost = int.Parse(carPrices[1]);
                }
                else if (price.Contains("mc"))
                {
                    string[] mcPrices = price.Split(':');
                    McCost = int.Parse(mcPrices[1]);
                }
                else
                {
                    string[] freeMinutes = price.Split(':');
                    FreeMinutes = int.Parse(freeMinutes[1]);
                }
            }
        }
    }
}
