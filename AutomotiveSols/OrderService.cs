using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AutomotiveSols.ServicesReport
{
    public class OrderServiceFromDB
    {
        string constr = "Data Source=(localdb)\\mssqllocaldb;Database=aspnet-AutomotiveSols-103ECA17-1716-4B1D-9297-9171642A1348;Trusted_Connection=True;MultipleActiveResultSets=true";
    
        public DataTable GetOrders()
        {
            var dt = new DataTable();
            using(SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SPGetOrders", con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            return dt;
        }
    }
}
