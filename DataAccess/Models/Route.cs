using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public class Route
    {
        public int Id{get; set;}
        public string Name { get; set; }
        public float CoupeFare { get; set; } // цена за купе
        public float ReservedSeatFare { get; set; }  // цена за плацкарт
        public float GeneralFare { get; set; }// цена за общий
        public string Description { get; set; }
        public Train Train { get; set; }
        public int? TrainId { get; set; }

        public ICollection<RouteStation> RouteStations { get; set; }
        public ICollection<RouteDate> RouteDate { get; set; }
        public Route()
        {
            RouteStations = new List<RouteStation>();
            RouteDate = new List<RouteDate>();


        }
        

    }
}