using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomotiveSols.Models
{
    public class ConnectionString
    {
        private static string cName = "Server=(localdb)\\mssqllocaldb;Database=aspnet-AutomotiveSols-103ECA17-1716-4B1D-9297-9171642A1348;Trusted_Connection=True;MultipleActiveResultSets=true";

        public static string CName
        {
            get => cName;
        }
    }
}
