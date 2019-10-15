using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudTrain.Models
{
    public class Route
    {
        public int Id{get; set;}
        public string Name { get; set; } 
        public float CoupeFare { get; set; } // цена за купе
        public float ReservedSeatFare { get; set; }  // цена за плацкарт
        public float GeneralFare { get; set; }// цена за общий
        public ICollection<RouteStation> RouteStations { get; set; }
        public ICollection<RouteTrain> RouteTrains { get; set; }
        public Route()
        {
            RouteStations = new List<RouteStation>();
            RouteTrains = new List<RouteTrain>();


        }
        

    }
}