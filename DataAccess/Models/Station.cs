using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Locality { get; set; }
        public string Description { get; set; }

        

        public ICollection<RouteStation> Routes { get; set; }
        public Station()
        {
            Routes = new List<RouteStation>();
        }
    }
}
