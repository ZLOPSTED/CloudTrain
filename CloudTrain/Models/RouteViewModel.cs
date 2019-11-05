using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudTrain.Models
{
    public class RouteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public float CoupeFare { get; set; } // цена за купе
        public float ReservedSeatFare { get; set; }  // цена за плацкарт
        public float GeneralFare { get; set; }// цена за 
        public string Description { get; set; }
        public int? TrainId { get; set; }

        public ICollection<RouteStationViewModel> RouteStations { get; set; }
    }

}