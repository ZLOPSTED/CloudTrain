using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudTrain.Models
{
    public class RouteStationViewModel
    {
        public string StationName { get; set; }

        public int StationId { get; set; }
        public int RouteId { get; set; }

        public DateTime TimeArrival { get; set; }
        public DateTime DateArrival { get; set; }

        public DateTime TimeDeparture { get; set; }
        public DateTime DateDeparture { get; set; }
        public string StationType { get; set; }

    }
}