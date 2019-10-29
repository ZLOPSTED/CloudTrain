using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public class RouteStation
    {

        [Key, Column(Order = 0)]
        public int StationId { get; set; }

        [Key, Column(Order = 1)]
        public int RouteId { get; set; }
        public Station Station { get; set; }
        public Route Route { get; set; }
        public DateTime DateArrival { get; set; }
        public DateTime DateDeparture { get; set; }
        public string StationType { get; set; }

    }
}