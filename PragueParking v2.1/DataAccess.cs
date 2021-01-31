using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace Prague_Parking_v2._1
{
    public class DataAccess
    {
        public List<Vehicle> GetVehicles()
        {
            //throw new NotImplementedException(); // för att kunna ändra i applikationen?
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PPDB")))
            {
                List<Vehicle> Vehicles = connection.Query<Vehicle>("dbo.usp_GetAllVehicles").ToList();
                return Vehicles;
            }
            // Efter denna sista } stängs "dörren" till SQL-servern, alltså att den stänger anslutningen
            //connection.Query - man frågar om data tillbaka
        }
    }
}
